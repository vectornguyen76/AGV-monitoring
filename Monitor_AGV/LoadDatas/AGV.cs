using System.Drawing;
using System.Windows.Forms;
using Monitor_AGV.Contributions;

namespace Monitor_AGV.LoadDatas
{
    public class AGV
    {
        /// <summary>
        /// AGV Ngang
        /// </summary>
        /// <param name="x_axis">Toạ độ trục X</param>
        /// <param name="y_axis">Toạ độ trục Y</param>
        /// <param name="scale">Tỉ lệ</param>
        /// <param name="scaleEncoder">Tỉ lệ xung encoder</param>
        /// <param name="idAGV">ID AGV</param>
        /// <param name="minLength">Giới hạn bên trái</param>
        /// <param name="maxLength">Giới hạn bên phải</param>
        /// <param name="jumpAGV">Bước nhảy</param>
        /// <returns></returns>
        public MyAGV AGV_Ngang(int x_axis, int y_axis, double scale, int scaleEncoder, int idAGV, int minLength, int maxLength, int jumpAGV)
        {
            MyAGV agv = new MyAGV()
            {
                Location = new Point(x_axis, y_axis),
                Image = new Bitmap(Application.StartupPath + "\\Resources\\agv.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ScaleAGV = scale,
                ScaleEncoder = scaleEncoder,
                IDAGV = idAGV,
                TypeAGV = TypeAgv.Horizontal,
                MinLength = minLength,
                MaxLength = maxLength,
                JumpAGV = jumpAGV
            };
            return agv;
        }

        /// <summary>
        /// AGV Dọc
        /// </summary>
        /// <param name="x_axis">Toạ độ trục X</param>
        /// <param name="y_axis">Toạ độ trục Y</param>
        /// <param name="scale">Tỉ lệ</param>
        /// <param name="scaleEncoder">Tỉ lệ xung encoder</param>
        /// <param name="idAGV">ID AGV</param>
        /// <param name="minLength">Giới hạn bên trên</param>
        /// <param name="maxLength">Giới hạn bên dưới</param>
        /// <param name="jumpAGV">Bước nhảy</param>
        /// <returns></returns>
        public MyAGV AGV_Doc(int x_axis, int y_axis, double scale, int scaleEncoder, int idAGV, int minLength, int maxLength, int jumpAGV)
        {
            MyAGV agv = new MyAGV()
            {
                Location = new Point(x_axis, y_axis),
                Image = new Bitmap(Application.StartupPath + "\\Resources\\agv_doc.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ScaleAGV = scale,
                ScaleEncoder = scaleEncoder,
                IDAGV = idAGV,
                TypeAGV = TypeAgv.Vertical,
                MinLength = minLength,
                MaxLength = maxLength,
                JumpAGV = jumpAGV
            };
            return agv;
        }
    }
}
