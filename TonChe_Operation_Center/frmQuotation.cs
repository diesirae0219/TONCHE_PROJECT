using FactoryObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Database;
using TonChe_Operation_Cneter.Utility;


namespace TonChe_Operation_Cneter
{
    public partial class frmQuotation : Form
    { 
        private PrintDocument printDocument1 = new PrintDocument();
        private int rowCounter = 0;
        private int CurPages = 0;
        private List<string> Order_List = new List<string>();
        public frmQuotation()
        {
            InitializeComponent();

            TB_GETTEXT_ID.KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnAdd.PerformClick();
                }
            };

            TB_GETTEXT_ID.GotFocus += TB_GETTEXT_ID_GotFocus;
            TB_GETTEXT_ID.LostFocus += TB_GETTEXT_ID_LostFocus;

            InitGv();
        }

        private void TB_GETTEXT_ID_GotFocus(object sender, EventArgs e)
        {
            TB_GETTEXT_ID.BackColor = Color.Yellow;
        }

        private void TB_GETTEXT_ID_LostFocus(object sender, EventArgs e)
        {
            TB_GETTEXT_ID.BackColor = SystemColors.Control;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (TB_GETTEXT_ID.Text != "")
            {
                if (cbAutoART.Checked == true)
                {
                    if (!TB_GETTEXT_ID.Text.Contains("ART"))
                    {
                        TB_GETTEXT_ID.Text = "ART" + TB_GETTEXT_ID.Text;
                    }
                }
                InserOrderText();
                TB_GETTEXT_ID.Text = "";
            }
            else
            {
                MessageBox.Show("請輸入布號!");
            }
        }

        private void InserOrderText()
        {
            //gvOrder.Rows.Add
            //if (gvOrder.Rows[0].Cells[0].Value == null)
            //{
            //    gvOrder.Rows.RemoveAt(0); 
            //}
            DataGridViewRow row1 = (DataGridViewRow)gvOrder.Rows[0].Clone();

            row1.Height = 200;
            ArtProd artProd = new ArtProd(TB_GETTEXT_ID.Text,GlobalVar.sMode.ToString());
            row1.Cells[0].Value = gvOrder.RowCount.ToString();
            row1.Cells[1].Value = TB_GETTEXT_ID.Text;
            row1.Cells[2].Value = artProd.Composition;
            row1.Cells[3].Value = "";
            //row1.Cells[2].Value = "1000";

            if (Order_List.Contains(TB_GETTEXT_ID.Text))
            {
                MessageBox.Show("此布號已存在!!");
            }
            else
            {
                Order_List.Add(TB_GETTEXT_ID.Text);
                try
                {
                    //Image image = Image.FromFile("E:\\SHARE\\TonChe_System\\TonChe_System\\TonChe_System\\Picture\\布品\\" + TB_GETTEXT_ID.Text + ".jpg");
                    Image image;
                    if (GlobalVar.sMode == GlobalVar.SysMode.Web)
                    {
                        WebClient wc = new WebClient();
                        byte[] bytes = wc.DownloadData(GlobalVar.WebTonChePicturePath + "布品縮圖/" + TB_GETTEXT_ID.Text + ".jpg");
                        MemoryStream ms = new MemoryStream(bytes);
                        image = System.Drawing.Image.FromStream(ms);
        
                    }
                    else
                    {
                        image = Image.FromFile(GlobalVar.LocalTonChePicturePath + "布品縮圖\\" + TB_GETTEXT_ID.Text + ".jpg");
                    }

                    //Image.FromFile(TonChePicturePath+"布品縮圖\\" + TB_GETTEXT_ID.Text + ".jpg");


                    Bitmap CellImage = ResizeImage(image, 100, 100);
                    row1.Cells[4].Value = CellImage;
                    

                    row1.Height = 100;
                }
                catch (Exception)
                {
                    Image image1 = TonChe_Operation_Cneter.Properties.Resources.NA;
                    Bitmap CellImage1 = ResizeImage(image1, 100, 100);
                    row1.Cells[4].Value = CellImage1;
                    row1.Height = 100;

                }

                gvOrder.Rows.Add(row1);
                UpdateFont(gvOrder);
                gvOrder_ReOrder();
               // gvOrder.AllowUserToAddRows = false;
            }

            #region OLD_CODE


            //DataGridViewImageColumn img = row1.


            //row1.Height = 200;

            //string[] row = new string[] { gvOrder.RowCount.ToString(), TB_GETTEXT_ID.Text, "1000" };

            //gvOrder.Rows.Add(row);
            //row1 = gvOrder.Rows[gvOrder.RowCount-2];
            //row1.Height = 200;
            //row = new string[] { "2", "Product 2", "2000" };
            //gvOrder.Rows.Add(row);
            //row1 = gvOrder.Rows[1];
            //row1.Height = 40;
            //row = new string[] { "3", "Product 3", "3000" };
            //gvOrder.Rows.Add(row);
            //row1 = gvOrder.Rows[2];
            //row1.Height = 40;
            //row = new string[] { "4", "Product 4", "4000" };
            //gvOrder.Rows.Add(row);
            //row1 = gvOrder.Rows[3];
            //row1.Height = 200;


            //DataGridViewImageColumn img = new DataGridViewImageColumn();
            //Image image = Image.FromFile("E:\\SHARE\\TonChe_System\\TonChe_System\\TonChe_System\\Picture\\布品測試\\" + TB_GETTEXT_ID.Text+".jpg");
            //PictureBox pb = new PictureBox();
            //pb.ImageLocation = "E:\\SHARE\\TonChe_System\\TonChe_System\\TonChe_System\\Picture\\布品\\ART10629.JPG"
            //image.Stretch = Stretch.Fill;

            //img.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //gvOrder.Columns.Add(img);



            //Padding newPadding = new Padding(0, 1, 0, 50);
            //gvOrder.RowTemplate.DefaultCellStyle.Padding = newPadding;

            //DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            //Button btnRemove = new Button();
            //ColRemovebtn.

            //DataGridViewCellStyle ds = new DataGridViewCellStyle();
            //ds.Padding = new System.Windows.Forms.Padding(20,80,20,80);
            //btnDelete.DefaultCellStyle = new DataGridViewCellStyle(ds);

            //btnDelete.HeaderText = "Remove";
            //btnDelete.Name = "Remove";
            //btnDelete.Text = "移除";
            //btnDelete.UseColumnTextForButtonValue = true;
            ////gvOrder.Columns[4]. = btnDelete;
            ////gvOrder.Columns.Insert(4, btnDelete);
            //gvOrder.Columns.Add(btnDelete);


            //btnDelete.HeaderText = "Remove";
            ////btnDelete.FillWeight = 50;
            ////btnDelete.

            ////gvOrder.Columns.Insert(4, btnDelete);
            //

            ////DataGridViewCell c = new DataGridViewCell();
            ////Button b = (Button)(c.findControls("铵钮名"));

            //gvOrder.Margin = new Padding(5);

            #endregion
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rowCounter = 0;
            CurPages = 0;
            Order_List.Clear();
            gvOrder.Rows.Clear();
            InitGv();
            tb_customer.Text = "";
        }

        private void InitGv()
        {

            //gvOrder.AllowUserToAddRows = false;
            gvOrder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gvOrder.ColumnCount = 4;
            gvOrder.Columns[0].Name = "colNO";
            gvOrder.Columns[0].HeaderText = "No.";
            gvOrder.Columns[0].Width = 100;
    

            gvOrder.Columns[1].Name = "colText";
            gvOrder.Columns[1].HeaderText = "Art_Id";
            gvOrder.Columns[1].Width = 250;

            gvOrder.Columns[2].Name = "colComp";
            gvOrder.Columns[2].HeaderText = "Composition";
            gvOrder.Columns[2].Width = 250;

            gvOrder.Columns[3].Name = "colNote";
            gvOrder.Columns[3].HeaderText = "Remark";
            gvOrder.Columns[3].Width = 250;
            gvOrder.Columns[3].ReadOnly = false;
            gvOrder.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //gvOrder.Columns[2].Name = "colPrice";
            //gvOrder.Columns[2].Name = "Price";
            //gvOrder.Columns[2].Width = 100;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img.HeaderText = "Sample";
            img.HeaderText = "Image";
            img.Name = "colImg";
            img.Width = 400;
            gvOrder.Columns.Add(img);
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            DataGridViewCellStyle ds = new DataGridViewCellStyle();
            ds.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            btnDelete.DefaultCellStyle = new DataGridViewCellStyle(ds);


        

            btnDelete.HeaderText = "Remove";
            btnDelete.Name = "Remove";
            btnDelete.Text = "移除";
            btnDelete.UseColumnTextForButtonValue = true;
            gvOrder.Columns.Add(btnDelete);
            
            gvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (DataGridViewRow row in gvOrder.Rows)
            {
                row.Height = 100;
                DataGridViewCell cell = row.Cells["colImg"];
                cell.Value = TonChe_Operation_Cneter.Properties.Resources.NA;
            }
            //gvOrder.AllowUserToAddRows = false;
        }


        #region DataGridView to Excel
        private void btnSaveOrderExcel_Click(object sender, EventArgs e)
        {
            if (gvOrder.Rows.Count >= 10000)
            {
                MessageBox.Show("! 考量電腦效能及實際需要，限制轉換資料筆數不能超過10000筆 !\n\n目前筆數為[ " + gvOrder.Rows.Count + " ]");
                return;
            }

            if (gvOrder.Rows.Count > 1)
            {

                Cursor = Cursors.WaitCursor;

                int nn = 1; //excel列址

                pp1.Value = 0;
                pp1.Visible = true;
                double nnn; int j = 1; // 進度條
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true); //引用Excel工作簿 

                object misValue = System.Reflection.Missing.Value;

                //Microsoft.Office.Interop.Excel.Workbook  xlWorkBook = excel.Workbooks.Add(misValue);
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1];//(Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                //——-標題———————-
                if (excel == null)
                {
                    MessageBox.Show("! 無法建立新Excel檔 !");
                    return;
                }

                //Bitmap ban = TonChe_Operation_Cneter.Properties.Resources.banner;
                //System.Windows.Forms.Clipboard.SetImage(ban);
                //Microsoft.Office.Interop.Excel.Range position = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[nn+1, 1];
                //xlWorkSheet.Paste(position); //copy the clipboard to the given position
                //nn++;

                excel.Cells[nn, 1] = tb_customer.Text;
                // ————————————- 讀取DataGridView資料轉入Excel檔

                //——-各欄名稱——————
                nn++; //Y
                for (int i = 0; i < gvOrder.ColumnCount - 1; i++)
                {
                    excel.Cells[nn, i + 1] = gvOrder.Columns[i].HeaderText;
                }
                Microsoft.Office.Interop.Excel.Range rr1 = excel.Range[excel.Cells[nn, 1], excel.Cells[nn, gvOrder.Columns.Count]];
                rr1.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DeepSkyBlue);
                rr1.ColumnWidth = Convert.ToInt32(rr1.ColumnWidth) + 2;
                //——內容———————–
                nn++;


                for (int r = 0; r < gvOrder.Rows.Count - 1; r++)
                //each (DataGridViewRow row in gvOrder.Rows)
                {
                    nnn = System.Convert.ToDouble(j++) / System.Convert.ToDouble(gvOrder.Rows.Count);
                    pp1.Value = System.Convert.ToInt16(nnn * 100);
                    for (int i = 0; i < gvOrder.Rows[r].Cells.Count - 1; i++)
                    {
                        if (gvOrder.Rows[r].Cells[i].Value != null)
                        {
                            if (i == 4)
                            {
                                // You have to get original bitmap path here
                                //string imagString = "bitmap1.bmp";
                                //Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 1, j + 1];
                                //float Left = (float)((double)oRange.Left);
                                //float Top = (float)((double)oRange.Top);
                                //const float ImageSize = 32;
                                //xlWorkSheet1.Shapes.AddPicture(imagString, Microsoft.Office.Interop.Excel.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
                                //oRange.RowHeight = ImageSize + 2;
                                try
                                {
                                    Bitmap bp = (Bitmap)gvOrder.Rows[r].Cells[i].Value;
                                    //string picname = Application.ActiveWorkbook.Path;
                                    String sFile = gvOrder.Rows[r].Cells[1].Value.ToString() + ".jpg";
                                    String sPath;
                                    if (GlobalVar.sMode == GlobalVar.SysMode.Web)
                                    {
                                        WebClient wc = new WebClient();
                                        byte[] bytes = wc.DownloadData(GlobalVar.WebTonChePicturePath + "布品縮圖/" + sFile);
                                        MemoryStream ms = new MemoryStream(bytes);
                                        //image = System.Drawing.Image.FromStream(ms);
                                        sPath = GlobalVar.WebTonChePicturePath + "布品縮圖/" + sFile;
                                    }
                                    else
                                    {
                                        sPath = GlobalVar.LocalTonChePicturePath + "布品縮圖\\" + sFile;
                                    }


                                    // String sPath = TonChePicturePath + "布品縮圖\\" + sFile;
                                    object missing = System.Reflection.Missing.Value;
                                    //Microsoft.Office.Interop.Excel.Range picPosition = excel.get_Range(excel.Cells[i, nn], excel.Cells[i + 1, nn]); // retrieve the range for picture insert
                                    Microsoft.Office.Interop.Excel.Pictures p = xlWorkSheet.Pictures(missing) as Microsoft.Office.Interop.Excel.Pictures;
                                    Microsoft.Office.Interop.Excel.Picture pic = null;

                                    Microsoft.Office.Interop.Excel.Range picRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[nn, i + 1];
                                    pic = p.Insert(sPath, missing);

                                    pic.Left = Convert.ToDouble(picRange.Left);
                                    pic.Top = Convert.ToDouble(picRange.Top);
                                    pic.Width = 100;
                                    pic.Height = 100;
                                    //pic.Placemen.t = // Can be any of Excel.XlPlacement.XYZ value
                                    //float PicLeft = (float)picPosition.Left;
                                    //float PicTop = (float)picPosition.Top;
                                    picRange.RowHeight = pic.Height + 2;
                                    picRange.ColumnWidth = 50;

                                }
                                catch (Exception)
                                {

                                }

                            }
                            else
                            {

                                excel.Cells[nn, i + 1] = gvOrder.Rows[r].Cells[i].Value.ToString();
                                if (i == 0)
                                {
                                    excel.Cells[nn, i + 1].ColumnWidth = 2;
                                }

                                if (i == 2)
                                {
                                    excel.Cells[nn, i + 1].ColumnWidth = 30;
                                }

                                if (i == 4)
                                {
                                    excel.Cells[nn, i + 1].ColumnWidth = 0;
                                }
                            }


                        }
                    }
                    nn++;
                }
                Microsoft.Office.Interop.Excel.Range rr2 = excel.Range[excel.Cells[2, 1], excel.Cells[nn - 1, gvOrder.Columns.Count]];
                rr2.Borders.LineStyle = 1;
                //—–結尾————————
                excel.Cells[nn, 1] = "";//ootText;
                excel.Cells[nn + 1, 1] = "TON  CHE TEXTILE Taiwan. ";//ootText;
                //———————————
                Cursor = Cursors.Default;
                //MessageBox.Show("* 資料轉至Excel作業完成 *");

                //excel.Visible = true;

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                if (String.IsNullOrEmpty(tb_customer.Text))
                {
                    tb_customer.Text = "NA";
                }
                string FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + tb_customer.Text;
                string FilePath = GlobalVar.ExcelSavePath + FileName;
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = FilePath;

                //暫時先預設都儲存
                //if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                excel.Application.Workbooks[1].SaveAs(FilePath);
                pp1.Value = 100;
                MessageBox.Show("Export Successful");

                //}

                pp1.Visible = false;
                releaseObject(xlWorkSheet);
                releaseObject(excel.Application.Workbooks[1]);
                releaseObject(excel);
                excel.Application.Workbooks[1].Close(null, null, null);
                excel.Application.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                excel = null;

                //System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                //foreach (System.Diagnostics.Process p in process)
                //{
                //    if (!string.IsNullOrEmpty(p.ProcessName))
                //    {
                //        try
                //        {
                //            p.Kill();
                //        }
                //        catch { }
                //    }
                //}

            }
            else
            {
                MessageBox.Show("No data!");
            }
        }

        #endregion


        private bool SaveSelectionl()
        {
            bool bRet = false;
            DB_Access dbTool = new DB_Access();
            string ins_SQL_DETAIL_FINAL = string.Empty;
          
            string ins_SQL_DETAIL_1 = SQL_TEXT.I_C_SEL_1;
                  if (String.IsNullOrEmpty(tb_customer.Text))
                {
                    tb_customer.Text = "NA";
                }
                string CID = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + tb_customer.Text;
           
            for (int i = 0; i < gvOrder.Rows.Count-1; i++)
            {
                string ins_SQL_DETAIL_2 = SQL_TEXT.I_C_SEL_2;
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":CID",CID);
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":CUSTOMER_NAME", tb_customer.Text);
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":ART_NO", (gvOrder.Rows[i].Cells[1].Value.ToString()));
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":REMARK", (gvOrder.Rows[i].Cells[3].Value.ToString()));
                ins_SQL_DETAIL_2 = ins_SQL_DETAIL_2.Replace(":SEQ", (gvOrder.Rows[i].Cells[0].Value.ToString()));

                if (i == gvOrder.Rows.Count - 2)
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
                if (gvOrder.Rows.Count > 0)
                {
                    dbTool.ExecData(ins_SQL_DETAIL_1 + " "+ins_SQL_DETAIL_FINAL);
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

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void gvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 5) && (gvOrder.Rows[e.RowIndex].Cells[1].Value != null) && (e.RowIndex != gvOrder.Rows.Count))
            {
                if (gvOrder.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    Order_List.Remove(gvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                gvOrder.Rows.Remove(gvOrder.Rows[e.RowIndex]);

            }
            gvOrder_ReOrder();
        }
        private void gvOrder_ReOrder()
        {
            foreach (DataGridViewRow row in gvOrder.Rows)
            {
                DataGridViewCell cell = row.Cells["colNo"];
                cell.Value = row.Index + 1;
            }
        }




        private void btnPrint_Click(object sender, EventArgs e)
        {

            rowCounter = 0;
            CurPages = 0;
            if (cbPrintWithSave.Checked == true)
            {
                btnSaveOrderExcel.PerformClick();
                SaveSelectionl();
            }
            //gvOrder.Columns.Remove("Remove");

            // this.printDocument1.Print();
            // PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);

            // PrintPreviewDialog PPD = new PrintPreviewDialog();

            // PPD.Document = PD;

            // PPD.ShowDialog();
            //Document.PrintPage += (sender, e) => { e.Graphics.Clear(Color.White); Document_PrintText(e, inputString);
            printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.BeginPrint += printDocument1_BeginPrint;
            //printDocument1.EndPrint += Document_Clear;
            //printDialog1.Document = printDocument1;
            printPreviewDialog1.Document = printDocument1;
            //printDialog1.ShowDialog();
            
            printPreviewDialog1.ShowDialog();
            
            
            //    ClsPrint cp = new ClsPrint(gvOrder, "AA");
            //   cp.PrintForm();
        }

        void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            rowCounter = 0;
            CurPages = 0;
        }

    

        private void Document_Clear(object sender, PrintPageEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

    
        private void UpdateFont(DataGridView dvTemp)
        {
            //Change cell font
            foreach (DataGridViewColumn c in dvTemp.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            }
        }

        private void frmQuotation_Load(object sender, EventArgs e)
        {

    
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
   
            int AllPages = 0;
            AllPages = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal((Decimal)(gvOrder.Rows.Count - 1) / 5)));
            //int rowCounter = 0;
            //if (CurPages + 1 == AllPages)
            //{
            //    rowCounter = 0;
            //    CurPages = 0;

            //}
            int z = 0;
            int pageOffset = 0;
            StringFormat str = new StringFormat();
            str.Alignment = StringAlignment.Near;
            str.LineAlignment = StringAlignment.Center;
            str.Trimming = StringTrimming.EllipsisCharacter;

            //int width = 500 / (gvOrder.Columns.Count - 2);
            //int realwidth = 100;
            //int height = 80;
            //Font TitleFont = new Font("微軟正黑體", 14, FontStyle.Bold);
            //int realheight = 100;
            int width = 500 / (gvOrder.Columns.Count - 2);
            int realwidth = 20;
            int Titleheight = 40;
            int TitlePosheight = 130;
            int height = 180;
            int realheight = 150;
            Font drawFont = new Font("微軟正黑體", 12);
            Font fTitle = new System.Drawing.Font("微軟正黑體", 36, FontStyle.Bold);
            Font TitleFont = new Font("微軟正黑體", 14, FontStyle.Bold);
          
            Image imgHeader = TonChe_Operation_Cneter.Properties.Resources.banner;//Image.FromFile(@"\Picture\TONCHE_MARK.jpg");
            //imgHeader. = imgHeader.Height * 80 / 100;
            e.Graphics.DrawImage(imgHeader, 2, 10, imgHeader.Width * 35 / 100, imgHeader.Height * 35 / 100);
            e.Graphics.DrawString("Customer Name:  " + tb_customer.Text, TitleFont, Brushes.Black, 20, 100);

            // Please note this is where I am Printing Sunday , Monday , Tuesday.... We can also move rowCounter to 
            // the maxRowcounter loop where we are printing below 
            //for (z = 0; z < gvOrder.Columns.Count - 1; z++)
            //{
            //    if (z == gvOrder.Columns.Count - 2)
            //    {
            //        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, 400, height);
            //        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 400, height);

            //        e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, gvOrder.Font, Brushes.Black, realwidth + 20, realheight + 25);
            //        realwidth = realwidth + 400;

            //    }
            //    else if (z == 1)
            //    {

            //        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Columns[z].Width + 50, height);
            //        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Columns[z].Width + 50, height);

            //        e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, gvOrder.Font, Brushes.Black, realwidth + 20, realheight + 25);
            //        realwidth = realwidth + gvOrder.Columns[z].Width + 50;


            //    }
            //    else
            //    {
            //        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Columns[z].Width, height);
            //        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Columns[z].Width, height);

            //        e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, gvOrder.Font, Brushes.Black, realwidth + 20, realheight + 25);
            //        realwidth = realwidth + gvOrder.Columns[z].Width;
            //    }

            //}
            for (z = 0; z < gvOrder.Columns.Count - 1; z++)
            {
                if (z == gvOrder.Columns.Count - 2)
                {
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, 250, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, 250, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 20, TitlePosheight + 5);
                    realwidth = realwidth + 250;

                }
                else if (z == 1)
                {

                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 50, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 50, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 20, TitlePosheight + 5);
                    realwidth = realwidth + gvOrder.Columns[z].Width + 50;


                }
                else if (z == 2)
                {

                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 80, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 80, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 20, TitlePosheight + 5);
                    realwidth = realwidth + gvOrder.Columns[z].Width + 80;


                }
                else if (z == 3)
                {

                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, 150, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, 150, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 20, TitlePosheight + 5);
                    realwidth = realwidth + 150;


                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, gvOrder.Columns[z].Width, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, gvOrder.Columns[z].Width, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 10, TitlePosheight + 5);
                    realwidth = realwidth + gvOrder.Columns[z].Width;
                }

            }
            z = 0;
            realheight = realheight + Titleheight-20;
           
            while (rowCounter < gvOrder.Rows.Count - 1)
            {
                realwidth = 20;

                {
                    if (gvOrder.Rows[rowCounter].Cells[0].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[0].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);

                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[0].Value.ToString(), drawFont, Brushes.Black, realwidth + 10, realheight + 80);
                    realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[0].Size.Width;

                    if (gvOrder.Rows[rowCounter].Cells[1].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[1].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);

                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[1].Value.ToString(), drawFont, Brushes.Black, realwidth + 20, realheight + 80);

                    realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50;
                    ///
                    if (gvOrder.Rows[rowCounter].Cells[2].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[2].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[2].Size.Width + 80, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[2].Size.Width + 80, height);

                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[2].Value.ToString(), drawFont, Brushes.Black, realwidth + 20, realheight + 80);

                    realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[2].Size.Width + 80;
                    ///
                    if (gvOrder.Rows[rowCounter].Cells[3].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[3].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, 150, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 150, height);
                    RectangleF rcf = new RectangleF(new PointF(realwidth + 10, realheight + 10), new Size(130, height));

                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), drawFont, Brushes.Black, rcf);
                    //e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), drawFont, Brushes.Black, realwidth + 20, realheight + 50);

                    realwidth = realwidth + 150;

                    try
                    {
                        if (gvOrder.Rows[rowCounter].Cells[4].Value == null)
                        {
                            gvOrder.Rows[rowCounter].Cells[4].Value = "";
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 250, height);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth + 10, realheight, 250, height);
                        }
                        else
                        {
                            Image img = gvOrder.Rows[rowCounter].Cells[4].Value as Image;
                            if (img != null)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 250, height);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 250, height);
                                e.Graphics.DrawImage(img, realwidth + 10, realheight + 5, 220, height - 10);
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    //e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + 250;

                }
                rowCounter++;
                e.Graphics.DrawString("Pages  " + (CurPages + 1).ToString() + "/" + AllPages.ToString(), TitleFont, Brushes.Black, 500, 100);

                realheight = realheight + height;
                pageOffset = realheight;


                if (pageOffset >= 1070)
                {
                    realheight = realheight + pageOffset;
                    if (rowCounter == gvOrder.Rows.Count - 1)
                    {
                        //No data

                        return;
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                    CurPages++;
                    pageOffset = 0;
                    return;
                }
                else
                {
                    e.HasMorePages = false;

                }

            }

            //while (rowCounter < gvOrder.Rows.Count)
            //{
            //    realwidth = 100;

            //    // if (columnsToPrint[rowCounter] == true)
            //    {
            //        //if ((f.checkBox8.Checked == true) || (f.checkBox1.Checked))
            //        //{
            //        if (gvOrder.Rows[rowCounter].Cells[0].Value == null)
            //        {
            //            gvOrder.Rows[rowCounter].Cells[0].Value = "";
            //        }
            //        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);
            //        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);

            //        e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[0].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth + 20, realheight + 25);
            //        realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[0].Size.Width;

             
            //        if (gvOrder.Rows[rowCounter].Cells[1].Value == null)
            //        {
            //            gvOrder.Rows[rowCounter].Cells[1].Value = "";
            //        }
            //        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);
            //        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);

            //        e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[1].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth + 5, realheight + 25);

            //        realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50;


            //        try
            //        {
            //            if (gvOrder.Rows[rowCounter].Cells[2].Value == null)
            //            {
            //                gvOrder.Rows[rowCounter].Cells[2].Value = "";
            //                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 400, height);
            //                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 400, height);
            //            }
            //            else
            //            {
            //                Image img = gvOrder.Rows[rowCounter].Cells[2].Value as Image;
            //                if (img != null)
            //                {
            //                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 400, height);
            //                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 400, height);
            //                    e.Graphics.DrawImage(img, realwidth + 5, realheight + 5, 200, height - 5);
            //                }
            //            }
            //        }
            //        catch (Exception)
            //        {

            //            throw;
            //        }

            //        //e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth, realheight);
            //        realwidth = realwidth + 400;

           
            //    }
            //    ++rowCounter;
            //    realheight = realheight + height;

            //}

  
        }

        private void printDocument1_PrintPage2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            
            int AllPages = 0;
            int pageOffset = 0;
            int z = 0;
            StringFormat str = new StringFormat();
            str.Alignment = StringAlignment.Near;
            str.LineAlignment = StringAlignment.Center;
            str.Trimming = StringTrimming.EllipsisCharacter;

            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;  

            int width = 500 / (gvOrder.Columns.Count - 2);
            int realwidth = 20;
            int Titleheight = 40;
            int TitlePosheight = 130;
            int height = 180;

            int realheight = 150;
            Font TitleFont = new Font("微軟正黑體", 14, FontStyle.Bold);

            Font drawFont = new Font("微軟正黑體", 12);
            Font fTitle = new System.Drawing.Font("微軟正黑體", 36, FontStyle.Bold);
            Image imgHeader = TonChe_Operation_Cneter.Properties.Resources.banner;//Image.FromFile(@"\Picture\TONCHE_MARK.jpg");
            //imgHeader. = imgHeader.Height * 80 / 100;
            //e.Graphics.DrawImage(imgHeader, 150, 0, imgHeader.Width * 80 / 100, imgHeader.Height * 80 / 100);
            e.Graphics.DrawImage(imgHeader, 2, 10, imgHeader.Width * 35 / 100, imgHeader.Height * 35 / 100);
            e.Graphics.DrawString("Customer Name:" + tb_customer.Text, TitleFont, Brushes.Black, 20, 100);
            
            
           

            // Please note this is where I am Printing Sunday , Monday , Tuesday.... We can also move rowCounter to 
            // the maxRowcounter loop where we are printing below 
            for (z = 0; z < gvOrder.Columns.Count - 1; z++)
            {
                if (z == gvOrder.Columns.Count - 2)
                {
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, 250, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, 250, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth+20, TitlePosheight+5);
                    realwidth = realwidth + 250;

                }
                else if (z == 1)
                {

                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 50, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 50, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 20, TitlePosheight+5);
                    realwidth = realwidth + gvOrder.Columns[z].Width + 50;


                }
                else if (z == 2)
                {

                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 80, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, gvOrder.Columns[z].Width + 80, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 20, TitlePosheight+5);
                    realwidth = realwidth + gvOrder.Columns[z].Width + 80;


                }
                else if (z == 3)
                {

                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, 150, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, 150, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 20, TitlePosheight + 5);
                    realwidth = realwidth + 150;


                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, TitlePosheight, gvOrder.Columns[z].Width, Titleheight);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, TitlePosheight, gvOrder.Columns[z].Width, Titleheight);

                    e.Graphics.DrawString(gvOrder.Columns[z].HeaderText, TitleFont, Brushes.Black, realwidth + 10, TitlePosheight+5);
                    realwidth = realwidth + gvOrder.Columns[z].Width;
                }

            }

            z = 0;
            realheight = 0;// TitlePosheight;

            AllPages = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal((Decimal)(gvOrder.Rows.Count-1) / 5)));

            while (rowCounter < gvOrder.Rows.Count-1)
            {
                realwidth = 20;

                {
                    if (gvOrder.Rows[rowCounter].Cells[0].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[0].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);

                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[0].Value.ToString(), drawFont, Brushes.Black, realwidth + 10, realheight + 80);
                    realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[0].Size.Width;

                    if (gvOrder.Rows[rowCounter].Cells[1].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[1].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);

                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[1].Value.ToString(), drawFont, Brushes.Black, realwidth + 20, realheight + 80);

                    realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50;
                    ///
                    if (gvOrder.Rows[rowCounter].Cells[2].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[2].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[2].Size.Width + 80, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[2].Size.Width + 80, height);

                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[2].Value.ToString(), drawFont, Brushes.Black, realwidth + 20, realheight + 80);

                    realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[2].Size.Width + 80;
                    ///
                    if (gvOrder.Rows[rowCounter].Cells[3].Value == null)
                    {
                        gvOrder.Rows[rowCounter].Cells[3].Value = "";
                    }
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, 150, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight,150, height);
                    RectangleF rcf = new RectangleF(new PointF(realwidth+10, realheight+10), new Size(130, height));
                    
                    e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), drawFont, Brushes.Black, rcf);
                    //e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), drawFont, Brushes.Black, realwidth + 20, realheight + 50);

                    realwidth = realwidth + 150;
             
                    try
                    {
                        if (gvOrder.Rows[rowCounter].Cells[4].Value == null)
                        {
                            gvOrder.Rows[rowCounter].Cells[4].Value = "";
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 250, height);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth + 10, realheight, 250, height);
                        }
                        else
                        {
                            Image img = gvOrder.Rows[rowCounter].Cells[4].Value as Image;
                            if (img != null)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 250, height);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 250, height);
                                e.Graphics.DrawImage(img, realwidth + 10, realheight + 5, 220, height - 10);
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    //e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + 250;

                }
                ++rowCounter;

                realheight = realheight+ height;
                pageOffset = realheight;

                e.Graphics.DrawString("Pages  " + (CurPages+1).ToString() + "/" + AllPages.ToString(), TitleFont, Brushes.Black, 500, 100);
                
                if (pageOffset >= 1070)
                {
                    realheight = realheight + pageOffset;
                    if (rowCounter == gvOrder.Rows.Count - 1)
                    {
                        //No data
                        return;
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                    CurPages++;
                    pageOffset = 0;
                    return;
                }
                else
                {
                    e.HasMorePages = false;

                }
            }

            #region PageMode
            //z = 0;
            //realheight = realheight + height;

            ////int pages = gvOrder.Rows.Count/5;
            //int IniIdx = 0;
            ////for (int a = 0; a < pages; a++)
            ////{
               
            //    int rowInd = IniIdx;
            //    for (int ii = rowInd; ii < rowInd + 5; rowInd++)
            //    {
            //        realwidth = 100;
            //        if (gvOrder.Rows[ii].Cells[0].Value == null)
            //        {
            //            gvOrder.Rows[a].Cells[0].Value = "";
            //        }
            //        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[ii].Cells[0].Size.Width, height);
            //        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[ii].Cells[0].Size.Width, height);

            //        e.Graphics.DrawString(gvOrder.Rows[ii].Cells[0].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth + 20, realheight + 25);
            //        realwidth = realwidth + gvOrder.Rows[ii].Cells[0].Size.Width;

            //        if (gvOrder.Rows[ii].Cells[1].Value == null)
            //        {
            //            gvOrder.Rows[ii].Cells[1].Value = "";
            //        }
            //        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[ii].Cells[1].Size.Width + 50, height);
            //        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[ii].Cells[1].Size.Width + 50, height);

            //        e.Graphics.DrawString(gvOrder.Rows[ii].Cells[1].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth + 5, realheight + 25);

            //        realwidth = realwidth + gvOrder.Rows[ii].Cells[1].Size.Width + 50;

            //        try
            //        {
            //            if (gvOrder.Rows[ii].Cells[2].Value == null)
            //            {
            //                gvOrder.Rows[ii].Cells[2].Value = "";
            //                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 200, height);
            //                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 200, height);
            //            }
            //            else
            //            {
            //                Image img = gvOrder.Rows[ii].Cells[2].Value as Image;
            //                if (img != null)
            //                {
            //                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 200, height);
            //                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 200, height);
            //                    e.Graphics.DrawImage(img, realwidth + 5, realheight + 5, 100, height - 5);
            //                }
            //            }
            //        }
            //        catch (Exception)
            //        {

            //            throw;
            //        }


            //    }

            #endregion
            //IniIdx = IniIdx;
                //e.HasMorePages = true;

            //}
            //realwidth = realwidth + 400;


            /*
                while (rowCounter < gvOrder.Rows.Count)
                {
                    realwidth = 100;

                    // if (columnsToPrint[rowCounter] == true)
                    {
                        //if ((f.checkBox8.Checked == true) || (f.checkBox1.Checked))
                        //{
                        if (gvOrder.Rows[rowCounter].Cells[0].Value == null)
                        {
                            gvOrder.Rows[rowCounter].Cells[0].Value = "";
                        }
                        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[0].Size.Width, height);

                        e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[0].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth + 20, realheight + 25);
                        realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[0].Size.Width;

                        //}
                        //else
                        //{
                        //    realwidth = realwidth + width;
                        //}
                        //if ((f.checkBox8.Checked == true) || (f.checkBox2.Checked))
                        //{
                        if (gvOrder.Rows[rowCounter].Cells[1].Value == null)
                        {
                            gvOrder.Rows[rowCounter].Cells[1].Value = "";
                        }
                        e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50, height);

                        e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[1].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth + 5, realheight + 25);

                        realwidth = realwidth + gvOrder.Rows[rowCounter].Cells[1].Size.Width + 50;



                        try
                        {
                            if (gvOrder.Rows[rowCounter].Cells[2].Value == null)
                            {
                                gvOrder.Rows[rowCounter].Cells[2].Value = "";
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 400, height);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 400, height);
                            }
                            else
                            {
                                Image img = gvOrder.Rows[rowCounter].Cells[2].Value as Image;
                                if (img != null)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, 400, height);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, 400, height);
                                    e.Graphics.DrawImage(img, realwidth + 5, realheight + 5, 200, height - 5);
                                }
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        //e.Graphics.DrawString(gvOrder.Rows[rowCounter].Cells[3].Value.ToString(), gvOrder.Font, Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + 400;


                    }
                    ++rowCounter;
                    realheight = realheight + height;



                    //if (realheight >= pageHeight)
                    //{
                    //    e.HasMorePages = true;
                    //    realheight = 0;
                    //    //return; // you need to return, then it will go into this function again
                    //}
                    //else
                    //{
                    //    e.HasMorePages = false;
                    //}
                }
            */
            //e.Graphics.DrawString("Ton Che" + tb_customer.Text, gvOrder.Font, Brushes.Black, 50, 50);

            //printDialog1.Document = printDocument1;
            //printPreviewDialog1.Document = printDocument1;

            //printPreviewDialog1.ShowDialog();
            //printDialog1.ShowDialog();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSelectionl();
        }

        //public static int GetPageCount(PrintDocument printDocument)
        //{
        //    int count = 0;
        //    printDocument.PrintController = new PreviewPrintController();
        //    printDocument.PrintPage += (sender, e) => count++;
        //    printDocument.Print();
        //    return count;
        //}
   
    }
}
