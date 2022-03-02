using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using S7.Net;
using information;
using Monitor_AGV.Contributions;
using Monitor_AGV.LoadDatas;
using Monitor_AGV.Communication;

namespace Monitor_AGV
{
    public partial class frmAGV : DevExpress.XtraEditors.XtraForm
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

        /// <summary>
        /// Biến lưu mã AGV khi được Clicked
        /// </summary>
        private int id_clicked;

        /// <summary>
        /// Khởi tạo class Plc thư viện S7.Net
        /// </summary>
        private Plc plc = null;

        /// <summary>
        /// Khởi tạo enum lỗi khi kết nối PLC
        /// </summary>
        private ErrorCode errCode;

        #endregion

        public frmAGV(INotify iNotify)
        {
            this._iNotify = iNotify;
            Text = "ĐIỀU KHIỂN GIÁM SÁT AGVS";
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


        /// <summary>
        /// Hàm load các dữ liệu gồm kệ, agv, line
        /// </summary>
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

            //Biến lưu giới hạn line dọc
            int limit_line_doc;

            //Tỉ lệ chung
            double _scale;

            //Biến điều chỉnh tỉ lệ kệ và agv
            double scale_shelf;
            double scale_line;
            double scale_agv;
            double scale_station;

            //Biến lưu khoảng cách giữa các hàng
            int distance_rows;

            //Biến lưu loại kệ
            string type_shelf;

            //Biến lưu ID của kệ
            string[] IDShelf;

            //Biến lưu ID của line ngang
            string[] IDLineNgang;

            //Khai báo ID kệ và ID các khung
            int _idShelf = 0;
            int _idFrame = 0;

            //Khai báo ID line ngang
            int _idLineNgang = 0;

            //Khai báo ID line dọc
            int _idLineDoc = 0;

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
            IDShelf = myRegistry.id_shelf;
            IDLineNgang = myRegistry.id_line_ngang;

            //Biến điều chỉnh tỉ lệ kệ và agv
            scale_shelf = _scale;
            scale_line = _scale;
            scale_agv = _scale;
            scale_station = _scale;

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
            AGV agv = new AGV();
            Station station = new Station();

            //Load kệ đơn mẫu
            loadSample.SingleShelf_sample(scale_shelf);

            //Load kệ đôi mẫu
            loadSample.DoubleShelf_sample(scale_shelf);

            //Load line ngang mẫu
            loadSample.line_ngang_sample(scale_line);

            //Load line dọc mẫu
            loadSample.line_doc_sample(scale_line);

            //Load agv ngang mẫu
            loadSample.AGV_ngang_sample(scale_agv);

            //Load agv dọc mẫu
            loadSample.AGV_doc_sample(scale_agv);

            //Load trạm sạc mẫu
            loadSample.charging_sample(scale_station);

            //Load trạm nhập xuất mẫu
            loadSample.exchange_sample(scale_station);
            #endregion

            #region Lấy thông số đầu vào setup
            //Khoảng cách hàng
            distance_rows = 2 * loadSample.height_line_doc - loadSample.height_DoubleShelf_sample;

            //Lấy bước nhảy AGV ngang
            Jump_AGV_ngang = loadSample.width_line_ngang;

            //Lấy bước nhảy AGV dọc
            Jump_AGV_doc = loadSample.height_line_doc;

            //Tổng AGV ngang, dọc lấy từ list danh sách tên AGV
            total_AGV_ngang = _NameAGVNgang.Count();
            total_AGV_doc = _NameAGVDoc.Count();

            //Set giá trị ban đầu
            Set_point_X = (width_grpAGV - loadSample.width_line_ngang * total_sections * total_columns - (total_AGV_doc * (loadSample.width_agv_doc_sample +  distance_rows))) / 2;
            Set_point_Y = (height_grpAGV - _history.Height - (total_rows - 1) * (2 * loadSample.height_SingleShelf_sample + distance_rows)) / 2;

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
                        shelves.Add(myshelf);

                        //Check Setting
                        bool checkIDShelf = IDShelf.Contains(_idShelf.ToString());
                        if(checkIDShelf == true)
                        {
                            myshelf.Image = null;
                        }
                    }
                }

                #endregion

                #region Set up line ngang
                //Reset sau mỗi hàng
                int _viTriKhoiTao = 0;
                int id = 0;
                int _viTriBatDau = 0;
                int _tongChieuDaiLine = 0;

                //Set up line theo phương ngang
                while ((_viTriKhoiTao < (shelf.total_width_shelf)) && (now_row < (total_rows - 1)))
                {
                    //Tăng ID line ngang
                    _idLineNgang++;

                    //Tìm vị trí theo trục X, Y
                    int X_axis = Set_point_X + _viTriKhoiTao;
                    int Y_axis = Set_point_Y + now_row * distance_rows + shelf.total_height_shelf + (distance_rows - loadSample.height_line_ngang) / 2;

                    //Check ID
                    bool checkID = IDLineNgang.Contains(_idLineNgang.ToString());

                    if(checkID == false)
                    {
                        MyLine _lineNgang = line.line_ngang(X_axis, Y_axis, scale_line, _idLineNgang);

                        //Thêm từng line vào GroupControl
                        GrpCtrl_WorkSpaceAGV.Controls.Add(_lineNgang);
                        _tongChieuDaiLine = _tongChieuDaiLine + _lineNgang.Width;
                        id++;
                    }

                    //Lấy vị trí khởi tạo tiếp theo
                    _viTriKhoiTao = _viTriKhoiTao + loadSample.width_line_ngang;

                    //Lấy vị trí bắt đầu cho AGV
                    if(id == 1)
                    {
                        _viTriBatDau = X_axis;
                    }
                }

                #endregion

                #region Set up AGV ngang

                //Set up AGV theo phương ngang
                if (now_row < total_AGV_ngang)
                {
                    //Tìm các thông số set up AGV ngang
                    int X_axis = _viTriBatDau;
                    int Y_axis = Set_point_Y + now_row * distance_rows + shelf.total_height_shelf + (distance_rows - loadSample.height_agv_ngang_sample) / 2;
                    int ID_AGV = _NameAGVNgang[now_row];
                    int scaleEncoder = 200;
                    int Minlength = _viTriBatDau;
                    int Maxlength = _viTriBatDau + _tongChieuDaiLine - loadSample.width_agv_ngang_sample;

                    //Khởi tạo đối tượng AGV ngang
                    MyAGV _agv = agv.AGV_Ngang(X_axis, Y_axis, scale_agv, scaleEncoder, ID_AGV, Minlength, Maxlength, Jump_AGV_ngang);

                    //Khởi tạo các sự kiện của AGV
                    LoadEvent(_agv);

                    //Add AGV vừa khởi tạo vào list AGV
                    agvs.Add(_agv);

                    //Thêm từng AGV vào GroupControl
                    GrpCtrl_WorkSpaceAGV.Controls.Add(_agv);

                    //Set up AGV phía trên Line
                    _agv.BringToFront();
                }

                #endregion
            }

            //Set up AGV và line theo phương dọc
            for (int now_AGV_doc = 0; now_AGV_doc < total_AGV_doc; now_AGV_doc++)
            {
                #region Set up line dọc
                //Reset sau mỗi hàng
                int _viTriKhoiTao = 0;

                //Lấy giới hạn line dọc
                limit_line_doc = 2 * loadSample.height_SingleShelf_sample + (total_rows - 2) * loadSample.height_DoubleShelf_sample + (total_rows - 1) * distance_rows + 2 * loadSample.height_line_doc;

                //Set up line theo phương dọc
                while (_viTriKhoiTao < limit_line_doc)
                {
                    //ID line dọc
                    _idLineDoc++;

                    //Tìm vị trí theo trục X, Y
                    int X_axis_line = Set_point_X + shelf.total_width_shelf + now_AGV_doc * (loadSample.width_agv_doc_sample + loadSample.width_line_doc) + distance_rows / 2 + (loadSample.width_agv_doc_sample - loadSample.width_line_doc) / 2;
                    int Y_axis_line = Set_point_Y + loadSample.height_SingleShelf_sample + distance_rows / 2 - loadSample.height_agv_doc_sample / 2 + _viTriKhoiTao - 2 * loadSample.height_line_doc;

                    MyLine _lineDoc = line.line_doc(X_axis_line, Y_axis_line, scale_line, _idLineDoc);
                    _viTriKhoiTao = _viTriKhoiTao + loadSample.height_line_doc;
                    //Thêm từng line vào GroupControl
                    GrpCtrl_WorkSpaceAGV.Controls.Add(_lineDoc);
                }
                
                #endregion

                #region Set up AGV dọc

                //Tìm các thông số set up AGV dọc
                int X_axis = Set_point_X + shelf.total_width_shelf + now_AGV_doc * (loadSample.width_agv_doc_sample + loadSample.height_line_ngang) + distance_rows / 2;
                int Y_axis = Set_point_Y + loadSample.height_SingleShelf_sample + distance_rows / 2 - loadSample.height_agv_doc_sample / 2 - 2 * loadSample.height_line_doc;
                int ID_AGV = _NameAGVDoc[now_AGV_doc];
                int scale_Encoder = 230;
                int Minlength = Y_axis;
                int Maxlength = Y_axis + _viTriKhoiTao - loadSample.height_agv_doc_sample;

                //Khởi tạo đối tượng AGV dọc
                MyAGV _agv = agv.AGV_Doc(X_axis, Y_axis, scale_agv, scale_Encoder, ID_AGV, Minlength, Maxlength, Jump_AGV_doc);

                //Add AGV vừa khởi tạo vào list AGV
                agvs.Add(_agv);

                //Khởi tạo các sự kiện của AGV
                LoadEvent(_agv);

                //Thêm từng AGV vào GroupControl
                GrpCtrl_WorkSpaceAGV.Controls.Add(_agv);

                //Set up AGV phía trên Line
                _agv.BringToFront();

                #endregion

                #region Set up Trạm sạc, Trạm nhập, Trạm xuất (Test)

                if (now_AGV_doc == total_AGV_doc - 1)
                {
                    int X_Station = X_axis + loadSample.width_line_doc + 10;
                    int Y_Charging1 = Y_axis + location_charging * loadSample.height_line_doc;
                    int Y_Charging2 = Y_axis + _viTriKhoiTao - loadSample.height_charging - location_charging * loadSample.height_line_doc;
                    int Y_Exchange1 = Y_axis + location_exchange * loadSample.height_line_doc;
                    int Y_Exchange2 = Y_axis + _viTriKhoiTao - loadSample.height_exchange - location_exchange * loadSample.height_line_doc;

                    GrpCtrl_WorkSpaceAGV.Controls.Add(station.Charging(X_Station, Y_Charging1, scale_station, 1));

                    GrpCtrl_WorkSpaceAGV.Controls.Add(station.Charging(X_Station, Y_Charging2, scale_station, 2));

                    GrpCtrl_WorkSpaceAGV.Controls.Add(station.Exchange(X_Station, Y_Exchange1, scale_station, 3));

                    GrpCtrl_WorkSpaceAGV.Controls.Add(station.Exchange(X_Station, Y_Exchange2, scale_station, 4));

                }

                #endregion
            }
            #endregion

        }

        private void frmAGV_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_Start_PLC_Click(object sender, EventArgs e)
        {
            //Kết nối với PLC
            Connect_PLC();
        }

        private void timer_read_data_Tick(object sender, EventArgs e)
        {
            //Đọc data từ PLC
            ReadData_PLC();
        }

        private void AGV_Clicked(object sender, EventArgs e)
        {
            //Bắt AGV được click
            MyAGV agv_clicked = sender as MyAGV;

            //Gọi hàm xử lí sự kiện click agv
            ClickedAGV(agv_clicked);
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            //Reset trạng thái AGV

            //Gán trạng thái về 0 (active)
            int status_agv = 0;

            //Gửi Data xuống PLC
            WriteData_PLC(id_clicked, status_agv);
        }

        private void Btn_Update_Speed_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_Random_Click(object sender, EventArgs e)
        {
            //Kích hoạt timer gửi data
            timer_send_data.Enabled = true;
        }

        private void timer_send_data_Tick(object sender, EventArgs e)
        {
            //Tạo ID AGV random
            Random random = new Random();
            int id_random = random.Next(601, 609);

            MyAGV agv = Find_AGV(id_random);

            //Gửi ID AGV xuống PLC
            WriteData_PLC(id_random, (int)agv.StatusAGV);
        }

        /// <summary>
        /// Khai báo các sự kiện của AGV
        /// </summary>
        /// <param name="agv">AGV khai báo sự kiện</param>
        void LoadEvent(MyAGV agv)
        {
            //Khai báo sự kiện AGV ngang được Clicked
            agv.Click += AGV_Clicked;
        }

        /// <summary>
        /// Hàm kết nối với PLC
        /// </summary>
        void Connect_PLC()
        {
            try
            {
                //Khởi tạo kết nối PLC 
                plc = new Plc(CpuType.S71200, "127.0.0.1", 0, 1);

                //Lưu trạng thái kết nối PLC
                errCode = plc.Open();

                //Kiểm tra trạng thái kết nối PLC
                if (errCode == ErrorCode.NoError)
                {
                    MessageBox.Show("Connect Successfully");
                    //kích hoạt timer đọc data
                    timer_read_data.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cannot connect to PLC");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm đọc data từ PLC
        /// </summary>
        void ReadData_PLC()
        {
            try
            {
                if (errCode != ErrorCode.NoError) return;

                ExchangeData readPLC = new ExchangeData();

                plc.ReadClass(readPLC, 1);

                //Đọc ID AGV từ AGV
                int id_agv = readPLC.ID_AGV;

                //Kiểm tra ID trong list ID được khai báo
                if (_NameAGVNgang.Contains(id_agv) == true || _NameAGVDoc.Contains(id_agv) == true)
                {
                    //Đọc các thông số từ PLC
                    int status_agv = readPLC.Status_AGV;
                    int encoder = readPLC.Position;
                    int step_line = readPLC.Position / 5000;
                    int speed_agv = readPLC.Speed;

                    //Tìm đối tượng AGV đã được set up
                    MyAGV found_agv = Find_AGV(id_agv);

                    //Update các thông số AGV đọc từ PLC
                    UpdateAGV update = new UpdateAGV(found_agv, speed_agv, encoder, step_line, status_agv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tìm đối tượng AGV trong mảng AGV đã được setup
        /// </summary>
        /// <param name="idAGV">ID AGV</param>
        /// <returns>Trả về đối tượng AGV tìm được</returns>
        MyAGV Find_AGV(int idAGV)
        {
            MyAGV this_agv = null;

            //Lọc AGV từ list AGV theo ID
            this_agv = agvs.Find(x => x.IDAGV == idAGV);

            return this_agv;
        }

        /// <summary>
        /// Hàm đọc data từ PLC
        /// </summary>
        /// <param name="id_AGV">Mã AGV</param>
        /// <param name="statusAGV">Trạng thái AGV</param>
        void WriteData_PLC(int id_AGV, int statusAGV)
        {
            try
            {
                ExchangeData writePLC = new ExchangeData();

                writePLC.ID_AGV = Convert.ToInt16(id_AGV);
                writePLC.Status_AGV = Convert.ToInt16(statusAGV);

                if (errCode != ErrorCode.NoError) return;
                plc.WriteClass(writePLC, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm xử lí sự kiện Click AGV. Hiện thông tin AGV lên 1 form mới.
        /// </summary>
        /// <param name="agvClick">AGV được click</param>
        void ClickedAGV(MyAGV agvClick)
        {
            //Khởi tạo đối tượng từ form Infor
            fInfor frm_infor = new fInfor();

            //Điền các thông tin cho form
            frm_infor.Txb_IDAGV.Text = agvClick.IDAGV.ToString();
            frm_infor.Txb_StatusAGV.Text = agvClick.StatusAGV.ToString();
            frm_infor.Txb_Speed.Text = agvClick.SpeedAGV.ToString();

            //Lưu ID AGV được click
            id_clicked = agvClick.IDAGV;

            //Tạo sự kiện cho nút Reset
            frm_infor.Btn_Reset.Click += Btn_Reset_Click;

            //Tạo sự kiện cho nút Update Speed
            frm_infor.Btn_Update_Speed.Click += Btn_Update_Speed_Click;

            //Show Infor
            frm_infor.ShowDialog();
        }
    }
}