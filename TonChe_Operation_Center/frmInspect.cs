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


namespace TonChe_Operation_Cneter
{
    public partial class frmInspect : Form
    {
        List<Reason_Item> dReason = new List<Reason_Item>();
        List<Ins_Record> lIR = new List<Ins_Record>();
        public DB_Access dbTool = new DB_Access();
        public enum Page_Mode { ADD, EDIT };
        public Page_Mode gpMode = Page_Mode.ADD;
        public frmInspect()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gpMode = Page_Mode.ADD;
            
            //Load EQP
            LoadEQP();

            //LoadINS
            LoadINS_DATA();

            //Load Reason
            string ssql = SQL_TEXT.Q_REASON_CODE;
            DataTable dtReasonCode = dbTool.QueryData(ssql);
            dReason.Clear();
            foreach (DataRow dr in dtReasonCode.Rows)
            {
                Reason_Item ri = new Reason_Item();
                ri.Reason_code = dr[0].ToString();
                ri.Reason = dr[1].ToString();
                ri.Point = dr[2].ToString();
                dReason.Add(ri);
            }

            for (int i = 1; i <= 4; i++)
            {
                Label lbY = (Label)this.Controls.Find("lbY" + i, true)[0];
                Label lbPts = (Label)this.Controls.Find("lbPts" + i, true)[0];
                Label lbG = (Label)this.Controls.Find("lbG" + i, true)[0];
                lbY.Text = "";
                lbPts.Text = "";
                lbG.Text = "";
            }

            #region Init Shift combobix
            //Init Shift combobix
            foreach (Control s in this.tableLayoutPanel2.Controls)
            {
                if (s is Panel)
                {
                    foreach (Control s1 in s.Controls)
                    {
                        if (s1.Name.Contains("cbS"))
                        {
                            ComboBox cb = (ComboBox)s1;
                            cb.Items.Clear();
                            cb.Items.Add("A");
                            cb.Items.Add("B");
                            cb.Items.Add("C");
                            cb.SelectedIndex = 0;
                            cb.DropDownStyle = ComboBoxStyle.DropDownList;
                        }

                        if (s1.Name.Contains("cbR"))
                        {
                            ComboBox cb = (ComboBox)s1;
                            cb.Items.Clear();
                            foreach (Reason_Item r in dReason)
                            {
                                ComboxItem cItem = new ComboxItem();
                                cItem.Text = r.Reason_code + "-" + r.Reason;
                                cItem.Value = r.Reason_code;
                                cb.Items.Add(cItem);
                            }
                            //cb.SelectedIndex = 0;
                            cb.DropDownStyle = ComboBoxStyle.DropDownList;
                        }
                    }
                }
            }
            cbS0.Items.Clear();
            cbS0.Items.Add("A");
            cbS0.Items.Add("B");
            cbS0.Items.Add("C");
            cbS0.SelectedIndex = 0;
            cbS0.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            //Init Table Layout
            this.tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            #region Event Handler
            //Event
            btnAddO1.Click += btnAddO1_Click;
            btnAddO2.Click += btnAddO1_Click;
            btnAddO3.Click += btnAddO1_Click;
            btnAddO4.Click += btnAddO1_Click;

            btnDelO1.Click += btnDelO1_Click;
            btnDelO2.Click += btnDelO1_Click;
            btnDelO3.Click += btnDelO1_Click;
            btnDelO4.Click += btnDelO1_Click;

            btnAddR1.Click += btnAddR1_Click;
            btnAddR2.Click += btnAddR1_Click;
            btnAddR3.Click += btnAddR1_Click;
            btnAddR4.Click += btnAddR1_Click;

            btnDelR1.Click += btnDelR1_Click;
            btnDelR2.Click += btnDelR1_Click;
            btnDelR3.Click += btnDelR1_Click;
            btnDelR4.Click += btnDelR1_Click;

            dgvO1.CellClick += dgvO1_CellClick;
            dgvO2.CellClick += dgvO1_CellClick;
            dgvO3.CellClick += dgvO1_CellClick;
            dgvO4.CellClick += dgvO1_CellClick;

            dgvR1.CellClick += dgvR1_CellClick;
            dgvR2.CellClick += dgvR1_CellClick;
            dgvR3.CellClick += dgvR1_CellClick;
            dgvR4.CellClick += dgvR1_CellClick;

            cbR1.SelectedIndexChanged += cbR1_SelectedIndexChanged;
            cbR2.SelectedIndexChanged += cbR1_SelectedIndexChanged;
            cbR3.SelectedIndexChanged += cbR1_SelectedIndexChanged;
            cbR4.SelectedIndexChanged += cbR1_SelectedIndexChanged;

            tbS12.KeyDown += tbS12_KeyDown;
            tbS22.KeyDown += tbS12_KeyDown;
            tbS32.KeyDown += tbS12_KeyDown;
            tbS42.KeyDown += tbS12_KeyDown;

            tbR11.KeyDown += tbS12_KeyDown;
            tbR21.KeyDown += tbS12_KeyDown;
            tbR31.KeyDown += tbS12_KeyDown;
            tbR41.KeyDown += tbS12_KeyDown;

            tbS11.KeyPress += textBox1_KeyPress;
            tbS12.KeyPress += textBox1_KeyPress;
            tbS21.KeyPress += textBox1_KeyPress;
            tbS22.KeyPress += textBox1_KeyPress;
            tbS31.KeyPress += textBox1_KeyPress;
            tbS32.KeyPress += textBox1_KeyPress;
            tbS41.KeyPress += textBox1_KeyPress;
            tbS42.KeyPress += textBox1_KeyPress;

            tbR11.KeyPress += textBox1_KeyPress;
            tbR21.KeyPress += textBox1_KeyPress;
            tbR31.KeyPress += textBox1_KeyPress;
            tbR41.KeyPress += textBox1_KeyPress;
            #endregion


        }

        private void LoadINS_Detail(string INS_NO)
        {
            string ssql = SQL_TEXT.Q_INS_MAIN_OUTPUT;
            string ssql2 = SQL_TEXT.Q_INS_MAIN_REASON;
            ssql = ssql.Replace(":INS_NO", INS_NO);
            ssql2 = ssql2.Replace(":INS_NO", INS_NO);

            string sDT = dateTimePicker1.Value.ToString("yyyyMMdd");
           // dgvINS.Rows.Clear();
            
            DataTable dtORet = dbTool.QueryData(ssql);
            DataTable dtRRet = dbTool.QueryData(ssql2);

            lbINS_LIST.Text = sDT + " 單號:";
            lIR.Clear();
            if (dtORet.Rows.Count > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Ins_Record ir = new Ins_Record();
                    string[] INS = (dtORet.Rows[0]["INS_NO"].ToString()).Split('_');
                    ir.INS_NO = dtORet.Rows[0]["INS_NO"].ToString();
                    ir.ART_NO = INS[1];
                    ir.EQP = INS[2];
                    ir.Sponsor = dtORet.Rows[0]["Sponsor"].ToString();                    
                    ir.OUT_LENGTH = dtORet.Rows[0]["LENGTH"].ToString();
                    ir.ALL_REMARK = dtORet.Rows[0]["REMARK"].ToString();
                    ir.OUT_SHIFT = dtORet.Rows[0]["OUT_SHIFT"].ToString();
                    ir.GRP = (i + 1).ToString();
          
                    DataRow[] foundRows = dtORet.Select("GRP="+(i+1).ToString(), "sYard ASC");
                   
                    if (foundRows.Length > 0)
                    {                        
                        DataTable dtOTmp = ir.dtOUTPUT;
                        
                        ir.GRADE = foundRows[0]["GRADE"].ToString();
                        ir.LENGTH = foundRows[0]["LENGTH_OUTPUT"].ToString();
                        ir.POINT = foundRows[0]["PTS"].ToString();
                        for (int j = 0; j < foundRows.Length; j++)
                        {
                            DataRow drOTmp = dtOTmp.NewRow();

                            drOTmp[0] = foundRows[j][10].ToString();
                            drOTmp[1] = foundRows[j][12].ToString();
                            drOTmp[2] = foundRows[j][13].ToString();
                            drOTmp[3] = (Convert.ToInt32(foundRows[j][13].ToString()) - Convert.ToInt32(foundRows[j][12].ToString()) + 1).ToString();
                            dtOTmp.Rows.Add(drOTmp);
                        }
                    }

                    DataRow[] foundRRows = dtRRet.Select("GRP=" + (i + 1).ToString(), "CHK_PT ASC");
                    if (foundRRows.Length > 0)
                    {
                        DataTable dtRTmp = ir.dtREASON;
                        for (int j = 0; j < foundRRows.Length; j++)
                        {
                            DataRow drRTmp = dtRTmp.NewRow();
                            drRTmp[0] = foundRRows[j][14].ToString();
                            drRTmp[1] = foundRRows[j][10].ToString();
                            drRTmp[2] = foundRRows[j][11].ToString();
                            drRTmp[3] = foundRRows[j][7].ToString();
                            drRTmp[4] = foundRRows[j][12].ToString();
                            dtRTmp.Rows.Add(drRTmp);
                        }
                    }

                    lIR.Add(ir);
                }
                FillContent();
            }

        }


        private void FillContent()
        {
            ResetControls();
            if (lIR.Count > 0)
            {
                tbART_NO.Text = lIR[0].ART_NO;
                cbEQP.Text = lIR[0].EQP;
                cbS0.Text = lIR[0].OUT_SHIFT;
                cbSpr.Text = lIR[0].Sponsor;
                tbTotalYard.Text = lIR[0].OUT_LENGTH;
                tbAllMark.Text = lIR[0].ALL_REMARK;
                lbINS_NO.Text = lIR[0].INS_NO;

                for (int i = 0; i < lIR.Count; i++)
                {                    
                    DataGridView dgvO = (DataGridView)this.Controls.Find("dgvO" + (i+1).ToString(), true)[0];
                    dgvO.DataSource = lIR[i].dtOUTPUT;

                    DataGridView dgvR = (DataGridView)this.Controls.Find("dgvR" + (i + 1).ToString(), true)[0];
                    dgvR.DataSource = lIR[i].dtREASON;

                    dgvO.AllowUserToAddRows = false;
                    dgvO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dgvO.Columns[0].Width = 25;
                    dgvO.BorderStyle = BorderStyle.FixedSingle;
                    dgvO.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
                    dgvO.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    dgvO.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                    dgvR.AllowUserToAddRows = false;
                    dgvR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dgvR.Columns[0].Width = 25;
                    dgvR.BorderStyle = BorderStyle.FixedSingle;
                    dgvR.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
                    dgvR.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    dgvR.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                }
            }
        }

        private void LoadINS_DATA()
        {
            string ssql = SQL_TEXT.Q_INS_MAIN_DISTINCT;
            string sDT = dateTimePicker1.Value.ToString("yyyyMMdd");
            ssql = ssql.Replace(":d1", sDT);

            //dgvINS.Rows.Clear();
            DataTable dtRet = dbTool.QueryData(ssql);
            lbINS_LIST.Text = sDT + " 單號:";

            if (dtRet.Rows.Count > 0)
            {
                DataTable dtINS_LIST = new DataTable();
                DataColumn dc1 = new DataColumn("日期");
                DataColumn dc2 = new DataColumn("布號");
                DataColumn dc3 = new DataColumn("機台號");
                DataColumn dc4 = new DataColumn("總碼數");
                DataColumn dc5 = new DataColumn("序號");
                dtINS_LIST.Columns.Add(dc1);
                dtINS_LIST.Columns.Add(dc2);
                dtINS_LIST.Columns.Add(dc3);
                dtINS_LIST.Columns.Add(dc4);
                dtINS_LIST.Columns.Add(dc5);
                foreach (DataRow dr in dtRet.Rows)
                {
                    DataRow drTmp = dtINS_LIST.NewRow();
                    string[] INS = (dr[0].ToString()).Split('_');
                    drTmp[0] = INS[0];
                    drTmp[1] = INS[1];
                    drTmp[2] = INS[2];
                    drTmp[3] = dr["LENGTH"].ToString();
                    drTmp[4] = INS[3];
                    dtINS_LIST.Rows.Add(drTmp);
                }
                dgvINS.DataSource = dtINS_LIST;
                dgvINS.AllowUserToAddRows = false;
                dgvINS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvINS.Columns[0].Width = 25;
                dgvINS.BorderStyle = BorderStyle.FixedSingle;
                dgvINS.CellBorderStyle =
                    DataGridViewCellBorderStyle.RaisedHorizontal;
                dgvINS.RowHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
                dgvINS.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
               
            }

        }

        private void LoadEQP()
        {
            string ssql = SQL_TEXT.Q_EQP;
            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                cbEQP.Items.Clear();
                foreach (DataRow dr in dtRet.Rows)
                {
                    cbEQP.Items.Add(dr[0]);
                }
            }
            cbEQP.SelectedIndex = 0;
        }

        //增加每班產出
        private void btnAddO1_Click(object sender, EventArgs e)
        {
            DataTable dtProc = new DataTable();
            Button btnProc = (Button)sender;
            string NO = btnProc.Name.Substring(btnProc.Name.Length - 1, 1);
            ComboBox cbProc = (ComboBox)this.Controls.Find("cbS" + NO, true)[0];
            TextBox tbS = (TextBox)this.Controls.Find("tbS" + NO + "1", true)[0];
            TextBox tbE = (TextBox)this.Controls.Find("tbS" + NO + "2", true)[0];

            DataGridView dgvProc = (DataGridView)this.Controls.Find("dgvO" + NO, true)[0];

            if (tbS.Text.Length > 0 && tbE.Text.Length > 0)
            {
                if (dgvProc.DataSource != null)
                {
                    dtProc = (DataTable)dgvProc.DataSource;
                }
                else
                {
                    dgvProc.Columns.Clear();
                    DataTable dtTmp = new DataTable();
                    DataColumn dc1 = new DataColumn("班");
                    DataColumn dc2 = new DataColumn("起始");
                    DataColumn dc3 = new DataColumn("終點");
                    DataColumn dc4 = new DataColumn("生產");
                    //DataColumn dc5 = new DataColumn("刪除");
                    dtTmp.Columns.Add(dc1);
                    dtTmp.Columns.Add(dc2);
                    dtTmp.Columns.Add(dc3);
                    dtTmp.Columns.Add(dc4);
                    dtProc = dtTmp;

                }

                DataRow drAdd = dtProc.NewRow();

                drAdd[0] = cbProc.Text;
                drAdd[1] = tbS.Text;
                drAdd[2] = tbE.Text;
                drAdd[3] = (Convert.ToInt32(tbE.Text) - Convert.ToInt32(tbS.Text)).ToString();
                dtProc.Rows.Add(drAdd);
                dgvProc.DataSource = dtProc;

                dgvProc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvProc.Columns[0].Width = 25;
                dgvProc.BorderStyle = BorderStyle.FixedSingle;
                dgvProc.CellBorderStyle =
                    DataGridViewCellBorderStyle.RaisedHorizontal;
                dgvProc.RowHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
                dgvProc.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
                dgvProc.AllowUserToAddRows = false;

                tbS.Text = (Convert.ToInt32(tbE.Text)+1).ToString();
                int newIndex = cbProc.SelectedIndex+1;
                if (newIndex > 2)
                {
                    newIndex = newIndex % 3;
                }
                cbProc.SelectedIndex = newIndex;
                tbE.Text = "";
            }
        }

        //增加故障原因
        private void btnAddR1_Click(object sender, EventArgs e)
        {
            DataTable dtProc = new DataTable();
            Button btnProc = (Button)sender;
            string NO = btnProc.Name.Substring(btnProc.Name.Length - 1, 1);

            ComboBox cbProc = (ComboBox)this.Controls.Find("cbS" + NO + NO, true)[0];
            ComboBox cbRProc = (ComboBox)this.Controls.Find("cbR" + NO, true)[0];
            TextBox tbS = (TextBox)this.Controls.Find("tbR" + NO + "1", true)[0];
            TextBox tbE = (TextBox)this.Controls.Find("tbR" + NO + "2", true)[0];
            Label lbR = (Label)this.Controls.Find("lbR" + NO, true)[0];
            DataGridView dgvProc = (DataGridView)this.Controls.Find("dgvR" + NO, true)[0];

            if (tbS.Text.Length > 0 && cbRProc.Text.Length>0)
            {
                if (dgvProc.DataSource != null)
                {
                    dtProc = (DataTable)dgvProc.DataSource;
                }
                else
                {
                    dgvProc.Columns.Clear();
                    DataTable dtTmp = new DataTable();
                    DataColumn dc1 = new DataColumn("班");
                    DataColumn dc2 = new DataColumn("故障碼處");
                    DataColumn dc3 = new DataColumn("原因");
                    DataColumn dc4 = new DataColumn("扣點");
                    DataColumn dc5 = new DataColumn("備註");

                    dtTmp.Columns.Add(dc1);
                    dtTmp.Columns.Add(dc2);
                    dtTmp.Columns.Add(dc3);
                    dtTmp.Columns.Add(dc4);
                    dtTmp.Columns.Add(dc5);
                    dtProc = dtTmp;



                }


                DataRow drAdd = dtProc.NewRow();

                drAdd[0] = cbProc.Text;
                drAdd[1] = tbS.Text;
                drAdd[2] = cbRProc.Text;
                drAdd[3] = lbR.Text;
                drAdd[4] = tbE.Text;
                dtProc.Rows.Add(drAdd);
                dgvProc.DataSource = dtProc;
                dgvProc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvProc.Columns[0].Width = 25;
                dgvProc.BorderStyle = BorderStyle.FixedSingle;
                dgvProc.CellBorderStyle =
                    DataGridViewCellBorderStyle.RaisedHorizontal;
                dgvProc.RowHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
                dgvProc.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
                dgvProc.AllowUserToAddRows = false;


                SummaryData();
            }

        }
        
            
 
        private void dgvO1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridView dgvProc = (DataGridView)sender;
                DataTable dtProc = (DataTable)dgvProc.DataSource;
                dtProc.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void dgvR1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                DataGridView dgvProc = (DataGridView)sender;
                DataTable dtProc = (DataTable)dgvProc.DataSource;
                dtProc.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void btnDelO1_Click(object sender, EventArgs e)
        {
            DataTable dtProc = new DataTable();
            Button btnProc = (Button)sender;
            string NO = btnProc.Name.Substring(btnProc.Name.Length - 1, 1);
            DataGridView dgvProc = (DataGridView)this.Controls.Find("dgvO" + NO, true)[0];
            dtProc = (DataTable)dgvProc.DataSource;
            try
            {
                dtProc.Rows.RemoveAt(dgvProc.CurrentCell.RowIndex);
            }
            catch (Exception)
            {
                
                
            }
            

        }
        private void btnDelR1_Click(object sender, EventArgs e)
        {
            DataTable dtProc = new DataTable();
            Button btnProc = (Button)sender;
            string NO = btnProc.Name.Substring(btnProc.Name.Length - 1, 1);
            DataGridView dgvProc = (DataGridView)this.Controls.Find("dgvR" + NO, true)[0];
            dtProc = (DataTable)dgvProc.DataSource;
            dtProc.Rows.RemoveAt(dgvProc.CurrentCell.RowIndex);
        }

        private void CreateNo()
        {
            string sDT = string.Empty;
            string ART_NO = string.Empty;
            string EQP_NO = string.Empty;
            string INS_NO = string.Empty;
            if (!string.IsNullOrEmpty(tbART_NO.Text) && cbEQP.Text.Length == 4)
            {
                sDT = dateTimePicker1.Value.ToString("yyyyMMdd");
                ART_NO = tbART_NO.Text;
                EQP_NO = cbEQP.Text;

                //if (gpMode == Page_Mode.ADD)
                //{
                string sNO = LoadINS_NO(sDT, EQP_NO, ART_NO);
                INS_NO = sDT + "_" + ART_NO + "_" + EQP_NO + "_" + sNO;
                lbINS_NO.Text = INS_NO;
                //}
                //else
                //{ 
                //編號不變
                //}
            }
        }
        private string LoadINS_NO(string _sDT, string _EQP, string _ART)
        {
            string sRet = string.Empty;
            string ssql = SQL_TEXT.Q_INSPECT_BY_ART_EQP;
            ssql = ssql.Replace(":eqp", _EQP);
            ssql = ssql.Replace(":art_no", _ART);
            ssql = ssql.Replace(":dt", _sDT);

            DataTable dtINS = dbTool.QueryData(ssql);

            if (dtINS.Rows.Count > 0)
            {
                if (gpMode == Page_Mode.ADD)
                {
                    string[] INS_NO = dtINS.Rows[0]["INS_NO"].ToString().Split('_');
                    string NO = INS_NO[3];
                    int New_NO = Convert.ToInt32(NO) + 1;
                    string sNew_NO = New_NO.ToString().PadLeft(3, '0');
                    sRet = sNew_NO;
                }
                else
                {
                    string[] INS_NO = dtINS.Rows[0]["INS_NO"].ToString().Split('_');
                    string NO = INS_NO[3];
                    sRet = NO;
                }
            }
            else
            {
                sRet = "001";
            }


            return sRet;
        }

        private void tbART_NO_TextChanged(object sender, EventArgs e)
        {
            CreateNo();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CreateNo();

            LoadINS_DATA();
        }
        private void cbEQP_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateNo();
        }
        private void cbR1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbTmp = (ComboBox)sender;
            string NO = cbTmp.Name.Substring(cbTmp.Name.Length - 1, 1);
            Label lbTmp = (Label)this.Controls.Find("lbR" + NO, true)[0];
            ComboxItem item = (ComboxItem)cbTmp.SelectedItem;
            if (item != null)
            {
                Reason_Item ri = dReason.Find(x => x.Reason_code.Contains(item.Value.ToString()));
                lbTmp.Text = ri.Point;
            }
            else
            {
                Reason_Item ri = null;
                lbTmp.Text = "";
            }

        }


        private void SummaryData()
        {
            lIR.Clear();
            for (int i = 1; i <= 4; i++)
            {

                int TotalPts = 0;
                string Grade = "";
                DataGridView dgvProc = (DataGridView)this.Controls.Find("dgvR" + i, true)[0];
                DataGridView dgvOProc = (DataGridView)this.Controls.Find("dgvO" + i, true)[0];
                Label lbPts = (Label)this.Controls.Find("lbPts" + i, true)[0];
                Label lbG = (Label)this.Controls.Find("lbG" + i, true)[0];
                Label lbY = (Label)this.Controls.Find("lbY" + i, true)[0];

                if (dgvOProc.DataSource != null)
                {
                    Ins_Record ir = new Ins_Record();
                    ir.INS_NO = lbINS_NO.Text;
                    ir.GRP = i.ToString();
                    ir.dtOUTPUT = (DataTable)dgvOProc.DataSource;
                    DataTable dtOTmp = (DataTable)dgvOProc.DataSource;

                    if (dgvProc.DataSource != null)
                    {                                            
                        ir.dtREASON = (DataTable)dgvProc.DataSource;

                        DataTable dtTmp = (DataTable)dgvProc.DataSource;
                        

                        foreach (DataRow dr in dtTmp.Rows)
                        {
                            TotalPts = TotalPts + Convert.ToInt32(dr[3].ToString());
                        }

                        lbPts.Text = TotalPts.ToString();
                        ir.POINT = TotalPts.ToString();

                        if (TotalPts >= 0)
                        {
                            if (TotalPts <= 18)
                            {
                                Grade = "A";
                                lbG.ForeColor = Color.Blue;
                            }
                            else if (TotalPts > 18 && TotalPts <= 24)
                            {
                                Grade = "B";
                                lbG.ForeColor = Color.Orange;
                            }
                            else if (TotalPts > 24)
                            {
                                Grade = "C";
                                lbG.ForeColor = Color.Red;
                            }

                            lbG.Text = Grade;
                            ir.GRADE = Grade;
                        }                 
                    }
                    else
                    {
                        lbG.Text = "A";
                        ir.GRADE = lbG.Text;
                        lbG.ForeColor = Color.Blue;
                        lbPts.Text = "0";
                        ir.POINT = TotalPts.ToString();
                    }
                    if (dtOTmp.Rows.Count > 0)
                    {
                        lbY.Text = dtOTmp.Rows[dtOTmp.Rows.Count - 1][2].ToString();
                    }
                    else
                    {
                        lbY.Text = "0";
                    }
                    ir.LENGTH = lbY.Text;

                    if (dtOTmp.Rows.Count > 0)
                    {
                        lIR.Add(ir);
                    }
                }
                else
                { 
                    
                }


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SummaryData();
        }

        private bool SaveMain(Ins_Record ir)
        {
            bool bRet = false;

            string ins_SQL_MAIN = SQL_TEXT.I_NEW_INS_MAIN;
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":INS_NO", lbINS_NO.Text);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":ART_NO", tbART_NO.Text);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":EQP_NO", cbEQP.Text);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":LENGTH", tbTotalYard.Text);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":OPLENGTH", ir.LENGTH);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":PTS", ir.POINT);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":GRADE", ir.GRADE);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":REMARK", tbAllMark.Text);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":SPONSOR", cbSpr.Text);
            ins_SQL_MAIN = ins_SQL_MAIN.Replace(":GRP", ir.GRP);
            try
            {
                dbTool.ExecData(ins_SQL_MAIN);
                bRet = true;
            }
            catch (Exception ex)
            {

            }
            return bRet;

        }

        private bool SaveMainOutput(Ins_Record ir)
        {
            bool bRet = false;

            DataTable dtTmp = ir.dtOUTPUT;
            string ins_SQL_DETAIL_FINAL = string.Empty;
            string I_DETAAIL_OUTPUT_1 = SQL_TEXT.I_NEW_INS_DETAIL_OUTPUT_1;
            for (int i = 0; i < dtTmp.Rows.Count; i++ )            
            {// ':INS_NO',':SHIFT',':GRP',':sYard',':eYard'
                string ins_SQL_DETAIL_2 = SQL_TEXT.I_NEW_INS_DETAIL_OUTPUT_2;
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":INS_NO", lbINS_NO.Text);
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":SHIFT", dtTmp.Rows[i][0].ToString());
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":GRP", ir.GRP);
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":sYard", dtTmp.Rows[i][1].ToString());
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":eYard", dtTmp.Rows[i][2].ToString());
                if (i == dtTmp.Rows.Count - 1)
                {
                    ins_SQL_DETAIL_FINAL = ins_SQL_DETAIL_FINAL + ins_SQL_DETAIL_2;
                }
                else
                {
                    ins_SQL_DETAIL_FINAL = ins_SQL_DETAIL_FINAL + ins_SQL_DETAIL_2 + "  UNION ALL  ";
                }            
            }
            try
            {
                ins_SQL_DETAIL_FINAL = I_DETAAIL_OUTPUT_1 + ins_SQL_DETAIL_FINAL;
                dbTool.ExecData(ins_SQL_DETAIL_FINAL);
                bRet = true;
                //MessageBox.Show(lbINS_NO.Text + " 儲存成功!");
                //CreateNo(gpMode);
                //this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("儲存失敗!");
            }
            return bRet;

        }

        private bool SaveReasonDetail(Ins_Record ir)
        {
            bool bRet = false;

            string ins_SQL_DETAIL_FINAL = string.Empty;
            string ins_SQL_DETAIL_1 = SQL_TEXT.I_NEW_INS_DETAIL_1;

            ins_SQL_DETAIL_FINAL = ins_SQL_DETAIL_1;
            DataTable dtRTmp = ir.dtREASON;
            for (int i = 0; i < dtRTmp.Rows.Count; i++)
            {
                string ins_SQL_DETAIL_2 = SQL_TEXT.I_NEW_INS_DETAIL_2;
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":INS_NO", lbINS_NO.Text);
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":CHK_PT", dtRTmp.Rows[i][1].ToString());
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":REASON_CODE", (dtRTmp.Rows[i][2].ToString()).Substring(0, 1));
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":REMARK", dtRTmp.Rows[i][4].ToString());
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":SHIFT", dtRTmp.Rows[i][0].ToString());
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":GRP", ir.GRP);
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":PTS", dtRTmp.Rows[i][3].ToString());
                if (i == dtRTmp.Rows.Count - 1)
                {
                    ins_SQL_DETAIL_FINAL = ins_SQL_DETAIL_FINAL + ins_SQL_DETAIL_2;
                }
                else
                {
                    ins_SQL_DETAIL_FINAL = ins_SQL_DETAIL_FINAL + ins_SQL_DETAIL_2 + "  UNION ALL  ";
                }
            }
            try
            {
                if (dtRTmp.Rows.Count > 0)
                {
                    dbTool.ExecData(ins_SQL_DETAIL_FINAL);
                    bRet = true;
                }
                else
                {
                    bRet = true;
                }
                
                //MessageBox.Show(lbINS_NO.Text + " 儲存成功!");
                //CreateNo(gpMode);
                //this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("儲存失敗!");
            }
            return bRet;
        }

        private void Save()
        {            
            SummaryData();
            bool bResult=true;
            bool[] bFinalResult = { true, true, true, true };
            //foreach (Ins_Record ir in lIR)
            for (int i = 0; i < lIR.Count;i++ )
            {
                if (gpMode == Page_Mode.ADD)
                {
                    bool bF1 = SaveMain(lIR[i]);
                    if (bF1)
                    {
                        if (lIR[i].dtOUTPUT != null)
                        {
                            bool bF2 = SaveMainOutput(lIR[i]);
                            bResult = bF2;
                        }
                        if (lIR[i].dtREASON != null)
                        {
                            bool bF3 = SaveReasonDetail(lIR[i]);
                            bResult = bF3;
                        }
                        
                        if (!bResult)
                        {
                            bFinalResult[i] = false;
                            MessageBox.Show("儲存失敗!");
                            break;
                        }
                    }
                    else
                    {
                        bFinalResult[i] = false;
                        MessageBox.Show("儲存失敗!");
                        break;
                    }
                    
                }
            }

            int  j= 0;
            foreach (bool b in bFinalResult)
            {
                if (b)
                {
                    j++;
                }
            }
            if(j==4)
            {
                MessageBox.Show("儲存成功!");
                ResetControls();
                LoadINS_DATA();
            }
        }

        private void ResetControls()
        { 
            tbART_NO.Text="";
            tbTotalYard.Text="";
            lbINS_NO.Text="";
            tbS11.Text="";
            tbS12.Text="";
            tbS21.Text="";
            tbS22.Text="";
            tbS31.Text="";
            tbS32.Text="";
            tbS41.Text = "";
            tbS42.Text="" ;
            tbR11.Text = "";
            tbR21.Text = "";
            tbR31.Text = "";
            tbR41.Text = "";
            //lIR.Clear();
            cbR1.SelectedItem = null;
            cbR2.SelectedItem = null;
            cbR3.SelectedItem = null;
            cbR4.SelectedItem = null;

            cbS1.SelectedIndex = 0;
            cbS2.SelectedIndex = 0;
            cbS3.SelectedIndex = 0;
            cbS4.SelectedIndex = 0;

            dgvO1.DataSource = null;
            dgvO2.DataSource = null;
            dgvO3.DataSource = null;
            dgvO4.DataSource = null;
            dgvR1.DataSource = null;
            dgvR2.DataSource = null;
            dgvR3.DataSource = null;
            dgvR4.DataSource = null;
        }
    

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbART_NO.Text.Length > 0 && dgvO1.Rows.Count > 0)
            {
                if (gpMode == Page_Mode.EDIT)
                {
                    gpMode = Page_Mode.ADD;
                    MessageBox.Show("舊版本不會覆蓋，會另存新檔!");
                    CreateNo();
                }
                
                Save();
            }
            else
            {
                MessageBox.Show("請輸入布號與疋號資料!");
            }
        }

        private void tbS12_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tbProc = (TextBox)sender;
            
            Button btnOK = new Button();
            string NO = tbProc.Name.Substring(tbProc.Name.Length - 2, 1);

            if (e.KeyCode == Keys.Return)
            {
                if (tbProc.Name.Contains("tbS"))
                {
                    TextBox tbS = (TextBox)this.Controls.Find("tbS" + NO + "1", true)[0]; ;
                    try
                    {
                        if (Convert.ToInt32(tbS.Text) >= Convert.ToInt32(tbProc.Text))
                        {
                            MessageBox.Show("結束碼必須大於起始碼!");
                            return;
                        }                    
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("結束碼必須大於起始碼!");
                    }
                    
                    btnOK = (Button)this.Controls.Find("btnAddO" + NO, true)[0];


                }
                else if (tbProc.Name.Contains("tbR"))
                {
                    btnOK = (Button)this.Controls.Find("btnAddR" + NO, true)[0];
                }

                btnOK.PerformClick();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        public class Ins_Record
        {
            public string INS_NO { get; set; }
            public string ART_NO { get; set; }
            public string EQP { get; set; }
            public string Sponsor { get; set; }
            public string OUT_SHIFT { get; set; }
            public string ALL_REMARK { get; set; }
            public string POINT { get; set; }
            public string LENGTH { get; set; }
            public string OUT_LENGTH { get; set; }
            public string GRADE { get; set; }
            public string GRP { get; set; }
            public DataTable dtREASON { get; set; }
            public DataTable dtOUTPUT { get; set; }

            public Ins_Record()
            {
                DataTable dtTmp = new DataTable();
                DataColumn dc1 = new DataColumn("班");
                DataColumn dc2 = new DataColumn("起始");
                DataColumn dc3 = new DataColumn("終點");
                DataColumn dc4 = new DataColumn("生產");
                //DataColumn dc5 = new DataColumn("刪除");
                dtTmp.Columns.Add(dc1);
                dtTmp.Columns.Add(dc2);
                dtTmp.Columns.Add(dc3);
                dtTmp.Columns.Add(dc4);
                this.dtOUTPUT = dtTmp;

                DataTable dtTmp2 = new DataTable();
                DataColumn dc21 = new DataColumn("班");
                DataColumn dc22 = new DataColumn("故障碼處");
                DataColumn dc23 = new DataColumn("原因");
                DataColumn dc24 = new DataColumn("扣點");
                DataColumn dc25 = new DataColumn("備註");

                dtTmp2.Columns.Add(dc21);
                dtTmp2.Columns.Add(dc22);
                dtTmp2.Columns.Add(dc23);
                dtTmp2.Columns.Add(dc24);
                dtTmp2.Columns.Add(dc25);
                this.dtREASON = dtTmp2;
            }
        }
        public class Reason_Item
        {
            public string Reason_code { get; set; }
            public string Reason { get; set; }
            public string Point { get; set; }

            public Reason_Item()
            {

            }
        }

        private void dgvINS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gpMode = Page_Mode.EDIT;    
            DataGridView dgvProc = (DataGridView)sender;
            DataTable dtProc = (DataTable)dgvProc.DataSource;
            lbINS_NO.Text = dtProc.Rows[e.RowIndex][0].ToString() + "_" + dtProc.Rows[e.RowIndex][1].ToString() + "_" + dtProc.Rows[e.RowIndex][2].ToString() + "_" + dtProc.Rows[e.RowIndex][4].ToString();
            LoadINS_Detail(lbINS_NO.Text);
            
        }

        private void btnDelIns_Click(object sender, EventArgs e)
        {
            DataTable dtProc = new DataTable();
            dtProc = (DataTable)dgvINS.DataSource;
            int RowIndex = dgvINS.CurrentCell.RowIndex;
            lbINS_NO.Text = dtProc.Rows[RowIndex][0].ToString() + "_" + dtProc.Rows[RowIndex][1].ToString() + "_" + dtProc.Rows[RowIndex][2].ToString() + "_" + dtProc.Rows[RowIndex][4].ToString();                

            DialogResult dialogResult = MessageBox.Show("確定要刪除此檢查單? " + lbINS_NO.Text, "確定刪除? ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                if (DeleteINS(lbINS_NO.Text))
                {
                    MessageBox.Show("刪除成功!");
                    LoadINS_DATA();
                }
                else
                {
                    MessageBox.Show("刪除失敗!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private bool DeleteINS(string _INS_NO)
        {
            bool ret = false;
            string ssql = SQL_TEXT.D_INS_MAIN;
            //string ins_SQL_MAIN = SQL_TEXT.I_NEW_INS_MAIN;
            ssql = ssql.Replace(":INS_NO", _INS_NO);
            try
            {
                dbTool.ExecData(ssql);
                ret = true;
                //MessageBox.Show("儲存成功!");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("更新失敗!");
                ret = false;
            }

            ssql = SQL_TEXT.D_INS_DETAIL;
            //string ins_SQL_MAIN = SQL_TEXT.I_NEW_INS_MAIN;
            ssql = ssql.Replace(":INS_NO", _INS_NO);
            try
            {
                dbTool.ExecData(ssql);
                //MessageBox.Show("儲存成功!");
                ret = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("更新失敗!");
                ret = false;
            }

            ssql = SQL_TEXT.D_INS_DETAIL_OUTPUT;
            //string ins_SQL_MAIN = SQL_TEXT.I_NEW_INS_MAIN;
            ssql = ssql.Replace(":INS_NO", _INS_NO);
            try
            {
                dbTool.ExecData(ssql);
                //MessageBox.Show("儲存成功!");
                ret = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("更新失敗!");
                ret = false;
            }

            return ret;
        }



      



 


    }






}
