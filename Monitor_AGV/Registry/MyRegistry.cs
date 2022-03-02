using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_AGV
{
    public class MyRegistry
    {
        /// <summary>
        /// Ghi dữ liệu xuống Registry
        /// </summary>
        public void WriteRegistry()
        {
            RegistryKey data = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
            //Nếu số lượng biến ít hơn thì mới ghi giá trị
            if (data.ValueCount < 10)
            {
                data.SetValue("Total_Columns", 15);
                data.SetValue("Total_Rows", 7);
                data.SetValue("Total_Sections", 3);
                data.SetValue("Scale", 1);
                data.SetValue("Location_Charging", 0);
                data.SetValue("Location_Exchange", 4);
                data.Close();
            }
        }

        //Khai báo các biến đọc dữ liệu
        public int height_grpAGV;
        public int width_grpAGV;
        public int total_columns;
        public int total_rows;
        public int total_sections;
        public double scale;
        public int location_charging;
        public int location_exchange;
        public string[] id_shelf;
        public string[] id_line_ngang;

        /// <summary>
        /// Đọc dữ liệu từ Registry
        /// </summary>
        public void ReadRegistry()
        {
            RegistryKey data = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\OurSettings");
            if (data != null)
            {
                total_columns = Convert.ToInt32(data.GetValue("Total_Columns"));
                total_rows = Convert.ToInt32(data.GetValue("Total_Rows"));
                total_sections = Convert.ToInt32(data.GetValue("Total_Sections"));
                scale = Convert.ToDouble(data.GetValue("Scale"));
                location_charging = Convert.ToInt32(data.GetValue("Location_Charging"));
                location_exchange = Convert.ToInt32(data.GetValue("Location_Exchange"));

                id_shelf = (string[])data.GetValue("ID_Shelf");
                id_line_ngang = (string[])data.GetValue("ID_Line_Ngang");

                height_grpAGV = Convert.ToInt32(data.GetValue("HeightGroupControl"));
                width_grpAGV = Convert.ToInt32(data.GetValue("WidthGroupControl"));

                data.Close();
            }

        }
    }
    
}
