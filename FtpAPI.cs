using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Forms;

namespace FTPManager
{
    class FtpAPI
    {
        /***************************************************** Variables *****************************************************/

        #region Variables

        private string _Host = null;
        private string _Root = null;
        private string _User = null;
        private string _Password = null;
        //private WebProxy _Proxy;
        private FtpWebRequest _FtpRequest = null;
        private FtpWebResponse _FtpResponse = null;
        private int _BufferSize = 2048;
        private double _TotalSize;
        private string _DownloadedFileTarget;
        private List<string> _DownloadedFilesTarget;

        #endregion


        /**************************************************** Constructor ****************************************************/

        #region Constructor

        public FtpAPI()
        {
            _DownloadedFilesTarget = new List<string>();
        }

        #endregion

        /***************************************************** Methods *******************************************************/

        #region Methods

        /*************************************************\
         * List Directory Contents File/Folder Name Only *
        \*************************************************/

        public void GetDirectoryList(Directory directory, BackgroundWorker worker, DoWorkEventArgs e)
        {
            /* Set parameters and return values */
            List<object> parameters = e.Argument as List<object>;
            List<object> returnArguments = new List<object>();

            if (((string)parameters[0]).Equals("GetDir"))
            {
                if (directory.Get_IsRoot())
                    returnArguments.Add("GetDir");
            }
            else if (((string)parameters[0]).Equals("DlLastUp"))
            {
                returnArguments.Add("DlLastUp");
            }
            else if (((string)parameters[0]).Equals("SyncLF"))
            {
                returnArguments.Add("SyncLF");
            }
            else if (((string)parameters[0]).Equals("ChDir"))
            {
                returnArguments.Add("ChDir");
            }


            if (directory.Get_FoldersList().Count == 0 && directory.Get_FilesList().Count == 0)
            {
                try
                {
                    // FYI
                    // http://stackoverflow.com/questions/1016690/how-to-improve-the-performance-of-ftpwebrequest

                    /* Instanciate FTP request */
                    worker.ReportProgress(0);
                    _FtpRequest = (FtpWebRequest)FtpWebRequest.Create(_Host);

                    /* Log in */
                    _FtpRequest.Credentials = new NetworkCredential(_User, _Password);

                    /* Set options */
                    _FtpRequest.UseBinary = true;
                    _FtpRequest.UsePassive = true;
                    _FtpRequest.KeepAlive = true;
                    _FtpRequest.ConnectionGroupName = "GetDirectoryList"; // To ensure that the connection pool is used
                    _FtpRequest.KeepAlive = true;
                    _FtpRequest.ServicePoint.ConnectionLimit = 2;

                    /* Specify type of request */
                    _FtpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    worker.ReportProgress(30);

                    /* Establish return communication with ftp server */
                    _FtpResponse = (FtpWebResponse)_FtpRequest.GetResponse();
                    worker.ReportProgress(60);

                    /* Establish return communication with ftp server */
                    //_FtpStream = _FtpResponse.GetResponseStream();
                    using (Stream ftpStream = _FtpResponse.GetResponseStream())
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                        }

                        else
                        {
                            /* get FTP server's response stream */
                            StreamReader ftpReader = new StreamReader(ftpStream, Encoding.ASCII);

                            /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                            List<string> lines = new List<string>(); // temporary list
                            string htmlResult = String.Empty;
                            string line = ftpReader.ReadLine();
                            while (line != null && line != String.Empty)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break;
                                }

                                lines.Add(line);
                                htmlResult += line;
                                line = ftpReader.ReadLine();
                            }
                            worker.ReportProgress(80);

                            /* parse HTML output (first, get only the name of file, then re-parse to get the timestamp/size */
                            try
                            {
                                //List<string> content = new List<string>();
                                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                doc.LoadHtml(htmlResult);
                                foreach (HtmlAgilityPack.HtmlNode node in doc.DocumentNode.SelectNodes("//a[@href]"))
                                {
                                    if (worker.CancellationPending)
                                    {
                                        e.Cancel = true;
                                        break;
                                    }

                                    else if (!node.InnerText.Contains("&gt") && !String.IsNullOrEmpty(node.InnerText))
                                    {
                                        /* suppress last char '/' */
                                        string stringRaw = node.InnerText;
                                        if (stringRaw[stringRaw.Length - 1] == '/')
                                            stringRaw = stringRaw.Substring(0, stringRaw.Length - 1);
                                        string[] split = stringRaw.Split('/');

                                        /* Parse timestamp and size, and then fill directory object */
                                        ParseSizeAndTimestamp(directory, split[split.Length - 1], lines);
                                    }
                                    else if (node.InnerText.Contains("&gt") && !String.IsNullOrEmpty(node.InnerText))
                                    {
                                        /* suppress last char '/' */
                                        string stringRaw = node.Attributes[0].Value;
                                        if (stringRaw[stringRaw.Length - 1] == '/')
                                            stringRaw = stringRaw.Substring(0, stringRaw.Length - 1);
                                        string[] split = stringRaw.Split('/');

                                        /* Parse timestamp and size, and then fill directory object */
                                        ParseSizeAndTimestamp(directory, split[split.Length - 1], lines);
                                    }
                                }
                            }
                            catch (Exception ex) { returnArguments.Add(ex.ToString()); }

                            /* Resource Cleanup */
                            ftpReader.Close();
                            _FtpResponse.Close();
                            _FtpRequest = null;
                        }
                    }
                }
                catch (Exception ex) { returnArguments.Add(ex.ToString()); }
            }

            worker.ReportProgress(100);
            e.Result = returnArguments;
        }

        /**************************************************************************************\
         * Parse timestamp and size, and then fill directory object (for each file in folder) *
        \**************************************************************************************/

        private void ParseSizeAndTimestamp(Directory directory, string fileName, List<string> lines)
        {
            /* Define path of file or folder */
            string filePath = String.Empty;
            filePath = _Host + "/" + fileName;

            /* Seek line to parse */
            string lineToParse = String.Empty;
            foreach (string line in lines)
            {
                if (line.Contains(fileName))
                {
                    lineToParse = line;
                    break;
                }
            }

            /* Test all regex to find the good timestamp/size patern, then create file object */
            Regex regex = new Regex("(.*)([A-Z][a-z]{2}[ ]{1,2}[0-9]{1,2} [0-9]{2}:[0-9]{2})(.*)k <A HREF"); // Regex for the format 'Jan 14 11:01  68773k'.
            Regex regex2 = new Regex("(.*)([0-9]{2}-[0-9]{2}-[0-9]{2} )([0-9]{2}:[0-9]{2}[A|M|P]{2})(.*)k <A HREF"); // Regex for the format '04-22-13 08:18PM  53019k'.
            Regex regex3 = new Regex("(.*)([A-Z][a-z]{2}[ ]{1,2}[0-9]{1,2}  [0-9]{4})(.*)k <A HREF"); // Regex for the format 'Dec  9  2013  37922k'.

            if (regex.IsMatch(lineToParse))
            {
                Match m = regex.Match(lineToParse);

                /* Set size, and timestamp */
                int size = int.Parse(m.Groups[3].Value.Replace(" ", ""));
                int month;
                int day;
                int hour;
                int minute;

                switch (m.Groups[2].Value.Substring(0, 3))
                {
                    case "Jan": month = 1; break;
                    case "Feb": month = 2; break;
                    case "Mar": month = 3; break;
                    case "Apr": month = 4; break;
                    case "May": month = 5; break;
                    case "Jun": month = 6; break;
                    case "Jul": month = 7; break;
                    case "Aug": month = 8; break;
                    case "Sep": month = 9; break;
                    case "Oct": month = 10; break;
                    case "Nov": month = 11; break;
                    case "Dec": month = 12; break;
                    default: month = 1; break;
                }

                day = int.Parse(m.Groups[2].Value.Substring(4, 2));
                hour = int.Parse(m.Groups[2].Value.Substring(7, 2));
                minute = int.Parse(m.Groups[2].Value.Substring(10, 2));

                DateTime dt = new DateTime(System.DateTime.Now.Year, month, day, hour, minute, 0);

                /* Create a file.*/
                directory.Get_FilesList().Add(new File(fileName, filePath, size, dt));
            }

            else if (regex2.IsMatch(lineToParse))
            {
                Match m = regex2.Match(lineToParse);

                /* Set size, and timestamp */
                int month = int.Parse(m.Groups[2].Value.Substring(0, 2));
                int day = int.Parse(m.Groups[2].Value.Substring(3, 2));
                int year = int.Parse(m.Groups[2].Value.Substring(6, 2)) + 2000;

                string ampm = m.Groups[3].Value.Substring(5, 2);
                int hour = int.Parse(m.Groups[3].Value.Substring(0, 2));
                if ((ampm.Equals("PM") || ampm.Equals("pm")) && hour != 12)
                    hour += 12;
                int minute = int.Parse(m.Groups[3].Value.Substring(3, 2));

                int size = int.Parse(m.Groups[4].Value.Replace(" ", ""));

                DateTime dt = new DateTime(year, month, day, hour, minute, 0);

                /* Create a file.*/
                directory.Get_FilesList().Add(new File(fileName, filePath, size, dt));
            }

            else if (regex3.IsMatch(lineToParse))
            {
                Match m = regex3.Match(lineToParse);

                /* Set size, and timestamp */
                int size = int.Parse(m.Groups[3].Value.Replace(" ", ""));
                int month;

                switch (m.Groups[2].Value.Substring(0, 3))
                {
                    case "Jan": month = 1; break;
                    case "Feb": month = 2; break;
                    case "Mar": month = 3; break;
                    case "Apr": month = 4; break;
                    case "May": month = 5; break;
                    case "Jun": month = 6; break;
                    case "Jul": month = 7; break;
                    case "Aug": month = 8; break;
                    case "Sep": month = 9; break;
                    case "Oct": month = 10; break;
                    case "Nov": month = 11; break;
                    case "Dec": month = 12; break;
                    default: month = 1; break;
                }

                int day = int.Parse(m.Groups[2].Value.Substring(4, 2));
                int year = int.Parse(m.Groups[2].Value.Substring(8, 4));

                DateTime dt = new DateTime(year, month, day, 0, 0, 0);

                /* Create a file.*/
                directory.Get_FilesList().Add(new File(fileName, filePath, size, dt));
            }

            /* Else, create a directory */
            else if (!fileName.Equals("Parent Directory") 
                && !fileName.Equals("Root Directory")
                && !_Host.Replace("%20", " ").Contains(fileName) 
                && !fileName.Contains(_User + "@") 
                && !directory.Get_Name().Replace("%20"," ").Contains(fileName))
            {
                directory.Get_FoldersList().Add(new Directory(fileName, filePath, false));
            }
        }

        /*****************\
         * Download file *
        \*****************/

        public void DownloadFile(string remoteFilePath, string localFilePath, double numberOfFiles, BackgroundWorker worker, DoWorkEventArgs e)
        {
            //List<object> parameters = e.Argument as List<object>;
            List<object> returnArguments = new List<object>();
                returnArguments.Add("Download");

            try
            {
                //_DownloadedFileTarget = localFilePath;
                _DownloadedFilesTarget.Add(localFilePath);
                if (numberOfFiles == 1)
                    worker.ReportProgress(0);

                /* Instanciate FTP request */
                _FtpRequest = (FtpWebRequest)FtpWebRequest.Create(remoteFilePath);

                /* Log in */
                _FtpRequest.Credentials = new NetworkCredential(_User, _Password);

                /* Set options */
                _FtpRequest.UseBinary = true;
                _FtpRequest.UsePassive = true;
                _FtpRequest.KeepAlive = true;

                /* Specify type of request */
                _FtpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                /* Establish return communication with ftp server */
                _FtpResponse = (FtpWebResponse)_FtpRequest.GetResponse();

                using (Stream ftpStream = _FtpResponse.GetResponseStream())
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                    }

                    else
                    {          
                        /* Open a file stream to write the downloaded file */
                        FileStream localFileStream = new FileStream(localFilePath, FileMode.Create);

                        /* Buffer for the downloaded data */
                        byte[] byteBuffer = new byte[_BufferSize];
                        int bytesRead = ftpStream.Read(byteBuffer, 0, _BufferSize);

                        /* Download the file by writting the buffered data until the transfer is complete */
                        try
                        {
                            double bytes = 0;
                            while (bytesRead > 0)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break;
                                }
                                bytes += bytesRead;
                                localFileStream.Write(byteBuffer, 0, bytesRead);
                                bytesRead = ftpStream.Read(byteBuffer, 0, _BufferSize);

                                if (numberOfFiles == 1)
                                    worker.ReportProgress(((int)(((bytes / 1000) / _TotalSize) * 100)));
                            }
                        }
                        catch (Exception ex) { returnArguments.Add(ex.ToString()); }

                        /* Ressources cleanup */
                        localFileStream.Close();
                        ftpStream.Close();
                        _FtpResponse.Close();
                        _FtpRequest = null;
                    }
                }
            }

            catch (Exception ex) { returnArguments.Add(ex.ToString()); }

            if(numberOfFiles == 1)
                worker.ReportProgress(100);
            e.Result = returnArguments;
        }

        /********************************\
         * Download several files       *
         *    . Case of last update     * 
         *    . Case of synchronization *
        \********************************/

        public void DownloadFiles(List<File> filesToDownload, string targetDirectoryPath, BackgroundWorker worker, DoWorkEventArgs e)
        {
            string localFilePath = String.Empty;

            worker.ReportProgress(0);
            /* Set return values */
            //List<object> returnArguments = new List<object>();
            //returnArguments.Add("DlLastUpBis");
            //e.Result = returnArguments;

            for (int i = 0; i < filesToDownload.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }

                else
                {
                    /* Set local file path */
                    localFilePath = targetDirectoryPath + "\\" + filesToDownload[i].Get_Name().Replace("%20", " ");

                    /* Download file */
                    _TotalSize = filesToDownload[i].Get_Size();
                    DownloadFile(filesToDownload[i].Get_Path(), localFilePath, filesToDownload.Count, worker, e);
                    worker.ReportProgress((int)((float)(i + 1) / (float)filesToDownload.Count * 100));
                }
            }
            worker.ReportProgress(100);
        }

        #endregion

        #region Accessors

        public string Get_DownloadedFileTarget(){ return _DownloadedFileTarget;}
        public void Reset_DownloadedFilesTarget() { _DownloadedFilesTarget.Clear(); }
        public List<string> Get_DownloadedFilesTarget() { return _DownloadedFilesTarget; }
        public void Set_Host(string host)
        { 
            _Host = host;
            if (_Host[_Host.Length - 1].ToString().Contains("/"))
                _Host = _Host.Remove(_Host.Length - 1, 1);
        }
        public string Get_Root() { return _Root; }
        public void Set_Root(string root) { _Root = root; }
        public void Set_User(string user) { _User = user; }
        public void Set_Total_Size(int size) { _TotalSize = size; }
        public void Set_Password(string password) { _Password = password; }

        #endregion
    }
}
