using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_AGV.Contributions
{
    public class MyLine : System.Windows.Forms.PictureBox
    {
        #region Property ScaleLine
        /// <summary>
        /// Thuộc tính tỉ lệ Kệ để thay đổi kích thước theo tỉ lệ
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Tỉ lệ AGV")]
        [DefaultValue(1)]

        private double _scaleLine;
        public double ScaleLine
        {
            get
            {
                return _scaleLine;
            }
            set
            {
                _scaleLine = value;

                //Gọi sự kiện thay đổi tỉ lệ
                OnChangeScaleLine();

                //Gọi hàm thay đổi kích thước theo tỉ lệ
                ThucHienScale(ScaleLine);
            }
        }
        #endregion

        #region Property IDLine
        /// <summary>
        /// Thuộc tính ID của line
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("ID line")]
        [DefaultValue(1)]

        private int _idLine;
        public int IDLine
        {
            get
            {
                return _idLine;
            }
            set
            {
                _idLine = value;
            }
        }
        #endregion

        #region Event ChangeScaleLine
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
        protected virtual void OnChangeScaleLine()
        {
            this.ChangeMyScale?.Invoke(this, EventArgs.Empty);

        }
        #endregion
    }
}
