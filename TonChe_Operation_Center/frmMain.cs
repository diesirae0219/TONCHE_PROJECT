using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;


namespace TonChe_Operation_Cneter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //this.tableLayoutPanel1.BackColor = Color.FromArgb(114, 186, 244);
            pnMain.AutoScroll = true;
            pnMain.AutoScrollMinSize = new Size(800, 600);
            Init();

        }

        private void Init()
        {
            this.WindowState = FormWindowState.Maximized;
            barButtonItem5.PerformClick();
       
        }

        private void InspectItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //frmInspect newMDIChild = new frmInspect();
            //this.splitContainerControl.Panel2.Controls.Add(newMDIChild);
            //newMDIChild.WindowState = FormWindowState.Maximized;

            //splitContainerControl.Panel2.Controls.Clear();
            //var form = new frmInspect();
            //form.TopLevel = false;
            //form.FormBorderStyle = FormBorderStyle.None;
            //form.Dock = DockStyle.Fill;
            //splitContainerControl.Panel2.Controls.Add(form);
            //form.Show();

            // Set the Parent Form of the Child window.
            //newMDIChild.MdiParent = this;
            //// Display the new form.
            //newMDIChild.Show();
            //newMDIChild.WindowState = FormWindowState.Maximized;
        }

        private void barInspect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();
            //pnMain.Controls.Clear();
            ClearControls();
            var form = new frmInspect();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;

            DevExpress.XtraEditors.VScrollBar vs1 = new DevExpress.XtraEditors.VScrollBar();
            vs1.Dock = DockStyle.Right;
            //pnMain.Controls.Add(vs1);

           // splitContainerControl.Panel2.Controls.Add(form);
            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();
            //pnMain.Controls.Clear();
            ClearControls();
            var form = new frmInspect();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;

            DevExpress.XtraEditors.VScrollBar vs1 = new DevExpress.XtraEditors.VScrollBar();
            vs1.Dock = DockStyle.Right;
            //pnMain.Controls.Add(vs1);

            // splitContainerControl.Panel2.Controls.Add(form);
            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();
            //pnMain.Controls.Clear();
            ClearControls();
            var form = new frmProdInfo();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;
            //form.WindowState = FormWindowState.Maximized;            

            DevExpress.XtraEditors.VScrollBar vs1 = new DevExpress.XtraEditors.VScrollBar();
            vs1.Dock = DockStyle.Right;
            //pnMain.Controls.Add(vs1);

            // splitContainerControl.Panel2.Controls.Add(form);
            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();
            //pnMain.Controls.Clear();
            ClearControls();
            var form = new frmInspect();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;

            DevExpress.XtraEditors.VScrollBar vs1 = new DevExpress.XtraEditors.VScrollBar();
            vs1.Dock = DockStyle.Right;
            //pnMain.Controls.Add(vs1);

            // splitContainerControl.Panel2.Controls.Add(form);
            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();
            //pnMain.Controls.Clear();
            ClearControls();
            var form = new frminsSummary();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;

            DevExpress.XtraEditors.VScrollBar vs1 = new DevExpress.XtraEditors.VScrollBar();
            vs1.Dock = DockStyle.Right;
            //pnMain.Controls.Add(vs1);

            // splitContainerControl.Panel2.Controls.Add(form);
            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }

        private void barHeaderItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();
           // pnMain.Controls.Clear();
            ClearControls();
            var form = new frmQuotation();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;

     
            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();

            ClearControls();
            var form = new frmQuotation();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;


            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }

        private void ClearControls()
        {
            pnMain.Visible = false;

            while (pnMain.Controls.Count > 0)
            {
                pnMain.Controls[0].Dispose();
            }

            pnMain.Visible = true;
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.splitContainerControl.Panel2.Controls.Clear();
            //pnMain.Controls.Clear();
            ClearControls();
            var form = new frmEQPSummary();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;

            DevExpress.XtraEditors.VScrollBar vs1 = new DevExpress.XtraEditors.VScrollBar();
            vs1.Dock = DockStyle.Right;
            //pnMain.Controls.Add(vs1);

            // splitContainerControl.Panel2.Controls.Add(form);
            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearControls();
            var form = new frmProfile();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;


            pnMain.Controls.Add(form);
            pnMain.AutoScroll = true;
            form.Show();
        }


      
      

    }
}