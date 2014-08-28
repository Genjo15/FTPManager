using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPManager
{
    public class Region
    {
        /***************************************************** Variables *****************************************************/

        #region Variables

        private string _Provider;
        private string _FtpHost;
        private string _Login;
        private string _Password;

        private string _RegionName;
        private string _TargetDirectory;
        private string _FileMask;
        private string _RecoveryFrequency;
        private string _RecoveryDay;


        #endregion

        /**************************************************** Constructor ****************************************************/

        #region Constructor

        public Region(string provider, string serverAddress, string login, string password, string regionName, string targetDirectory, string fileMask, string recoveryFrequency, string recoveryDay)
        {
            _Provider = provider;
            _FtpHost = serverAddress;
            _Login = login;
            _Password = password;
            _RegionName = regionName;
            _TargetDirectory = targetDirectory;
            _FileMask = fileMask;
            _RecoveryFrequency = recoveryFrequency;
            _RecoveryDay = recoveryDay;
        }

        public Region()
        {
            _Provider = null;
            _FtpHost = null;
            _Login = null;
            _Password = null;
            _RegionName = null;
            _TargetDirectory = null;
            _FileMask = null;
            _RecoveryFrequency = null;
            _RecoveryDay = null;
        }

        #endregion

        /***************************************************** Methods *******************************************************/

        #region Methods

        public void Clone(Region regionToClone)
        {
            _Provider = regionToClone.Get_Provider();
            _FtpHost = regionToClone.Get_FtpHost();
            _Login = regionToClone.Get_Login();
            _Password = regionToClone.Get_Password();

            _RegionName = regionToClone.Get_RegionName();
            _TargetDirectory = regionToClone.Get_TargetDirectory();
            _FileMask = regionToClone.Get_FileMask();
            _RecoveryFrequency = regionToClone.Get_RecoveryFrequency();
            _RecoveryDay = regionToClone.Get_RecoveryDay();
        }

        #endregion

        #region Accessors

        public String Get_FtpHost() { return _FtpHost; }
        public String Get_RegionName(){return _RegionName;}
        public void Set_RegionNameForClone() { _RegionName += " (1)"; }
        public String Get_Provider() { return _Provider; }
        public String Get_Login() { return _Login; }
        public String Get_Password() { return _Password; }
        public String Get_TargetDirectory() { return _TargetDirectory; }
        public String Get_FileMask() { return _FileMask; }
        public String Get_RecoveryFrequency() { return _RecoveryFrequency; }
        public String Get_RecoveryDay() { return _RecoveryDay; }

        #endregion
    }
}
