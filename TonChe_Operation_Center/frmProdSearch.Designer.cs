namespace TonChe_Operation_Cneter
{
    partial class frmProdSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbD = new System.Windows.Forms.ComboBox();
            this.p2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.TextBox();
            this.tbArtCons = new System.Windows.Forms.TextBox();
            this.tbART_TYPE = new System.Windows.Forms.TextBox();
            this.cbArtCons = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cbArtType = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_SEARCH_ART = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gvART_DATA = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.selArt = new System.Windows.Forms.Label();
            this.btn_SEARCH = new System.Windows.Forms.Button();
            this.pSample = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArtCons.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbArtType.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvART_DATA)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.65038F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.34962F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1371, 778);
            this.tableLayoutPanel1.TabIndex = 54;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.selArt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbD);
            this.panel1.Controls.Add(this.p2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.p1);
            this.panel1.Controls.Add(this.tbArtCons);
            this.panel1.Controls.Add(this.tbART_TYPE);
            this.panel1.Controls.Add(this.cbArtCons);
            this.panel1.Controls.Add(this.cbArtType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tb_SEARCH_ART);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btn_SEARCH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1365, 177);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(1060, 51);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 25);
            this.label5.TabIndex = 78;
            this.label5.Text = "幣別 :";
            // 
            // cbD
            // 
            this.cbD.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbD.FormattingEnabled = true;
            this.cbD.Items.AddRange(new object[] {
            "NTD",
            "USD",
            "RMB"});
            this.cbD.Location = new System.Drawing.Point(1129, 49);
            this.cbD.Name = "cbD";
            this.cbD.Size = new System.Drawing.Size(187, 33);
            this.cbD.TabIndex = 77;
            // 
            // p2
            // 
            this.p2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.p2.Location = new System.Drawing.Point(1244, 7);
            this.p2.Margin = new System.Windows.Forms.Padding(4);
            this.p2.Name = "p2";
            this.p2.ReadOnly = true;
            this.p2.Size = new System.Drawing.Size(72, 34);
            this.p2.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(1209, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 25);
            this.label4.TabIndex = 75;
            this.label4.Text = "~";
            // 
            // p1
            // 
            this.p1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.p1.Location = new System.Drawing.Point(1129, 8);
            this.p1.Margin = new System.Windows.Forms.Padding(4);
            this.p1.Name = "p1";
            this.p1.ReadOnly = true;
            this.p1.Size = new System.Drawing.Size(72, 34);
            this.p1.TabIndex = 74;
            // 
            // tbArtCons
            // 
            this.tbArtCons.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbArtCons.Location = new System.Drawing.Point(779, 48);
            this.tbArtCons.Margin = new System.Windows.Forms.Padding(4);
            this.tbArtCons.Name = "tbArtCons";
            this.tbArtCons.ReadOnly = true;
            this.tbArtCons.Size = new System.Drawing.Size(275, 34);
            this.tbArtCons.TabIndex = 73;
            // 
            // tbART_TYPE
            // 
            this.tbART_TYPE.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbART_TYPE.Location = new System.Drawing.Point(434, 49);
            this.tbART_TYPE.Margin = new System.Windows.Forms.Padding(4);
            this.tbART_TYPE.Name = "tbART_TYPE";
            this.tbART_TYPE.ReadOnly = true;
            this.tbART_TYPE.Size = new System.Drawing.Size(275, 34);
            this.tbART_TYPE.TabIndex = 72;
            // 
            // cbArtCons
            // 
            this.cbArtCons.EditValue = "";
            this.cbArtCons.Location = new System.Drawing.Point(779, 9);
            this.cbArtCons.Name = "cbArtCons";
            this.cbArtCons.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbArtCons.Properties.Appearance.Options.UseFont = true;
            this.cbArtCons.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbArtCons.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("A", "A (壓克力/腈綸)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("C", "C (棉)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("CD", "CD (陽離子)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("L", "L (麻)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("LU", "LU (蔥)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("LY", "LY (萊卡/氨綸)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("M", "M (金屬蔥)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("N", "N (尼龍/锦纶)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("OP", "OP"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("R", "R (縲縈)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("T", "T (Poly/涤纶)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("T吸濕排汗", "T吸濕排汗"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("T透明蔥", "T透明蔥"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("V", "V (Viscose/粘胶纤维)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("W", "W (羊毛)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("鋼絲", "鋼絲")});
            this.cbArtCons.Size = new System.Drawing.Size(274, 32);
            this.cbArtCons.TabIndex = 71;
            this.cbArtCons.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cbArtCons_Closed);
            // 
            // cbArtType
            // 
            this.cbArtType.EditValue = "";
            this.cbArtType.Location = new System.Drawing.Point(431, 10);
            this.cbArtType.Name = "cbArtType";
            this.cbArtType.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbArtType.Properties.Appearance.Options.UseFont = true;
            this.cbArtType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbArtType.Size = new System.Drawing.Size(274, 32);
            this.cbArtType.TabIndex = 70;
            this.cbArtType.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cbArtType_Closed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(712, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 59;
            this.label3.Text = "成分 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(1060, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "價格 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(354, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 57;
            this.label1.Text = "分類 :";
            // 
            // tb_SEARCH_ART
            // 
            this.tb_SEARCH_ART.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_SEARCH_ART.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_SEARCH_ART.Location = new System.Drawing.Point(131, 25);
            this.tb_SEARCH_ART.Margin = new System.Windows.Forms.Padding(4);
            this.tb_SEARCH_ART.Name = "tb_SEARCH_ART";
            this.tb_SEARCH_ART.Size = new System.Drawing.Size(186, 34);
            this.tb_SEARCH_ART.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(25, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 25);
            this.label10.TabIndex = 56;
            this.label10.Text = "搜尋布號 :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.26373F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.73626F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 186);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1365, 589);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.gvART_DATA);
            this.panel5.Controls.Add(this.pSample);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(2, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1037, 585);
            this.panel5.TabIndex = 27;
            // 
            // gvART_DATA
            // 
            this.gvART_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvART_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvART_DATA.Location = new System.Drawing.Point(0, 0);
            this.gvART_DATA.Margin = new System.Windows.Forms.Padding(4);
            this.gvART_DATA.MultiSelect = false;
            this.gvART_DATA.Name = "gvART_DATA";
            this.gvART_DATA.ReadOnly = true;
            this.gvART_DATA.RowTemplate.Height = 24;
            this.gvART_DATA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvART_DATA.Size = new System.Drawing.Size(1037, 585);
            this.gvART_DATA.TabIndex = 16;
            this.gvART_DATA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvART_DATA_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1044, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 583);
            this.panel2.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(202, 139);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 79;
            this.label6.Text = "目前選擇:";
            // 
            // selArt
            // 
            this.selArt.AutoSize = true;
            this.selArt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.selArt.ForeColor = System.Drawing.Color.Blue;
            this.selArt.Location = new System.Drawing.Point(312, 139);
            this.selArt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selArt.Name = "selArt";
            this.selArt.Size = new System.Drawing.Size(102, 25);
            this.selArt.TabIndex = 80;
            this.selArt.Text = "搜尋布號 :";
            // 
            // btn_SEARCH
            // 
            this.btn_SEARCH.BackColor = System.Drawing.Color.White;
            this.btn_SEARCH.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_SEARCH.Image = global::TonChe_Operation_Cneter.Properties.Resources.magnifier13;
            this.btn_SEARCH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SEARCH.Location = new System.Drawing.Point(30, 135);
            this.btn_SEARCH.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SEARCH.Name = "btn_SEARCH";
            this.btn_SEARCH.Size = new System.Drawing.Size(145, 32);
            this.btn_SEARCH.TabIndex = 55;
            this.btn_SEARCH.Text = "    開始搜尋";
            this.btn_SEARCH.UseVisualStyleBackColor = false;
            this.btn_SEARCH.Click += new System.EventHandler(this.btn_SEARCH_Click);
            // 
            // pSample
            // 
            this.pSample.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pSample.Location = new System.Drawing.Point(1036, 2);
            this.pSample.Margin = new System.Windows.Forms.Padding(2);
            this.pSample.Name = "pSample";
            this.pSample.Size = new System.Drawing.Size(290, 266);
            this.pSample.TabIndex = 52;
            this.pSample.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(11, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 266);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExport.Image = global::TonChe_Operation_Cneter.Properties.Resources.upload;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1057, 136);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(179, 32);
            this.btnExport.TabIndex = 81;
            this.btnExport.Text = "    匯出EXCEL";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmProdSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 778);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmProdSearch";
            this.Text = "布號搜尋";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArtCons.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbArtType.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvART_DATA)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SEARCH_ART;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_SEARCH;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbArtCons;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbArtType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbD;
        private System.Windows.Forms.TextBox p2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox p1;
        private System.Windows.Forms.TextBox tbArtCons;
        private System.Windows.Forms.TextBox tbART_TYPE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView gvART_DATA;
        private System.Windows.Forms.PictureBox pSample;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label selArt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExport;

    }
}