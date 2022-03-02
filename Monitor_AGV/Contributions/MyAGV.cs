using System;
using System.ComponentModel;
using System.Drawing;

namespace Monitor_AGV.Contributions
{
    #region enum StatusAgv
    /// <summary>
    /// Trạng thái AGV: Đang hoạt động, giao hàng, nhận hàng, không hoạt động, lỗi, bảo trì, sạc pin
    /// </summary>
    public enum StatusAgv
    {
        Active = 0,
        Delivery = 1,
        Pickup = 2,
        Inactive = 3,
        Error = 4,
        Maintenance = 5,
        Charging = 6
    }
    #endregion

    #region enum TypeAgv
    /// <summary>
    /// Các loại AGV: AGV ngang, AGV dọc
    /// </summary>
    public enum TypeAgv
    {
        Horizontal = 0,
        Vertical = 1,
    }
    #endregion

    public class MyAGV : System.Windows.Forms.PictureBox
    {
        #region Property IDAGV
        /// <summary>
        /// Thuộc tính id AGV để phân biệt các AGV
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Mã Agv")]
        private int _idAGV;
        public int IDAGV
        {
            get
            {
                return _idAGV;
            }
            set
            {
                _idAGV = value;
            }
        }
        #endregion

        #region Property TypeAGV
        /// <summary>
        /// Thuộc tính Type AGV để phân biệt các AGV theo chiều ngang và chiều dọc
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Loại Agv")]
        private TypeAgv _type_agv;
        public TypeAgv TypeAGV
        {
            get
            {
                return _type_agv;
            }
            set
            {
                _type_agv = value;
            }
        }
        #endregion

        #region Property ScaleAGV
        /// <summary>
        /// Thuộc tính tỉ lệ AGV để thay đổi kích thước theo tỉ lệ
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Tỉ lệ AGV")]
        [DefaultValue(1)]

        private double _scaleAGV;
        public double ScaleAGV
        {
            get
            {
                return _scaleAGV;
            }
            set
            {
                _scaleAGV = value;

                //Gọi sự kiện thay đổi tỉ lệ
                OnChangeScaleAGV();

                //Gọi hàm thay đổi kích thước theo tỉ lệ
                ThucHienScale(ScaleAGV);
            }
        }
        #endregion

        #region Property SpeedAGV
        /// <summary>
        /// Thuộc tính tốc độ AGV
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Tốc độ AGV")]
        //[DefaultValue(1)]

        private int _speedAGV;
        public int SpeedAGV
        {
            get
            {
                return _speedAGV;
            }
            set
            {
                _speedAGV = value;
            }
        }
        #endregion      

        #region Property StatusAGV
        /// <summary>
        /// Thuộc tính StatusAGV để lưu các trạng thái AGV.
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Trạng thái AGV")]
        private StatusAgv _statusAGV;
        public StatusAgv StatusAGV
        {
            get
            {
                return _statusAGV;
            }
            set
            {
                _statusAGV = value;

                //Gọi sự kiện thay đổi trạng thái
                OnChangeStatusAGV();
            }
        }
        #endregion

        #region Property EncoderAGV
        /// <summary>
        /// Thuộc tính encoder lưu trữ xung từ PLC gửi lên
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Xung encoder từ PLC")]
        //[DefaultValue(1)]

        private int _encoderAGV;
        public int EncoderAGV
        {
            get
            {
                return _encoderAGV;
            }
            set
            {
                _encoderAGV = value;

                //Mỗi khi thay đổi giá trị -> set, get 1 lần sẽ gọi sự kiện thay đổi xung
                UpdateEncoder(EncoderAGV);
                OnChangeEncoderAGV();
            }
        }
        #endregion      

        #region Property JumpAGV
        /// <summary>
        /// Thuộc tính JumAGV lưu các bước nhảy của AGV trên line
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Bước nhảy AGV")]
        //[DefaultValue(1)]

        private int _jumpAGV;
        public int JumpAGV
        {
            get
            {
                return _jumpAGV;
            }
            set
            {
                _jumpAGV = value;
            }
        }
        #endregion

        #region Property StepLine
        /// <summary>
        /// Thuộc tính StepLine: AGV sẽ di chuyển tới các mốc trên line khi có tín hiệu
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Set các bước nhảy AGV")]
        //[DefaultValue(1)]

        private int _stepLine;
        public int StepLine
        {
            get
            {
                return _stepLine;
            }
            set
            {
                _stepLine = value;

                //Update vị trí sai lệch
                UpdateLocation(StepLine, Location.X, Location.Y);
            }
        }
        #endregion      

        #region Property ScaleEncoder
        /// <summary>
        /// Thuộc tính Scale Encoder để chia tỉ lệ xung thực tế với xung AGV chạy trên màn hình giám sát
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Scale xung encoder từ PLC")]
        //[DefaultValue(1)]

        private int _scaleEncoder;
        public int ScaleEncoder
        {
            get
            {
                return _scaleEncoder;
            }
            set
            {
                _scaleEncoder = value;
            }
        }
        #endregion      

        #region Property MinLength
        /// <summary>
        /// Thuộc tính MinLength là giới hạn nhỏ nhất quãng đường của AGV
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Xung nhỏ nhất từ PLC")]
        //[DefaultValue(1)]

        private int _minLength;
        public int MinLength
        {
            get
            {
                return _minLength;
            }
            set
            {
                _minLength = value;
            }
        }
        #endregion

        #region Property MaxLength
        /// <summary>
        /// Thuộc tính MinLength là giới hạn lớn nhất quãng đường của AGV
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Xung nhỏ nhất từ PLC")]
        //[DefaultValue(1)]

        private int _maxLength;
        public int MaxLength
        {
            get
            {
                return _maxLength;
            }
            set
            {
                _maxLength = value;
            }
        }
        #endregion

        #region Event ChangeScaleAGV
        /// <summary>
        /// Hàm thay đổi kích thước theo tỉ lệ
        /// </summary>
        /// <param name="scale">Tỷ lệ </param>
        private void ThucHienScale(double scale)
        {
            if (Image != null)
            {   
                this.Height = Convert.ToInt32(this.Image.Height * scale);
                this.Width = Convert.ToInt32(this.Image.Width * scale);
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi thay đổi Tỉ lệ. Khi đó, chiều dài và chiều rộng sẽ được nhân với tỉ lệ mới
        /// </summary>
        [Category("Sự kiện xây dựng thêm")]
        [Description("Sự kiện thay đổi tỷ lệ")]
        public event EventHandler ChangeScaleAGV;

        protected virtual void OnChangeScaleAGV()
        {
            this.ChangeScaleAGV?.Invoke(this, EventArgs.Empty);

        }
        #endregion

        #region Event ChangeEncoderAGV

        private void UpdateEncoder(int encoder)
        {
            if (TypeAGV == TypeAgv.Horizontal)
            {
                //Tìm toạ độ bước nhảy cho AGV theo trục X, Y
                int X_axis = MinLength + encoder/ScaleEncoder + ToleranceEncoder;
                int Y_axis = Location.Y;

                //Lấy giới hạn quãng đường
                int min = MinLength;
                int max = MaxLength;

                //Giới hạn quãng đường tối thiểu
                if (X_axis <= min)
                {
                    Location = new Point(min, Y_axis);
                }
                //Giới hạn quãng đường tối đa
                else if (X_axis >= max)
                {
                    Location = new Point(max, Y_axis);
                }
                else
                    Location = new Point(X_axis, Y_axis);
            }
            else if (TypeAGV == TypeAgv.Vertical)
            {
                //Tìm toạ độ bước nhảy cho AGV theo trục X, Y
                int X_axis = Location.X;
                int Y_axis = MinLength + encoder / ScaleEncoder + ToleranceEncoder;

                //Lấy giới hạn quãng đường
                int min = MinLength;
                int max = MaxLength;

                //Giới hạn quãng đường tối thiểu
                if (Y_axis <= min)
                {
                    Location = new Point(X_axis, min);
                }
                //Giới hạn quãng đường tối đa
                else if (Y_axis >= max)
                {
                    Location = new Point(X_axis, max);
                }
                else
                    Location = new Point(X_axis, Y_axis);
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi giá trị Encoder thay đổi
        /// </summary>
        [Category("Sự kiện xây dựng thêm")]
        [Description("Xung encoder thay đổi")]
        public event EventHandler ChangeEncoderAGV;

        protected virtual void OnChangeEncoderAGV()
        {
            this.ChangeEncoderAGV?.Invoke(this, EventArgs.Empty);

        }
        #endregion

        #region Event ChangeStatusAGV  
        /// <summary>
        /// Sự kiện xảy ra khi trạng thái AGV thay đổi
        /// </summary>
        [Category("Sự kiện xây dựng thêm")]
        [Description("Thay đổi trạng thái")]
        public event EventHandler ChangeStatusAGV;//Khai báo sự kiện
        protected virtual void OnChangeStatusAGV()
        {
            this.ChangeStatusAGV?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region UpdateLocationAGV
        /// <summary>
        /// Biến lưu sai số Encoder
        /// </summary>
        private int ToleranceEncoder = 0;

        /// <summary>
        /// Update vị trí AGV khi xảy ra sai số
        /// </summary>
        /// <param name="stepLine">Các mốc trên line</param>
        /// <param name="locationX">Toạ độ AGV hiện tại trên trục X</param>
        /// <param name="locationY">Toạ độ AGV hiện tại trên trục Y</param>
        private void UpdateLocation(int stepLine, int locationX, int locationY)
        {
            if (TypeAGV == TypeAgv.Horizontal)
            {
                //Tìm vị trí của StepLine
                int X_axis = MinLength + stepLine * JumpAGV; 

                //Tính sai số chênh lệch
                int Tolerance = X_axis - locationX;

                //Update sai số chênh lệch
                ToleranceEncoder = ToleranceEncoder + Tolerance;
            }
            else if (TypeAGV == TypeAgv.Vertical)
            {
                //Tìm vị trí của StepLine
                int Y_axis = MinLength + stepLine * JumpAGV;

                //Tính sai số chênh lệch
                int Tolerance = Y_axis - locationY;

                //Update sai số chênh lệch
                ToleranceEncoder = ToleranceEncoder + Tolerance;
            }
        }

        #endregion
    }
}
