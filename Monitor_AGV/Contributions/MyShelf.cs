using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_AGV.Contributions
{
    public class MyShelf : System.Windows.Forms.PictureBox
    {
        #region Property MyScale
        /// <summary>
        /// Thuộc tính tỉ lệ Kệ để thay đổi kích thước theo tỉ lệ
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Tỉ lệ AGV")]
        [DefaultValue(1)]

        private double _scaleShelf;
        public double ScaleShelf
        {
            get
            {
                return _scaleShelf;
            }
            set
            {
                _scaleShelf = value;

                //Gọi sự kiện thay đổi tỉ lệ
                OnChangeScaleShelf();

                //Gọi hàm thay đổi kích thước theo tỉ lệ
                ThucHienScale(ScaleShelf);
            }
        }
        #endregion

        #region Property IDShelf
        /// <summary>
        /// Thuộc tính ID của kệ
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("ID kệ")]
        [DefaultValue(1)]

        private int _idShelf;
        public int IDShelf
        {
            get
            {
                return _idShelf;
            }
            set
            {
                _idShelf = value;
            }
        }
        #endregion

        #region Property IDFrame
        /// <summary>
        /// Thuộc tính ID của khung 
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("ID khung")]
        [DefaultValue(1)]

        private int _idFrame;
        public int IDFrame
        {
            get
            {
                return _idFrame;
            }
            set
            {
                _idFrame = value;
            }
        }
        #endregion

        #region Event ChangeScaleShelf
        /// <summary>
        /// Hàm thay đổi kích thước theo tỉ lệ
        /// </summary>
        /// <param name="scale">Tỷ lệ</param>
        private void ThucHienScale(double scale)
        {
            if (Image != null)
            {
                this.Height = Convert.ToInt32(this.Image.Height * scale);
                this.Width = Convert.ToInt32(this.Image.Width * scale);
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi thay đổi Tỉ lệ. Khi đó, chiều dài và chiều rộng sẽ được nhân với tỉ lệ mới.
        /// </summary>
        [Category("Sự kiện xây dựng thêm")]
        [Description("Sự kiện thay đổi tỷ lệ")]

        //Khai báo sự kiện
        public event EventHandler ChangeMyScale;
        protected virtual void OnChangeScaleShelf()
        {
            this.ChangeMyScale?.Invoke(this, EventArgs.Empty);

        }
        #endregion
    }
}
