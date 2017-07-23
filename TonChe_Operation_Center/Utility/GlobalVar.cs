using TonChe_Operation_Cneter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FactoryObject;


namespace TonChe_Operation_Cneter.Utility
{
    public static class GlobalVar
    {
        private static EMPLOYEE _LoginUser;
        public enum SysMode { Web, Local };
        //public static string WebVersion = Properties.Settings.Default["WebVersion"].ToString();
        public static string LocalTonChePicturePath = Properties.Settings.Default["LocalPicture"].ToString();
        public static string LocalDesignFormPath = Properties.Settings.Default["LocalDesignForm"].ToString();

        public static string WebTonChePicturePath = Properties.Settings.Default["WebPicture"].ToString();
        public static string WebDesignFormPath = Properties.Settings.Default["WebDesignForm"].ToString();

        public static string ExcelSavePath = Properties.Settings.Default["SaveFile"].ToString();

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
