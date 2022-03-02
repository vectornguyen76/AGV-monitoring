using System.Drawing;
using System.Windows.Forms;
using Monitor_AGV.Contributions;

namespace Monitor_AGV.LoadDatas
{
    public class Line
    {

        /// <summary>
        /// Line ngang
        /// </summary>
        /// <param name="X_axis">Toạ độ ban đầu theo trục X</param>
        /// <param name="Y_axis">Toạ độ ban đầu theo trục Y</param>
        /// <param name="scale">Tỉ lệ của line ngang</param>
        /// <returns></returns>
        public MyLine line_ngang(int X_axis, int Y_axis, double scale, int id_line)
        {
            MyLine line = new MyLine
            {
                Location = new Point(X_axis, Y_axis),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = new Bitmap(Application.StartupPath + "\\Resources\\6.png"),
                ScaleLine = scale,
                IDLine = id_line
            };
            return line;
        }

        /// <summary>
        /// Line dọc
        /// </summary>
        /// <param name="X_axis">Toạ độ trục X</param>
        /// <param name="Y_axis">Toạ độ trục Y</param>
        /// <param name="scale">Tỉ lệ</param>
        /// <returns></returns>
        public MyLine line_doc(int X_axis, int Y_axis, double scale, int id_line)
        {
            MyLine line = new MyLine
            {
                Location = new Point(X_axis, Y_axis),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = new Bitmap(Application.StartupPath + "\\Resources\\7.png"),
                ScaleLine = scale,
                IDLine = id_line
            };
            return line;
        }
    }
}
