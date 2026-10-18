using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.Services;
using SmartParking.UI.Common;

namespace SmartParking.UI.UserControls
{
    public partial class ucPricingConfig : UserControl
    {
        public ucPricingConfig()
        {
            InitializeComponent();
            SetupEvents();

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadCurrentPricing();
        }

        private void SetupEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnReset.Click += (s, e) => LoadCurrentPricing();
        }

        private void LoadCurrentPricing()
        {
            try
            {
                var rule = PricingCalculator.GetCurrentRules();
                numGraceMin.Value = rule.FreeGraceMinutes;
                numElectricSurcharge.Value = rule.ElectricSurcharge;
                numStandardMonthly.Value = rule.StandardMonthlyFee;
                numOverQuotaMult.Value = rule.OverQuotaMultiplier;
                numCardReplace.Value = rule.CardReplacementFee;

                numMotorDay.Value = rule.MotorDay;
                numMotorNight.Value = rule.MotorNight;
                numMotorOvernight.Value = rule.MotorOvernight;
                numBikeDay.Value = rule.BicycleDay;

                numCar2Hours.Value = rule.CarFirst2Hours;
                numCarNextHour.Value = rule.CarNextHour;
                numCarOvernight.Value = rule.CarOvernight;
                numLostPenalty.Value = rule.LostTicketPenalty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải bảng giá: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE PricingRules SET
                            FreeGraceMinutes = @Grace,
                            ElectricSurcharge = @Elec,
                            StandardMonthlyFee = @Monthly,
                            OverQuotaMultiplier = @Mult,
                            CardReplacementFee = @Replace,
                            MotorDay = @MDay,
                            MotorNight = @MNight,
                            MotorOvernight = @MOver,
                            BicycleDay = @BDay,
                            CarFirst2Hours = @C2h,
                            CarNextHour = @CNext,
                            CarOvernight = @COver,
                            LostTicketPenalty = @Penalty
                        WHERE RuleID = 1;
                    ";
                    cmd.Parameters.AddWithValue("@Grace", (int)numGraceMin.Value);
                    cmd.Parameters.AddWithValue("@Elec", numElectricSurcharge.Value);
                    cmd.Parameters.AddWithValue("@Monthly", numStandardMonthly.Value);
                    cmd.Parameters.AddWithValue("@Mult", numOverQuotaMult.Value);
                    cmd.Parameters.AddWithValue("@Replace", numCardReplace.Value);
                    cmd.Parameters.AddWithValue("@MDay", numMotorDay.Value);
                    cmd.Parameters.AddWithValue("@MNight", numMotorNight.Value);
                    cmd.Parameters.AddWithValue("@MOver", numMotorOvernight.Value);
                    cmd.Parameters.AddWithValue("@BDay", numBikeDay.Value);
                    cmd.Parameters.AddWithValue("@C2h", numCar2Hours.Value);
                    cmd.Parameters.AddWithValue("@CNext", numCarNextHour.Value);
                    cmd.Parameters.AddWithValue("@COver", numCarOvernight.Value);
                    cmd.Parameters.AddWithValue("@Penalty", numLostPenalty.Value);
                    cmd.ExecuteNonQuery();
                }

                PricingCalculator.ClearCache();
                EventAggregator.PublishPricingRulesUpdated();

                MessageBox.Show("ĐÃ CẬP NHẬT BẢNG GIÁ THÀNH CÔNG!\n\nCác làn vào/ra sẽ tự động áp dụng biểu phí mới ngay từ lượt xe tiếp theo.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật bảng giá: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
