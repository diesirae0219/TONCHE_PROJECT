using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Utility;

namespace TonChe_Operation_Cneter
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
            HideControl(false);
        }

        private void HideControl(bool show)
        {
            if (show)
            {
                btn_EDIT_OK.Enabled = false;
            }
            lbNew.Visible = show;
            lbNewChk.Visible = show;
            lbOld.Visible = show;

            pOLD.Visible = show;
            pNEW.Visible = show;
            pRE.Visible = show;


            btn_EDIT_OK.Visible = show;
            btn_EDIT_CANCEL.Visible = show;
        }

        private void btnEditPW_Click(object sender, EventArgs e)
        {
            HideControl(true);
        }

        private void tbOld_TextChanged(object sender, EventArgs e)
        {
            pOLD.Visible = false;
            if ((tbOld.Text).Length > 0)
            {
                if (GlobalVar.LoginUser.CheckPW(tbOld.Text))
                {
                    pOLD.Image = TonChe_Operation_Cneter.Properties.Resources.confirm;
                }
                else
                {
                    pOLD.Image = TonChe_Operation_Cneter.Properties.Resources.cancel;
                }
            }
        }
        private void tbNew_TextChanged(object sender, EventArgs e)
        {
            pNEW.Visible = false;
            if ((tbNew.Text).Length > 0)
            {
                pNEW.Image = TonChe_Operation_Cneter.Properties.Resources.confirm;
            }
            else
            {
                pNEW.Image = TonChe_Operation_Cneter.Properties.Resources.cancel;
            }            
        }
        private void tbNewChk_TextChanged(object sender, EventArgs e)
        {
            pRE.Visible = false;
            if ((tbOld.Text).Length > 0)
            {
                pRE.Image = TonChe_Operation_Cneter.Properties.Resources.confirm;
            }
            else
            {
                pRE.Image = TonChe_Operation_Cneter.Properties.Resources.cancel;
            }           
        }
    }
}
