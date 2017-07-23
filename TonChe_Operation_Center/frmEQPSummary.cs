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
        public frmEQPSummary()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string ssql = SQL_TEXT.Q_EQPSummary_By_Date;

            //ssql = ssql.Replace(":dt1", dt1.ToString("yyyyMMdd"));
            //ssql = ssql.Replace(":dt2", dt2.ToString("yyyyMMdd"));

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
        }

    }
}

