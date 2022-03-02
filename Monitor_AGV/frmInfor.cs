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
using Monitor_AGV;

namespace information
{
    public partial class fInfor : DevExpress.XtraEditors.XtraForm
    {
        public fInfor()
        {
            InitializeComponent();

            //set phạm vi hoạt động lên public để thao tác bên form fAGV

        }
        private frmAGV mainForm = null;
        public fInfor(Form callingForm)
        {
            mainForm = callingForm as frmAGV;
            InitializeComponent();
        }

        private void Btn_Reset_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}