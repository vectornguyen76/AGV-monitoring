using System.Drawing;
using System.Windows.Forms;
using Monitor_AGV.Contributions;

namespace Monitor_AGV.LoadDatas
{
    public class LoadSample
    {
        #region Sample Shelf
        /// <summary>
        /// Lấy thông số chiều cao của kệ để đơn setup
        /// </summary>
        public int height_SingleShelf_sample = 0;

        /// <summary>
        /// Khởi tạo kệ mẫu để lấy thông số
        /// </summary>
        /// <param name="scale">Tỉ lệ của kệ</param>
        /// <returns></returns>
        public MyShelf SingleShelf_sample(double scale)
        {
            MyShelf _singleshelf_sample = new MyShelf
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\3.png"),
                ScaleShelf = scale
            };

            //Lấy chiều cao của kệ
            height_SingleShelf_sample = _singleshelf_sample.Height;

            return _singleshelf_sample;
        }

        /// <summary>
        /// Lấy thông số chiều cao của kệ đôi để setup
        /// </summary>
        public int height_DoubleShelf_sample = 0;

        /// <summary>
        /// Khởi tạo kệ mẫu để lấy thông số
        /// </summary>
        /// <param name="scale">Tỉ lệ của kệ</param>
        /// <returns></returns>
        public MyShelf DoubleShelf_sample(double scale)
        {
            MyShelf _doubleshelf_sample = new MyShelf
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\33.png"),
                ScaleShelf = scale
            };

            //Lấy chiều cao của kệ
            height_DoubleShelf_sample = _doubleshelf_sample.Height;

            return _doubleshelf_sample;
        }
        #endregion

        #region Sample Line
        /// <summary>
        /// Lấy chiều cao của đường line
        /// </summary>
        public int height_line_ngang;

        /// <summary>
        /// Lấy thông số chiều rộng của line
        /// </summary>
        public int width_line_ngang;

        /// <summary>
        /// Khởi tạo line mẫu để lấy thông số
        /// </summary>
        /// <param name="scale">Tỉ lệ line</param>
        /// <returns></returns>
        public MyLine line_ngang_sample(double scale)
        {
            MyLine _line_ngang_sample = new MyLine
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\6.png"),
                ScaleLine = scale
            };
            height_line_ngang = _line_ngang_sample.Height;
            width_line_ngang = _line_ngang_sample.Width;

            return _line_ngang_sample;
        }

        /// <summary>
        /// Lấy chiều cao của đường line
        /// </summary>
        public int height_line_doc;

        /// <summary>
        /// Lấy thông số chiều rộng của line
        /// </summary>
        public int width_line_doc;

        /// <summary>
        /// Khởi tạo line mẫu để lấy thông số
        /// </summary>
        /// <param name="scale">Tỉ lệ line</param>
        /// <returns></returns>
        public MyLine line_doc_sample(double scale)
        {
            MyLine _line_doc_sample = new MyLine
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\7.png"),
                ScaleLine = scale
            };
            height_line_doc = _line_doc_sample.Height;
            width_line_doc = _line_doc_sample.Width;

            return _line_doc_sample;
        }

        #endregion

        #region Sample AGV

        /// <summary>
        /// Lấy chiều cao của AGV ngang
        /// </summary>
        public int height_agv_ngang_sample;

        /// <summary>
        /// Lấy chiều rộng của AGV ngang
        /// </summary>
        public int width_agv_ngang_sample;

        /// <summary>
        /// Tạo mẫu AGV để lấy thông số khởi tạo hàng loạt
        /// </summary>
        /// <param name="scale">Tỉ lệ AGV</param>
        /// <returns></returns>
        public MyAGV AGV_ngang_sample(double scale)
        {
            MyAGV _AGV_ngang_sample = new MyAGV
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\agv.png"),
                ScaleAGV = scale
            };
            height_agv_ngang_sample = _AGV_ngang_sample.Height;
            width_agv_ngang_sample = _AGV_ngang_sample.Width;

            return _AGV_ngang_sample;
        }

        /// <summary>
        /// Lấy chiều cao của AGV dọc
        /// </summary>
        public int height_agv_doc_sample;

        /// <summary>
        /// Lấy chiều rộng của AGV dọc
        /// </summary>
        public int width_agv_doc_sample;

        /// <summary>
        /// Tạo mẫu AGV để lấy thông số khởi tạo hàng loạt
        /// </summary>
        /// <param name="scale">Tỉ lệ AGV</param>
        /// <returns></returns>
        public MyAGV AGV_doc_sample(double scale)
        {
            MyAGV _AGV_doc_sample = new MyAGV
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\agv_doc.png"),
                ScaleAGV = scale
            };
            height_agv_doc_sample = _AGV_doc_sample.Height;
            width_agv_doc_sample = _AGV_doc_sample.Width;

            return _AGV_doc_sample;
        }
        #endregion

        #region Sample Station
        public int height_charging;
        public int width_charging;
        public MyStation charging_sample(double scale)
        {
            MyStation _charging_sample = new MyStation
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\charging.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ScaleStation = scale
            };
            height_charging = _charging_sample.Height;
            width_charging = _charging_sample.Width;

            return _charging_sample;
        }

        public int height_exchange;
        public int width_exchange;
        public MyStation exchange_sample(double scale)
        {
            MyStation _exchange_sample = new MyStation
            {
                Image = new Bitmap(Application.StartupPath + "\\Resources\\exchange.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ScaleStation = scale
            };
            height_exchange = _exchange_sample.Height;
            width_exchange = _exchange_sample.Width;

            return _exchange_sample;
        }
        #endregion

    }
}
