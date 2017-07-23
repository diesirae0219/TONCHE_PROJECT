using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Database;
using TonChe_Operation_Cneter.Utility;

namespace TonChe_Operation_Cneter
{
    public partial class frmProdSearch : Form
    {
        private DB_Access dbTool = new DB_Access();
        public frmProdSearch()
        {
            InitializeComponent();
            LoadART_Type();
        }

        private void cbArtType_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            CheckedComboBoxEdit edit = sender as CheckedComboBoxEdit;
            //if (e.CloseMode == PopupCloseMode.ButtonClick)
            //    MessageBox.Show(edit.EditValue.ToString());
            tbART_TYPE.Text = cbArtType.EditValue.ToString();
        }

        private void cbArtCons_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            CheckedComboBoxEdit edit = sender as CheckedComboBoxEdit;
            //if (e.CloseMode == PopupCloseMode.ButtonClick)
            //    MessageBox.Show(edit.EditValue.ToString());
            tbArtCons.Text = cbArtCons.EditValue.ToString();
        }


        private void LoadART_Type()
        {

            string ssql = SQL_TEXT.Q_ART_TYPE;
            DataTable dtRet = dbTool.QueryData(ssql);
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

        private void btn_SEARCH_Click(object sender, EventArgs e)
        {
            string ssql = SQL_TEXT.Q_PROD_SEARCH;
            string sWhere = " Where 1=1 ";
            string cond1 = "";
            string cond2 = "";
            string cond3 = "";
            if (!String.IsNullOrEmpty(tb_SEARCH_ART.Text))
            {
                cond1 = " ART_NO like '%" + tb_SEARCH_ART.Text + "%'";
            }

            if (!String.IsNullOrEmpty(tbART_TYPE.Text))
            {
                string[] sType = tbART_TYPE.Text.Split(';');
                for (int i = 0; i < sType.Length; i++)
                {
                    if (i == sType.Length - 1)
                    {
                        cond2 = cond2 + " ART_TYPE like '%" + (sType[i]).Trim() + "%' ";
                    }
                    else
                    {
                        cond2 = cond2 + " ART_TYPE like '%" + (sType[i]).Trim() + "%' " + " OR ";
                    }
                    
                }
                cond2 = "(" + cond2 + ")";
                    
            }

            if (!String.IsNullOrEmpty(tbArtCons.Text))
            {
                string[] sCons = tbArtCons.Text.Split(';');
                for (int i = 0; i < sCons.Length; i++)
                {
                    if (i == sCons.Length - 1)
                    {
                        cond3 = cond3 + " COMPOSITION like '%" + (sCons[i]).Trim() + "%' ";
                    }
                    else
                    {
                        cond3 = cond3 + " COMPOSITION like '%" + (sCons[i]).Trim() + "%' " + " OR ";
                    }
                    
                }
                cond3 = "(" + cond3 + ")";

            }

            if (!String.IsNullOrEmpty(cond1) || !String.IsNullOrEmpty(cond2) || !String.IsNullOrEmpty(cond3))
            {
                ssql = ssql + sWhere ;
                if (!String.IsNullOrEmpty(cond1))
                {
                    ssql = ssql +" AND " + cond1;
                }
                if (!String.IsNullOrEmpty(cond2))
                {
                    ssql = ssql + " AND " + cond2;
                }
                if (!String.IsNullOrEmpty(cond3))
                {
                    ssql = ssql + " AND " + cond3;
                }

                DataTable dtART = dbTool.QueryData(ssql);
                gvART_DATA.DataSource = dtART;

            }
            else
            {
                MessageBox.Show("請至少輸入一個條件!");
            }

        }

        private void gvART_DATA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != null)
            {
                selArt.Text = gvART_DATA.Rows[e.RowIndex].Cells[0].Value.ToString();
                SetCurrentART_NO(e.RowIndex);
               
            }
        }

        private void SetCurrentART_NO(int CurrentRowIndex)
        {
            LoadImageSample();
        }
        public void LoadImageSample()
        {
            Image image;
            try
            {
                if (GlobalVar.sMode == GlobalVar.SysMode.Web)
                {
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(@GlobalVar.WebTonChePicturePath + "布品縮圖/" + selArt.Text + ".jpg");
                    MemoryStream ms = new MemoryStream(bytes);
                    image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    image = Image.FromFile(GlobalVar.LocalTonChePicturePath + "布品縮圖\\" + selArt.Text + ".jpg"); //From Local file
                }


            }
            catch (Exception)
            {
                image = TonChe_Operation_Cneter.Properties.Resources.NA;
            }
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary> 
        /// Exports the datagridview values to Excel. 
        /// </summary> 
        private void ExportToExcel(DataGridView gv)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "布號資料";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < gv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < gv.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = gv.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = gv.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(gvART_DATA);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Sample fmSample = new Sample(selArt.Text);
            Image image;
            try
            {

                if( GlobalVar.sMode == GlobalVar.SysMode.Web)
                {
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(GlobalVar.WebTonChePicturePath + "布品/" + selArt.Text + ".jpg");
                    MemoryStream ms = new MemoryStream(bytes);
                    image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    image = Image.FromFile(GlobalVar.LocalTonChePicturePath + "布品\\" + selArt.Text + ".jpg");
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
        
    }
}
