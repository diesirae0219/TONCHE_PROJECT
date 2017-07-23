using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using FactoryObject.Utility;

namespace FactoryObject
{
    public class DB_Access
    {//114.33.130.81\SQLEXPRESS
        //public static string Constr = @"Provider=SQLOLEDB;Data Source=.\\SQLEXPRESS; AttachDbFilename =D:\\Database\\TonChe.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";//"Provider=SQLOLEDB;server=(local);Initial Catalog=TonChe;Integrated Security=true;";//"Provider=Microsoft.Ace.OLEDB.12.0;Data Sorce=";
        public static string Constr = @"Server=114.33.130.81\SQLEXPRESS;Database=TonChe;User Id=sa;Password=tonche.t888;";//"Provider=SQLOLEDB;server=(local);Initial Catalog=TonChe;Integrated Security=true;";//"Provider=Microsoft.Ace.OLEDB.12.0;Data Sorce=";
        public static string ConstrLocal = @"Server=" + Environment.UserDomainName + @"\SQLEXPRESS;Database=TonChe;User Id=sa;Password=tonche.t888;";
        public static string Database = "";

        public DB_Access(GlobalVar.SysMode sMode)
        {
            // Constr = Constr;//+ _Database;
            //if (GlobalVar.sMode == GlobalVar.SysMode.Local)
            if (sMode == GlobalVar.SysMode.Local)
            {
                Constr = ConstrLocal;//"Provider=SQLOLEDB;server=(local);Initial Catalog=TonChe;Integrated Security=true;";//"Provider=Microsoft.Ace.OLEDB.12.0;Data Sorce=";
            }
        }

        public static OleDbConnection OleDbOpenConn(string Database)
        {
            OleDbConnection icn = new OleDbConnection();

            icn.ConnectionString = Constr;
            if (icn.State == ConnectionState.Open) icn.Close();
            icn.Open();
            return icn;

        }

        public static DataTable GetOleDbDataTable(string OleDbString)
        {
            DataTable myDataTable = new DataTable();
            OleDbConnection icn = OleDbOpenConn(Database);
            OleDbDataAdapter da = new OleDbDataAdapter(OleDbString, icn);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            myDataTable = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
        }

        public static void OleDbInsertUpdateDelete(string Database, string OleDbSelectString)
        {
            //string cnstr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Database);
            OleDbConnection icn = OleDbOpenConn(Constr);
            OleDbCommand cmd = new OleDbCommand(OleDbSelectString, icn);
            cmd.ExecuteNonQuery();
            if (icn.State == ConnectionState.Open) icn.Close();
        }

        public DataTable QueryData(string sql)
        {
            SqlConnection cnn;
            DataTable dtResult = new DataTable();
            cnn = new SqlConnection(Constr);

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            SqlDataReader mydr = cmd.ExecuteReader();
            dtResult.Load(mydr);
            mydr.Close();
            cmd.Clone();
            cnn.Close();
            return dtResult;
        }

        public bool ExecData(string sql)
        {
            SqlConnection cnn;
            DataTable dtResult = new DataTable();
            cnn = new SqlConnection(Constr);

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            int mydr = cmd.ExecuteNonQuery();
            //dtResult.Load(mydr);
            //mydr.Close();
            cmd.Clone();
            cnn.Close();
            if (mydr > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
