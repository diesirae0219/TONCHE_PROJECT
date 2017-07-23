namespace FactoryObject.ucObject
{
    partial class ucEQP_INFO
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbEQP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbEQP
            // 
            this.lbEQP.AutoSize = true;
            this.lbEQP.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbEQP.Location = new System.Drawing.Point(17, 19);
            this.lbEQP.Name = "lbEQP";
            this.lbEQP.Size = new System.Drawing.Size(85, 31);
            this.lbEQP.TabIndex = 0;
            this.lbEQP.Text = "label1";
            // 
            // ucEQP_INFO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbEQP);
            this.Name = "ucEQP_INFO";
            this.Size = new System.Drawing.Size(830, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEQP;
    }
}
