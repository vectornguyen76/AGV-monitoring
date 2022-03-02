using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Monitor_AGV.Contributions
{
    #region enum TypeStation
    
    /// <summary>
    /// Loại trạm: Trạm nhập xuất, trạm sạc
    /// </summary>
    public enum TypeStation
    {
        Exchange = 0,
        Charging = 1,
    }
    #endregion
    public class MyStation : System.Windows.Forms.PictureBox
    {
        #region Property IDStation
        /// <summary>
        /// Thuộc tính ID các trạm 
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("ID trạm")]
        private int _idStation;
        public int IDStation
        {
            get
            {
                return _idStation;
            }
            set
            {
                _idStation = value;
            }
        }
        #endregion

        #region Property TypeStation
        /// <summary>
        /// Thuộc tính Type Station để phân biệt các loại trạm (Nhập xuất và sạc)
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Loại trạm")]
        private TypeStation _typeStation;
        public TypeStation TypeStation
        {
            get
            {
                return _typeStation;
            }
            set
            {
                _typeStation = value;
            }
        }
        #endregion

        #region Property ScaleStation
        /// <summary>
        /// Thuộc tính tỉ lệ AGV để thay đổi kích thước theo tỉ lệ
        /// </summary>
        [Category("Thuộc tính mới")]
        [Description("Tỉ lệ trạm")]
        [DefaultValue(1)]

        private double _scaleStation;
        public double ScaleStation
        {
            get
            {
                return _scaleStation;
            }
            set
            {
                _scaleStation = value;
                //Gọi hàm thay đổi kích thước theo tỉ lệ
                ThucHienScale(ScaleStation);
            }
        }
        #endregion

        #region Event ScaleStation
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
        #endregion
    }
}
