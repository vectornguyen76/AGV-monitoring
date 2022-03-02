namespace Monitor_AGV
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnMonitorAGV = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatusSystem = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.Shelf = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnSettingShelves = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnMonitorAGV,
            this.lblStatusSystem,
            this.btnSettingShelves});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1274, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnMonitorAGV
            // 
            this.btnMonitorAGV.Caption = "Giám Sát Hoạt Động AGVs";
            this.btnMonitorAGV.Id = 1;
            this.btnMonitorAGV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonitorAGV.ImageOptions.Image")));
            this.btnMonitorAGV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMonitorAGV.ImageOptions.LargeImage")));
            this.btnMonitorAGV.Name = "btnMonitorAGV";
            this.btnMonitorAGV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMonitorAGV_ItemClick);
            // 
            // lblStatusSystem
            // 
            this.lblStatusSystem.Caption = "barStaticItem1";
            this.lblStatusSystem.Id = 2;
            this.lblStatusSystem.Name = "lblStatusSystem";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.Shelf});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMonitorAGV);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "AGVs";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblStatusSystem);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 696);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1274, 23);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.RootContainer.Element = null;
            // 
            // Shelf
            // 
            this.Shelf.ItemLinks.Add(this.btnSettingShelves);
            this.Shelf.Name = "Shelf";
            this.Shelf.Text = "Shelf";
            // 
            // btnSettingShelves
            // 
            this.btnSettingShelves.Caption = "Setting Shelves";
            this.btnSettingShelves.Id = 3;
            this.btnSettingShelves.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSettingShelves.ImageOptions.Image")));
            this.btnSettingShelves.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSettingShelves.ImageOptions.LargeImage")));
            this.btnSettingShelves.Name = "btnSettingShelves";
            this.btnSettingShelves.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSettingShelves_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 719);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnMonitorAGV;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarStaticItem lblStatusSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup Shelf;
        private DevExpress.XtraBars.BarButtonItem btnSettingShelves;
    }
}