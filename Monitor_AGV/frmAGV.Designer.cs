namespace Monitor_AGV
{
    partial class frmAGV
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
            this.components = new System.ComponentModel.Container();
            this.bt_Start_PLC = new System.Windows.Forms.Button();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this._history = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_Random = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.timer_read_data = new System.Windows.Forms.Timer(this.components);
            this.GrpCtrl_WorkSpaceAGV = new DevExpress.XtraEditors.GroupControl();
            this.timer_send_data = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._history)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpCtrl_WorkSpaceAGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Start_PLC
            // 
            this.bt_Start_PLC.Location = new System.Drawing.Point(40, 58);
            this.bt_Start_PLC.Name = "bt_Start_PLC";
            this.bt_Start_PLC.Size = new System.Drawing.Size(75, 23);
            this.bt_Start_PLC.TabIndex = 17;
            this.bt_Start_PLC.Text = "Connect";
            this.bt_Start_PLC.UseVisualStyleBackColor = true;
            this.bt_Start_PLC.Click += new System.EventHandler(this.Bt_Start_PLC_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            // 
            // _history
            // 
            this._history.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._history.Controls.Add(this.labelControl3);
            this._history.Controls.Add(this.bt_Start_PLC);
            this._history.Controls.Add(this.Btn_Random);
            this._history.Controls.Add(this.gridControl2);
            this._history.Location = new System.Drawing.Point(0, 562);
            this._history.Name = "_history";
            this._history.Size = new System.Drawing.Size(1368, 187);
            this._history.TabIndex = 16;
            this._history.Text = "Lịch sử hoạt động";
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
            // Btn_Random
            // 
            this.Btn_Random.Location = new System.Drawing.Point(144, 58);
            this.Btn_Random.Name = "Btn_Random";
            this.Btn_Random.Size = new System.Drawing.Size(62, 23);
            this.Btn_Random.TabIndex = 18;
            this.Btn_Random.Text = "Random";
            this.Btn_Random.Click += new System.EventHandler(this.Btn_Random_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 21);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1364, 164);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // timer_read_data
            // 
            this.timer_read_data.Interval = 2;
            this.timer_read_data.Tick += new System.EventHandler(this.timer_read_data_Tick);
            // 
            // GrpCtrl_WorkSpaceAGV
            // 
            this.GrpCtrl_WorkSpaceAGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpCtrl_WorkSpaceAGV.Location = new System.Drawing.Point(0, 1);
            this.GrpCtrl_WorkSpaceAGV.Name = "GrpCtrl_WorkSpaceAGV";
            this.GrpCtrl_WorkSpaceAGV.Size = new System.Drawing.Size(1368, 563);
            this.GrpCtrl_WorkSpaceAGV.TabIndex = 19;
            this.GrpCtrl_WorkSpaceAGV.Text = "Vị trí AGVs (Theo phương ngang)";
            // 
            // timer_send_data
            // 
            this.timer_send_data.Interval = 2;
            this.timer_send_data.Tick += new System.EventHandler(this.timer_send_data_Tick);
            // 
            // frmAGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.GrpCtrl_WorkSpaceAGV);
            this.Controls.Add(this._history);
            this.Name = "frmAGV";
            this.Text = "ĐIỀU KHIỂN GIÁM SÁT AGVS";
            this.Load += new System.EventHandler(this.frmAGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this._history)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpCtrl_WorkSpaceAGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl _history;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.Button bt_Start_PLC;
        private System.Windows.Forms.Timer timer_read_data;
        private DevExpress.XtraEditors.GroupControl GrpCtrl_WorkSpaceAGV;
        private DevExpress.XtraEditors.SimpleButton Btn_Random;
        private System.Windows.Forms.Timer timer_send_data;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}

