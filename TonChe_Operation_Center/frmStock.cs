using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Database;
using TonChe_Operation_Cneter.Utility;

namespace TonChe_Operation_Cneter
{
    public partial class frmStock : Form
    {
        enum Mode { IN,OUT,MODIFY };
        private Mode _mode;
        private string ART_NO;
        public DB_Access dbTool = new DB_Access();     
        public frmStock(string _ART_NO)
        {
            InitializeComponent();
            
            //LoadSTKQty();
            ART_NO = _ART_NO;
            this.tbART_NO.Text = _ART_NO;
            LoadStockHistory();
        }

      
        private void LoadStockHistory()
        {
            string ssql = SQL_TEXT.Q_STOCK_HISTORY;
            ssql = ssql.Replace(":ART_NO", ART_NO);
            DataTable dtRet = dbTool.QueryData(ssql);
            btnSave.Visible = true;
            btnGet.Visible = true;

            if (dtRet.Rows.Count > 0)
            {
                dgvStock.DataSource = dtRet;                
            }

            string ssql2 = SQL_TEXT.Q_LAST_STOCK_HISTORY;
            ssql2 = ssql2.Replace(":ART_NO", ART_NO);
            DataTable dtLastRet = dbTool.QueryData(ssql2);

            if (dtLastRet.Rows.Count > 0)
            {
                foreach (DataRow dr in dtLastRet.Rows)
                {
                    if (dr["UPDATE_REASON"].ToString().Contains("-1"))
                    {
                        tb1Loc.Text = dr["STK_NAME"].ToString();
                        tb1Qty.Text = dr["Qty"].ToString();
                    }

                    if (dr["UPDATE_REASON"].ToString().Contains("-2"))
                    {
                        tb2Loc.Text = dr["STK_NAME"].ToString();
                        tb2Qty.Text = dr["Qty"].ToString();
                    }

                    lbSubTotal.Text = (int.Parse(String.IsNullOrEmpty(tb1Qty.Text) ? "0" : tb1Qty.Text) + int.Parse(String.IsNullOrEmpty(tb2Qty.Text) ? "0" : tb2Qty.Text)).ToString();

                    if (dr["UPDATE_REASON"].ToString().Contains("-H"))
                    {
                        tbHLoc.Text = dr["STK_NAME"].ToString();
                        tbHQty.Text = dr["Qty"].ToString();
                    }

                    if (dr["UPDATE_REASON"].ToString().Contains("-S"))
                    {
                        tbSLoc.Text = dr["STK_NAME"].ToString();
                        tbSQty.Text = dr["Qty"].ToString();
                    }

                    if (dr["UPDATE_REASON"].ToString().Contains("-E"))
                    {
                        tbELoc.Text = dr["STK_NAME"].ToString();
                        tbEQty.Text = dr["Qty"].ToString();
                    }

                    lbSubTotal2.Text = (int.Parse(String.IsNullOrEmpty(tbHQty.Text) ? "0" : tbHQty.Text) + int.Parse(String.IsNullOrEmpty(tbSQty.Text) ? "0" : tbSQty.Text) + int.Parse(String.IsNullOrEmpty(tbEQty.Text) ? "0" : tbEQty.Text)).ToString();
                }
            }
            else
            {
                btnSave.Visible = false;
                btnGet.Visible = false;
            }
        }

        private void LoadSTKDEF()
        { 
             string ssql = SQL_TEXT.Q_STK_DEF;
             DataTable dtRet = dbTool.QueryData(ssql);
             if (dtRet.Rows.Count > 0)
             {
                
                 cb1Loc.Items.Clear();
                 cb2Loc.Items.Clear();

                 //cbLoc1Qty.Items.Add("無");
                 //cbLoc2Qty.Items.Add("無");
                 foreach (DataRow dr in dtRet.Rows)
                 {
                     if (dr["STK_NAME"].ToString() == "倉庫")
                     {
                         cb1Loc.Items.Add(dr["STK_NAME"].ToString() + "-" + dr["STK_NO"].ToString());
                     }
                 }

                 foreach (DataRow dr in dtRet.Rows)
                 {
                     if (dr["STK_NAME"].ToString() == "布架")
                     {
                         cb2Loc.Items.Add(dr["STK_NAME"].ToString() + "-" + dr["STK_NO"].ToString());
                     }
                 }
                 //ssql = ssql.Replace(":ART_NO", ART_NO);
             }

        }

        private void LoadART_Type()
        {
            string ssql = SQL_TEXT.Q_ART_TYPE;
            //cbLoc1Qty.Items.Clear();
            //cbHLoc.Items.Clear();
            //cbSLoc.Items.Clear();
            //cbELoc.Items.Clear();

            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                foreach (DataRow dr in dtRet.Rows)
                {
                    //cbART_Type.Properties.Items.Add(dr["NO"].ToString() + "-" + dr["ART_TYPE"].ToString(), CheckState.Unchecked, true);
                    cbHLoc.Items.Add(dr["NO"].ToString() + "-" + dr["ART_TYPE"].ToString());
                    cbSLoc.Items.Add(dr["NO"].ToString() + "-" + dr["ART_TYPE"].ToString());
                    cbELoc.Items.Add(dr["NO"].ToString() + "-" + dr["ART_TYPE"].ToString());
                }
                //cbART_Type.Properties.SeparatorChar = ';';
            }

        }

        //private void LoadSTKQty()
        //{
        //    cbLoc1Qty.Items.Clear();
        //    cbLoc2Qty.Items.Clear();

        //    for (int i = 1; i <= 100; i++)
        //    {
        //        cbLoc1Qty.Items.Add(i.ToString());
        //        cbLoc2Qty.Items.Add(i.ToString());
        //    }

        //    for (int i = 1; i <= 5; i++)
        //    {
        //        cbHQty.Items.Add(i.ToString());
        //        cbSQty.Items.Add(i.ToString());
        //        cbEQty.Items.Add(i.ToString());
        //    }
        
        //}

        private void btnUpdateMode_Click(object sender, EventArgs e)
        {
            LoadART_Type();
            _mode = Mode.MODIFY;
            LoadSTKCurrent();
            ShowEditArea(_mode,true);
            btnColor(sender, true);
           
        }

        private void LoadSTKCurrent()
        {
            cb1Loc.Text = tb1Loc.Text;
            cb2Loc.Text = tb2Loc.Text;

            int Qty=0;
            if (int.TryParse(tb1Qty.Text, out Qty))
            { cb1Qty.Value = Qty; }
            else
            { cb1Qty.Value = 0; }

            if (int.TryParse(tb2Qty.Text, out Qty))
            { cb2Qty.Value = Qty; }
            else
            { cb2Qty.Value = 0; }

            cbHLoc.Text = tbHLoc.Text;
            cbSLoc.Text = tbSLoc.Text;
            cbELoc.Text = tbELoc.Text;

            if (int.TryParse(tbHQty.Text, out Qty))
            { cbHQty.Value = Qty; }
            else
            { cbHQty.Value = 0; }

            if (int.TryParse(tbSQty.Text, out Qty))
            { cbSQty.Value = Qty; }
            else
            { cbSQty.Value = 0; }

            if (int.TryParse(tbEQty.Text, out Qty))
            { cbEQty.Value = Qty; }
            else
            { cbEQty.Value = 0; }

        }


        private void ShowEditArea(Mode m,bool flag)
        {
            LoadSTKDEF();

            pEdit.Location = pAction.Location;
            pEdit.Visible = false;
            pAction.Visible = false;

            if (m == Mode.MODIFY)
            {
                pEdit.Visible = flag;
            }
            else if (m == Mode.IN)
            {
                pAction.Visible = flag;
                cbIn1QTY.Maximum = 1000;
                cbIn1QTY.Minimum = 0;                
                cbIn1QTY.Value = 0;
                cbIn2QTY.Maximum = 1000;
                cbIn2QTY.Minimum = 0;
                cbIn2QTY.Value = 0;
                cbInHQTY.Maximum = 1000;
                cbInHQTY.Minimum = 0;
                cbInHQTY.Value = 0;
                cbInSQTY.Maximum = 1000;
                cbInSQTY.Minimum = 0;
                cbInSQTY.Value = 0;
                cbInEQTY.Maximum = 1000;
                cbInEQTY.Minimum = 0;
                cbInEQTY.Value = 0;
            }
            else if (m == Mode.OUT)
            {
                pAction.Visible = flag;
                cbIn1QTY.Maximum = tb1Qty.Text == "" ? 0 : int.Parse(tb1Qty.Text);
                cbIn1QTY.Value = 0;
                cbIn2QTY.Maximum = tb2Qty.Text == "" ? 0 : int.Parse(tb2Qty.Text);
                cbIn2QTY.Value = 0;
                cbInHQTY.Maximum = tbHQty.Text == "" ? 0 : int.Parse(tbHQty.Text);
                cbInHQTY.Value = 0;
                cbInSQTY.Maximum = tbSQty.Text == "" ? 0 : int.Parse(tbSQty.Text);
                cbInSQTY.Value = 0;
                cbInEQTY.Maximum = tbEQty.Text == "" ? 0 : int.Parse(tbEQty.Text);
                cbInEQTY.Value = 0;
            }

            btn_EDIT_OK.Visible = flag;
            btn_EDIT_CANCEL.Visible = flag;

        }

        //private void ShowEditArea(bool flag)
        //{
        //    LoadSTKDEF();
        //    cb1Loc.Visible = flag;
        //    cb2Loc.Visible = flag;
        //    cbHLoc.Visible = flag;
        //    cbSLoc.Visible = flag;
        //    cbHQty.Visible = flag;
        //    cbSQty.Visible = flag;
        //    cbELoc.Visible = flag;
        //    cbEQty.Visible = flag;
            
        //    cb1Qty.Visible = flag;
        //    cb2Qty.Visible = flag;

        //    lbY1.Visible = flag;
        //    lbY2.Visible = flag;
        //    label12.Visible = flag;
            
        //    label14.Visible = flag;
        //    label15.Visible = flag;
        //    label17.Visible = flag;

        //    mRMK.Visible = flag;            

        //    //cbART_Type.Visible = flag;

        
        //}

        private void btn_EDIT_CANCEL_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("確定要取消嗎?", "編輯庫存紀錄", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ShowEditArea(_mode,false);
                btnColor(sender, false);
            }
        }

        private bool CheckAndSave(System.Windows.Forms.TextBox tbLoc , Mode m)
        { 
            bool fSave = false;

            if (m == Mode.MODIFY)
            {
                string tbName = tbLoc.Name;
                string SaveName = tbName.Substring(2, 1);

                //Original
                System.Windows.Forms.NumericUpDown oriQty = (System.Windows.Forms.NumericUpDown)pEdit.Controls["cb" + SaveName + "Qty"];
                
                //New
                System.Windows.Forms.ComboBox cbLoc = (System.Windows.Forms.ComboBox)pEdit.Controls["cb" + SaveName + "Loc"];
                System.Windows.Forms.NumericUpDown newQty = (System.Windows.Forms.NumericUpDown)pEdit.Controls["cb" + SaveName + "Qty"];

                if ((tbLoc.Text == cbLoc.Text && newQty.Text == oriQty.Text) || (oriQty.Text == "" && newQty.Value == 0))
                {
                    //do nothing
                    return true;
                }
                else
                {
                    //Save
                    if (SaveRecord(tbART_NO.Text, cbLoc.Text, newQty.Text, mRMK.Text, "庫存調整-" + SaveName,""))
                        return true;
                }
            }
            else if (m == Mode.IN)
            {
                string tbName = tbLoc.Name;
                string SaveName = tbName.Substring(2, 1);

                //Original
                System.Windows.Forms.NumericUpDown newQty = (System.Windows.Forms.NumericUpDown)pAction.Controls["cbIn" + SaveName + "Qty"];
                System.Windows.Forms.TextBox oriQty = (System.Windows.Forms.TextBox)mPan.Controls["tb" + SaveName + "Qty"];

                //New
                System.Windows.Forms.TextBox Loc = (System.Windows.Forms.TextBox)mPan.Controls["tb" + SaveName + "Loc"];

                if (newQty.Value == 0 || oriQty.Text == newQty.ToString())
                {
                    //do nothing
                    return true;
                }
                else
                {
                    //Add in stock amount
                    oriQty.Text = (int.Parse(String.IsNullOrEmpty(oriQty.Text) ? "0" : oriQty.Text) + newQty.Value).ToString();
                    //Save
                    if (SaveRecord(tbART_NO.Text, Loc.Text, oriQty.Text, mRMK.Text, "存樣-" + SaveName, newQty.Value.ToString()))
                        return true;
                }
            }
            else if (m == Mode.OUT)
            {
                string tbName = tbLoc.Name;
                string SaveName = tbName.Substring(2, 1);

                //Original
                System.Windows.Forms.TextBox Loc = (System.Windows.Forms.TextBox)this.Controls[0].Controls["mPan"].Controls["tb" + SaveName + "Loc"];
                System.Windows.Forms.TextBox oriQty = (System.Windows.Forms.TextBox)this.Controls[0].Controls["mPan"].Controls["tb" + SaveName + "Qty"];
                
                //New
                
                System.Windows.Forms.NumericUpDown newQty = (System.Windows.Forms.NumericUpDown)this.Controls[0].Controls["mPan"].Controls["pAction"].Controls["cbIn" + SaveName + "Qty"];
                if (newQty.Value == 0 )
                {
                    //do nothing
                    return true;
                }
                else
                {
                    //Add in stock amount
                    oriQty.Text = (int.Parse(String.IsNullOrEmpty(oriQty.Text) ? "0" : oriQty.Text) - newQty.Value).ToString();
                    //Save
                    if (SaveRecord(tbART_NO.Text, Loc.Text, oriQty.Text, mRMK.Text, "取樣-" + SaveName, newQty.Value.ToString()))
                        return true;
                }
            }


            return fSave;
        }

        private bool SaveRecord(string ART_NO, string Loc, string Qty, string Remark, string UPDATE_REASON, string Qty_modify)
        {
            bool bRet = false;

            // (':ART_NO',':STK_NAME',':QTY',':UPDATE_REASON',':UPDATE_USER',':RMK' )";
            string ins_ART_HIS = SQL_TEXT.I_STK_HIS;
            ins_ART_HIS = ins_ART_HIS.Replace(":ART_NO", ART_NO);
            ins_ART_HIS = ins_ART_HIS.Replace(":STK_NAME", Loc);
            ins_ART_HIS = ins_ART_HIS.Replace(":QTY_MODIFY", Qty_modify);
            ins_ART_HIS = ins_ART_HIS.Replace(":QTY", Qty);
            ins_ART_HIS = ins_ART_HIS.Replace(":UPDATE_REASON", UPDATE_REASON);
            ins_ART_HIS = ins_ART_HIS.Replace(":RMK", Remark);
            ins_ART_HIS = ins_ART_HIS.Replace(":UPDATE_USER", GlobalVar.LoginUser.USER_ID);
            

            try
            {
                dbTool.ExecData(ins_ART_HIS);
                bRet = true;
            }
            catch (Exception ex)
            {

            }

            return bRet;

        }

        //儲存紀錄
        private void btn_EDIT_OK_Click(object sender, EventArgs e)
        {            
            
            DialogResult dialogResult = MessageBox.Show("確定要儲存嗎", "編輯庫存紀錄", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //CheckAndSave();
                if (!(CheckAndSave(tb1Loc, _mode))) { MessageBox.Show("倉庫位置編輯錯誤!"); }
                if (!(CheckAndSave(tb2Loc, _mode))) { MessageBox.Show("布架位置編輯錯誤!"); }
                if (!(CheckAndSave(tbHLoc, _mode))) { MessageBox.Show("吊卡位置編輯錯誤!"); }
                if (!(CheckAndSave(tbSLoc, _mode))) { MessageBox.Show("布卡位置編輯錯誤!"); }
                if (!(CheckAndSave(tbELoc, _mode))) { MessageBox.Show("展覽位置編輯錯誤!"); }
                
                ShowEditArea(_mode,false);
                btnColor(sender, false);
                LoadStockHistory();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }


        private void cbART_Type_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            CheckedComboBoxEdit edit = sender as CheckedComboBoxEdit;
                        //if (e.CloseMode == PopupCloseMode.ButtonClick)
                        //    MessageBox.Show(edit.EditValue.ToString());
                        //memoEdit1.Text = cbART_Type.EditValue.ToString();
          
        }

        private void btnColor(object sender, bool bPress)
        {
            Button btn = (Button)sender;
            btnUpdateMode.BackColor = SystemColors.Control;
            btnGet.BackColor = SystemColors.Control;
            btnSave.BackColor = SystemColors.Control;

            if (bPress)
            {
                btn.BackColor = Color.Orange;
            }

        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _mode = Mode.OUT;
            btnColor((Button)sender,true);
            ShowEditArea(_mode, true);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            _mode = Mode.IN;
            btnColor((Button)sender, true);
            ShowEditArea(_mode, true);
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            pEdit.Location = pAction.Location;
        }


 



     

       

     

   

      

    }
}
