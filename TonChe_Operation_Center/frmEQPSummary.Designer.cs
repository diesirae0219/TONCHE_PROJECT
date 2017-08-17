namespace TonChe_Operation_Cneter
{
    partial class frmEQPSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new DevExpress.XtraCharts.ChartControl();
            this.pnDate = new System.Windows.Forms.Panel();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gvEQPSummary = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv1Date = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSelDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbA_Qty = new System.Windows.Forms.Label();
            this.lbB_Qty = new System.Windows.Forms.Label();
            this.lbC_Qty = new System.Windows.Forms.Label();
            this.lbC_Eff = new System.Windows.Forms.Label();
            this.lbB_Eff = new System.Windows.Forms.Label();
            this.lbA_Eff = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbTotal_earn = new System.Windows.Forms.Label();
            this.lbAll_Eff = new System.Windows.Forms.Label();
            this.lbAll_Qty = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbSumEarn = new System.Windows.Forms.Label();
            this.lbSumYards = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbAll_RPM = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbART_NO = new System.Windows.Forms.ComboBox();
            this.cbEQP_ID = new System.Windows.Forms.ComboBox();
            this.lbEQP_ID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbSumEff = new System.Windows.Forms.Label();
            this.lbSumRPM = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnDate.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEQPSummary)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1Date)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnDate, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.55172F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.44828F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 438F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1144, 725);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1138, 433);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 176);
            this.panel1.TabIndex = 1;
            // 
            // chart1
            // 
            this.chart1.DataBindings = null;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Legend.Name = "Default Legend";
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.RuntimeHitTesting = true;
            this.chart1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chart1.Size = new System.Drawing.Size(1138, 176);
            this.chart1.TabIndex = 0;
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // pnDate
            // 
            this.pnDate.Controls.Add(this.lbSumRPM);
            this.pnDate.Controls.Add(this.label18);
            this.pnDate.Controls.Add(this.lbSumEff);
            this.pnDate.Controls.Add(this.label11);
            this.pnDate.Controls.Add(this.cbEQP_ID);
            this.pnDate.Controls.Add(this.lbEQP_ID);
            this.pnDate.Controls.Add(this.cbART_NO);
            this.pnDate.Controls.Add(this.label12);
            this.pnDate.Controls.Add(this.lbSumYards);
            this.pnDate.Controls.Add(this.lbSumEarn);
            this.pnDate.Controls.Add(this.label9);
            this.pnDate.Controls.Add(this.label8);
            this.pnDate.Controls.Add(this.dtEnd);
            this.pnDate.Controls.Add(this.label2);
            this.pnDate.Controls.Add(this.dtStart);
            this.pnDate.Controls.Add(this.button1);
            this.pnDate.Controls.Add(this.btnQuery);
            this.pnDate.Controls.Add(this.label1);
            this.pnDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDate.Location = new System.Drawing.Point(3, 3);
            this.pnDate.Name = "pnDate";
            this.pnDate.Size = new System.Drawing.Size(1138, 98);
            this.pnDate.TabIndex = 0;
            // 
            // dtEnd
            // 
            this.dtEnd.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtEnd.Location = new System.Drawing.Point(248, 23);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 38);
            this.dtEnd.TabIndex = 6;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(215, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "~";
            // 
            // dtStart
            // 
            this.dtStart.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtStart.Location = new System.Drawing.Point(14, 23);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 38);
            this.dtStart.TabIndex = 4;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // button1
            // 
            this.button1.Image = global::TonChe_Operation_Cneter.Properties.Resources.magnifier13;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1044, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "    查詢";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::TonChe_Operation_Cneter.Properties.Resources.magnifier13;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(461, 23);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(105, 33);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "    總表查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(982, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.88928F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.11072F));
            this.tableLayoutPanel2.Controls.Add(this.gvEQPSummary, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1138, 433);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // gvEQPSummary
            // 
            this.gvEQPSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEQPSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvEQPSummary.Location = new System.Drawing.Point(3, 3);
            this.gvEQPSummary.Name = "gvEQPSummary";
            this.gvEQPSummary.RowTemplate.Height = 27;
            this.gvEQPSummary.Size = new System.Drawing.Size(300, 427);
            this.gvEQPSummary.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dgv1Date, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(309, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.48244F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.51756F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(826, 427);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // dgv1Date
            // 
            this.dgv1Date.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1Date.Location = new System.Drawing.Point(3, 98);
            this.dgv1Date.Name = "dgv1Date";
            this.dgv1Date.RowTemplate.Height = 27;
            this.dgv1Date.Size = new System.Drawing.Size(820, 326);
            this.dgv1Date.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lbAll_RPM);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.lbAll_Qty);
            this.panel3.Controls.Add(this.lbAll_Eff);
            this.panel3.Controls.Add(this.lbTotal_earn);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.lbC_Eff);
            this.panel3.Controls.Add(this.lbB_Eff);
            this.panel3.Controls.Add(this.lbA_Eff);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lbC_Qty);
            this.panel3.Controls.Add(this.lbB_Qty);
            this.panel3.Controls.Add(this.lbA_Qty);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lbSelDate);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(820, 89);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "選取日期:";
            // 
            // lbSelDate
            // 
            this.lbSelDate.AutoSize = true;
            this.lbSelDate.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbSelDate.ForeColor = System.Drawing.Color.Blue;
            this.lbSelDate.Location = new System.Drawing.Point(87, 16);
            this.lbSelDate.Name = "lbSelDate";
            this.lbSelDate.Size = new System.Drawing.Size(14, 22);
            this.lbSelDate.TabIndex = 9;
            this.lbSelDate.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(190, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "產量:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(236, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(236, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "B";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(236, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "C";
            // 
            // lbA_Qty
            // 
            this.lbA_Qty.AutoSize = true;
            this.lbA_Qty.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbA_Qty.ForeColor = System.Drawing.Color.Blue;
            this.lbA_Qty.Location = new System.Drawing.Point(258, 16);
            this.lbA_Qty.Name = "lbA_Qty";
            this.lbA_Qty.Size = new System.Drawing.Size(14, 22);
            this.lbA_Qty.TabIndex = 14;
            this.lbA_Qty.Text = " ";
            // 
            // lbB_Qty
            // 
            this.lbB_Qty.AutoSize = true;
            this.lbB_Qty.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbB_Qty.ForeColor = System.Drawing.Color.Blue;
            this.lbB_Qty.Location = new System.Drawing.Point(259, 38);
            this.lbB_Qty.Name = "lbB_Qty";
            this.lbB_Qty.Size = new System.Drawing.Size(14, 22);
            this.lbB_Qty.TabIndex = 15;
            this.lbB_Qty.Text = " ";
            // 
            // lbC_Qty
            // 
            this.lbC_Qty.AutoSize = true;
            this.lbC_Qty.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbC_Qty.ForeColor = System.Drawing.Color.Blue;
            this.lbC_Qty.Location = new System.Drawing.Point(258, 60);
            this.lbC_Qty.Name = "lbC_Qty";
            this.lbC_Qty.Size = new System.Drawing.Size(14, 22);
            this.lbC_Qty.TabIndex = 16;
            this.lbC_Qty.Text = " ";
            // 
            // lbC_Eff
            // 
            this.lbC_Eff.AutoSize = true;
            this.lbC_Eff.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbC_Eff.ForeColor = System.Drawing.Color.Blue;
            this.lbC_Eff.Location = new System.Drawing.Point(392, 60);
            this.lbC_Eff.Name = "lbC_Eff";
            this.lbC_Eff.Size = new System.Drawing.Size(14, 22);
            this.lbC_Eff.TabIndex = 23;
            this.lbC_Eff.Text = " ";
            // 
            // lbB_Eff
            // 
            this.lbB_Eff.AutoSize = true;
            this.lbB_Eff.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbB_Eff.ForeColor = System.Drawing.Color.Blue;
            this.lbB_Eff.Location = new System.Drawing.Point(393, 38);
            this.lbB_Eff.Name = "lbB_Eff";
            this.lbB_Eff.Size = new System.Drawing.Size(14, 22);
            this.lbB_Eff.TabIndex = 22;
            this.lbB_Eff.Text = " ";
            // 
            // lbA_Eff
            // 
            this.lbA_Eff.AutoSize = true;
            this.lbA_Eff.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbA_Eff.ForeColor = System.Drawing.Color.Blue;
            this.lbA_Eff.Location = new System.Drawing.Point(392, 16);
            this.lbA_Eff.Name = "lbA_Eff";
            this.lbA_Eff.Size = new System.Drawing.Size(14, 22);
            this.lbA_Eff.TabIndex = 21;
            this.lbA_Eff.Text = " ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(370, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 22);
            this.label14.TabIndex = 20;
            this.label14.Text = "C";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(370, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 22);
            this.label15.TabIndex = 19;
            this.label15.Text = "B";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(370, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 22);
            this.label16.TabIndex = 18;
            this.label16.Text = "A";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(324, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 22);
            this.label17.TabIndex = 17;
            this.label17.Text = "效率:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(465, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 22);
            this.label22.TabIndex = 28;
            this.label22.Text = "開機效率:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(465, 60);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 22);
            this.label23.TabIndex = 29;
            this.label23.Text = "合計產量:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(10, 60);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 22);
            this.label24.TabIndex = 30;
            this.label24.Text = "合計工繳:";
            // 
            // lbTotal_earn
            // 
            this.lbTotal_earn.AutoSize = true;
            this.lbTotal_earn.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbTotal_earn.ForeColor = System.Drawing.Color.Blue;
            this.lbTotal_earn.Location = new System.Drawing.Point(87, 60);
            this.lbTotal_earn.Name = "lbTotal_earn";
            this.lbTotal_earn.Size = new System.Drawing.Size(14, 22);
            this.lbTotal_earn.TabIndex = 31;
            this.lbTotal_earn.Text = " ";
            // 
            // lbAll_Eff
            // 
            this.lbAll_Eff.AutoSize = true;
            this.lbAll_Eff.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbAll_Eff.ForeColor = System.Drawing.Color.Blue;
            this.lbAll_Eff.Location = new System.Drawing.Point(553, 16);
            this.lbAll_Eff.Name = "lbAll_Eff";
            this.lbAll_Eff.Size = new System.Drawing.Size(14, 22);
            this.lbAll_Eff.TabIndex = 32;
            this.lbAll_Eff.Text = " ";
            // 
            // lbAll_Qty
            // 
            this.lbAll_Qty.AutoSize = true;
            this.lbAll_Qty.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbAll_Qty.ForeColor = System.Drawing.Color.Blue;
            this.lbAll_Qty.Location = new System.Drawing.Point(553, 60);
            this.lbAll_Qty.Name = "lbAll_Qty";
            this.lbAll_Qty.Size = new System.Drawing.Size(14, 22);
            this.lbAll_Qty.TabIndex = 33;
            this.lbAll_Qty.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(14, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 22);
            this.label8.TabIndex = 31;
            this.label8.Text = "累計工繳:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(186, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 22);
            this.label9.TabIndex = 32;
            this.label9.Text = "累計總產量:";
            // 
            // lbSumEarn
            // 
            this.lbSumEarn.AutoSize = true;
            this.lbSumEarn.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbSumEarn.ForeColor = System.Drawing.Color.Blue;
            this.lbSumEarn.Location = new System.Drawing.Point(98, 67);
            this.lbSumEarn.Name = "lbSumEarn";
            this.lbSumEarn.Size = new System.Drawing.Size(14, 22);
            this.lbSumEarn.TabIndex = 33;
            this.lbSumEarn.Text = " ";
            // 
            // lbSumYards
            // 
            this.lbSumYards.AutoSize = true;
            this.lbSumYards.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbSumYards.ForeColor = System.Drawing.Color.Blue;
            this.lbSumYards.Location = new System.Drawing.Point(291, 67);
            this.lbSumYards.Name = "lbSumYards";
            this.lbSumYards.Size = new System.Drawing.Size(14, 22);
            this.lbSumYards.TabIndex = 34;
            this.lbSumYards.Text = " ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(465, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 22);
            this.label10.TabIndex = 34;
            this.label10.Text = "平均轉速:";
            // 
            // lbAll_RPM
            // 
            this.lbAll_RPM.AutoSize = true;
            this.lbAll_RPM.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbAll_RPM.ForeColor = System.Drawing.Color.Blue;
            this.lbAll_RPM.Location = new System.Drawing.Point(553, 38);
            this.lbAll_RPM.Name = "lbAll_RPM";
            this.lbAll_RPM.Size = new System.Drawing.Size(14, 22);
            this.lbAll_RPM.TabIndex = 35;
            this.lbAll_RPM.Text = " ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(646, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 25);
            this.label12.TabIndex = 36;
            this.label12.Text = "指定布號:";
            // 
            // cbART_NO
            // 
            this.cbART_NO.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbART_NO.FormattingEnabled = true;
            this.cbART_NO.Location = new System.Drawing.Point(746, 23);
            this.cbART_NO.Name = "cbART_NO";
            this.cbART_NO.Size = new System.Drawing.Size(221, 33);
            this.cbART_NO.TabIndex = 37;
            this.cbART_NO.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbEQP_ID
            // 
            this.cbEQP_ID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbEQP_ID.FormattingEnabled = true;
            this.cbEQP_ID.Location = new System.Drawing.Point(746, 63);
            this.cbEQP_ID.Name = "cbEQP_ID";
            this.cbEQP_ID.Size = new System.Drawing.Size(221, 33);
            this.cbEQP_ID.TabIndex = 39;
            // 
            // lbEQP_ID
            // 
            this.lbEQP_ID.AutoSize = true;
            this.lbEQP_ID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbEQP_ID.Location = new System.Drawing.Point(646, 67);
            this.lbEQP_ID.Name = "lbEQP_ID";
            this.lbEQP_ID.Size = new System.Drawing.Size(97, 25);
            this.lbEQP_ID.TabIndex = 38;
            this.lbEQP_ID.Text = "指定機號:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(389, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 22);
            this.label11.TabIndex = 40;
            this.label11.Text = "總效率:";
            // 
            // lbSumEff
            // 
            this.lbSumEff.AutoSize = true;
            this.lbSumEff.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbSumEff.ForeColor = System.Drawing.Color.Blue;
            this.lbSumEff.Location = new System.Drawing.Point(451, 68);
            this.lbSumEff.Name = "lbSumEff";
            this.lbSumEff.Size = new System.Drawing.Size(14, 22);
            this.lbSumEff.TabIndex = 41;
            this.lbSumEff.Text = " ";
            // 
            // lbSumRPM
            // 
            this.lbSumRPM.AutoSize = true;
            this.lbSumRPM.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbSumRPM.ForeColor = System.Drawing.Color.Blue;
            this.lbSumRPM.Location = new System.Drawing.Point(556, 68);
            this.lbSumRPM.Name = "lbSumRPM";
            this.lbSumRPM.Size = new System.Drawing.Size(14, 22);
            this.lbSumRPM.TabIndex = 43;
            this.lbSumRPM.Text = " ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(513, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 22);
            this.label18.TabIndex = 42;
            this.label18.Text = "轉速:";
            // 
            // frmEQPSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 725);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmEQPSummary";
            this.Text = "frmEQPSummary";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnDate.ResumeLayout(false);
            this.pnDate.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEQPSummary)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1Date)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private DevExpress.XtraCharts.ChartControl chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView gvEQPSummary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgv1Date;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbAll_Qty;
        private System.Windows.Forms.Label lbAll_Eff;
        private System.Windows.Forms.Label lbTotal_earn;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbC_Eff;
        private System.Windows.Forms.Label lbB_Eff;
        private System.Windows.Forms.Label lbA_Eff;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbC_Qty;
        private System.Windows.Forms.Label lbB_Qty;
        private System.Windows.Forms.Label lbA_Qty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSelDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSumYards;
        private System.Windows.Forms.Label lbSumEarn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbAll_RPM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbART_NO;
        private System.Windows.Forms.ComboBox cbEQP_ID;
        private System.Windows.Forms.Label lbEQP_ID;
        private System.Windows.Forms.Label lbSumEff;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbSumRPM;
        private System.Windows.Forms.Label label18;
    }
}