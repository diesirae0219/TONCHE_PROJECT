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
    public partial class frmEQPSummary : Form
    {
        private DB_Access dbTool = new DB_Access();
        public string[] Today = new string[3];
        private Dictionary<string,string> dInDateData = new Dictionary<string,string>();
        public frmEQPSummary()
        {
            InitializeComponent();
            GetToday();
            RefreshcbArtNO();
            RefreshcbEQPID();
        }

        //Ini today
        private void GetToday()
        {
            int year = Int32.Parse(DateTime.Now.ToString("yyyy")) - 1911;
            Today[0] = year.ToString();
            string Mon = DateTime.Now.ToString("MM");
            Today[1] = Mon;
            string Day = DateTime.Now.ToString("dd");
            Today[2] = Day;
            int month = Int32.Parse(Mon);
            int LastDay = DateTime.DaysInMonth(Int32.Parse(DateTime.Now.ToString("yyyy")), month);
            dtStart.Value = Convert.ToDateTime(Mon + "/01/" + DateTime.Now.ToString("yyyy"));
            dtEnd.Value = Convert.ToDateTime(Mon + "/" + LastDay.ToString() + "/" + DateTime.Now.ToString("yyyy"));   
        }


        private void LoadEQPDataBy1Date(string Date)
        {
            //1.Create table
            string ssql = SQL_TEXT.Q_EQPSummary_By_1Date;
            ssql = ssql.Replace(":dt1", Date);

            if (cbART_NO.Text != "顯示全部" && !String.IsNullOrEmpty(cbART_NO.Text))
            {
                ssql = ssql.Replace(" --#prod_id#", " and prod_id = '" + cbART_NO.Text + "' ");
            }
            if (cbEQP_ID.Text != "顯示全部" && !String.IsNullOrEmpty(cbEQP_ID.Text))
            {
                ssql = ssql.Replace(" --#eqp_id#", " and eqp_id = '" + cbEQP_ID.Text + "' ");
            }
              DataTable dtRet = dbTool.QueryData(ssql);
              DataTable dtShow = new DataTable();
              if (dtRet.Rows.Count > 0)
              {
                  //機號	布   號	RPM	緯	抄表	%		折算碼	產量		工 繳	停台原因	%
                  DataColumn c0 = new DataColumn("機號");
                  DataColumn c1 = new DataColumn("布號");
                  DataColumn c2 = new DataColumn("RPM");
                  DataColumn c3 = new DataColumn("緯密");
                  DataColumn c4 = new DataColumn("班別");
                  DataColumn c5 = new DataColumn("抄表");
                  DataColumn c6 = new DataColumn("效率%");
                  DataColumn c7 = new DataColumn("折算碼");
                  DataColumn c8 = new DataColumn("產量");
                  DataColumn c9 = new DataColumn("工繳");
                  DataColumn c10 = new DataColumn("停台原因");
                  dtShow.Columns.Add(c0);
                  dtShow.Columns.Add(c1);
                  dtShow.Columns.Add(c2);
                  dtShow.Columns.Add(c3);
                  dtShow.Columns.Add(c4);
                  dtShow.Columns.Add(c5);
                  dtShow.Columns.Add(c6);
                  dtShow.Columns.Add(c7);
                  dtShow.Columns.Add(c8);
                  dtShow.Columns.Add(c9);
                  dtShow.Columns.Add(c10);

                  foreach (DataRow dr in dtRet.Rows)
                  {
                      //string[] INS_NO = dr[0].ToString().Split('_');
                      DataRow drA = dtShow.NewRow();
                      //DataRow drB = dtShow.NewRow();
                     // DataRow drC = dtShow.NewRow();

                      //DataRow drSplitter = dtShow.NewRow();
                      for (int i = 0; i < dtRet.Columns.Count; i++)
                      {
                          drA[i] = dr[i];//EQP_ID                    
                      }
                      dtShow.Rows.Add(drA);

                      
                  }
                  dgv1Date.DataSource = dtShow;

              }

            //2.Load summary data
              LoadInDateSummaryData(Date);
              foreach (KeyValuePair<string, string> obj in dInDateData)
              {
                  if (obj.Key.Contains("-AEFF"))
                  {
                      lbA_Eff.Text = obj.Value;
                  }
                  if (obj.Key.Contains("-BEFF"))
                  {
                      lbB_Eff.Text = obj.Value;
                  }
                  if (obj.Key.Contains("-CEFF"))
                  {
                      lbC_Eff.Text = obj.Value;
                  }

                  if (obj.Key.Contains("-AQTY"))
                  {
                      lbA_Qty.Text = obj.Value;
                  }
                  if (obj.Key.Contains("-BQTY"))
                  {
                      lbB_Qty.Text = obj.Value;
                  }
                  if (obj.Key.Contains("-CQTY"))
                  {
                      lbC_Qty.Text = obj.Value;
                  }

                  if (obj.Key.Contains("-ALLEFF"))
                  {
                      lbAll_Eff.Text = obj.Value;
                  }
                  if (obj.Key.Contains("-ALLQTY"))
                  {
                      lbAll_Qty.Text = obj.Value;
                  }
                  if (obj.Key.Contains("-ALLRPM"))
                  {
                      lbAll_RPM.Text = obj.Value;
                  }
                  if (obj.Key.Contains("-ALLEARN"))
                  {
                      lbTotal_earn.Text = obj.Value;
                  }
              }
        }

        private void LoadInDateSummaryData(string Date)
        {
            dInDateData.Clear();
            string ssql = SQL_TEXT.Q_EQPSummary_By_1Date_ByShift;
            ssql = ssql.Replace(":dt1", Date);
            if (cbART_NO.Text != "顯示全部" && !String.IsNullOrEmpty(cbART_NO.Text))
            {
                ssql = ssql.Replace(" --#prod_id#", " and prod_id = '" + cbART_NO.Text + "' ");
            }
            if (cbEQP_ID.Text != "顯示全部" && !String.IsNullOrEmpty(cbEQP_ID.Text))
            {
                ssql = ssql.Replace(" --#eqp_id#", " and eqp_id = '" + cbEQP_ID.Text + "' ");
            }
            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                foreach (DataRow dr in dtRet.Rows)
                {
                    dInDateData.Add(dr[0].ToString() + "-" + dr[0].ToString() + "EFF", dr[1].ToString());
                    dInDateData.Add(dr[0].ToString()+"-"+dr[0].ToString()+"QTY", dr[2].ToString());
                }
            }

            string ssql2 = SQL_TEXT.Q_EQPSummary_By_1Date_ByAll;
            ssql2 = ssql2.Replace(":dt1", Date);
            if (cbART_NO.Text != "顯示全部" && !String.IsNullOrEmpty(cbART_NO.Text))
            {
                ssql2 = ssql2.Replace(" --#prod_id#", " and prod_id = '" + cbART_NO.Text + "' ");
            }
            if (cbEQP_ID.Text != "顯示全部" && !String.IsNullOrEmpty(cbEQP_ID.Text))
            {
                ssql2 = ssql2.Replace(" --#eqp_id#", " and eqp_id = '" + cbEQP_ID.Text + "' ");
            }
            DataTable dtRet2 = dbTool.QueryData(ssql2);
            if (dtRet2.Rows.Count > 0)
            {
                foreach (DataRow dr in dtRet2.Rows)
                {
                    dInDateData.Add(dr[0].ToString()+"-ALLEFF",dr[0].ToString());
                    dInDateData.Add(dr[0].ToString()+"-ALLQTY", dr[1].ToString());
                    dInDateData.Add(dr[0].ToString() + "-ALLRPM", dr[2].ToString());
                    dInDateData.Add(dr[0].ToString() + "-ALLEARN", dr[3].ToString());
                }
            }            
        }

        private void RefreshcbArtNO()
        {
            string ssql = SQL_TEXT.Q_PROD_ID_By_Date;

            ssql = ssql.Replace(":dt1", dtStart.Value.ToString("yyyy-MM-dd"));
            ssql = ssql.Replace(":dt2", dtEnd.Value.ToString("yyyy-MM-dd"));

            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                cbART_NO.Items.Clear();
                cbART_NO.Items.Add("顯示全部");
                foreach (DataRow dr in dtRet.Rows)
                {
                    cbART_NO.Items.Add(dr[0]);   
                }
                cbART_NO.SelectedIndex = 0;
            }
        }

        private void RefreshcbEQPID()
        {
            string ssql = SQL_TEXT.Q_EQP_ID_By_Date;

            ssql = ssql.Replace(":dt1", dtStart.Value.ToString("yyyy-MM-dd"));
            ssql = ssql.Replace(":dt2", dtEnd.Value.ToString("yyyy-MM-dd"));

            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                cbEQP_ID.Items.Clear();
                cbEQP_ID.Items.Add("顯示全部");
                foreach (DataRow dr in dtRet.Rows)
                {
                    cbEQP_ID.Items.Add(dr[0]);
                }
                cbEQP_ID.SelectedIndex = 0;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //1.Create left table
            string ssql = SQL_TEXT.Q_EQPSummary_By_Date;

            ssql = ssql.Replace(":dt1", dtStart.Value.ToString("yyyy-MM-dd"));
            ssql = ssql.Replace(":dt2", dtEnd.Value.ToString("yyyy-MM-dd"));

            if (cbART_NO.Text != "顯示全部" && !String.IsNullOrEmpty(cbART_NO.Text))
            {
                ssql = ssql.Replace(" --#prod_id#", " and prod_id = '" + cbART_NO.Text + "' ");
            }

            if (cbEQP_ID.Text != "顯示全部" && !String.IsNullOrEmpty(cbEQP_ID.Text))
            {
                ssql = ssql.Replace(" --#eqp_id#", " and prod_id = '" + cbART_NO.Text + "' ");
            }


            DataTable dtRet = dbTool.QueryData(ssql);
            if (dtRet.Rows.Count > 0)
            {
                gvEQPSummary.DataSource = dtRet;

                chart1.Series.Clear();



                Series seriesEff = new Series("效率", ViewType.Line);
                Series seriesQTY = new Series("產量(y)", ViewType.Bar);
                Series seriesEarn = new Series("工繳", ViewType.Line);



                chart1.Series.Add(seriesEff);
                chart1.Series.Add(seriesQTY);
                chart1.Series.Add(seriesEarn);

                foreach (DataRow dr in dtRet.Rows)
                {
                    seriesEff.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1]));
                    seriesQTY.Points.Add(new SeriesPoint(dr[0].ToString(), dr[2]));
                    seriesEarn.Points.Add(new SeriesPoint(dr[0].ToString(), dr[3]));
                }

                // Create two secondary axes, and add them to the chart's Diagram.
                //SecondaryAxisY myAxisX = new SecondaryAxisY("Eff");
                SecondaryAxisY myAxisY = new SecondaryAxisY("Yard");
                SecondaryAxisY myAxisZ = new SecondaryAxisY("NTD");
                ((XYDiagram)chart1.Diagram).SecondaryAxesY.Clear();
                //((XYDiagram)chart1.Diagram).SecondaryAxesY.Add(myAxisX);
                ((XYDiagram)chart1.Diagram).SecondaryAxesY.Add(myAxisY);
                ((XYDiagram)chart1.Diagram).SecondaryAxesY.Add(myAxisZ);

                // Assign the series2 to the created axes.
                //((LineSeriesView)seriesEff.View).AxisY = myAxisX;
                ((BarSeriesView)seriesQTY.View).AxisY = myAxisY;
                ((LineSeriesView)seriesEarn.View).AxisY = myAxisZ;

                // Customize the appearance of the secondary axes (optional).
                myAxisY.Title.Text = "碼";
                myAxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                myAxisY.Title.TextColor = Color.Red;
                myAxisY.Label.TextColor = Color.Red;
                myAxisY.Color = Color.Red;

                myAxisZ.Title.Text = "元";
                myAxisZ.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                myAxisZ.Title.TextColor = Color.Blue;
                myAxisZ.Label.TextColor = Color.Blue;
                myAxisZ.Color = Color.Blue;

                seriesEff.Label.TextPattern = "{A}: {VP:p0}";
                seriesQTY.Label.TextPattern = "{A}: {VP:p0}";
                seriesEarn.Label.TextPattern = "{A}: {VP:p0}";


            }

            //2.Create total avg
            string ssql2 = SQL_TEXT.Q_EQP_AVG_By_Date;

            ssql2 = ssql2.Replace(":dt1", dtStart.Value.ToString("yyyy-MM-dd"));
            ssql2 = ssql2.Replace(":dt2", dtEnd.Value.ToString("yyyy-MM-dd"));

            if (cbART_NO.Text != "顯示全部" && !String.IsNullOrEmpty(cbART_NO.Text))
            {
                ssql2 = ssql2.Replace(" --#prod_id#", " and prod_id = '" + cbART_NO.Text + "' ");
            }

            if (cbEQP_ID.Text != "顯示全部" && !String.IsNullOrEmpty(cbEQP_ID.Text))
            {
                ssql2 = ssql2.Replace(" --#eqp_id#", " and eqp_id = '" + cbEQP_ID.Text + "' ");
            }

              DataTable dtRet2= dbTool.QueryData(ssql2);
              if (dtRet2.Rows.Count > 0)
              {
                  lbSumEarn.Text = dtRet2.Rows[0][0].ToString();
                  lbSumEff.Text = dtRet2.Rows[0][1].ToString();
                  lbSumYards.Text = dtRet2.Rows[0][2].ToString();
                  lbSumRPM.Text = dtRet2.Rows[0][3].ToString();
              }


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadEQPDataBy1Date("2017-08-13");
        }

        ToolTip tooltip = new ToolTip();
        Point? clickPosition = null;
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            ChartHitInfo hi = chart1.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            SeriesPoint point = hi.SeriesPoint;
            if (point != null)
            {
                // Obtain the series point argument.
                string argument =point.Argument.ToString(); //DATE
                DateTime dt = Convert.ToDateTime(argument);
                string InDate = dt.ToString("yyyy-MM-dd");
                lbSelDate.Text = InDate;
                LoadEQPDataBy1Date(InDate);
                // Obtain series point values.
                //string values = "Value(s): " + point.Values[0].ToString();
                //if (point.Values.Length > 1)
                //{
                //    for (int i = 1; i < point.Values.Length; i++)
                //    {
                //        values = values + ", " + point.Values[i].ToString();
                //    }
                //}             
            }
            //Series hitArea = (Series)hi.HitTest.;
            //this.Text = hi.HitTest.ToString();
            //tooltip.Show("X=" + hi.HitTest.ToString(), this.chart1, e.Location.X, e.Location.Y - 15);
            //var pos = e.Location;
            //clickPosition = pos;
            //var results = chart1.HitTest(pos.X, pos.Y);
            //foreach (var result in results)
            //{
            //    if (result. == ChartElementType.PlottingArea)
            //    {
            //        var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
            //        var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

            //        tooltip.Show("X=" + xVal + ", Y=" + yVal,
            //                     this.chart1, e.Location.X, e.Location.Y - 15);
            //    }
            //}
        }

        private void tbART_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            RefreshcbArtNO();
            RefreshcbEQPID();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            RefreshcbArtNO();
            RefreshcbEQPID();
        }

      
    

     

    }
}

