using FactoryObject.Database;
using FactoryObject.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace FactoryObject
{
    public class EMPLOYEE
    {
        public enum shift { S1, S2, S3 };//1:早班 2:中班 3:晚班           
        private string _USER_ID = "";
        private DB_Access dbTool;
        public string USER_ID
        {
            get { return _USER_ID; }
            set { _USER_ID = value; }
        }

        private string _USER_CNAME = "";
        public string USER_NAME
        {
            get { return _USER_CNAME; }
            set { _USER_CNAME = value; }
        }

        public EMPLOYEE(string _USER_ID, string _USER_CNAME, string _sMode)
        {
            GlobalVar.SysMode sMode = (GlobalVar.SysMode)Enum.Parse(typeof(GlobalVar.SysMode), _sMode, false);
            dbTool = new DB_Access(sMode);
            this.USER_ID = _USER_ID;
            this.USER_NAME = _USER_CNAME;
        }

        public bool CheckPW(string password)
        {
            bool bOK = false;
            string ssql = SQL_TEXT.Q_CHECK_PW;
            ssql = ssql.Replace(":empl", _USER_ID);
            ssql = ssql.Replace(":password", password);

            DataTable dtTable = dbTool.QueryData(ssql);

            if (dtTable.Rows.Count > 0)
            {
                bOK = true;
            }           

            return bOK;
        }

    }
}
