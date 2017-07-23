namespace TonChe_Operation_Cneter
{
    partial class frmQuotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotation));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbPrintWithSave = new System.Windows.Forms.CheckBox();
            this.cbAutoART = new System.Windows.Forms.CheckBox();
            this.pp1 = new System.Windows.Forms.ProgressBar();
            this.btnSaveOrderExcel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_GETTEXT_ID = new System.Windows.Forms.TextBox();
            this.tb_customer = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gvOrder = new System.Windows.Forms.DataGridView();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2116, 208);
            this.panel3.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.btnSave);
            this.panel6.Controls.Add(this.cbPrintWithSave);
            this.panel6.Controls.Add(this.cbAutoART);
            this.panel6.Controls.Add(this.pp1);
            this.panel6.Controls.Add(this.btnSaveOrderExcel);
            this.panel6.Controls.Add(this.btnReset);
            this.panel6.Controls.Add(this.btnPrint);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.TB_GETTEXT_ID);
            this.panel6.Controls.Add(this.tb_customer);
            this.panel6.Controls.Add(this.btnAdd);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2116, 202);
            this.panel6.TabIndex = 26;
            // 
            // cbPrintWithSave
            // 
            this.cbPrintWithSave.AutoSize = true;
            this.cbPrintWithSave.Checked = true;
            this.cbPrintWithSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrintWithSave.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbPrintWithSave.Location = new System.Drawing.Point(1284, 42);
            this.cbPrintWithSave.Margin = new System.Windows.Forms.Padding(5);
            this.cbPrintWithSave.Name = "cbPrintWithSave";
            this.cbPrintWithSave.Size = new System.Drawing.Size(241, 44);
            this.cbPrintWithSave.TabIndex = 29;
            this.cbPrintWithSave.Text = "列印同時儲存";
            this.cbPrintWithSave.UseVisualStyleBackColor = true;
            // 
            // cbAutoART
            // 
            this.cbAutoART.AutoSize = true;
            this.cbAutoART.Checked = true;
            this.cbAutoART.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoART.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbAutoART.Location = new System.Drawing.Point(624, 133);
            this.cbAutoART.Margin = new System.Windows.Forms.Padding(5);
            this.cbAutoART.Name = "cbAutoART";
            this.cbAutoART.Size = new System.Drawing.Size(112, 44);
            this.cbAutoART.TabIndex = 28;
            this.cbAutoART.Text = "ART";
            this.cbAutoART.UseVisualStyleBackColor = true;
            // 
            // pp1
            // 
            this.pp1.Location = new System.Drawing.Point(1462, 157);
            this.pp1.Name = "pp1";
            this.pp1.Size = new System.Drawing.Size(162, 22);
            this.pp1.TabIndex = 27;
            this.pp1.Visible = false;
            // 
            // btnSaveOrderExcel
            // 
            this.btnSaveOrderExcel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSaveOrderExcel.Location = new System.Drawing.Point(871, 131);
            this.btnSaveOrderExcel.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveOrderExcel.Name = "btnSaveOrderExcel";
            this.btnSaveOrderExcel.Size = new System.Drawing.Size(162, 56);
            this.btnSaveOrderExcel.TabIndex = 26;
            this.btnSaveOrderExcel.Text = "EXCEL";
            this.btnSaveOrderExcel.UseVisualStyleBackColor = true;
            this.btnSaveOrderExcel.Click += new System.EventHandler(this.btnSaveOrderExcel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.Location = new System.Drawing.Point(871, 38);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(162, 54);
            this.btnReset.TabIndex = 25;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Image = global::TonChe_Operation_Cneter.Properties.Resources.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1058, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(202, 54);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "   列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(36, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 31);
            this.label2.TabIndex = 20;
            this.label2.Text = "掃描布號:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(31, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 31);
            this.label3.TabIndex = 22;
            this.label3.Text = "客戶名稱:";
            // 
            // TB_GETTEXT_ID
            // 
            this.TB_GETTEXT_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TB_GETTEXT_ID.Location = new System.Drawing.Point(179, 131);
            this.TB_GETTEXT_ID.Name = "TB_GETTEXT_ID";
            this.TB_GETTEXT_ID.Size = new System.Drawing.Size(290, 36);
            this.TB_GETTEXT_ID.TabIndex = 19;
            // 
            // tb_customer
            // 
            this.tb_customer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_customer.Location = new System.Drawing.Point(172, 45);
            this.tb_customer.Name = "tb_customer";
            this.tb_customer.Size = new System.Drawing.Size(644, 36);
            this.tb_customer.TabIndex = 23;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Image = global::TonChe_Operation_Cneter.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(479, 131);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 46);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "   加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvOrder
            // 
            this.gvOrder.AllowUserToOrderColumns = true;
            this.gvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvOrder.Location = new System.Drawing.Point(0, 208);
            this.gvOrder.Margin = new System.Windows.Forms.Padding(6);
            this.gvOrder.Name = "gvOrder";
            this.gvOrder.RowTemplate.Height = 24;
            this.gvOrder.Size = new System.Drawing.Size(2116, 989);
            this.gvOrder.TabIndex = 29;
            this.gvOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvOrder_CellClick);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(1058, 129);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(202, 56);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2116, 1197);
            this.Controls.Add(this.gvOrder);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmQuotation";
            this.Text = "frmQuotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuotation_Load);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ProgressBar pp1;
        private System.Windows.Forms.Button btnSaveOrderExcel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_GETTEXT_ID;
        private System.Windows.Forms.TextBox tb_customer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gvOrder;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.CheckBox cbAutoART;
        private System.Windows.Forms.CheckBox cbPrintWithSave;
        private System.Windows.Forms.Button btnSave;
    }
}