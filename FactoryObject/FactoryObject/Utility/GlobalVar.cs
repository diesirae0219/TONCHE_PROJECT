using FactoryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FactoryObject.Utility
{
    public static class GlobalVar
    {
        private static EMPLOYEE _LoginUser;
        public enum SysMode { Web, Local };
        //public static string WebVersion = Properties.Settings.Default["WebVersion"].ToString();
   
        public static EMPLOYEE LoginUser
        {
            get { return _LoginUser; }
            set { _LoginUser = value; }
        }

        public static SysMode sMode
        {
            get;
            set;
        }

    }
}
