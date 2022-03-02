using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Monitor_AGV.Contributions;
using Monitor_AGV.LoadDatas;
using Microsoft.Win32;

namespace Monitor_AGV
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        INotify _iNotify;
        #region Khởi tạo đối tượng và khai báo biến

        /// <summary>
        /// List lưu các AGV được khởi tạo
        /// </summary>
        List<MyAGV> agvs = new List<MyAGV>();

        /// <summary>
        /// List lưu các Shelf được khởi tạo
        /// </summary>
        List<MyShelf> shelves = new List<MyShelf>();

        /// <summary>
        /// List lưu các Line ngang được khởi tạo
        /// </summary>
        List<MyLine> lineNgang = new List<MyLine>();

        /// <summary>
        /// List lưu ID kệ được click
        /// </summary>
        List<string> ID_Shelf = new List<string>();

        /// <summary>
        /// List lưu ID line ngang được click
        /// </summary>
        List<string> ID_Line_Ngang = new List<string>();

        /// <summary>
        /// ID AGV ngang đọc từ database
        /// </summary>
        List<int> _NameAGVNgang = new List<int>()
        {
            601,602,603,604,605,606
        };

        /// <summary>
        /// ID AGV dọc đọc từ database
        /// </summary>
        List<int> _NameAGVDoc = new List<int>()
        {
            607,608
        };

        #endregion
        public frmSetting(INotify iNotify)
        {
            this._iNotify = iNotify;
            Text = "Setting";
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            //Load các dữ liệu gồm: kệ, agv, line
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadData()
        {
            #region Khai báo biến 

            //Biến lưu chiều cao và chiều rộng GroupControl WorkSpace AGV
            int height_grpAGV;
            int width_grpAGV;

            //Biến lưu tổng số cột, hàng, ngăn
            int total_columns;
            int total_rows;
            int total_sections;

            //Tổng số AGV theo phương ngang
            int total_AGV_ngang;

            //Tổng số AGV theo phương dọc
            int total_AGV_doc;

            //Vị trí đặt trạm sạc
            int location_charging;

            //Vị trí đặt trạm nhập xuất
            int location_exchange;

            //Biến lưu bước nhảy các mốc trên line ngang
            int Jump_AGV_ngang;

            //Biến lưu bước nhảy các mốc trên line dọc
            int Jump_AGV_doc;

            //Toạ độ trục X của kệ đầu tiên (Chọn làm gốc toạ độ)
            int Set_point_X;

            //Toạ độ trục Y của kệ đầu tiên (Chọn làm gốc toạ độ)
            int Set_point_Y;

            //Tỉ lệ chung
            double _scale;

            //Biến điều chỉnh tỉ lệ kệ và agv
            double scale_shelf;
            double scale_line;
            double scale_agv;

            //Biến lưu khoảng cách giữa các hàng
            int distance_rows;

            //Biến lưu loại kệ
            string type_shelf;

            //Khai báo ID kệ và ID các khung
            int _idShelf = 0;
            int _idFrame = 0;

            //Khai báo ID line ngang
            int _idLineNgang = 0;

            #endregion

            #region Ghi và đọc dữ liệu từ Registry

            //Khởi tạo Registry
            MyRegistry myRegistry = new MyRegistry();

            //Gửi dữ liệu xuống Registry
            myRegistry.WriteRegistry();

            //Đọc dữ liệu từ Registry
            myRegistry.ReadRegistry();

            //Lấy thông số chiều cao, chiều rộng của GroupControl WorkSpace AGV
            height_grpAGV = myRegistry.height_grpAGV;
            width_grpAGV = myRegistry.width_grpAGV;

            //Lấy các thông số khởi tạo kệ, line
            total_columns = myRegistry.total_columns;
            total_rows = myRegistry.total_rows;
            total_sections = myRegistry.total_sections;
            _scale = myRegistry.scale;
            location_charging = myRegistry.location_charging;
            location_exchange = myRegistry.location_exchange;

            //Biến điều chỉnh tỉ lệ kệ và agv
            scale_shelf = _scale;
            scale_line = _scale;
            scale_agv = _scale;

            //Biến lưu khoảng cách giữa các hàng
            distance_rows = (int)(40 * _scale);
            #endregion

            #region Test
            //Test nhanh (Xoá khi không test)
            //total_columns = 15;
            //total_rows = 7;
            //total_sections = 3;
            //distance_rows = 24;
            //total_AGV_ngang = 6;
            //total_AGV_doc = 2;
            #endregion

            #region Khởi tạo đối tượng và tạo đối tượng mẫu

            //Khởi tạo đối tượng
            LoadSample loadSample = new LoadSample();
            Shelf shelf = new Shelf();
            Line line = new Line();
            
            //Load kệ đơn mẫu
            loadSample.SingleShelf_sample(scale_shelf);

            //Load kệ đôi mẫu
            loadSample.DoubleShelf_sample(scale_shelf);

            //Load line ngang mẫu
            loadSample.line_ngang_sample(scale_line);

            //Load agv ngang mẫu
            loadSample.AGV_ngang_sample(scale_agv);
            #endregion

            #region Lấy thông số đầu vào setup

            //Lấy bước nhảy AGV ngang
            Jump_AGV_ngang = loadSample.width_line_ngang;

            //Lấy bước nhảy AGV dọc
            Jump_AGV_doc = loadSample.height_line_doc;

            //Tổng AGV ngang, dọc lấy từ list danh sách tên AGV
            total_AGV_ngang = _NameAGVNgang.Count();
            total_AGV_doc = _NameAGVDoc.Count();

            //Set giá trị ban đầu
            Set_point_X = (width_grpAGV - loadSample.width_line_ngang * total_sections * total_columns) / 2;
            Set_point_Y = (height_grpAGV - grp_thaotac.Height - (total_rows - 1) * (2 * loadSample.height_SingleShelf_sample + distance_rows)) / 2;

            #endregion

            #region Set up các đối tượng
            
            //Vòng lặp theo từng hàng ngang của kệ
            for (int now_row = 0; now_row < total_rows; now_row++)
            {
                #region Set up kệ 
                //Reset vị trí sau mỗi hàng
                shelf.total_width_shelf = 0;

                //Phân biệt kệ đơn và ghép
                if (now_row == 0 || now_row == (total_rows - 1))
                {
                    type_shelf = "_single";
                }
                else type_shelf = "_double";

                //Vòng lặp theo từng cột
                for (int now_column = 0; now_column < total_columns; now_column++)
                {
                    _idFrame++;
                    //Vòng lặp theo từng ngăn
                    for (int now_section = 1; now_section <= total_sections; now_section++)
                    {
                        _idShelf++;
                        //Tìm vị trí theo trục X, Y
                        int X_axis = Set_point_X + shelf.total_width_shelf;
                        int Y_axis = Set_point_Y + now_row * distance_rows + shelf.total_height_shelf;
                        MyShelf myshelf = shelf._shelfes(X_axis, Y_axis, type_shelf, now_section, total_sections, now_column, total_columns, scale_shelf, _idShelf, _idFrame);
                        
                        //Thêm từng ngăn kệ vào GroupControl
                        GrpCtrl_WorkSpaceAGV.Controls.Add(myshelf);

                        //Thêm kệ vào list kệ
                        shelves.Add(myshelf);

                        //Tạo sự kiện click kệ
                        myshelf.Click += _shelf_Click;
                    }
                }

                #endregion

                #region Set up line ngang
                //Reset vị trí line sau mỗi hàng
                int _viTriKhoiTao = 0;

                //Set up line theo phương ngang
                while ((_viTriKhoiTao < (shelf.total_width_shelf)) && (now_row < (total_rows - 1)))
                {
                    //Tăng ID line ngang
                    _idLineNgang++;

                    //Tìm vị trí theo trục X, Y
                    int X_axis = Set_point_X + _viTriKhoiTao;
                    int Y_axis = Set_point_Y + now_row * distance_rows + shelf.total_height_shelf + (distance_rows - loadSample.height_line_ngang) / 2;

                    MyLine _lineNgang = line.line_ngang(X_axis, Y_axis, scale_line, _idLineNgang);

                    //Lấy vị trí khởi tạo tiếp theo
                    _viTriKhoiTao = _viTriKhoiTao + loadSample.width_line_ngang;

                    //Thêm từng line vào GroupControl
                    GrpCtrl_WorkSpaceAGV.Controls.Add(_lineNgang);

                    //Add to list
                    lineNgang.Add(_lineNgang);

                    //Create event
                    _lineNgang.Click += _lineNgang_Click;
                }

                #endregion

                
            }

           #endregion
        }

        private void _shelf_Click(object sender, EventArgs e)
        {
            MyShelf shelf = sender as MyShelf;

            MyShelf this_shelf = null;

            //tìm các kệ có cùng id khung 
            foreach (MyShelf _shelf in shelves)
            {
                if(_shelf.IDFrame == shelf.IDFrame)
                {
                    ID_Shelf.Add(_shelf.IDShelf.ToString());
                }
            }
            
            //Xử lí từng kệ 
            foreach (string _id in ID_Shelf)
            {
                this_shelf = shelves.Find(x => x.IDShelf.ToString() == _id);

                //xoá các hình của các shelf có id_column được tìm thấy
                this_shelf.Image = null;
            }
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            //Chuyển từ list sang string array để lưu xuống registry
            string[] id_shelf = ID_Shelf.ToArray();
            string[] id_line_ngang = ID_Line_Ngang.ToArray();

            //Lưu ID kệ xuống Registry
            RegistryKey data = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
            data.SetValue("ID_Shelf", id_shelf);
            data.SetValue("ID_Line_Ngang", id_line_ngang);
            data.Close();
        }

        private void _lineNgang_Click(object sender, EventArgs e)
        {
            MyLine _lineNgang = sender as MyLine;

            ID_Line_Ngang.Add(_lineNgang.IDLine.ToString());

            //Xoá các Image Line được click
            _lineNgang.Image = null;
        }
    }
}