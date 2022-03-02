using System.Drawing;
using System.Windows.Forms;
using Monitor_AGV.Contributions;

namespace Monitor_AGV.LoadDatas
{
    public class Station
    {
        /// <summary>
        /// Trạm sạc AGV
        /// </summary>
        /// <param name="X_axis">Toạ độ trục X</param>
        /// <param name="Y_axis">Toạ độ trục Y</param>
        /// <param name="scale">Tỉ lệ</param>
        /// <param name="id_station">ID trạm</param>
        /// <returns></returns>
        public MyStation Charging(int X_axis, int Y_axis, double scale, int id_station)
        {
            MyStation myStation = new MyStation
            {
                Location = new Point(X_axis, Y_axis),
                Image = new Bitmap(Application.StartupPath + "\\Resources\\charging.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ScaleStation = scale,
                IDStation = id_station,
                TypeStation = TypeStation.Charging
            };
            return myStation;
        }

        /// <summary>
        /// Trạm nhập xuất hàng
        /// </summary>
        /// <param name="X_axis">Toạ độ trục X</param>
        /// <param name="Y_axis">Toạ độ trục Y</param>
        /// <param name="scale">Tỉ lệ</param>
        /// <param name="id_station">ID trạm</param>
        /// <returns></returns>
        public MyStation Exchange(int X_axis, int Y_axis, double scale, int id_station)
        {
            MyStation myExchange = new MyStation
            {
                Location = new Point(X_axis, Y_axis),
                Image = new Bitmap(Application.StartupPath + "\\Resources\\exchange.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ScaleStation = scale,
                IDStation = id_station,
                TypeStation = TypeStation.Exchange
            };
            return myExchange;
        }
    }
}
