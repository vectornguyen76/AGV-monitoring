using System.Drawing;
using System.Windows.Forms;
using Monitor_AGV.Contributions;

namespace Monitor_AGV.LoadDatas
{
    public class Shelf 
    {
        /// <summary>
        /// Tổng kích thước theo chiều rộng của kệ
        /// </summary>
        public int total_width_shelf = 0;

        /// <summary>
        /// Chiều cao của kệ
        /// </summary>
        public int total_height_shelf = 0;

        /// <summary>
        /// Kệ chứa hàng
        /// </summary>
        /// <param name="X_axis">Toạ độ ban đầu theo trục X</param>
        /// <param name="Y_axis">Toạ độ ban đầu theo trục Y</param>
        /// <param name="type_shelve">Loại kệ: đơn/ghép</param>
        /// <param name="now_section">Ngăn hiện tại</param>
        /// <param name="total_sections">Tổng số ngăn</param>
        /// <param name="now_colum">Cột hiện tại</param>
        /// <param name="total_columns">Tổng số cột</param>
        /// <param name="scale">Tỷ lệ kệ</param>
        /// <returns></returns>
        public MyShelf _shelfes(int X_axis, int Y_axis, string type_shelve, int now_section, int total_sections, int now_colum, int total_columns, double scale,int _idShelf,  int _idFrame)

        {
            //khai báo
            MyShelf _shelf = new MyShelf
            {
                Location = new Point(X_axis, Y_axis),
                SizeMode = PictureBoxSizeMode.StretchImage,
                IDShelf = _idShelf,
                IDFrame = _idFrame
            };

            //kệ đơn
            if (type_shelve == "_single")
            {
                //Load ảnh ngăn đầu
                if (now_section == 1)
                {
                    _shelf.Image = new Bitmap(Application.StartupPath + "\\Resources\\1.png");
                    _shelf.ScaleShelf = scale;


                }

                //Load ảnh ngăn cuối và cộng dồn chiều cao nếu ở cột cuối cùng
                else if (now_section == total_sections)
                {
                    _shelf.Image = new Bitmap(Application.StartupPath + "\\Resources\\3.png");
                    _shelf.ScaleShelf = scale;

                    if (now_colum == (total_columns - 1))
                        total_height_shelf = total_height_shelf + _shelf.Height;
                }

                //Load ảnh các ngăn ở giữa
                else
                {
                    _shelf.Image = new Bitmap(Application.StartupPath + "\\Resources\\2.png");
                    _shelf.ScaleShelf = scale;
                }

                //Cộng dồn chiều rộng sau mỗi lượt khởi tạo ngăn
                total_width_shelf = total_width_shelf + _shelf.Width;
            }

            //kệ ghép
            else if (type_shelve == "_double")
            {
                //Load ảnh ngăn đầu
                if (now_section == 1)
                {
                    _shelf.Image = new Bitmap(Application.StartupPath + "\\Resources\\11.png");
                    _shelf.ScaleShelf = scale;
                }

                //Load ảnh ngăn cuối và cộng dồn chiều cao nếu ở cột cuối cùng
                else if (now_section == total_sections)
                {
                    _shelf.Image = new Bitmap(Application.StartupPath + "\\Resources\\33.png");
                    _shelf.ScaleShelf = scale;
                    if (now_colum == (total_columns - 1))
                        total_height_shelf = total_height_shelf + _shelf.Height;
                }

                //Load ảnh các ngăn ở giữa
                else
                {
                    _shelf.Image = new Bitmap(Application.StartupPath + "\\Resources\\22.png");
                    _shelf.ScaleShelf = scale;
                }

                //Cộng dồn chiều rộng sau mỗi lượt khởi tạo ngăn
                total_width_shelf = total_width_shelf + _shelf.Width;
            }
            return _shelf;
        }
    }
}
