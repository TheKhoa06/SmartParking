using System;
using System.Drawing;
using System.Windows.Forms;
using SmartParking.Models;
using SmartParking.Services;

namespace SmartParking.UI.Forms
{
    public partial class frmQuickReceipt : Form
    {
        private ParkingSession session;
        private string calculationDetail;

        public frmQuickReceipt() : this(new ParkingSession
        {
            SessionID = 1001,
            PlateNumber = "29B1-555.66",
            VehicleType = "Xe máy",
            SlotCode = "A-01",
            CheckInTime = DateTime.Now.AddHours(-2),
            CheckOutTime = DateTime.Now,
            IsCharging = false,
            TotalAmount = 5000
        }, "Vé lượt xe máy ban ngày (5,000 VNĐ)")
        {
        }

        public frmQuickReceipt(ParkingSession s, string calcDetail)
        {
            session = s ?? new ParkingSession
            {
                SessionID = 1001,
                PlateNumber = "29B1-555.66",
                VehicleType = "Xe máy",
                SlotCode = "A-01",
                CheckInTime = DateTime.Now.AddHours(-2),
                CheckOutTime = DateTime.Now,
                IsCharging = false,
                TotalAmount = 5000
            };
            calculationDetail = calcDetail ?? "Vé lượt xe máy ban ngày (5,000 VNĐ)";

            InitializeComponent();
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            lblTransCodeVal.Text = $"#{session.SessionID:D6}";
            lblPlateVal.Text = session.PlateNumber;
            lblVehTypeVal.Text = session.VehicleType;
            lblSlotVal.Text = session.SlotCode;
            lblCheckInVal.Text = session.CheckInTime.ToString("dd/MM/yyyy HH:mm");
            lblCheckOutVal.Text = (session.CheckOutTime ?? DateTime.Now).ToString("dd/MM/yyyy HH:mm");

            TimeSpan span = (session.CheckOutTime ?? DateTime.Now) - session.CheckInTime;
            string durationStr = span.TotalDays >= 1 ? $"{(int)span.TotalDays} ngày {span.Hours}h {span.Minutes}p" : $"{span.Hours}h {span.Minutes}p";
            lblDurationVal.Text = durationStr;

            lblChargingVal.Text = session.IsCharging ? "Có sử dụng (Phụ thu)" : "Không";
            lblDetailVal.Text = calculationDetail;
            lblTotalVal.Text = $"{session.TotalAmount:N0} VNĐ";

            if (session.SessionID > 0)
            {
                picQr.Image = BarcodeService.GenerateQrCode($"RECEIPT-{session.SessionID}-{session.PlateNumber}-{session.TotalAmount:N0}VND", 115, 115);
            }

            btnPrint.Click += (s, e) => Close();
        }
    }
}
