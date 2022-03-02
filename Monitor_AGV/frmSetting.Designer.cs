namespace Monitor_AGV
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.GrpCtrl_WorkSpaceAGV = new DevExpress.XtraEditors.GroupControl();
            this.btn_Apply = new DevExpress.XtraEditors.SimpleButton();
            this.grp_thaotac = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GrpCtrl_WorkSpaceAGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_thaotac)).BeginInit();
            this.grp_thaotac.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpCtrl_WorkSpaceAGV
            // 
            this.GrpCtrl_WorkSpaceAGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpCtrl_WorkSpaceAGV.Location = new System.Drawing.Point(0, 0);
            this.GrpCtrl_WorkSpaceAGV.Name = "GrpCtrl_WorkSpaceAGV";
            this.GrpCtrl_WorkSpaceAGV.Size = new System.Drawing.Size(1368, 563);
            this.GrpCtrl_WorkSpaceAGV.TabIndex = 20;
            this.GrpCtrl_WorkSpaceAGV.Text = "Vị trí AGVs (Theo phương ngang)";
            // 
            // btn_Apply
            // 
            this.btn_Apply.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Apply.ImageOptions.Image")));
            this.btn_Apply.Location = new System.Drawing.Point(606, 68);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(89, 41);
            this.btn_Apply.TabIndex = 1;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // grp_thaotac
            // 
            this.grp_thaotac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_thaotac.Controls.Add(this.btn_Apply);
            this.grp_thaotac.Controls.Add(this.labelControl3);
            this.grp_thaotac.Location = new System.Drawing.Point(0, 567);
            this.grp_thaotac.Name = "grp_thaotac";
            this.grp_thaotac.Size = new System.Drawing.Size(1368, 181);
            this.grp_thaotac.TabIndex = 21;
            this.grp_thaotac.Text = "Thao tác";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(1494, 117);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "ID Station";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.grp_thaotac);
            this.Controls.Add(this.GrpCtrl_WorkSpaceAGV);
            this.Name = "frmSetting";
            this.Text = "frmSetting";
            ((System.ComponentModel.ISupportInitialize)(this.GrpCtrl_WorkSpaceAGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_thaotac)).EndInit();
            this.grp_thaotac.ResumeLayout(false);
            this.grp_thaotac.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GrpCtrl_WorkSpaceAGV;
        private DevExpress.XtraEditors.GroupControl grp_thaotac;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_Apply;
    }
}