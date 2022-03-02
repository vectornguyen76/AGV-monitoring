using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_AGV
{
    public interface INotify
    {
        /// <summary>
        /// Cài status cho chương trình chính
        /// </summary>
        /// <param name="message">Tin nhắn có thể chứa format</param>
        /// <param name="args">Tham số cho tin nhắn</param>
        void Status(string message = "Sẵn sàng", params object[] args);
    }
}
