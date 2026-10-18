using System;
using System.Windows.Forms;

namespace SmartParking.UI.Forms
{
    public partial class frmPlateWarning : Form
    {
        public bool ChoiceAllowPass { get; private set; } = false;

        public frmPlateWarning() : this("29A-123.45", "30B-999.99", "Nguyễn Văn A")
        {
        }

        public frmPlateWarning(string registeredPlate, string actualPlate, string residentName)
        {
            InitializeComponent();
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            lblMsg.Text = $"Chủ thẻ cư dân: {residentName}\n" +
                          $"• Biển số đăng ký thẻ tháng:   {registeredPlate}\n" +
                          $"• Biển số thực tế trước camera:  {actualPlate}\n\n" +
                          "Bảo vệ vui lòng xác nhận phương án xử lý:";

            btnCasual.Click += (s, e) =>
            {
                ChoiceAllowPass = false;
                DialogResult = DialogResult.OK;
                Close();
            };

            btnException.Click += (s, e) =>
            {
                ChoiceAllowPass = true;
                DialogResult = DialogResult.OK;
                Close();
            };
        }
    }
}
