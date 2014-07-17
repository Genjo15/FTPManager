using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPManager
{
    class Directory
    {
        /***************************************************** Variables *******************************************************/

        #region Variables

        private string _Path;
        private string _Name;

        private List<Directory> _FoldersList;
        private Directory _ParentFolder;
        private List<File> _FilesList;
        private Boolean _IsRoot;

        #endregion

        /**************************************************** Constructor *******************************************************/

        #region Constructor

        public Directory(string name, string path, Boolean isRoot)
        {
            _FoldersList = new List<Directory>();
            _FilesList = new List<File>();
            _ParentFolder = null;
            _IsRoot = isRoot;
            _Path = path;
            _Name = name;
        }

        public Directory()
        {
            _FoldersList = new List<Directory>();
            _FilesList = new List<File>();
            _ParentFolder = null;
            _IsRoot = false;
            _Path = String.Empty;
            _Name = String.Empty;        
        }

        #endregion

        /****************************************************** Methods *********************************************************/

        #region Methods

        #endregion

        #region Accessors

        public void Set_Name(string name) { _Name = name; }
        public void Set_Path(string path) { _Path = path; }
        public void Set_IsRoot(Boolean isRoot) { _IsRoot = isRoot; }
        public void Set_ParentFolder(Directory dir) { _ParentFolder = dir; }

        public string Get_Name() { return _Name; }
        public string Get_Path() { return _Path; }
        public Boolean Get_IsRoot() { return _IsRoot; }
        public Directory Get_ParentFolder() { return _ParentFolder; }


        public List<File> Get_FilesList() { return _FilesList; }
        public List<Directory> Get_FoldersList() { return _FoldersList; }

        #endregion
    }
}
