using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitor_AGV.Contributions;

namespace Monitor_AGV.LoadDatas
{
    class UpdateAGV
    {
        /// <summary>
        /// Cập nhật thông số AGV đọc từ PLC
        /// </summary>
        /// <param name="agv">AGV được đọc về</param>
        /// <param name="speedAGV">Tốc độ AGV</param>
        /// <param name="encoderAGV">Encoder của AGV</param>
        /// <param name="stepLine">Các mốc Line</param>
        /// <param name="statusAGV">Trạng thái AGV</param>
        public UpdateAGV(MyAGV agv, int speedAGV, int encoderAGV, int stepLine, int statusAGV)
        {
            #region Đọc thông số AGV hiện tại
            double now_speed = agv.SpeedAGV;
            int now_Encoder = agv.EncoderAGV;
            int now_Location = agv.StepLine;
            int now_Status = (int)agv.StatusAGV;
            #endregion

            #region Cập nhật tốc độ
            //Kiểm tra tốc độ
            if (now_speed != speedAGV)
            {
                //Cập nhật xung
                agv.SpeedAGV = speedAGV;
            }
            #endregion

            #region Cập nhật xung
            //Kiểm tra xung
            if (now_Encoder != encoderAGV)
            {
                //Cập nhật xung
                agv.EncoderAGV = encoderAGV;
            }
            #endregion

            #region Cập nhật các mốc vị trí
            //Kiểm tra vị trí
            if (now_Location != stepLine)
            {
                //Cập nhật vị trí
                agv.StepLine = stepLine;
            }
            #endregion

            #region Cập nhật trạng thái
            //Kiểm tra trạng thái
            if (now_Status != statusAGV)
            {
                //Kiểm tra loại AGV ngang
                if (agv.TypeAGV == TypeAgv.Horizontal)
                {
                    //Cập nhật trạng thái
                    switch (statusAGV)
                    {
                        case 0:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\agv.png");
                                agv.StatusAGV = StatusAgv.Active;
                            }
                            break;
                        case 1:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\delivery.gif");
                                agv.StatusAGV = StatusAgv.Delivery;
                            }
                            break;
                        case 2:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\pickup.gif");
                                agv.StatusAGV = StatusAgv.Pickup;
                            }
                            break;
                        case 3:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\inactive.png");
                                agv.StatusAGV = StatusAgv.Inactive;
                            }
                            break;
                        case 4:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\error.gif");
                                agv.StatusAGV = StatusAgv.Error;
                            }
                            break;
                        case 5:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\maintenance.gif");
                                agv.StatusAGV = StatusAgv.Maintenance;
                            }
                            break;
                        case 6:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\charging_agv_ngang.gif");
                                agv.StatusAGV = StatusAgv.Charging;
                            }
                            break;
                        default:
                            break;
                    }
                }
                //Kiểm tra loại AGV dọc
                else if (agv.TypeAGV == TypeAgv.Vertical)
                {
                    //Cập nhật trạng thái
                    switch (statusAGV)
                    {
                        case 0:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\agv_doc.png");
                                agv.StatusAGV = StatusAgv.Active;
                            }
                            break;
                        case 1:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\delivery_doc.gif");
                                agv.StatusAGV = StatusAgv.Delivery;
                            }
                            break;
                        case 2:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\pickup_doc.gif");
                                agv.StatusAGV = StatusAgv.Pickup;
                            }
                            break;
                        case 3:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\inactive_doc.png");
                                agv.StatusAGV = StatusAgv.Inactive;
                            }
                            break;
                        case 4:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\error_doc.gif");
                                agv.StatusAGV = StatusAgv.Error;
                            }
                            break;
                        case 5:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\maintenance_doc.gif");
                                agv.StatusAGV = StatusAgv.Maintenance;
                            }
                            break;
                        case 6:
                            {
                                agv.Image = new Bitmap(Application.StartupPath + "\\Resources\\charging_agv_doc.gif");
                                agv.StatusAGV = StatusAgv.Charging;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion
        }
    }
}
