using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Database;

namespace TonChe_Operation_Cneter
{
    public partial class frmNewART : Form
    {
        private string ART_TYPE_STRING = "";
        public DB_Access db_Tool = new DB_Access();
        private Form Enter_F;
        //string Connstr = "Data Source=Localhost;Initial Catalog=TonChe;user id=sa;password=7891mirac;persist security info=false;Connect Timeout=30;";
        public frmNewART(Form _Enter_F)
        {
            InitializeComponent();
            Enter_F = _Enter_F;
            LoadART_Type();
        }

        private void NewART_Load(object sender, EventArgs e)
        {

        }

        private bool CHECK_MUST()
        {
            bool CHK_RESULT = true;
            if (tb_NEW_ART.Text == "")
            {
                tb_NEW_ART.BackColor = Color.Yellow;
                CHK_RESULT = false;
            }
            else
            {
                tb_NEW_ART.BackColor = Color.White;
            }

            if (tb_NEW_CONST.Text == "")
            {
                tb_NEW_CONST.BackColor = Color.Yellow;
                CHK_RESULT = false;
            }
            else
            {
                tb_NEW_CONST.BackColor = Color.White;
            }

            if (tb_NEW_CONST.Text == "")
            {
                tb_NEW_CONST.BackColor = Color.Yellow;
                CHK_RESULT = false;
            }
            else
            {
                tb_NEW_CONST.BackColor = Color.White;
            }

            if (tb_NEW_COMPO.Text=="")
            {
             tb_NEW_COMPO.BackColor = Color.Yellow;
                CHK_RESULT = false;
            }
             else
            {
                tb_NEW_COMPO.BackColor = Color.White;
            }

            if (tb_NEW_WEIGHT.Text == "")
            {
                tb_NEW_WEIGHT.BackColor = Color.Yellow;
                CHK_RESULT = false;
            }
            else
            {
                tb_NEW_WEIGHT.BackColor = Color.White;
            }

            return CHK_RESULT;
        
        }

        private void btn_NEW_OK_Click(object sender, EventArgs e)
        {
            if (CHECK_MUST())
            {
                SqlConnection cnn = new SqlConnection(DB_Access.Constr);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                string sql = SQL_TEXT.I_NEW_ART;

                SqlCommand cmd = new SqlCommand(sql, cnn);


                cmd.Parameters.Add("@ART_NO", SqlDbType.VarChar).Value = tb_NEW_ART.Text;
                cmd.Parameters.Add("@CONSTRUCTION", SqlDbType.VarChar).Value = tb_NEW_CONST.Text;
                cmd.Parameters.Add("@COMPOSITION", SqlDbType.VarChar).Value = tb_NEW_COMPO.Text;
                cmd.Parameters.Add("@WEIGHT", SqlDbType.VarChar).Value = tb_NEW_WEIGHT.Text;
                cmd.Parameters.Add("@REMARK", SqlDbType.VarChar).Value = tb_NEW_REMARK.Text;
                cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = tb_NEW_COLOR.Text;
                cmd.Parameters.Add("@ART_TYPE", SqlDbType.VarChar).Value = tbART_TYPE.Text;
                if (tb_NEW_PRICE.Text == "")
                {
                    tb_NEW_PRICE.Text = "0";
                }
                cmd.Parameters.Add("@PRICE", SqlDbType.VarChar).Value = double.Parse(tb_NEW_PRICE.Text);

                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cnn.Close();
                    MessageBox.Show("新增成功!");
                    frmProdInfo f = (frmProdInfo)Enter_F;
                    //Form1 ff = new Form1();
                    f.loadData();                    
                    f.RefreshGV();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增失敗! 錯誤訊息:" + ex.Message);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("請填寫必要欄位!");
            }
        }

        private void btn_NEW_CANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbArtType_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            CheckedComboBoxEdit edit = sender as CheckedComboBoxEdit;
            //if (e.CloseMode == PopupCloseMode.ButtonClick)
            //    MessageBox.Show(edit.EditValue.ToString());
            tbART_TYPE.Text = cbArtType.EditValue.ToString();
        }

        private void LoadART_Type()
        {
            string ssql = SQL_TEXT.Q_ART_TYPE;
            DataTable dtRet = db_Tool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                //if (tbART_TYPE.Text == "")
                //{
                int idx = 0;
                cbArtType.Properties.Items.Clear();
                foreach (DataRow dr in dtRet.Rows)
                {
                    cbArtType.Properties.Items.Add(dr["NO"].ToString() + "-" + dr["ART_TYPE"].ToString(), CheckState.Unchecked, true);
                    if (tbART_TYPE.Text.Contains(dr["NO"].ToString() + "-" + dr["ART_TYPE"].ToString()))
                    {
                        cbArtType.Properties.Items[idx].CheckState = CheckState.Checked;
                    }
                    idx++;
                }

                //}

            }
            cbArtType.Properties.SeparatorChar = ';';

        }
    }
}
