using DevExpress.XtraCharts;
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

namespace TonChe_Operation_Cneter
{
    public partial class frminsSummary : Form
    {
        private DB_Access dbTool = new DB_Access();
        public frminsSummary()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadInsData(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadInsSummary(dateTimePicker1.Value, dateTimePicker2.Value);
            //DrawRate(dateTimePicker1.Value, dateTimePicker2.Value);
            //DrawBar(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void LoadInsSummary(DateTime dt1, DateTime dt2)
        {
            string ssql = SQL_TEXT.Q_SEARCH_INS_SUMMARY;

            ssql = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            ssql = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));

            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                Dictionary<string, int> dLength = new Dictionary<string, int>();
                for (int i = 0; i < dtRet.Rows.Count; i++)
                {
                    dLength.Add(dtRet.Rows[i]["GRADE"].ToString(), (int)dtRet.Rows[i]["LENGTH"]);
                    //if (dtRet.Rows[i]["GRADE"].ToString() == "A")
                    //{
                    //    if (!String.IsNullOrEmpty(dtRet.Rows[i]["LENGTH"].ToString()))
                    //    {
                    //        lbA.Text = dtRet.Rows[i]["LENGTH"].ToString();
                    //    }
                    //}
                    //if (dtRet.Rows[i]["GRADE"].ToString() == "B")
                    //{
                    //    if (!String.IsNullOrEmpty(dtRet.Rows[i]["LENGTH"].ToString()))
                    //    {
                    //        lbB.Text = dtRet.Rows[i]["LENGTH"].ToString();
                    //    }
                    //}
                    //if (dtRet.Rows[i]["GRADE"].ToString() == "C")
                    //{
                    //    if (!String.IsNullOrEmpty(dtRet.Rows[i]["LENGTH"].ToString()))
                    //    {
                    //        lbC.Text = dtRet.Rows[i]["LENGTH"].ToString();
                    //    }
                    //}
                }


                foreach (KeyValuePair<string, int> kvp in dLength)
                {
                    switch (kvp.Key)
                    {
                        case  "A":
                            lbA.Text = kvp.Value.ToString();
                            break;

                        case "B":
                            lbB.Text = kvp.Value.ToString();
                            break;

                        case "C":
                            lbC.Text = kvp.Value.ToString();
                            break;

                        default:
                            lbA.Text = "0";
                            lbB.Text = "0";
                            lbC.Text = "0";
                            break;

                    }
                }
            }

        }

        private void LoadInsData(DateTime dt1, DateTime dt2)
        {
            string ssql = SQL_TEXT.Q_SAERCH_INS;

            //string ssql2 = SQL_TEXT.Q_SAERCH_INS_OUTPUT;

            ssql = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            ssql = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));

            //ssql2 = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            //ssql2 = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));

            DataTable dtRet = dbTool.QueryData(ssql);
            //DataTable dtOutput = dbTool.QueryData(ssql2);

            DataTable dtGroup = dtRet.DefaultView.ToTable(true, "GRADE");
            dtGroup.Columns.Add("SumColumn");

            int count = 0;

            //for (int i = 0; i < dtGroup.Rows.Count; i++)
            //{
            //    //取資料，用String是因為上方加欄位時，沒指定型別為數字

            //    string strSum = dtRet.Compute("SUM(LENGTH_OUTPUT)", "GRADE='" + dtGroup.Rows[i]["GRADE"].ToString() + "'").ToString();
      

            //    //設定資料
            //    dtGroup.Rows[i]["SumColumn"] = (strSum == "" ? "0" : strSum);
               
            //}


            DataTable dtShow = new DataTable();

            for (int i = 0; i < dtRet.Columns.Count; i++)
            {
                if (i == 0)
                {
                    DataColumn c0 = new DataColumn("日期");
                    DataColumn c1 = new DataColumn("布號");
                    DataColumn c2 = new DataColumn("疋號");
                    DataColumn c3 = new DataColumn("機台");
                    DataColumn c4 = new DataColumn("缺失");
                    dtShow.Columns.Add(c0);
                    dtShow.Columns.Add(c1);
                    dtShow.Columns.Add(c2);
                    dtShow.Columns.Add(c3);
                    dtShow.Columns.Add(c4);
                }
                else
                {
                    if (dtRet.Columns[i].ColumnName.Contains("C"))
                    {
                        DataColumn c1 = new DataColumn("C" + i.ToString());
                        dtShow.Columns.Add(c1);
                    }
                }

            }

            DataColumn c5 = new DataColumn("總分");
            DataColumn c6 = new DataColumn("等級");
            DataColumn c7 = new DataColumn("疋長");
            DataColumn c8 = new DataColumn("總長度");
            DataColumn c9 = new DataColumn("驗布員");
            dtShow.Columns.Add(c5);
            dtShow.Columns.Add(c6);
            dtShow.Columns.Add(c7);
            dtShow.Columns.Add(c8);
            dtShow.Columns.Add(c9);



            foreach (DataRow dr in dtRet.Rows)
            {
                string[] INS_NO = dr[0].ToString().Split('_');
                DataRow drNew = dtShow.NewRow();
                DataRow drR = dtShow.NewRow();
                DataRow drPTS = dtShow.NewRow();

                DataRow drSplitter = dtShow.NewRow();


                drR[0] = INS_NO[0];//Date
                drR[1] = INS_NO[1];//ART NO
                drR[3] = INS_NO[2];//EQP NO
                drR[2] = INS_NO[3] + "_" + INS_NO[4];//INS NO

                //drR[0] = INS_NO[0];//Date
                //drR[1] = INS_NO[1];//ART NO
                //drR[2] = INS_NO[2];//EQP NO

                //drPTS[0] = INS_NO[0];//Date
                //drPTS[1] = INS_NO[1];//ART NO
                //drPTS[2] = INS_NO[2];//EQP NO

                drR[4] = "缺失";
                drNew[4] = "檢查點";
                drPTS[4] = "扣分";


                for (int i = 0; i < 12; i++)
                {
                    string[] INS_DATA = dr[i + 1].ToString().Split('_');
                    if (INS_DATA.Length > 1)
                    {
                        drNew[i + 5] = INS_DATA[0].ToString();
                        drR[i + 5] = INS_DATA[1].ToString();
                        drPTS[i + 5] = INS_DATA[2].ToString();

                    }
                }

                drR[17] = dr[13].ToString();
                drR[18] = dr[14].ToString();

                //DataRow[] drOutput = dtOutput.Select("INS_NO=" + drR[2].ToString());
                //drR[19] = (Convert.ToInt32(drOutput[4].ToString()) - Convert.ToInt32(drOutput[3].ToString()) + 1).ToString();

                drR[19] = dr[16].ToString();
                drR[20] = dr[15].ToString();
                drR[21] = dr[17].ToString();

                //drR[20] = dr[13].ToString();
                //drR[21] = dr[14].ToString();
                //drR[22] = dr[15].ToString();
                //drR[23] = dr[16].ToString();

                //drPTS[20] = dr[13].ToString();
                //drPTS[21] = dr[14].ToString();
                //drPTS[22] = dr[15].ToString();
                //drPTS[23] = dr[16].ToString();

                dtShow.Rows.Add(drNew);
                dtShow.Rows.Add(drR);
                dtShow.Rows.Add(drPTS);
                dtShow.Rows.Add(drSplitter);
            }

            //dtShow.Rows.RemoveAt(dtShow.Rows.Count-1);
            dgvIns.DataSource = dtShow;
            dgvIns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvIns.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            for (int i = 0; i < dgvIns.Rows.Count; i++)
            {
                if (i % 4 == 0 && i >= 4)
                {
                    dgvIns.Rows[i - 1].Height = dgvIns.Rows[i - 1].Height / 4;
            
                }
            }

            foreach (DataGridViewColumn dc in dgvIns.Columns)
            {
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dc.HeaderText == "疋號" || dc.HeaderText == "布號" || dc.HeaderText == "日期" || dc.HeaderText == "機台" || dc.HeaderText == "總分" || dc.HeaderText == "長度" || dc.HeaderText == "品檢員")
                {
                    dc.DefaultCellStyle.Font = new Font("微軟正黑體", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                    dc.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (dc.HeaderText == "等級")
                {
                    dc.DefaultCellStyle.Font = new Font("微軟正黑體", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
                    //foreach (DataGridViewRow dr in dgvIns.Rows)
                    foreach (DataGridViewRow dr in dgvIns.Rows)
                    {
                        //if (dr.HeaderCell.Value.ToString() == dc.HeaderText)

                        if (dr.Cells[dc.HeaderText].Value != null)
                        {
                            switch (dr.Cells[dc.HeaderText].Value.ToString())
                            {
                                case "A":
                                    dr.Cells[dc.HeaderText].Style.ForeColor = Color.Blue;
                                    break;
                                case "B":
                                    dr.Cells[dc.HeaderText].Style.ForeColor = Color.Orange;
                                    break;
                                case "C":
                                    dr.Cells[dc.HeaderText].Style.ForeColor = Color.Red;
                                    break;
                                default:
                                    dr.Cells[dc.HeaderText].Style.ForeColor = Color.Black;
                                    break;
                            }
                        }


                    }

                }
                else
                {
                    dc.DefaultCellStyle.Font = new Font("微軟正黑體", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                    dc.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
            dgvIns.AllowUserToAddRows = false;
            //gridControl2.DataSource = dtShow;

            //GridView gv = (GridView)gridControl2.Views[0];
            //gv.OptionsView.AllowCellMerge = true;

            //gv.Columns[0].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

        }

        /*
        private void DrawRate(DateTime dt1, DateTime dt2)
        {
            string ssql = SQL_TEXT.Q_EQP_ERROR;

            ssql = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            ssql = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));

            DataTable dtRet = dbTool.QueryData(ssql);
            cEQP.Series.Clear();

            Series series = new Series("機台", ViewType.Pie);
            cEQP.Series.Add(series);
            foreach (DataRow dr in dtRet.Rows)
            {
                series.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1]));
            }

            series.Label.TextPattern = "{A}: {VP:p0}";
            // Adjust the position of series labels. 
            ((PieSeriesLabel)series.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels.
            ((PieSeriesLabel)series.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series.
            PieSeriesView myView = (PieSeriesView)series.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series.Name;

            // Specify a data filter to explode points.
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.RuntimeExploding = true;
            myView.HeightToWidthRatio = 0.75;

            // Hide the legend (if necessary).
            cEQP.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add the chart to the form.
            cEQP.Dock = DockStyle.Fill;

            //cEQP.Series.Clear();
            //Series series = new Series("Series1", ViewType.Pie);
            //cEQP.Series.Add(series);
            //series.DataSource = dtRet;
            //series.ArgumentScaleType = ScaleType.Auto;
            //series.ArgumentDataMember = "R";

            //series.ValueScaleType = ScaleType.Numerical;
            //series.ValueDataMembers.AddRange(new string[] { "CNT" });

            //cEQP.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            //cEQP.Dock = DockStyle.Fill;

        }
        */
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lTotal_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvIns_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            if ((e.RowIndex+1) % 4 == 0 && (e.RowIndex+1) >= 4)
            {
               // int r = e.RowIndex - 1;
                Rectangle newRect = new Rectangle(e.CellBounds.X ,
               e.CellBounds.Y , e.CellBounds.Width ,
               e.CellBounds.Height );

                using (
                Brush gridBrush = new SolidBrush(dgvIns.GridColor),
                backColorBrush = new SolidBrush(e.CellStyle.BackColor),
                FillBrush = new SolidBrush(Color.SkyBlue))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        // Draw the grid lines (only the right and bottom lines;
                        // DataGridView takes care of the others).

                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                        // Draw the inset highlight box.
                        //e.Graphics.DrawRectangle(Pens.Blue, newRect);
                        e.Graphics.FillRectangle(FillBrush, newRect);

                        // Draw the text content of the cell, ignoring alignment.
                        //if (e.Value != null)
                        //{
                        //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                        //        Brushes.Black, e.CellBounds.X + 2,
                        //        e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        //}
                        e.Handled = true;
                    }

                }
            }
        }

       /*
        private void DrawBar(DateTime dt1, DateTime dt2)
        {
            string ssql = SQL_TEXT.Q_GRADE_SUMMARY_A;

            ssql = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            ssql = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));
            DataTable dtRet_A = dbTool.QueryData(ssql);

            ssql = SQL_TEXT.Q_GRADE_SUMMARY_B;
            ssql = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            ssql = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));
            DataTable dtRet_B = dbTool.QueryData(ssql);

            ssql = SQL_TEXT.Q_GRADE_SUMMARY_C;
            ssql = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            ssql = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));
            DataTable dtRet_C = dbTool.QueryData(ssql);


            cGradeSummary.Series.Clear();

            Series seriesA = new Series("A", ViewType.Bar);
            Series seriesB = new Series("B", ViewType.Bar);
            Series seriesC = new Series("C", ViewType.Bar);

            cGradeSummary.Series.Add(seriesA);
            cGradeSummary.Series.Add(seriesB);
            cGradeSummary.Series.Add(seriesC);

            seriesA.DataSource = dtRet_A;
            seriesB.DataSource = dtRet_B;
            seriesC.DataSource = dtRet_C;


            seriesA.ArgumentScaleType = ScaleType.DateTime;
            seriesA.ArgumentDataMember = "DT";
            seriesA.ValueScaleType = ScaleType.Numerical;
            seriesA.ValueDataMembers.AddRange(new string[] { "LENGTH" });


            seriesB.ArgumentScaleType = ScaleType.DateTime;
            seriesB.ArgumentDataMember = "DT";
            seriesB.ValueScaleType = ScaleType.Numerical;
            seriesB.ValueDataMembers.AddRange(new string[] { "LENGTH" });


            seriesC.ArgumentScaleType = ScaleType.DateTime;
            seriesC.ArgumentDataMember = "DT";
            seriesC.ValueScaleType = ScaleType.Numerical;
            seriesC.ValueDataMembers.AddRange(new string[] { "LENGTH" });
            //cGradeSummary.SeriesDataMember = "DT";
            //cGradeSummary.SeriesTemplate.ArgumentDataMember = "GRADE";
            //cGradeSummary.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "LENGTH" });
            // Specify the template's series view.
            cGradeSummary.SeriesTemplate.View = new StackedBarSeriesView();

            // Specify the template's name prefix.
            cGradeSummary.SeriesNameTemplate.BeginText = "Month: ";
            cGradeSummary.Dock = DockStyle.Fill;


        }
         
        */

    
    }
}
