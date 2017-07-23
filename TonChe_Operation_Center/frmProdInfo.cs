using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Database;
using TonChe_Operation_Cneter.Utility;

namespace TonChe_Operation_Cneter
{
    public partial class frmProdInfo : Form
    {
        BindingSource bs;
        public DB_Access db_Tool = new DB_Access();
        private bool bUpdate_mode = false;
        //public static string TonChePicturePath = Properties.Settings.Default["Picture"].ToString();
        public frmProdInfo()
        {
            InitializeComponent();
            this.KeyPreview = true;
            InitPage();

        }

        private  void InitPage()
        {
            tb_SEARCH_ART.GotFocus += tb_SEARCH_ART_GotFocus;
            tb_SEARCH_ART.LostFocus += tb_SEARCH_ART_LostFocus;
            this.ActiveControl = tb_SEARCH_ART;
        

            tb_SEARCH_ART.KeyDown += (sender, args) =>
            {
            
                    if (args.KeyCode == Keys.Return)
                    {
                        btn_SEARCH.PerformClick();
                    }
                    if (args.KeyCode == Keys.Down)
                    {
                        button4.PerformClick();
                    }
                    if (args.KeyCode == Keys.Up)
                    {
                        button3.PerformClick();
                    }
            
            };

           this.KeyDown += new KeyEventHandler(Form_KeyDown);

            loadData();
            //RefreshGV();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.F1)       // Ctrl-S Save
            if (e.KeyCode == Keys.F1) 
            {
                // Do what you want here
                //e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                if (bUpdate_mode != true)
                {
                    btn_F1.PerformClick();
                }
                else
                {
                    MessageBox.Show("請先結束更新模式!");
                }

            }
        }

        public void loadData()
        {
            DataTable tt = db_Tool.QueryData(@"select a.*,b.type from ART_BASIC a left OUTER JOIN  A2017_NY_LIST b 
            on a.art_no = b.art_no
            order by art_no");

            string priART_NO = tb_ART_NAME.Text;

            bs = new BindingSource();
            bs.DataSource = tt;
            tb_ART_NAME.DataBindings.Clear();
            tb_ART_NAME.DataBindings.Add("Text", bs, "ART_NO");

            tb_CONST.DataBindings.Clear();
            tb_CONST.DataBindings.Add("Text", bs, "CONSTRUCTION");

            tb_COMPO.DataBindings.Clear();
            tb_COMPO.DataBindings.Add("Text", bs, "COMPOSITION");

            tb_WEIGHT.DataBindings.Clear();
            tb_WEIGHT.DataBindings.Add("Text", bs, "WEIGHT");

            tb_REMARK.DataBindings.Clear();
            tb_REMARK.DataBindings.Add("Text", bs, "REMARK");

            tb_REMARK2.DataBindings.Clear();
            tb_REMARK2.DataBindings.Add("Text", bs, "REMARK2");

            tb_COLOR.DataBindings.Clear();
            tb_COLOR.DataBindings.Add("Text", bs, "COLOR");

            tb_PRICE.DataBindings.Clear();
            tb_PRICE.DataBindings.Add("Text", bs, "PRICE");

            tbCost.DataBindings.Clear();
            tbCost.DataBindings.Add("Text", bs, "COST");

            tbWD.DataBindings.Clear();
            tbWD.DataBindings.Add("Text", bs, "WEFT_DENSE");

            tbWM.DataBindings.Clear();
            tbWM.DataBindings.Add("Text", bs, "WARP_M");

            tbAft.DataBindings.Clear();
            tbAft.DataBindings.Add("Text", bs, "AFT");

            tbSh.DataBindings.Clear();
            tbSh.DataBindings.Add("Text", bs, "SH_RATE");

            tb2017.DataBindings.Clear();
            tb2017.DataBindings.Add("Text", bs, "Type");


            tbART_TYPE.DataBindings.Clear();
            tbART_TYPE.DataBindings.Add("Text", bs, "ART_TYPE");


            gvART_DATA.DataSource = bs;



            //gvART_DATA.AutoResizeColumns();
            gvART_DATA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (priART_NO != "")
            {
                gvART_DATA.Rows[bs.Find("ART_NO", priART_NO)].Selected = true;
                bs.Position = bs.Find("ART_NO", priART_NO);
                //tb_ART_NAME.Text = priART_NO;
            }

        }


        public void InitEditMode()
        {
            bUpdate_mode = false;
            btnUpdateMode.BackColor = SystemColors.ButtonFace;
         
            tb_CONST.ReadOnly = true;
            tb_CONST.BackColor = SystemColors.Control;

            tb_COMPO.ReadOnly = true;
            tb_COMPO.BackColor = SystemColors.Control;

            tb_WEIGHT.ReadOnly = true;
            tb_WEIGHT.BackColor = SystemColors.Control;

            tb_REMARK.ReadOnly = true;
            tb_REMARK.BackColor = SystemColors.Control;

            tb_REMARK2.ReadOnly = true;
            tb_REMARK2.BackColor = SystemColors.Control;

            tb_COLOR.ReadOnly = true;
            tb_COLOR.BackColor = SystemColors.Control;

            tb_PRICE.ReadOnly = true;
            tb_PRICE.BackColor = SystemColors.Control;

            tbCost.ReadOnly = true;
            tbCost.BackColor = SystemColors.Control;

            tbWD.ReadOnly = true;
            tbWD.BackColor = SystemColors.Control;

            tbWM.ReadOnly = true;
            tbWM.BackColor = SystemColors.Control;

            tbSh.ReadOnly = true;
            tbSh.BackColor = SystemColors.Control;

            tbAft.ReadOnly = true;
            tbAft.BackColor = SystemColors.Control;

            cbArtType.Visible = false;
            cbArtType.Properties.Items.Clear();

            btn_EDIT_OK.Visible = false;
            btn_EDIT_CANCEL.Visible = false;

            gvART_DATA.Enabled = true;
            gvART_DATA.ForeColor = Color.Black;

        }
        private void btn_EDIT_CANCEL_Click(object sender, EventArgs e)
        {
            InitEditMode();
            MessageBox.Show("取消更新.");
        }

        private void btn_SEARCH_Click(object sender, EventArgs e)
        {
            DataTable dtART = bs.DataSource as DataTable;
            if (tb_SEARCH_ART.Text != "")
            {
                try
                {
                    //DataRow dr = dtART.Select("ART_NO='" + tb_SEARCH_ART.Text + "'")[0];
                    DataRow dr = dtART.Select("ART_NO like  '%" + tb_SEARCH_ART.Text + "%'")[0];

                    bs.Position = dtART.Rows.IndexOf(dr);
                    gvART_DATA.CurrentCell = gvART_DATA.Rows[dtART.Rows.IndexOf(dr)].Cells[0];
                    LoadImageSample();
                    ShowRecordStuts();
                    if (dr == null)
                    {
                        MessageBox.Show("找不到資料!");
                        tb_SEARCH_ART.Text = "";
                    }

                    //gvART_DATA.Refresh();
                }
                catch (Exception)
                {
                    MessageBox.Show("找不到資料!");
                    tb_SEARCH_ART.Text = "";
                    //throw;
                }
            }
            else
            {
                MessageBox.Show("請輸入布號!");
            }
        }

        private void ShowRecordStuts()
        {
            Sorce_info.Text = String.Format("目前選擇第{0}筆，共{1}筆資料", bs.Position + 1, bs.Count);
        }

        public void LoadImageSample()
        {
            Image image;
            try
            {

                if (GlobalVar.sMode == GlobalVar.SysMode.Web)
                {
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(@GlobalVar.WebTonChePicturePath + "布品縮圖/" + tb_ART_NAME.Text + ".jpg");
                    MemoryStream ms = new MemoryStream(bytes);
                    image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    image = Image.FromFile(GlobalVar.LocalTonChePicturePath + "布品縮圖\\" + tb_ART_NAME.Text + ".jpg"); //From Local file
                }


            }
            catch (Exception)
            {
                image = TonChe_Operation_Cneter.Properties.Resources.NA;
            }
            pSample.Image = image;
            pSample.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnUpdateMode_Click(object sender, EventArgs e)
        {
            bUpdate_mode = true;
            btnUpdateMode.BackColor = Color.Yellow;            
            gvART_DATA.ForeColor = Color.Gray;
            gvART_DATA.Enabled = false;
            tb_CONST.ReadOnly = false;
            tb_CONST.BackColor = Color.Yellow;
            
            tb_COMPO.ReadOnly = false;
            tb_COMPO.BackColor = Color.Yellow;
            
            tb_REMARK.ReadOnly = false;
            tb_REMARK.BackColor = Color.Yellow;
            
            tb_REMARK2.ReadOnly = false;
            tb_REMARK2.BackColor = Color.Yellow;
            
            tb_COLOR.ReadOnly = false;
            tb_COLOR.BackColor = Color.Yellow;
            
            tb_PRICE.ReadOnly = false;
            tb_PRICE.BackColor = Color.Yellow;
            
            tb_WEIGHT.ReadOnly = false;
            tb_WEIGHT.BackColor = Color.Yellow;
            
            tbCost.ReadOnly = false;
            tbCost.BackColor = Color.Yellow;
            
            tbWD.ReadOnly = false;
            tbWD.BackColor = Color.Yellow;
            
            tbWM.ReadOnly = false;
            tbWM.BackColor = Color.Yellow;
            
            tbSh.ReadOnly = false;
            tbSh.BackColor = Color.Yellow;
            
            tbAft.ReadOnly = false;
            tbAft.BackColor = Color.Yellow;

            LoadART_Type();
            cbArtType.Visible = true;
            btn_EDIT_OK.Visible = true;
            btn_EDIT_CANCEL.Visible = true;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Form ff in Application.OpenForms)
            {
                //檢測目前所有視窗
                if (ff.Text == "新增資料")
                {
                    //若視窗的標題="新增資料"
                    ff.Activate();//拉到最前作用中的視窗
                    return;//整個結束button1_Click，form2就不會被new出來
                }
            }

            frmNewART f2 = new frmNewART(this);
            //Form2中的方法，用來取得BindingSource
            f2.Show();
            //f2.ShowDialog();//像Dialog般秀出來(沒操作此視窗, 不能執行其他視窗)
        }

        public void RefreshGV()
        {                               
            //DataTable tt = db_Tool.QueryData("select * from ART_BASIC ORDER BY ART_NO");
            //gvART_DATA.DataSource = tt;
            loadData();

        }

        private void btn_DELETE_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("是否要刪除布號:" + tb_ART_NAME.Text, "刪除布號",
           MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
              == DialogResult.Yes)
            {
               
                string sql = @"DELETE FROM ART_BASIC  WHERE ART_NO='"+tb_ART_NAME.Text+"'";
                
                if(db_Tool.ExecData(sql))
                {             
                    RefreshGV();
                    MessageBox.Show("刪除成功!");
                }
                else
                {
                    MessageBox.Show("刪除失敗!");
                    //throw;
                }
            }
            else
            {

            }
        }

        private void btn_EDIT_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbART_TYPE.Text))
            {
                MessageBox.Show("未選擇分類!!");
            }
            else
            {
                SqlConnection cnn;
                if (GlobalVar.sMode == GlobalVar.SysMode.Web)
                {
                    cnn = new SqlConnection(DB_Access.Constr);
                }
                else
                {
                    cnn = new SqlConnection(DB_Access.ConstrLocal);
                }                 
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                string sql = @"UPDATE ART_BASIC  SET CONSTRUCTION=@CONSTRUCTION, COMPOSITION=@COMPOSITION,WEIGHT = @WEIGHT,REMARK = @REMARK,REMARK2 = @REMARK2,COLOR=@COLOR ,PRICE=@PRICE 
                                    ,COST=@COST  ,WEFT_DENSE=@WD ,WARP_M=@WM ,SH_RATE=@SH ,AFT=@AFT,ART_TYPE=@ART_TYPE   WHERE ART_NO=@ART_NAME;";

                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.Add("@ART_NAME", SqlDbType.VarChar).Value = tb_ART_NAME.Text;
                cmd.Parameters.Add("@CONSTRUCTION", SqlDbType.VarChar).Value = tb_CONST.Text;
                cmd.Parameters.Add("@COMPOSITION", SqlDbType.VarChar).Value = tb_COMPO.Text;
                cmd.Parameters.Add("@WEIGHT", SqlDbType.VarChar).Value = tb_WEIGHT.Text;
                cmd.Parameters.Add("@REMARK", SqlDbType.VarChar).Value = tb_REMARK.Text;
                cmd.Parameters.Add("@REMARK2", SqlDbType.VarChar).Value = tb_REMARK2.Text;
                cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = tb_COLOR.Text;
                cmd.Parameters.Add("@ART_TYPE", SqlDbType.VarChar).Value = tbART_TYPE.Text;

                if (!String.IsNullOrEmpty(tb_PRICE.Text))
                {
                    cmd.Parameters.Add("@PRICE", SqlDbType.VarChar).Value = double.Parse(tb_PRICE.Text);
                }
                else
                {
                    cmd.Parameters.Add("@PRICE", SqlDbType.VarChar).Value = 0;
                }

                if (!String.IsNullOrEmpty(tbCost.Text))
                {
                    cmd.Parameters.Add("@COST", SqlDbType.VarChar).Value = double.Parse(tbCost.Text);
                }
                else
                {
                    cmd.Parameters.Add("@COST", SqlDbType.VarChar).Value = 0;
                }
                if (!String.IsNullOrEmpty(tbWD.Text))
                {
                    cmd.Parameters.Add("@WD", SqlDbType.VarChar).Value = double.Parse(tbWD.Text);
                }
                else
                {
                    cmd.Parameters.Add("@WD", SqlDbType.VarChar).Value = 0;
                }
                if (!String.IsNullOrEmpty(tbWM.Text))
                {
                    cmd.Parameters.Add("@WM", SqlDbType.VarChar).Value = double.Parse(tbWM.Text);
                }
                else
                {
                    cmd.Parameters.Add("@WM", SqlDbType.VarChar).Value = 0;
                }
                if (!String.IsNullOrEmpty(tbSh.Text))
                {
                    cmd.Parameters.Add("@SH", SqlDbType.VarChar).Value = double.Parse(tbSh.Text);
                }
                else
                {
                    cmd.Parameters.Add("@SH", SqlDbType.VarChar).Value = 0;
                }
                if (!String.IsNullOrEmpty(tbAft.Text))
                {
                    cmd.Parameters.Add("@AFT", SqlDbType.VarChar).Value = double.Parse(tbAft.Text);
                }
                else
                {
                    cmd.Parameters.Add("@AFT", SqlDbType.VarChar).Value = 0;
                }


                try
                {
                    //dataAdapter.Update((DataTable)bs.DataSource);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cnn.Close();
                    RefreshGV();
                    MessageBox.Show("更新成功!");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新失敗! 錯誤訊息:" + ex.Message);
                    //throw;
                }
                InitEditMode();
            }
          
            
//            string sql = @"UPDATE ART_BASIC  SET CONSTRUCTION='@CONSTRUCTION', COMPOSITION='@COMPOSITION',WEIGHT ='@WEIGHT',
//                                REMARK = '@REMARK',REMARK2 =' @REMARK2',COLOR='@COLOR' ,PRICE='@PRICE' 
//                                    ,COST='@COST'  ,WEFT_DENSE='@WD' ,WARP_M='@WM' ,SH_RATE='@SH' ,AFT='@AFT'   WHERE ART_NO='@ART_NAME'";

//            sql.Replace("@ART_NAME",         tb_ART_NAME.Text);
//            sql.Replace("@CONSTRUCTION", tb_CONST.Text);
//            sql.Replace("@COMPOSITION",   tb_COMPO.Text);
//            sql.Replace("@WEIGHT",            tb_WEIGHT.Text);
//            sql.Replace("@REMARK",            tb_REMARK.Text);
//            sql.Replace("@REMARK2",          tb_REMARK2.Text);
//            sql.Replace("@COLOR",              tb_COLOR.Text);

//            if (!String.IsNullOrEmpty(tb_PRICE.Text))
//            {
//                sql.Replace("@PRICE", tb_PRICE.Text);
//                // cmd.Parameters.Add("@PRICE", SqlDbType.VarChar).Value = double.Parse(tb_PRICE.Text);
//            }
//            else
//            {
//                sql.Replace("@PRICE", "");
//            }
//            if (!String.IsNullOrEmpty(tbCost.Text))
//            {
//                sql.Replace("@COST", "0");
//                //cmd.Parameters.Add("@COST", SqlDbType.VarChar).Value = double.Parse(tbCost.Text);
//            }
//            else
//            {
//                sql.Replace("@COST", tbCost.Text);
//                //cmd.Parameters.Add("@COST", SqlDbType.VarChar).Value = 0;
//            }

//            if (!String.IsNullOrEmpty(tbWD.Text))
//            {
//                sql.Replace("@WD", tbWD.Text);
//                //cmd.Parameters.Add("@WD", SqlDbType.VarChar).Value = double.Parse(tbWD.Text);
//            }
//            else
//            {
//                sql.Replace("@WD", "0");
//                //cmd.Parameters.Add("@WD", SqlDbType.VarChar).Value = 0;
//            }

//            if (!String.IsNullOrEmpty(tbWM.Text))
//            {
//                sql.Replace("@WM", tbWM.Text);
//                //cmd.Parameters.Add("@WM", SqlDbType.VarChar).Value = double.Parse(tbWM.Text);
//            }
//            else
//            {
//                sql.Replace("@WM", "0");
//                //cmd.Parameters.Add("@WM", SqlDbType.VarChar).Value = 0;
//            }

//            if (!String.IsNullOrEmpty(tbSh.Text))
//            {
//                sql.Replace("@SH", tbSh.Text);
//                //cmd.Parameters.Add("@SH", SqlDbType.VarChar).Value = double.Parse(tbSh.Text);
//            }
//            else
//            {
//                sql.Replace("@SH", "0");
//                //cmd.Parameters.Add("@SH", SqlDbType.VarChar).Value = 0;
//            }
//            if (!String.IsNullOrEmpty(tbAft.Text))
//            {
//                sql.Replace("@AFT", tbAft.Text);
//                // cmd.Parameters.Add("@AFT", SqlDbType.VarChar).Value = double.Parse(tbAft.Text);
//            }
//            else
//            {
//                sql.Replace("@AFT", "0");
//                //cmd.Parameters.Add("@AFT", SqlDbType.VarChar).Value = 0;
//            }


//            try
//            {
//                if (db_Tool.ExecData(sql))
//                {
//                    RefreshGV();
//                    MessageBox.Show("更新成功!");
//                    InitEditMode();
//                }
//                else
//                {
//                    MessageBox.Show("更新失敗!");
//                }

//            }
//            catch (Exception ex)
//            {
//                InitEditMode();
//                MessageBox.Show("更新失敗! 錯誤訊息:" + ex.Message);
//                //throw;
//            }

//            // bs.
        }

        private void tb_SEARCH_ART_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btn_SEARCH.PerformClick();
            }
        }

        private void btn_REFRESH_ALL_Click(object sender, EventArgs e)
        {
            RefreshGV();
        }

        private void gvART_DATA_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (bUpdate_mode == false)
            {
                if (e.RowIndex!=null)
                {
                    SetCurrentART_NO(e.RowIndex);
                }
            }
            else
            {                 
                 MessageBox.Show("更新資料中" + tb_ART_NAME.Text + "，請先儲存或離開目前設定!");               
            }
        }

        private void SetCurrentART_NO(int CurrentRowIndex)
        {
            bs.Position = CurrentRowIndex;
            ShowRecordStuts();
            LoadImageSample();
        }

        private void gvART_DATA_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                SetCurrentART_NO(e.RowIndex);                
            }
        }

        private void pSample_Click(object sender, EventArgs e)
        {
            Sample fmSample = new Sample(tb_ART_NAME.Text);
            Image image;
            try
            {

                if( GlobalVar.sMode == GlobalVar.SysMode.Web)
                {
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(GlobalVar.WebTonChePicturePath + "布品/" + tb_ART_NAME.Text + ".jpg");
                    MemoryStream ms = new MemoryStream(bytes);
                    image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    image = Image.FromFile(GlobalVar.LocalTonChePicturePath + "布品\\" + tb_ART_NAME.Text + ".jpg");
                }
            }
            catch (Exception)
            {
                image = TonChe_Operation_Cneter.Properties.Resources.NA;
            }
            //pSample.Image = image;
            //pSample.SizeMode = PictureBoxSizeMode.StretchImage;
            fmSample.pcSampleDetail.Image = image;
            fmSample.pcSampleDetail.SizeMode = PictureBoxSizeMode.StretchImage;
            fmSample.Show();
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            //((((cosT+wm+(0.5 * wd ))/SH+aft)*2)+8)/32
            if (!string.IsNullOrEmpty(tbCost.Text))
            {
                //int Cost = tbCost.Text;
                Double Cost = Int32.Parse(tbCost.Text);
                Double WD = Int32.Parse(tbWD.Text);
                Double WM = Int32.Parse(tbWM.Text);
                Double SH = Int32.Parse(tbSh.Text);
                Double AFT = Int32.Parse(tbAft.Text);
                Double TT;
                if (WD >= 50)
                {

                    TT = Math.Round(((((Cost + WM + (0.3 * WD)) / ((100 - SH) / 100) + AFT) * 2) + 8) / 32, 3);
                }
                else
                {
                    TT = Math.Round(((((Cost + WM + (0.5 * WD)) / ((100 - SH) / 100) + AFT) * 2) + 8) / 32, 3);
                }
                tb_PRICE.Text = TT.ToString();
            }
            else
            {
                tb_PRICE.DataBindings.Clear();
                tb_PRICE.DataBindings.Add("Text", bs, "PRICE");
            }
        }

        private void tb_SEARCH_ART_GotFocus(object sender, EventArgs e)
        {
            tb_SEARCH_ART.BackColor = Color.Yellow;
        }

        private void tb_SEARCH_ART_LostFocus(object sender, EventArgs e)
        {
            tb_SEARCH_ART.BackColor = SystemColors.Control;
        }

        private void gvART_DATA_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            
                ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("庫存登記與查詢"));
                //m.MenuItems.Add(new MenuItem("設計表"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = gvART_DATA.HitTest(e.X, e.Y).RowIndex;

                //var hti = gvART_DATA.HitTest(e.X, e.Y);
                //gvART_DATA.ClearSelection();
                gvART_DATA.Rows[currentMouseOverRow].Selected = true;

                if (currentMouseOverRow >= 0)
                {

                    SetCurrentART_NO(currentMouseOverRow);
                    MenuItem iStock = new MenuItem(string.Format("庫存登記與查詢", currentMouseOverRow.ToString()));
                    m.MenuItems.Add(iStock);
                    iStock.Click += new EventHandler(iStock_Click);

                    m.MenuItems.Add(new MenuItem(string.Format("查詢設計表", currentMouseOverRow.ToString())));


                }

                m.Show(gvART_DATA, new Point(e.X, e.Y));

            }
        }

        private void iStock_Click(object sender, EventArgs e)
        {
            frmStock frm1 = new frmStock(tb_ART_NAME.Text);
            frm1.Show();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
           
            List<string >No_Image_Art = new List<string>();
            DataTable dtART = bs.DataSource as DataTable;
            Image image;
            foreach (DataRow dr in dtART.Rows)
            {

                try
                {

                    if (GlobalVar.sMode == GlobalVar.SysMode.Web)
                    {
                        WebClient wc = new WebClient();
                        byte[] bytes = wc.DownloadData(GlobalVar.WebTonChePicturePath + "布品/" + dr["ART_NO"].ToString().Trim() + ".jpg");
                        MemoryStream ms = new MemoryStream(bytes);
                        image = System.Drawing.Image.FromStream(ms);
                    }
                    else
                    {
                        //image = Image.FromFile(GlobalVar.LocalTonChePicturePath + "布品\\" + ART_NO + ".jpg");
                        FileStream fs = File.OpenRead(GlobalVar.LocalTonChePicturePath + "布品\\" + dr["ART_NO"].ToString().Trim() + ".jpg");
                        image = Image.FromStream(fs);
                        //Bitmap bmp1 = (Bitmap)Image.FromStream(fs);
                        fs.Close();
                    }
                }
                catch (Exception)
                {
                    No_Image_Art.Add(dr["ART_NO"].ToString());
                   
                    image = TonChe_Operation_Cneter.Properties.Resources.NA;
                }

                //try
                //{
                //    image = Image.FromFile(TonChePicturePath+"布品\\" + dr["ART_NO"].ToString() + ".jpg");
                //}
                //catch (Exception)
                //{
                //    No_Image_Art.Add(dr["ART_NO"].ToString());
                //    //image = TonChe_System.Properties.Resources.NA;
                //}
            }

            string Output = string.Empty;

            foreach (string a in No_Image_Art)
            {
                Output = Output + "'" + a + "'" + "," + Environment.NewLine;
            }

            MessageBox.Show(Output);


        
        }

        private void cbArtType_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            CheckedComboBoxEdit edit = sender as CheckedComboBoxEdit;
            //if (e.CloseMode == PopupCloseMode.ButtonClick)
            //    MessageBox.Show(edit.EditValue.ToString());
            tbART_TYPE.Text = cbArtType.EditValue.ToString();
        }

        private void RecordMoveEvent(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "  第一筆": bs.MoveFirst(); break;
                case "  上一筆": bs.MovePrevious(); break;
                case "  下一筆": bs.MoveNext(); break;
                case "   最後一筆": bs.MoveLast(); break;
            }
            ShowRecordStuts();
        }

        private void btnProdSearch_Click(object sender, EventArgs e)
        {
            foreach (Form ff in Application.OpenForms)
            {
                //檢測目前所有視窗
                if (ff.Text == "布號搜尋")
                {
                    //若視窗的標題="新增資料"
                    ff.Activate();//拉到最前作用中的視窗
                    return;//整個結束button1_Click，form2就不會被new出來
                }
            }
            frmProdSearch f2 = new frmProdSearch();
            //Form2中的方法，用來取得BindingSource
            f2.Show();
            //f2.ShowDialog();//像Dialog般秀出來(沒操作此視窗, 不能執行其他視窗)
        }

        private void btn_F1_Click(object sender, EventArgs e)
        {
            tb_SEARCH_ART.Text = "";
            this.ActiveControl = tb_SEARCH_ART;
        }

        private void btnOpenDesign_Click(object sender, EventArgs e)
        {
            //string DesginFormPath = Properties.Settings.Default["DesignForm"].ToString();
            string ART_NO = tb_ART_NAME.Text;

            if (!string.IsNullOrEmpty(ART_NO))
            {
                if (ART_NO.Contains("ART"))
                {
                    frmDesignFormList fmTemp = new frmDesignFormList(ART_NO);
                    fmTemp.Show();
                }
                else
                {
                    MessageBox.Show("暫時不支援非ART編號設計表!");
                }
            }
            else
            {
                MessageBox.Show("請先輸入要查詢設計表的布號!");
            }


        }



    }
}
