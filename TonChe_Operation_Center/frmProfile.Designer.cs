namespace TonChe_Operation_Cneter
{
    partial class frmProfile
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbOld = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.btnEditPW = new System.Windows.Forms.Button();
            this.btn_EDIT_CANCEL = new System.Windows.Forms.Button();
            this.btn_EDIT_OK = new System.Windows.Forms.Button();
            this.lbNew = new System.Windows.Forms.Label();
            this.lbNewChk = new System.Windows.Forms.Label();
            this.tbOld = new System.Windows.Forms.TextBox();
            this.tbNew = new System.Windows.Forms.TextBox();
            this.tbNewChk = new System.Windows.Forms.TextBox();
            this.pOLD = new System.Windows.Forms.PictureBox();
            this.pNEW = new System.Windows.Forms.PictureBox();
            this.pRE = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pOLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRE)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // lbOld
            // 
            this.lbOld.AutoSize = true;
            this.lbOld.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbOld.Location = new System.Drawing.Point(26, 141);
            this.lbOld.Name = "lbOld";
            this.lbOld.Size = new System.Drawing.Size(77, 25);
            this.lbOld.TabIndex = 1;
            this.lbOld.Text = "舊密碼:";
            this.lbOld.Visible = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbName.Location = new System.Drawing.Point(90, 35);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 25);
            this.lbName.TabIndex = 2;
            // 
            // btnEditPW
            // 
            this.btnEditPW.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPW.Image = global::TonChe_Operation_Cneter.Properties.Resources.edit;
            this.btnEditPW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditPW.Location = new System.Drawing.Point(28, 81);
            this.btnEditPW.Name = "btnEditPW";
            this.btnEditPW.Size = new System.Drawing.Size(143, 34);
            this.btnEditPW.TabIndex = 3;
            this.btnEditPW.Text = "   修改密碼";
            this.btnEditPW.UseVisualStyleBackColor = true;
            this.btnEditPW.Click += new System.EventHandler(this.btnEditPW_Click);
            // 
            // btn_EDIT_CANCEL
            // 
            this.btn_EDIT_CANCEL.BackColor = System.Drawing.Color.White;
            this.btn_EDIT_CANCEL.Image = global::TonChe_Operation_Cneter.Properties.Resources.cancel;
            this.btn_EDIT_CANCEL.Location = new System.Drawing.Point(228, 81);
            this.btn_EDIT_CANCEL.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EDIT_CANCEL.Name = "btn_EDIT_CANCEL";
            this.btn_EDIT_CANCEL.Size = new System.Drawing.Size(36, 35);
            this.btn_EDIT_CANCEL.TabIndex = 57;
            this.btn_EDIT_CANCEL.UseVisualStyleBackColor = false;
            this.btn_EDIT_CANCEL.Visible = false;
            // 
            // btn_EDIT_OK
            // 
            this.btn_EDIT_OK.BackColor = System.Drawing.Color.White;
            this.btn_EDIT_OK.Image = global::TonChe_Operation_Cneter.Properties.Resources.confirm;
            this.btn_EDIT_OK.Location = new System.Drawing.Point(182, 81);
            this.btn_EDIT_OK.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EDIT_OK.Name = "btn_EDIT_OK";
            this.btn_EDIT_OK.Size = new System.Drawing.Size(38, 34);
            this.btn_EDIT_OK.TabIndex = 56;
            this.btn_EDIT_OK.UseVisualStyleBackColor = false;
            this.btn_EDIT_OK.Visible = false;
            // 
            // lbNew
            // 
            this.lbNew.AutoSize = true;
            this.lbNew.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbNew.Location = new System.Drawing.Point(26, 183);
            this.lbNew.Name = "lbNew";
            this.lbNew.Size = new System.Drawing.Size(77, 25);
            this.lbNew.TabIndex = 58;
            this.lbNew.Text = "新密碼:";
            this.lbNew.Visible = false;
            // 
            // lbNewChk
            // 
            this.lbNewChk.AutoSize = true;
            this.lbNewChk.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbNewChk.Location = new System.Drawing.Point(6, 222);
            this.lbNewChk.Name = "lbNewChk";
            this.lbNewChk.Size = new System.Drawing.Size(97, 25);
            this.lbNewChk.TabIndex = 59;
            this.lbNewChk.Text = "再次輸入:";
            this.lbNewChk.Visible = false;
            // 
            // tbOld
            // 
            this.tbOld.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbOld.Location = new System.Drawing.Point(109, 138);
            this.tbOld.Name = "tbOld";
            this.tbOld.Size = new System.Drawing.Size(252, 34);
            this.tbOld.TabIndex = 60;
            this.tbOld.UseSystemPasswordChar = true;
            this.tbOld.Visible = false;
            this.tbOld.TextChanged += new System.EventHandler(this.tbOld_TextChanged);
            // 
            // tbNew
            // 
            this.tbNew.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbNew.Location = new System.Drawing.Point(109, 178);
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(252, 34);
            this.tbNew.TabIndex = 61;
            this.tbNew.UseSystemPasswordChar = true;
            this.tbNew.Visible = false;
            this.tbNew.TextChanged += new System.EventHandler(this.tbNew_TextChanged);
            // 
            // tbNewChk
            // 
            this.tbNewChk.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbNewChk.Location = new System.Drawing.Point(109, 219);
            this.tbNewChk.Name = "tbNewChk";
            this.tbNewChk.Size = new System.Drawing.Size(252, 34);
            this.tbNewChk.TabIndex = 62;
            this.tbNewChk.UseSystemPasswordChar = true;
            this.tbNewChk.Visible = false;
            this.tbNewChk.TextChanged += new System.EventHandler(this.tbNewChk_TextChanged);
            // 
            // pOLD
            // 
            this.pOLD.BackgroundImage = global::TonChe_Operation_Cneter.Properties.Resources.confirm;
            this.pOLD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pOLD.InitialImage = global::TonChe_Operation_Cneter.Properties.Resources.confirm;
            this.pOLD.Location = new System.Drawing.Point(367, 138);
            this.pOLD.Name = "pOLD";
            this.pOLD.Size = new System.Drawing.Size(31, 34);
            this.pOLD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pOLD.TabIndex = 63;
            this.pOLD.TabStop = false;
            this.pOLD.Visible = false;
            // 
            // pNEW
            // 
            this.pNEW.BackgroundImage = global::TonChe_Operation_Cneter.Properties.Resources.confirm;
            this.pNEW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pNEW.InitialImage = global::TonChe_Operation_Cneter.Properties.Resources.confirm;
            this.pNEW.Location = new System.Drawing.Point(367, 178);
            this.pNEW.Name = "pNEW";
            this.pNEW.Size = new System.Drawing.Size(31, 34);
            this.pNEW.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pNEW.TabIndex = 64;
            this.pNEW.TabStop = false;
            this.pNEW.Visible = false;
            // 
            // pRE
            // 
            this.pRE.BackgroundImage = global::TonChe_Operation_Cneter.Properties.Resources.confirm;
            this.pRE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pRE.InitialImage = global::TonChe_Operation_Cneter.Properties.Resources.confirm;
            this.pRE.Location = new System.Drawing.Point(367, 218);
            this.pRE.Name = "pRE";
            this.pRE.Size = new System.Drawing.Size(31, 34);
            this.pRE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pRE.TabIndex = 65;
            this.pRE.TabStop = false;
            this.pRE.Visible = false;
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 304);
            this.Controls.Add(this.pRE);
            this.Controls.Add(this.pNEW);
            this.Controls.Add(this.pOLD);
            this.Controls.Add(this.tbNewChk);
            this.Controls.Add(this.tbNew);
            this.Controls.Add(this.tbOld);
            this.Controls.Add(this.lbNewChk);
            this.Controls.Add(this.lbNew);
            this.Controls.Add(this.btn_EDIT_CANCEL);
            this.Controls.Add(this.btn_EDIT_OK);
            this.Controls.Add(this.btnEditPW);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbOld);
            this.Controls.Add(this.label1);
            this.Name = "frmProfile";
            this.Text = "frmProfile";
            ((System.ComponentModel.ISupportInitialize)(this.pOLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbOld;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnEditPW;
        private System.Windows.Forms.Button btn_EDIT_CANCEL;
        private System.Windows.Forms.Button btn_EDIT_OK;
        private System.Windows.Forms.Label lbNew;
        private System.Windows.Forms.Label lbNewChk;
        private System.Windows.Forms.TextBox tbOld;
        private System.Windows.Forms.TextBox tbNew;
        private System.Windows.Forms.TextBox tbNewChk;
        private System.Windows.Forms.PictureBox pOLD;
        private System.Windows.Forms.PictureBox pNEW;
        private System.Windows.Forms.PictureBox pRE;
    }
}