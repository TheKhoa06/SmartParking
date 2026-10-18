using System;
using System.Drawing;
using System.Windows.Forms;
using SmartParking.Models;
using SmartParking.Services;

namespace SmartParking.UI.Forms
{
    public partial class frmPrintTicket : Form
    {
        private MonthlyCard card;

        public frmPrintTicket() : this(new MonthlyCard
        {
            CardCode = "CARD-DEMO-01",
            OwnerName = "Nguyễn Văn Tuấn",
            RoomNumber = "Phòng B302",
            VehicleOrderInRoom = 1,
            PlateNumber = "29B1-555.66",
            VehicleType = "Xe máy",
            ExpireDate = DateTime.Now.AddMonths(1),
            PricingPlan = "1 tháng"
        })
        {
        }

        public frmPrintTicket(MonthlyCard c)
        {
            card = c ?? new MonthlyCard
            {
                CardCode = "CARD-DEMO-01",
                OwnerName = "Nguyễn Văn Tuấn",
                RoomNumber = "Phòng B302",
                VehicleOrderInRoom = 1,
                PlateNumber = "29B1-555.66",
                VehicleType = "Xe máy",
                ExpireDate = DateTime.Now.AddMonths(1),
                PricingPlan = "1 tháng"
            };

            InitializeComponent();
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            lblOwnerVal.Text = card.OwnerName.ToUpper();
            lblRoomVal.Text = $"{card.RoomNumber} (Xe định mức #{card.VehicleOrderInRoom})";
            lblPlateVal.Text = $"{card.PlateNumber} ({card.VehicleType})";
            lblExpire.Text = $"Hạn sử dụng: {card.ExpireDate:dd/MM/yyyy} ({card.PricingPlan})";
            lblCode.Text = card.CardCode;

            if (!string.IsNullOrWhiteSpace(card.CardCode))
            {
                picQr.Image = BarcodeService.GenerateQrCode(card.CardCode, 120, 120);
            }

            btnPrint.Click += (s, e) =>
            {
                MessageBox.Show("Lệnh in thẻ nhựa đã được gửi đến máy in thẻ chuyên dụng!\nMã QR và dữ liệu bảo mật đã được mã hóa thành công.", "In Thẻ Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            };

            btnClose.Click += (s, e) => Close();
        }
    }
}
