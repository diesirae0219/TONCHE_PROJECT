using TonChe_Operation_Cneter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using TonChe_Operation_Cneter.Database;
using TonChe_Operation_Cneter.Utility;
using FactoryObject;


namespace TonChe_Operation_Cneter
{        
    public partial class frmLogin : Form
    {
        public DB_Access dbTool = new DB_Access();
        public frmLogin()
        {
            InitializeComponent();
            this.rgMode.SelectedIndex = 0;
            SetSysMode(); 
            Init();
        }

        private void Init()
        {
            this.AcceptButton = btnLogin;
            string ssql = SQL_TEXT.Q_EMPL;
            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {                
                cbName.Items.Clear();
                for (int i = 0; i < dtRet.Rows.Count; i++)
                {
                    ComboxItem cbItem = new ComboxItem();
                    cbItem.Text = string.Format("{0}-{1}", dtRet.Rows[i]["EMPLNO"], dtRet.Rows[i]["EMPLNAME"]);
                    cbItem.Value = dtRet.Rows[i]["EMPLNO"].ToString();
                    cbName.Items.Add(cbItem);
                }
                cbName.SelectedIndex = 0;
            }
        }

        private void SetSysMode()
        {
            if (this.rgMode.SelectedIndex == 0)
            {
                GlobalVar.sMode = GlobalVar.SysMode.Web;
            }
            else
            {
                GlobalVar.sMode = GlobalVar.SysMode.Local;
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbName.Text))
            {

                ComboxItem cbItem = (ComboxItem)cbName.SelectedItem;
                string[] emplStr = cbItem.Text.Split('-');
                EMPLOYEE empl = new EMPLOYEE(emplStr[0], emplStr[1],GlobalVar.sMode.ToString());
                if (tbPW.Text == "111111")
                //if (empl.CheckPW(tbPW.Text))
                {                   
                    GlobalVar.LoginUser = empl;                
                    DialogResult = DialogResult.OK;
                }
                else
                {
                   MessageBox.Show("密碼錯誤!");
                }
            }
            else
            {
                lbNote.Text = "請選擇使用者!";
            }
        }

        private void tbPW_TextChanged(object sender, EventArgs e)
        {
            lbNote.Text = "";
        }


    }
}
