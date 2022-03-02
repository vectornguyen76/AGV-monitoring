using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_AGV.Communication
{
    /// <summary>
    /// Tạo các biến trao đổi dữ liệu với PLC
    /// </summary>
    public class ExchangeData
    {
        /// <summary>
        /// Mô tả
        /// </summary>
        public short CodeType { get; set; }

        /// <summary>
        /// Độ dài chuỗi data
        /// </summary>
        public short Data_leng { get; set; }

        /// <summary>
        /// ID của AGV đã được đăng kí
        /// </summary>
        public short ID_AGV { get; set; }

        /// <summary>
        /// Vị trí AGV đọc từ PLC
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Tốc độ AGV
        /// </summary>
        public short Speed { get; set; }

        /// <summary>
        /// ID của trạm xuất/nhập
        /// </summary>
        public short ID_Station { get; set; }

        /// <summary>
        /// Đọc các mốc trên line
        /// </summary>
        public short Step_Line { get; set; }

        /// <summary>
        /// Lưu trạng thái AGV
        /// </summary>
        public short Status_AGV { get; set; }
    }
}
