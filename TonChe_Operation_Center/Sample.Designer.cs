namespace TonChe_Operation_Cneter
{
    partial class Sample
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
            this.pcSampleDetail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcSampleDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pcSampleDetail
            // 
            this.pcSampleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcSampleDetail.Location = new System.Drawing.Point(0, 0);
            this.pcSampleDetail.Name = "pcSampleDetail";
            this.pcSampleDetail.Size = new System.Drawing.Size(282, 255);
            this.pcSampleDetail.TabIndex = 0;
            this.pcSampleDetail.TabStop = false;
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.pcSampleDetail);
            this.Name = "Sample";
            this.Text = "SampleView";
            ((System.ComponentModel.ISupportInitialize)(this.pcSampleDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pcSampleDetail;
    }
}