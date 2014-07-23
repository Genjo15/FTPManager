using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

namespace FTPManager
{
    public partial class FTPManager : UserControl
    {
        /***************************************************** Variables *****************************************************/

        #region Variables

        private FtpAPI _FtpAPI;
        private Directory _Root;
        private Directory _CurrentDirectory;
        private Region _ConnectedRegion;
        private List<File> _FilesToDownload;
        private string _LocalFilePath;

        private List<Region> _RegionsList;
        private ToolTip _TargetPathTooltip;
        private BackgroundWorker _Worker;

        private ToolTip _SynchronizeButtonTooltip;

        #endregion


        /**************************************************** Constructor ****************************************************/

        #region Constructor

        public FTPManager()
        {
            InitializeComponent();

            _FtpAPI = new FtpAPI();
            _Root = new Directory();
            _CurrentDirectory = new Directory();

            _FilesToDownload = new List<File>();
            _ConnectedRegion = new Region();

            _RegionsList = new List<Region>();
            _TargetPathTooltip = new ToolTip();
            _TargetPathTooltip.SetToolTip(TargetDirectoryButton, "");

            AddButton.Click += AddButton_Click;
            EditButton.Click += EditButton_Click;

            GetRegions();
            FillFtpListDataGridView();

            ResetSummaryTextboxesAndLabels();

            _Worker = new BackgroundWorker();
            _Worker.WorkerReportsProgress = true;
            _Worker.WorkerSupportsCancellation = true;
            _Worker.DoWork += Worker_DoWork;
            _Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            _Worker.ProgressChanged += Worker_ProgressChanged;

            _SynchronizeButtonTooltip = new ToolTip();
            _SynchronizeButtonTooltip.SetToolTip(SynchronizeLocalFileButton, "Download all files in the FTP which are more recent than the more recent file in your selected region's local folder.");
        }

        #endregion


        /******************************** * FTP Creation/Edition/Suppression Methods *****************************************/

        #region CreationMethods

        /*******************************************\
         * Start editing by make Textboxes visible *
         *    - Case of FTP creation               *
         *    - Case of FTP edition                *
        \*******************************************/

        private void AddButton_Click(object sender, EventArgs e)
        {
            BeginCreateFTP();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            BeginEditFTP();
        }

        private void BeginCreateFTP()
        {
            ServerAddressLabel2.Visible = false;
            ServerAddressTextBox.Visible = true;
            RegionNameLabel2.Visible = false;
            RegionNameTextBox.Visible = true;
            ProviderLabel2.Visible = false;
            ProviderTextBox.Visible = true;
            LoginLabel2.Visible = false;
            LoginTextBox.Visible = true;
            PasswordLabel2.Visible = false;
            PasswordTextBox.Visible = true;
            _TargetPathTooltip.SetToolTip(TargetDirectoryButton, "");
            TargetDirectoryButton.Tag = true;
            TargetDirectoryButton.Visible = true;
            FileMaskLabel2.Visible = false;
            FileMaskTextBox.Visible = true;
            RecoveryFrequencyLabel2.Visible = false;
            RecoveryFrequencyComboBox.Visible = true;
            RecoveryFrequencyComboBox.SelectedIndex = -1;
            RecoveryDayLabel2.Visible = false;
            RecoveryDayComboBox.Visible = true;
            RecoveryDayComboBox.SelectedIndex = -1;
            OkPictureBox.Visible = true;
            OkPictureBox.Tag = "";
            BackButton.Visible = true;

            AddButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            DeleteButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            EditButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            ConnectButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            DLLastUpdateButton.Enabled = false;
            SynchronizeLocalFileButton.Enabled = false;
            FTPListDataGridView.ClearSelection();
        }

        private void BeginEditFTP()
        {
            if (FTPListDataGridView.CurrentCell.RowIndex != -1)
            {
                /* Retrieve region information */
                Region regionToUpdate = new Region();
                foreach (Region element in _RegionsList)
                {
                    if (element.Get_RegionName().Equals(FTPListDataGridView.CurrentCell.Value.ToString()))
                    {
                        regionToUpdate = element;
                        break;
                    }
                }

                /* Show/Hide controls */
                ServerAddressLabel2.Visible = false;
                ServerAddressTextBox.Visible = true;
                ServerAddressTextBox.Text = regionToUpdate.Get_FtpHost();
                RegionNameLabel2.Visible = false;
                RegionNameTextBox.Visible = true;
                RegionNameTextBox.Text = regionToUpdate.Get_RegionName();
                ProviderLabel2.Visible = false;
                ProviderTextBox.Visible = true;
                ProviderTextBox.Text = regionToUpdate.Get_Provider();
                LoginLabel2.Visible = false;
                LoginTextBox.Visible = true;
                LoginTextBox.Text = regionToUpdate.Get_Login();
                PasswordLabel2.Visible = false;
                PasswordTextBox.Visible = true;
                PasswordTextBox.Text = regionToUpdate.Get_Password();
                _TargetPathTooltip.SetToolTip(TargetDirectoryButton, regionToUpdate.Get_TargetDirectory());
                TargetDirectoryButton.Tag = true;
                TargetDirectoryButton.Visible = true;
                FileMaskLabel2.Visible = false;
                FileMaskTextBox.Visible = true;
                FileMaskTextBox.Text = regionToUpdate.Get_FileMask();
                RecoveryFrequencyLabel2.Visible = false;
                RecoveryFrequencyComboBox.Visible = true;
                RecoveryFrequencyComboBox.Text = regionToUpdate.Get_RecoveryFrequency();
                RecoveryDayLabel2.Visible = false;
                RecoveryDayComboBox.Visible = true;
                RecoveryDayComboBox.Text = regionToUpdate.Get_RecoveryDay();
                OkPictureBox.Visible = true;
                OkPictureBox.Tag = regionToUpdate.Get_RegionName();
                BackButton.Visible = true;

                AddButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                DeleteButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                EditButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                ConnectButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                DLLastUpdateButton.Enabled = false;
                SynchronizeLocalFileButton.Enabled = false;
                FTPListDataGridView.ClearSelection();
            }
        }

        /************************************\
         * Back button click (in edit mode) *
        \************************************/

        private void BackButton_Click(object sender, EventArgs e)
        {
            EndEdit();
        }

        private void EndEdit()
        {
            ResetSummaryTextboxesAndLabels();

            TargetDirectoryButton.Tag = false;
            ServerAddressLabel2.Visible = true;
            ServerAddressTextBox.Visible = false;
            RegionNameLabel2.Visible = true;
            RegionNameTextBox.Visible = false;
            ProviderLabel2.Visible = true;
            ProviderTextBox.Visible = false;
            LoginLabel2.Visible = true;
            LoginTextBox.Visible = false;
            PasswordLabel2.Visible = true;
            PasswordTextBox.Visible = false;
            FileMaskLabel2.Visible = true;
            FileMaskTextBox.Visible = false;
            RecoveryFrequencyLabel2.Visible = true;
            RecoveryFrequencyComboBox.Visible = false;
            RecoveryDayLabel2.Visible = true;
            RecoveryDayComboBox.Visible = false;
            OkPictureBox.Visible = false;
            BackButton.Visible = false;
            AddButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            DLLastUpdateButton.Enabled = false;
            SynchronizeLocalFileButton.Enabled = false;

            FTPListDataGridView.ClearSelection();
        }

        /********************************************************\
         * Create FTP (OK button click)                         *
         * - Create/Edit FTP (depending on the context)         *
         * - CheckFields : check if mandatory fields are filled *
        \********************************************************/

        private void OkPictureBox_Click(object sender, EventArgs e)
        {
            /* Check if fields are OK */
            if (CheckFields())
            {
                /* Create service */
                FTPWebService.ftpSoapClient service = new FTPWebService.ftpSoapClient();

                /* CASE 1 : CREATION */
                if (((string)OkPictureBox.Tag).Equals(""))
                {
                    /* Check if server exists (Provider|Server Adress|Login|Password) */
                    int serverID = service.Get_server_id(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
                    if (serverID == 0)
                    {
                        /* Create server if not exists then get id_server */
                        service.Add_server(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
                        serverID = service.Get_server_id(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
                    }

                    /* Set idFrequency and idDay */
                    int idFrequency;
                    int idDay;
                    string frequency;
                    string day;
                    switch (RecoveryFrequencyComboBox.Text)
                    {
                        case "None": idFrequency = 5; frequency = "None"; break;
                        case "Daily": idFrequency = 1; frequency = "Daily"; break;
                        case "Weekly": idFrequency = 2; frequency = "Weekly"; break;
                        case "Monthly": idFrequency = 3; frequency = "Monthly"; break;
                        case "Yearly": idFrequency = 4; frequency = "Yearly"; break;
                        default: idFrequency = 5; frequency = "None"; break;
                    }
                    switch (RecoveryDayComboBox.Text)
                    {
                        case "None": idDay = 8; day = "None"; break;
                        case "Monday": idDay = 1; day = "Monday"; break;
                        case "Tuesday": idDay = 2; day = "Tuesday"; break;
                        case "Wednesday": idDay = 3; day = "Wednesday"; break;
                        case "Thursday": idDay = 4; day = "Thursday"; break;
                        case "Friday": idDay = 5; day = "Friday"; break;
                        case "Saturday": idDay = 6; day = "Saturday"; break;
                        case "Sunday": idDay = 7; day = "Sunday"; break;
                        default: idDay = 8; day = "None"; break;
                    }

                    /* Insert region */
                    service.Add_region(serverID, RegionNameTextBox.Text, FileMaskTextBox.Text, _TargetPathTooltip.GetToolTip(TargetDirectoryButton), idFrequency, idDay);

                    /* Add new region to the list */
                    _RegionsList.Add(new Region(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, RegionNameTextBox.Text, _TargetPathTooltip.GetToolTip(TargetDirectoryButton), FileMaskTextBox.Text, frequency, day));

                    /* Refresh List of FTP */
                    FTPListDataGridView.DataSource = null;
                    FillFtpListDataGridView();

                    /* Display result */
                    KryptonMessageBox.Show("FTP Created !", "Saved",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }

                /* CASE 2 : EDIT */
                else if (!((string)OkPictureBox.Tag).Equals(""))
                {
                    /* Check if server exists (Provider|Server Adress|Login|Password) */
                    int serverID = service.Get_server_id(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
                    if (serverID == 0)
                    {
                        /* Create server if not exists then get id_server */
                        service.Add_server(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
                        serverID = service.Get_server_id(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
                    }

                    /* Set idFrequency and idDay */
                    int idFrequency;
                    int idDay;
                    switch (RecoveryFrequencyComboBox.Text)
                    {
                        case "None": idFrequency = 5; break;
                        case "Daily": idFrequency = 1; break;
                        case "Weekly": idFrequency = 2; break;
                        case "Monthly": idFrequency = 3; break;
                        case "Yearly": idFrequency = 4; break;
                        default: idFrequency = 5; break;
                    }
                    switch (RecoveryDayComboBox.Text)
                    {
                        case "None": idDay = 8; break;
                        case "Monday": idDay = 1; break;
                        case "Tuesday": idDay = 2; break;
                        case "Wednesday": idDay = 3; break;
                        case "Thursday": idDay = 4; break;
                        case "Friday": idDay = 5; break;
                        case "Saturday": idDay = 6; break;
                        case "Sunday": idDay = 7; break;
                        default: idDay = 8; break;
                    }

                    /* Update region */
                    service.Update_region((string)OkPictureBox.Tag, serverID, RegionNameTextBox.Text, FileMaskTextBox.Text, _TargetPathTooltip.GetToolTip(TargetDirectoryButton), idFrequency, idDay);

                    /* Remove old region from the list */
                    foreach (Region element in _RegionsList)
                    {
                        if (element.Get_RegionName().Equals((string)OkPictureBox.Tag))
                        {
                            _RegionsList.Remove(element);
                            break;
                        }
                    }

                    /* Add new one */
                    _RegionsList.Add(new Region(ProviderTextBox.Text, ServerAddressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, RegionNameTextBox.Text, _TargetPathTooltip.GetToolTip(TargetDirectoryButton), FileMaskTextBox.Text, RecoveryFrequencyComboBox.Text, RecoveryDayComboBox.Text));

                    /* Refresh List of FTP */
                    FTPListDataGridView.DataSource = null;
                    FillFtpListDataGridView();

                    /* Display result */
                    KryptonMessageBox.Show("FTP updated !", "Updated",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }

                /* Finally, End Edit */
                EndEdit();

                /* Close service */
                service.Close();
            }
        }

        private Boolean CheckFields()
        {
            /* Check server address field validity */
            if (!ServerAddressTextBox.Text.StartsWith("ftp://"))
            {
                KryptonMessageBox.Show("Server address must start with \"ftp://\"", "Server address incorrect",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);

                return false;
            }

            /* Check empty fields */
            if (ServerAddressTextBox.Text.Equals("") || RegionNameTextBox.Text.Equals("") || LoginTextBox.Text.Equals("") || PasswordTextBox.Text.Equals(""))
            {
                KryptonMessageBox.Show("Please fill at least the server address, the region name, the login and the password.", "Please fill fields.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);

                return false;
            }

            /* Check region name (if it doesn't already exists) */
            foreach (Region element in _RegionsList)
            {
                if ((RegionNameTextBox.Text.Equals(element.Get_RegionName()) && ((string)OkPictureBox.Tag).Equals("")) || ((RegionNameTextBox.Text.Equals(element.Get_RegionName()) && !((string)OkPictureBox.Tag).Equals(RegionNameTextBox.Text))))
                {
                    KryptonMessageBox.Show("Region name already exists !!!", "Wrong region name",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        /****************************************\
         * Delete FTP button click event        *
         *    - Delete selected region from DB. *
        \****************************************/

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            /* Create service */
            FTPWebService.ftpSoapClient service = new FTPWebService.ftpSoapClient();

            /* Delete region from DB */
            service.Delete_region(FTPListDataGridView.CurrentCell.Value.ToString());

            /* Delete region in list of region */
            foreach (Region element in _RegionsList)
            {
                if (element.Get_RegionName().Equals(FTPListDataGridView.CurrentCell.Value.ToString()))
                {
                    _RegionsList.Remove(element);
                    break;
                }
            }

            /* Refresh DataGridView */
            FTPListDataGridView.DataSource = null;
            FillFtpListDataGridView();
            FTPListDataGridView.ClearSelection();

            /* CLose service */
            service.Close();
        }

        /************************************\
         * Target Path button click event : *
         *    - Define target path          *
        \************************************/

        private void TargetDirectoryButton_Click(object sender, EventArgs e)
        {
            if ((Boolean)TargetDirectoryButton.Tag == true)
            {
                FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
                openFolderDialog.RootFolder = Environment.SpecialFolder.Desktop;

                DialogResult result = openFolderDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _TargetPathTooltip.SetToolTip(TargetDirectoryButton, openFolderDialog.SelectedPath);

                    var result2 = KryptonMessageBox.Show("Path defined at \n" + _TargetPathTooltip.GetToolTip(TargetDirectoryButton), "Path Defined",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
        }

        /**************************************\
         * Reset summary textboxes and labels *
        \**************************************/

        private void ResetSummaryTextboxesAndLabels()
        {
            PasswordLabel2.Text = "";
            LoginLabel2.Text = "";
            ProviderLabel2.Text = "";
            RecoveryDayLabel2.Text = "";
            RecoveryFrequencyLabel2.Text = "";
            RegionNameLabel2.Text = "";
            ServerAddressLabel2.Text = "";
            FileMaskLabel2.Text = "";
            PasswordTextBox.Text = "";
            LoginTextBox.Text = "";
            ProviderTextBox.Text = "";
            RecoveryFrequencyComboBox.Text = "";
            RecoveryDayComboBox.Text = "";
            RecoveryDayComboBox.SelectedIndex = -1;
            RecoveryFrequencyComboBox.SelectedIndex = -1;
            RegionNameTextBox.Text = "";
            ServerAddressTextBox.Text = "";
            FileMaskTextBox.Text = "";
            _TargetPathTooltip.SetToolTip(TargetDirectoryButton, "");
            TargetDirectoryButton.Tag = false;
            TargetDirectoryButton.Visible = false;
            OkPictureBox.Tag = false;
        }

        #endregion


        /******************************************* Methods driving the FTP API ***********************************************/

        #region UsingFtpAPIMethods

        /*************************************************************\
         * "Connect" to FTP                                          *
         *    -> FTP Query that get files/folders of indicated path. *
         *    -> Fill TreeView.                                      *
        \*************************************************************/

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            StopButton.Enabled = ButtonEnabled.True;
            DLLastUpdateButton.Enabled = false;
            SynchronizeLocalFileButton.Enabled = false;
            FileExplorerListView.SetSortIcon(0, SortOrder.None);
            FileExplorerListView.ListViewItemSorter = new ListViewItemComparer(0,SortOrder.Ascending);

            DirFileCounterLabel.Text = "";

            /* Reset current directory */
            _Root = new Directory();

            /* Get region to connect */
            Region regionToConnect = new Region();
            foreach (Region element in _RegionsList)
            {
                if (element.Get_RegionName().Equals(FTPListDataGridView.CurrentCell.Value))
                {
                    regionToConnect = element;
                    break;
                }
            }

            _ConnectedRegion = regionToConnect;

            /* Set credentials & current folder */
            _FtpAPI.Set_Host(regionToConnect.Get_FtpHost());
            _FtpAPI.Set_Root(regionToConnect.Get_FtpHost());
            _FtpAPI.Set_User(regionToConnect.Get_Login());
            _FtpAPI.Set_Password(regionToConnect.Get_Password());
            _Root.Set_IsRoot(true);
            _Root.Set_Name("Root");
            _Root.Set_Path(regionToConnect.Get_FtpHost());
            

            /* Start backgroundworker to get files*/
            FTPBrowserHeaderGroup.ValuesPrimary.Heading = "FTP Browser (" + regionToConnect.Get_RegionName() + ") :";
            LogcatRichTextBox.AppendText("Connecting to " + regionToConnect.Get_RegionName() + " : " + regionToConnect.Get_FtpHost() + "... ");
            FileExplorerListView.Items.Clear();
            List<object> arguments = new List<object>();
            arguments.Add("GetDir");
            _Worker.RunWorkerAsync(arguments);
        }

        /*******************************************************\
         * Change directory                                    *
         *    -> FTP Query that get files/folders of new path. *
         *    -> Fill TreeView.                                *
        \*******************************************************/

        private void ChangeDirectory(Directory dirToGo)
        {
            StopButton.Enabled = ButtonEnabled.True;
            
            /* Set current directory  */
            _CurrentDirectory = dirToGo;
            
            /* Modify credential (host) */
            _FtpAPI.Set_Host(_CurrentDirectory.Get_Path());
            
            /* Start backgroundworker to get files*/
            LogcatRichTextBox.AppendText("Changing directory to : " + _CurrentDirectory.Get_Path() + "... ");
            FileExplorerListView.Items.Clear();
            List<object> arguments = new List<object>();
            arguments.Add("ChDir");
            _Worker.RunWorkerAsync(arguments);
        }

        /**************************************\
         * Download selected item in ListView *
        \**************************************/

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadButton.Enabled = ButtonEnabled.False;
            DLLastUpdateButton.Enabled = false;
            SynchronizeLocalFileButton.Enabled = false;

            /* Clear list of files to dl */
            _FilesToDownload.Clear();

            /* Get item to download */
            foreach (File file in _CurrentDirectory.Get_FilesList())
            {
                if (FileExplorerListView.FocusedItem.Text.Equals(file.Get_Name()) || FileExplorerListView.FocusedItem.Text.Equals(file.Get_Name().Replace("%20"," ")))
                {
                    _FilesToDownload.Add(file);
                    _FtpAPI.Set_Total_Size(file.Get_Size());
                    break;
                }
            }

            /* If the target directory has been specified, directly download the file */
            if (!String.IsNullOrEmpty(_ConnectedRegion.Get_TargetDirectory()) && System.IO.Directory.Exists(_ConnectedRegion.Get_TargetDirectory()))
            {
                StopButton.Enabled = ButtonEnabled.True;

                //_LocalFilePath = _ConnectedRegion.Get_TargetDirectory() + "\\" + _FileToDownload.Get_Name();
                _LocalFilePath = _ConnectedRegion.Get_TargetDirectory() + "\\" + _FilesToDownload[0].Get_Name().Replace("%20", " ");

                /* Start Backgroundworker to download the file */
                LogcatRichTextBox.AppendText("Downloading " + _FilesToDownload[0].Get_Name().Replace("%20", " ") + "... ");
                List<object> arguments = new List<object>();
                arguments.Add("Download");
                _Worker.RunWorkerAsync(arguments);
            }

            /* If the target directory is not specified, ask the user where he wants to download the file */
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                //saveFileDialog.FileName = _FileToDownload.Get_Name().Replace("%20", " ");
                saveFileDialog.FileName = _FilesToDownload[0].Get_Name().Replace("%20", " ");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StopButton.Enabled = ButtonEnabled.True;

                    _LocalFilePath = System.IO.Path.GetFullPath(saveFileDialog.FileName);

                    /* Start Backgroundworker to download the file */
                    //LogcatRichTextBox.AppendText("Downloading " + _FileToDownload.Get_Name() + "... ");
                    LogcatRichTextBox.AppendText("Downloading " + _FilesToDownload[0].Get_Name() + "... ");
                    List<object> arguments = new List<object>();
                    arguments.Add("Download");
                    _Worker.RunWorkerAsync(arguments);
                }
            }
        }

        /*******************************************\
         * Download last update of selected region *
        \*******************************************/

        private void DLLastUpdateButton_Click(object sender, EventArgs e)
        {
            if (!_Worker.IsBusy)
            {
                StopButton.Enabled = ButtonEnabled.True;

                /* Clear interface */
                ProgressBar.Value = 0;
                ProgressLabel.Text = "-";
                DirFileCounterLabel.Text = "";
                FTPBrowserHeaderGroup.ValuesPrimary.Heading = "FTP Browser :";

                /* Clear list of files to dl */
                _FilesToDownload.Clear();

                /* Reset root */
                _Root = new Directory();

                /* Get region to connect */
                Region regionToConnect = new Region();
                foreach (Region element in _RegionsList)
                {
                    if (element.Get_RegionName().Equals(FTPListDataGridView.CurrentCell.Value))
                    {
                        regionToConnect = element;
                        break;
                    }
                }

                /* Set credentials & current folder */
                _ConnectedRegion = regionToConnect;
                _FtpAPI.Set_Host(regionToConnect.Get_FtpHost());
                _FtpAPI.Set_Root(regionToConnect.Get_FtpHost());
                _FtpAPI.Set_User(regionToConnect.Get_Login());
                _FtpAPI.Set_Password(regionToConnect.Get_Password());
                _Root.Set_IsRoot(true);
                _Root.Set_Name("Root");
                _Root.Set_Path(regionToConnect.Get_FtpHost());

                /* Start backgroundworker to get files*/
                LogcatRichTextBox.AppendText("Connecting to " + regionToConnect.Get_RegionName() + " : " + regionToConnect.Get_FtpHost() + "... ");
                List<object> arguments = new List<object>();
                arguments.Add("DlLastUp");
                _Worker.RunWorkerAsync(arguments);
            }
        }


        /**********************************************************************\
         * Synchronize local file with FTP server                             *
         *    - Get the newest file in local and Download all files in server *
         *      which are relatively more recent.                             *
        \**********************************************************************/

        private void SynchronizeLocalFileButton_Click(object sender, EventArgs e)
        {
            if (!_Worker.IsBusy)
            {
                /* Clear files to dl */
                _FtpAPI.Reset_DownloadedFilesTarget();
                _FilesToDownload.Clear();

                /* Get region from list and check if its target directory has been defined */
                Region regionToConnect = new Region();
                foreach (Region element in _RegionsList)
                {
                    if (element.Get_RegionName().Equals(FTPListDataGridView.CurrentCell.Value))
                    {
                        regionToConnect = element;
                        break;
                    }
                }

                if (String.IsNullOrEmpty(regionToConnect.Get_TargetDirectory()) || !System.IO.Directory.Exists(regionToConnect.Get_TargetDirectory()))
                {
                    KryptonMessageBox.Show("Target directory not defined, or directory doesn't exist !", "Error while checking the target directory",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                }

                else
                {
                    /* Reset root */
                    _Root = new Directory();

                    /* Set credentials & current folder */
                    _ConnectedRegion = regionToConnect;
                    _FtpAPI.Set_Host(regionToConnect.Get_FtpHost());
                    _FtpAPI.Set_Root(regionToConnect.Get_FtpHost());
                    _FtpAPI.Set_User(regionToConnect.Get_Login());
                    _FtpAPI.Set_Password(regionToConnect.Get_Password());
                    _Root.Set_IsRoot(true);
                    _Root.Set_Name("Root");
                    _Root.Set_Path(regionToConnect.Get_FtpHost());

                    /* Start backgroundworker to get files*/
                    LogcatRichTextBox.AppendText("Connecting to " + regionToConnect.Get_RegionName() + " : " + regionToConnect.Get_FtpHost() + "... ");
                    List<object> arguments = new List<object>();
                    arguments.Add("SyncLF");
                    _Worker.RunWorkerAsync(arguments);
                }
            }
        }

        /*****************\
         * Cancel Action *
        \*****************/

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = ButtonEnabled.False;

            /* Stop backgroundworker */
            _Worker.CancelAsync();          
        }

        #endregion


        /*************************************************** Misc Methods *******************************************************/

        #region MiscMethods

        /*************************************\
         * Get all regions from DB           *
         *   - Query for getting all regions *
         *   - instanciate region objects    *
        \*************************************/

        private void GetRegions()
        {
            try
            {
                FTPWebService.ftpSoapClient service = new FTPWebService.ftpSoapClient();
                _RegionsList.Clear();
                DataSet dataSet = service.Get_all_regions();
                service.Close();
                

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    _RegionsList.Add(new Region(row["provider"].ToString(),
                                                row["server_address"].ToString(),
                                                row["login"].ToString(),
                                                row["password"].ToString(),
                                                row["name"].ToString(),
                                                row["target_directory"].ToString(),
                                                row["file_mask"].ToString(),
                                                row["type"].ToString(),
                                                row["day"].ToString()));
                }
            }

            catch (Exception ex) { KryptonMessageBox.Show(ex.ToString()); }
        }

        /*******************************\
         * Add download historic on DB *
        \*******************************/

        private void AddDownloadLog()
        {
            int regionID = 0;
            int fileID = 0;

            try
            {
                /* Create service */
                FTPWebService.ftpSoapClient service = new FTPWebService.ftpSoapClient();

                /* Create Timestamp of download date */
                System.DateTime dateOfDownload = System.DateTime.Now;
                string dateOfDownloadTreated = dateOfDownload.ToString("yyyy-MM-dd HH':'mm':'ss");

                /* Get region_id of downloaded file */
                regionID = service.Get_region_id(_ConnectedRegion.Get_RegionName());
                if (regionID == 0)
                    throw new Exception("Region doesn't exist !");

                foreach (File downloadedFile in _FilesToDownload)
                {
                    /* Check if file (with it's associated region) already exists, if not, create one and get its ID. */
                    fileID = service.Get_file_id(downloadedFile.Get_Name(), regionID);
                    if (fileID == 0)
                    {
                        service.Add_file(regionID, downloadedFile.Get_Name());
                        fileID = service.Get_file_id(downloadedFile.Get_Name(), regionID);
                    }

                    /* Add historic in DB */
                    service.Add_download_per_region(regionID, fileID, dateOfDownloadTreated);
                }

                /* Update FileExplorer ListView */
                FileExplorerListView.Items.Clear();
                FillFileExplorerListView();

                /* Close service */
                service.Close();

                /* Reset targets paths & set labels*/
                _FtpAPI.Reset_DownloadedFilesTarget();
                DirFileCounterLabel.Text = _CurrentDirectory.Get_FoldersList().Count + " dir / " + _CurrentDirectory.Get_FilesList().Count + " files";
                FTPBrowserHeaderGroup.ValuesPrimary.Heading = "FTP Browser (" + _ConnectedRegion.Get_RegionName() + ") :";
            }

            catch (Exception ex) { KryptonMessageBox.Show(ex.ToString()); }
        }

        /**********************************\
         * Fill DataGridView with regions *
        \**********************************/

        private void FillFtpListDataGridView()
        {
            /* Create dataTable & add column */
            DataTable dataTable = new DataTable();
            DataColumn nameCol = dataTable.Columns.Add("name", typeof(string));

            /* Fill dataTable */
            foreach (Region element in _RegionsList)
            {
                DataRow row = dataTable.NewRow();
                row["name"] = element.Get_RegionName();
                dataTable.Rows.Add(row);
            }

            /* Set dataTable as a DataSource for the DataGridView */
            FTPListDataGridView.DataSource = dataTable;
            FTPListDataGridView.Columns["name"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            FTPListDataGridView.Columns["name"].HeaderText = "Name";

            FTPListDataGridView.Sort(FTPListDataGridView.Columns[0], ListSortDirection.Ascending);
        }

        /***********************************\
         * DatagridView Cell click event : *
         *      - display FTP summary      *
        \***********************************/

        private void FTPListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DownloadButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False; ;

                if ((Boolean)TargetDirectoryButton.Tag == false) // if no edition mode
                {
                    DeleteButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    EditButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    if (!_Worker.IsBusy)
                    {
                        ConnectButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                        DLLastUpdateButton.Enabled = true;
                        SynchronizeLocalFileButton.Enabled = true;
                    }
                }

                foreach (Region element in _RegionsList)
                {
                    if (element.Get_RegionName().Equals(FTPListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                        ServerAddressLabel2.Text = element.Get_FtpHost();
                        RegionNameLabel2.Text = element.Get_RegionName();
                        ProviderLabel2.Text = element.Get_Provider();
                        LoginLabel2.Text = element.Get_Login();
                        PasswordLabel2.Text = "************";
                        FileMaskLabel2.Text = element.Get_FileMask();
                        RecoveryFrequencyLabel2.Text = element.Get_RecoveryFrequency();
                        RecoveryDayLabel2.Text = element.Get_RecoveryDay();
                        TargetDirectoryButton.Visible = true;
                        _TargetPathTooltip.SetToolTip(TargetDirectoryButton, element.Get_TargetDirectory());
                        break;
                    }
                }
            }
        }

        /**********************************************\
         * Clear selection after databinding complete *
        \**********************************************/

        private void FTPListDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FTPListDataGridView.ClearSelection();
        }

        /*******************************************\
         * File explorer ListView item click event *
        \*******************************************/

        private void FileExplorerListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!_Worker.IsBusy && FileExplorerListView.FocusedItem != null && FileExplorerListView.FocusedItem.ImageIndex != 1 && FileExplorerListView.FocusedItem.ImageIndex != 2)
            {
                DownloadButton.Enabled = ButtonEnabled.True;
            }
            else
            {
                DownloadButton.Enabled = ButtonEnabled.False;
            }
        }

        /******************************\
         * Fill FileExplorer ListView *
        \******************************/

        private void FillFileExplorerListView()
        {
            DataSet fileDataSet = new DataSet(); ; // result of DB request (get download dates).

            /* If not parent directory, add "Parent directory" */ 
            if (_CurrentDirectory.Get_IsRoot() == false)
            {
                ListViewItem item = new ListViewItem();

                item.SubItems[0].Text = "Parent Directory";
                item.SubItems.Add("-");
                item.SubItems.Add("-");
                item.SubItems.Add("-");
                item.ImageIndex = 2;

                FileExplorerListView.Items.AddRange(new ListViewItem[] { item });
            }

            /* Fill Directories */
            foreach (Directory dir in _CurrentDirectory.Get_FoldersList())
            {
                ListViewItem item = new ListViewItem();
                
                item.SubItems[0].Text = dir.Get_Name().Replace("%20"," ");
                item.SubItems.Add("-");
                item.SubItems.Add("-");
                item.SubItems.Add("-");
                item.ImageIndex = 1;

                FileExplorerListView.Items.AddRange(new ListViewItem[] { item });
            }

            /* Get eventual modification date of files */
            try
            {
                FTPWebService.ftpSoapClient service = new FTPWebService.ftpSoapClient();
                int regionID = service.Get_region_id(_ConnectedRegion.Get_RegionName());
                fileDataSet = service.Get_files_download_date(regionID);
                service.Close();
            }

            catch (Exception ex) { KryptonMessageBox.Show(ex.ToString()); }


            /* Fill files */
            foreach (File file in _CurrentDirectory.Get_FilesList())
            {
                Boolean downloaded = false;

                /* Set Name, size, date of modification */
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = file.Get_Name().Replace("%20", " ");
                item.SubItems.Add(file.Get_Size().ToString() + " Ko");
                item.SubItems.Add(file.Get_Timestamp().ToString());

                /* Set icon */
                if (file.Get_Name().Contains(".xlsx") || file.Get_Name().Contains(".xls"))
                    item.ImageIndex = 4;
                else if (file.Get_Name().Replace(".ZIP",".zip").Contains(".zip") || file.Get_Name().Contains(".tar") || file.Get_Name().Contains(".7z"))
                    item.ImageIndex = 5;
                else if (file.Get_Name().Contains(".rar"))
                    item.ImageIndex = 6;
                else item.ImageIndex = 0;

                /* Check if file (with it's associated region) has already been downloaded. If yes, color it. */
                foreach (DataRow row in fileDataSet.Tables[0].Rows)
                {
                    if (row["name"].ToString().Equals(file.Get_Name()))
                    {
                        item.SubItems.Add(row["max(download_date)"].ToString());
                        item.BackColor = Color.LemonChiffon;
                        downloaded = true;
                        break;
                    }
                }
                if (!downloaded)
                    item.SubItems.Add("-");

                FileExplorerListView.Items.AddRange(new ListViewItem[] { item });
            }

            /* Re initialize some graphics */
        }

        /************************************\
         * File Explorer Column click event * 
         *  Sort column.                    *
        \************************************/

        private void FileExplorerListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FileExplorerListView.SelectedItems.Clear();

            if (FileExplorerListView.Sorting == SortOrder.Ascending)
            {
                FileExplorerListView.Sorting = SortOrder.Descending;
                FileExplorerListView.SetSortIcon(e.Column, SortOrder.Descending);
            }
            else
            {
                FileExplorerListView.Sorting = SortOrder.Ascending;
                FileExplorerListView.SetSortIcon(e.Column, SortOrder.Ascending);
            }

            FileExplorerListView.ListViewItemSorter = new ListViewItemComparer(e.Column,FileExplorerListView.Sorting);
        }

        /************************************\
         * File Explorer double click event * 
         *    change directory              *
        \************************************/

        private void FileExplorerListView_DoubleClick(object sender, EventArgs e)
        {
            if (!_Worker.IsBusy && FileExplorerListView.SelectedItems.Count > 0)
            {
                if (FileExplorerListView.FocusedItem.ImageIndex == 1)
                {
                    /* Reset File Explorer Sorting */
                    FileExplorerListView.SetSortIcon(0, SortOrder.None);
                    FileExplorerListView.ListViewItemSorter = new ListViewItemComparer(0, SortOrder.Ascending);

                    /* Get directory to go */
                    Directory directoryToGo = new Directory();
                    foreach (Directory dir in _CurrentDirectory.Get_FoldersList())
                    {
                        if (dir.Get_Name().Equals(FileExplorerListView.SelectedItems[0].Text) || dir.Get_Name().Equals(FileExplorerListView.SelectedItems[0].Text.Replace(" ","%20")))
                        {
                            directoryToGo = dir;
                            directoryToGo.Set_ParentFolder(_CurrentDirectory);
                            break;
                        }
                    }

                    /* Change directory */
                    ChangeDirectory(directoryToGo);
                }

                else if (FileExplorerListView.FocusedItem.ImageIndex == 2)
                {
                    /* Go to parent */
                    LogcatRichTextBox.AppendText("Changing directory to : " + _CurrentDirectory.Get_ParentFolder().Get_Path() + "... ");
                    _CurrentDirectory = _CurrentDirectory.Get_ParentFolder();
                    FileExplorerListView.Items.Clear();
                    FillFileExplorerListView();
                    LogcatRichTextBox.AppendText("Done !\n");
                    LogcatRichTextBox.ScrollToCaret();

                    /* Update Files/dir counter label */
                    DirFileCounterLabel.Text = _CurrentDirectory.Get_FoldersList().Count + " dir / " + _CurrentDirectory.Get_FilesList().Count + " files";
                }
            }
        }

        /***********************************************\
         * Set Files to DL (in case of DL last update) *
         *    . by checking the mask                   *
         *    . Fill FilesToDownload                   *
        \***********************************************/

        private void SetFilesToDownload()
        {
            /* Get Last file, according to if there is a mask or not */
            /* Get matching files */
            File referenceFile = new File();
            List<File> matchingFiles = new List<File>();
            if (!String.IsNullOrEmpty(_ConnectedRegion.Get_FileMask()))
                foreach (File element in _CurrentDirectory.Get_FilesList())
                {
                    if (element.Get_Name().Replace("%20", " ").Contains(_ConnectedRegion.Get_FileMask()))
                        matchingFiles.Add(element);
                }

            if (matchingFiles.Count > 0) // Select files to DL among those which match with the mask
            {
                referenceFile = matchingFiles[0];
                /* Get first last modified file, as a reference */
                for (int i = 1; i < matchingFiles.Count; i++)
                {
                    if ((DateTime.Compare(referenceFile.Get_Timestamp(), matchingFiles[i].Get_Timestamp()) < 0))
                    {
                        referenceFile = matchingFiles[i];
                    }
                }

                /* Then get all files with the same modification date. */
                foreach (File element in matchingFiles)
                {
                    if (DateTime.Compare(element.Get_Timestamp(), referenceFile.Get_Timestamp()) == 0)
                    {
                        _FilesToDownload.Add(element);
                    }
                }
            }

            else // Select files to DL among all files (without taking account the mask)
            {
                referenceFile = _Root.Get_FilesList()[0];
                /* Get first last modified file, as a reference */
                for (int i = 1; i < _CurrentDirectory.Get_FilesList().Count; i++)
                {
                    if (DateTime.Compare(referenceFile.Get_Timestamp(), _CurrentDirectory.Get_FilesList()[i].Get_Timestamp()) < 0)
                    {
                        referenceFile = _CurrentDirectory.Get_FilesList()[i];
                    }
                }

                /* Then get all files with the same modification date. */
                foreach (File element in _CurrentDirectory.Get_FilesList())
                {
                    if (DateTime.Compare(element.Get_Timestamp(), referenceFile.Get_Timestamp()) == 0)
                    {
                        _FilesToDownload.Add(element);
                    }
                }
            }
        }

        /*************************************************\
         * Set Files to DL (in case of sync)             *
         *    . check all local files' modification date *
         *    . Check the mask                           *
         *    . Fill FilesToDownload                     *
        \*************************************************/

        private void SetFilesToDownloadBis()
        {
            /* Get file names inside target directory */
            List<string> filesName = new List<string>();
            foreach (FileInfo file in new DirectoryInfo(_ConnectedRegion.Get_TargetDirectory()).GetFiles())
            {
                filesName.Add(file.Name);
            }

            /* Define last modification date (in local) */
            DateTime lastModificationDateInLocal = new DateTime(1959, 1, 1, 0, 0, 0);
            foreach (File element in _CurrentDirectory.Get_FilesList())
            {
                foreach (String fileName in filesName)
                {
                    if (element.Get_Name().Replace("%20", " ").Equals(fileName) && DateTime.Compare(element.Get_Timestamp(), lastModificationDateInLocal) > 0) // Means lastModificationDateInLocal > element.Get_Timestamp()
                    {
                        lastModificationDateInLocal = element.Get_Timestamp();
                    }
                }
            }

            /* Select all files which timestamp > lastModificationDateLocal */
            List<File> filesTmp = new List<File>();
            foreach (File element in _CurrentDirectory.Get_FilesList())
            {
                if ((DateTime.Compare(element.Get_Timestamp(), lastModificationDateInLocal) > 0 || DateTime.Compare(element.Get_Timestamp(), lastModificationDateInLocal) == 0) && !filesName.Contains(element.Get_Name().Replace("%20"," ")))
                    filesTmp.Add(element);
            }

            /* Now get all matching files according to the mask */
            List<File> matchingFiles = new List<File>();
            if (!String.IsNullOrEmpty(_ConnectedRegion.Get_FileMask()))
                foreach (File element in filesTmp)
                    if (element.Get_Name().Replace("%20", " ").Contains(_ConnectedRegion.Get_FileMask()))
                        matchingFiles.Add(element);

            if (matchingFiles.Count > 0)
                foreach (File file in matchingFiles)
                    _FilesToDownload.Add(file);

            else if(filesTmp.Count >0)
                    foreach (File file in filesTmp)
                        _FilesToDownload.Add(file);
        }

        #endregion


        /******************************************** BACKGROUND WORKER HANDLERS ************************************************/

        #region BackgroundWorker

        private void Worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 100)
                ProgressBar.Value = 100;
            else
            {
                ProgressBar.Value = e.ProgressPercentage;
                ProgressLabel.Text = e.ProgressPercentage + "%";
            }
        }

        private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            StopButton.Enabled = ButtonEnabled.False;

            if (e.Error != null)
            {
                LogcatRichTextBox.AppendText("Error ! Details : \n" + e.Error.Message + "\n");
                LogcatRichTextBox.ScrollToCaret();
                _FilesToDownload.Clear();
                _FtpAPI.Reset_DownloadedFilesTarget();
            }
            else if (e.Cancelled)
            {
                LogcatRichTextBox.AppendText("Cancelled !\n");
                LogcatRichTextBox.ScrollToCaret();
                ProgressBar.Value = 0;
                ProgressLabel.Text = " - ";
                _FilesToDownload.Clear();
                _FtpAPI.Reset_DownloadedFilesTarget();
            }
            else
            {
                List<object> returnArguments = e.Result as List<object>;
                if (returnArguments.Count > 1)
                {
                    for (int i = 1; i < returnArguments.Count; i++)
                    {
                        LogcatRichTextBox.AppendText("Error ! :\n" + (string)returnArguments[i]);
                    }
                    _FilesToDownload.Clear();
                    _FtpAPI.Reset_DownloadedFilesTarget();
                }

                else
                {
                    switch ((string)returnArguments[0])
                    {
                        case "GetDir":
                            LogcatRichTextBox.AppendText("Done !\n");
                            LogcatRichTextBox.ScrollToCaret();
                            _CurrentDirectory = _Root;
                            FillFileExplorerListView();
                            DirFileCounterLabel.Text = _Root.Get_FoldersList().Count + " dir / " + _Root.Get_FilesList().Count + " files";
                            break;

                        case "ChDir":
                            LogcatRichTextBox.AppendText("Done !\n");
                            LogcatRichTextBox.ScrollToCaret();
                            FillFileExplorerListView();
                            DirFileCounterLabel.Text = _CurrentDirectory.Get_FoldersList().Count + " dir / " + _CurrentDirectory.Get_FilesList().Count + " files";
                            break;

                        case "Download":
                            LogcatRichTextBox.AppendText("Downloaded to " + _FtpAPI.Get_DownloadedFilesTarget()[0] + ".\n");
                            for(int i = 1;i<_FtpAPI.Get_DownloadedFilesTarget().Count;i++)
                            {
                                LogcatRichTextBox.AppendText("................................................... Downloaded to " + _FtpAPI.Get_DownloadedFilesTarget()[i] + ".\n");
                            }
                            LogcatRichTextBox.ScrollToCaret();
                            AddDownloadLog();                           
                            break;

                        case "DlLastUp":
                            LogcatRichTextBox.AppendText("Done !\n");
                            LogcatRichTextBox.AppendText("Downloading last updates... ");
                            LogcatRichTextBox.ScrollToCaret();
                            _CurrentDirectory = _Root;
                            List<object> arguments = new List<object>();
                            arguments.Add("DlLastUpBis");

                            SetFilesToDownload();

                            if (String.IsNullOrEmpty(_ConnectedRegion.Get_TargetDirectory()) || !System.IO.Directory.Exists(_ConnectedRegion.Get_TargetDirectory()))
                            {
                                FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
                                openFolderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                                openFolderDialog.Description = "Please select target folder";
                                DialogResult result = openFolderDialog.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    arguments.Add(openFolderDialog.SelectedPath);
                                }
                                else
                                {
                                    LogcatRichTextBox.AppendText("Cancelled !\n");
                                    LogcatRichTextBox.ScrollToCaret();
                                    ProgressBar.Value = 0;
                                    ProgressLabel.Text = " - ";
                                    _FilesToDownload.Clear();
                                    _FtpAPI.Reset_DownloadedFilesTarget();
                                    break;
                                }
                            }
                            else
                            {
                                arguments.Add(_ConnectedRegion.Get_TargetDirectory());
                            }

                            StopButton.Enabled = ButtonEnabled.True;
                            _Worker.RunWorkerAsync(arguments);
                            break;
                        case "SyncLF":
                            LogcatRichTextBox.AppendText("Done !\n");
                            LogcatRichTextBox.AppendText("Synchronizing with local file... ");
                            LogcatRichTextBox.ScrollToCaret();
                            _CurrentDirectory = _Root;
                            List<object> arguments2 = new List<object>();
                            arguments2.Add("SyncLFBis");

                            SetFilesToDownloadBis();

                            if (_FilesToDownload.Count > 0)
                            {
                                arguments2.Add(_ConnectedRegion.Get_TargetDirectory());
                                StopButton.Enabled = ButtonEnabled.True;
                                _Worker.RunWorkerAsync(arguments2);
                            }
                            else LogcatRichTextBox.AppendText("Already up to date !\n");
                            break;
                    }
                }
            }
        }

        private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as System.ComponentModel.BackgroundWorker;
            List<object> arguments = e.Argument as List<object>;

            switch ((string)arguments[0])
            {
                /* Connect and Fill current folder */
                case "GetDir":                 
                    _FtpAPI.GetDirectoryList(_Root, worker, e);
                    break;

                /* Change directory */
                case "ChDir":
                    _FtpAPI.GetDirectoryList(_CurrentDirectory, worker, e);
                    break;

                /* Download file */
                case "Download":
                    _FtpAPI.DownloadFile(_FilesToDownload[0].Get_Path(), _LocalFilePath, 1, worker, e);
                    break;

                /* Download last update */
                case "DlLastUp":
                    _FtpAPI.GetDirectoryList(_Root, worker, e);
                    break;
                case "DlLastUpBis":
                    _FtpAPI.DownloadFiles(_FilesToDownload, ((string)arguments[1]), worker, e);
                    break;

                /* Synchronize local folder */
                case "SyncLF" :
                    _FtpAPI.GetDirectoryList(_Root, worker, e);
                    break;
                case "SyncLFBis":
                    _FtpAPI.DownloadFiles(_FilesToDownload, ((string)arguments[1]), worker, e);
                    break;
            }
        }

        #endregion   
    }

    #region ExtensionClasses

    /***************************************\
     * ListView Comparer class for sorting *
    \***************************************/

    public class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;

        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;

            switch (col)
            {
                case 0:
                    if (((ListViewItem)x).SubItems[col].Text.Equals("Parent Directory") && this.order == SortOrder.Ascending)
                        returnVal = -1;
                    else if (((ListViewItem)x).SubItems[col].Text.Equals("Parent Directory") && this.order == SortOrder.Descending)
                        returnVal = 1;
                    else returnVal = ((ListViewItem)x).SubItems[col].Text.CompareTo(((ListViewItem)y).SubItems[col].Text);
                    break;
                case 1:
                    if (((ListViewItem)x).SubItems[0].Text.Equals("Parent Directory") && this.order == SortOrder.Ascending)
                        returnVal = -1;
                    else if (((ListViewItem)x).SubItems[0].Text.Equals("Parent Directory") && this.order == SortOrder.Descending)
                        returnVal = 1;
                    else returnVal = int.Parse(((ListViewItem)x).SubItems[col].Text.Replace(" Ko", "").Replace("-", "-1")).CompareTo(
                        int.Parse(((ListViewItem)y).SubItems[col].Text.Replace(" Ko", "").Replace("-", "-1")));
                    break;
                case 2:
                case 3:
                    if (((ListViewItem)x).SubItems[0].Text.Equals("Parent Directory") && this.order == SortOrder.Ascending)
                        returnVal = -1;
                    else if (((ListViewItem)x).SubItems[0].Text.Equals("Parent Directory") && this.order == SortOrder.Descending)
                        returnVal = 1;
                    else returnVal = DateTime.Compare(
                        DateTime.Parse(((ListViewItem)x).SubItems[col].Text.Replace("-", new DateTime(1959,1,1,0,0,0).ToString())),
                        DateTime.Parse(((ListViewItem)y).SubItems[col].Text.Replace("-", new DateTime(1959,1,1,0,0,0).ToString())));
                    break;

                default:
                    returnVal = String.Compare(
                        ((ListViewItem)x).SubItems[col].Text,
                        ((ListViewItem)y).SubItems[col].Text);
                    break;
            }

            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
            {
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            }

            return returnVal;
        }
    }


    /*****************************************************\
     * ListView extension class for displaying the arrow *
    \*****************************************************/

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ListViewExtensions
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct HDITEM
        {
            public Mask mask;
            public int cxy;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public IntPtr hbm;
            public int cchTextMax;
            public Format fmt;
            public IntPtr lParam;
            // _WIN32_IE >= 0x0300 
            public int iImage;
            public int iOrder;
            // _WIN32_IE >= 0x0500
            public uint type;
            public IntPtr pvFilter;
            // _WIN32_WINNT >= 0x0600
            public uint state;

            [Flags]
            public enum Mask
            {
                Format = 0x4,       // HDI_FORMAT
            };

            [Flags]
            public enum Format
            {
                SortDown = 0x200,   // HDF_SORTDOWN
                SortUp = 0x400,     // HDF_SORTUP
            };
        };

        public const int LVM_FIRST = 0x1000;
        public const int LVM_GETHEADER = LVM_FIRST + 31;

        public const int HDM_FIRST = 0x1200;
        public const int HDM_GETITEM = HDM_FIRST + 11;
        public const int HDM_SETITEM = HDM_FIRST + 12;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam);

        public static void SetSortIcon(this ListView listViewControl, int columnIndex, SortOrder order)
        {
            IntPtr columnHeader = SendMessage(listViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            for (int columnNumber = 0; columnNumber <= listViewControl.Columns.Count - 1; columnNumber++)
            {
                var columnPtr = new IntPtr(columnNumber);
                var item = new HDITEM
                {
                    mask = HDITEM.Mask.Format
                };

                if (SendMessage(columnHeader, HDM_GETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }

                if (order != SortOrder.None && columnNumber == columnIndex)
                {
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            item.fmt &= ~HDITEM.Format.SortDown;
                            item.fmt |= HDITEM.Format.SortUp;
                            break;
                        case SortOrder.Descending:
                            item.fmt &= ~HDITEM.Format.SortUp;
                            item.fmt |= HDITEM.Format.SortDown;
                            break;
                    }
                }
                else
                {
                    item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
                }

                if (SendMessage(columnHeader, HDM_SETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
            }
        }
    }

    #endregion
}
