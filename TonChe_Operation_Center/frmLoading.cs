using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Database;

namespace TonChe_Operation_Cneter
{
    public partial class frmLoading : Form
    {
        private static DB_Access db_tool = new DB_Access();
        private int ART_CNT = 0;

        public frmLoading()
        {
            InitializeComponent();

            string sql = SQL_TEXT.Q_ART_CNT;
            DataTable dtRet = new DataTable();
            
            try
            {
                //dtRet = db_tool.QueryData(sql);
                //ART_CNT = Int32.Parse(dtRet.Rows[0]["CNT"].ToString());
            }
            catch (Exception)
            {

            }               
            progressBar1.Value = 0;
            timer1.Stop();
            timer1.Interval = 1;
            progressBar1.Maximum = 160;
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value = progressBar1.Value + 1;
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }

  
    }
}
