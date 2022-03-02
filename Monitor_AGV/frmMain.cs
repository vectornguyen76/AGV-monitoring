using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using Microsoft.Win32;

namespace Monitor_AGV
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm, INotify
    {

        public void Status(string message = "Sẵn sàng", params object[] args)
        {
            lblStatusSystem.Caption = string.Format(message, args);
        }
        public frmMain()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }
        void _openForm(Form f)
        {
            var frm = MdiChildren.FirstOrDefault(q => q.Text == f.Text);
            if (frm == null)
            {
                f.MdiParent = this;

                int height_form = f.Height;
                int width_form = f.Width;
                int height_ribbon = ribbon.Height;

                RegistryKey data = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
                data.SetValue("HeightGroupControl", (height_form - height_ribbon));
                data.SetValue("WidthGroupControl", width_form);
                data.Close();

                f.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void BtnMonitorAGV_ItemClick(object sender, ItemClickEventArgs e)
        {
            _openForm(new frmAGV(this));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSettingShelves_ItemClick(object sender, ItemClickEventArgs e)
        {
            _openForm(new frmSetting(this));
        }
    }
}