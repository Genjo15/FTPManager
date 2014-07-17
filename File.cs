using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPManager
{
    class File
    {
        /***************************************************** Variables *******************************************************/

        #region Variables

        private string _Name;
        private string _Path;
        private int _Size;
        private DateTime _Timestamp;

        #endregion

        /**************************************************** Constructor *******************************************************/

        #region Constructors

        public File()
        {
            _Name = String.Empty;
            _Path = String.Empty;
            _Size = 0;
            _Timestamp = new DateTime();
        }

        public File(string name, string path, int size, DateTime timestamp)
        {
            _Name = name;
            _Path = path;
            _Size = size;
            _Timestamp = timestamp;
        }

        #endregion

        /****************************************************** Methods *********************************************************/

        #region Methods

        #endregion

        #region Accessors

        public string Get_Name() { return _Name; }
        public string Get_Path() { return _Path; }
        public int Get_Size() { return _Size; }
        public DateTime Get_Timestamp() { return _Timestamp; }

        #endregion
    }
}
