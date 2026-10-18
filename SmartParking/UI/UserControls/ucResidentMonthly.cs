using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.Services;
using SmartParking.UI.Common;
using SmartParking.UI.Forms;

namespace SmartParking.UI.UserControls
{
    public partial class ucResidentMonthly : UserControl
    {
        private MonthlyCard? selectedMonthlyCard = null;
        private DataTable cardsTable = new();

        public ucResidentMonthly()
        {
            InitializeComponent();
            SetupEvents();

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadRooms();
            LoadCarFixedSlots();
            LoadMonthlyCards();
            EventAggregator.MonthlyCardUpdated += () => LoadMonthlyCards();
        }

        private void SetupEvents()
        {
            cboRoom.SelectedIndexChanged += (s, e) => RecalculateFeeAndQuota();
            cboVehicleType.SelectedIndexChanged += (s, e) =>
            {
                cboFixedSlot.Enabled = cboVehicleType.SelectedItem?.ToString() == "Ô tô";
                RecalculateFeeAndQuota();
            };
            cboPlan.SelectedIndexChanged += (s, e) => RecalculateFeeAndQuota();

            btnRegister.Click += BtnRegister_Click;
            btnRenew.Click += BtnRenew_Click;
            btnReissue.Click += BtnReissue_Click;
            btnSendBulkEmail.Click += BtnSendBulkEmail_Click;

            txtSearchGrid.TextChanged += (s, e) => FilterCardsGrid();

            pnlCardMiniPreview.Paint += PnlCardMiniPreview_Paint;

            ModernGridHelper.ApplyModernStyle(dgvCards);
            dgvCards.RowPrePaint += DgvCards_RowPrePaint;
            dgvCards.SelectionChanged += DgvCards_SelectionChanged;
        }

        private void LoadRooms()
        {
            cboRoom.Items.Clear();
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT RoomID, RoomNumber, BuildingBlock FROM Rooms ORDER BY RoomNumber ASC;";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboRoom.Items.Add(new ComboBoxItem($"{reader["RoomNumber"]} ({reader["BuildingBlock"]})", Convert.ToInt32(reader["RoomID"])));
                }
                if (cboRoom.Items.Count > 0) cboRoom.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách phòng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCarFixedSlots()
        {
            cboFixedSlot.Items.Clear();
            cboFixedSlot.Items.Add(new ComboBoxItem("(Không chọn ô cố định)", 0));
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT SlotID, SlotCode FROM ParkingSlots WHERE Zone = 'B1' AND Status IN (0, 2);";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboFixedSlot.Items.Add(new ComboBoxItem(reader["SlotCode"].ToString()!, Convert.ToInt32(reader["SlotID"])));
                }
                cboFixedSlot.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải ô cố định: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalculateFeeAndQuota()
        {
            if (cboRoom.SelectedItem is not ComboBoxItem roomItem) return;

            string plan = cboPlan.SelectedItem?.ToString() ?? "Học kỳ 5 tháng";
            string vehType = cboVehicleType.SelectedItem?.ToString() ?? "Xe máy xăng";

            var calc = PricingCalculator.CalculateMonthlyPlanFee(roomItem.Value, plan, vehType);

            lblQuotaWarning.Text = calc.quotaMessage;
            lblQuotaWarning.ForeColor = calc.order <= 2 ? UITheme.Success :
                                        calc.order == 3 ? UITheme.Warning : UITheme.Danger;

            lblFeeSummary.Text = $"Tổng tiền thanh toán ({plan}): {calc.totalPaid:N0} VNĐ";
        }

        public void LoadMonthlyCards()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT m.CardID AS [ID], m.CardCode AS [Mã Thẻ], r.FullName AS [Chủ Xe], rm.RoomNumber AS [Phòng], v.PlateNumber AS [Biển Số], v.VehicleType AS [Loại Xe], m.PricingPlan AS [Gói Cước], m.ExpireDate AS [Ngày Hết Hạn], m.VehicleOrderInRoom AS [Thứ Tự Xe], m.TotalPaid AS [Đã Thu (VNĐ)], m.Status AS [Trạng Thái]
                    FROM MonthlyCards m
                    JOIN Vehicles v ON m.VehicleID = v.VehicleID
                    JOIN Residents r ON v.ResidentID = r.ResidentID
                    JOIN Rooms rm ON r.RoomID = rm.RoomID
                    ORDER BY m.CardID DESC;
                ";
                cardsTable = cmd.ExecuteDataTable();
                dgvCards.DataSource = cardsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách thẻ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterCardsGrid()
        {
            if (cardsTable == null || cardsTable.Rows.Count == 0) return;
            string q = txtSearchGrid.Text.Trim().Replace("'", "''");
            if (string.IsNullOrWhiteSpace(q))
            {
                cardsTable.DefaultView.RowFilter = "";
            }
            else
            {
                cardsTable.DefaultView.RowFilter = $"[Chủ Xe] LIKE '%{q}%' OR [Phòng] LIKE '%{q}%' OR [Biển Số] LIKE '%{q}%' OR [Mã Thẻ] LIKE '%{q}%'";
            }
        }

        private void DgvCards_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCards.Rows.Count) return;
            var row = dgvCards.Rows[e.RowIndex];
            string status = row.Cells["Trạng Thái"].Value?.ToString() ?? "";
            DateTime expDate = DateTime.TryParse(row.Cells["Ngày Hết Hạn"].Value?.ToString(), out var dt) ? dt : DateTime.Now;

            int daysLeft = (int)Math.Ceiling((expDate - DateTime.Now).TotalDays);

            if (status == "Bị khóa")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                row.DefaultCellStyle.ForeColor = Color.DarkGray;
            }
            else if (daysLeft <= 0 || status == "Hết hạn")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238); // Đỏ nhạt
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }
            else if (daysLeft <= 5 || status == "Sắp hết hạn")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 225); // Vàng nhạt
                row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 100, 0);
            }
        }

        private void DgvCards_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCards.SelectedRows.Count == 0) return;
            var row = dgvCards.SelectedRows[0];

            selectedMonthlyCard = new MonthlyCard
            {
                CardID = Convert.ToInt32(row.Cells["ID"].Value),
                CardCode = row.Cells["Mã Thẻ"].Value.ToString()!,
                OwnerName = row.Cells["Chủ Xe"].Value.ToString()!,
                RoomNumber = row.Cells["Phòng"].Value.ToString()!,
                PlateNumber = row.Cells["Biển Số"].Value.ToString()!,
                VehicleType = row.Cells["Loại Xe"].Value.ToString()!,
                PricingPlan = row.Cells["Gói Cước"].Value.ToString()!,
                ExpireDate = DateTime.Parse(row.Cells["Ngày Hết Hạn"].Value.ToString()!),
                VehicleOrderInRoom = Convert.ToInt32(row.Cells["Thứ Tự Xe"].Value),
                TotalPaid = Convert.ToDecimal(row.Cells["Đã Thu (VNĐ)"].Value),
                Status = row.Cells["Trạng Thái"].Value.ToString()!
            };

            pnlCardMiniPreview.Invalidate();
        }

        private void PnlCardMiniPreview_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            if (selectedMonthlyCard == null)
            {
                using var fEmpty = new Font("Segoe UI", 9f, FontStyle.Italic);
                using var bEmpty = new SolidBrush(Color.FromArgb(148, 163, 184));
                g.DrawString("Chọn một thẻ trong danh sách phía trên để xem trước phôi thẻ nhựa...", fEmpty, bEmpty, 15, 38);
                return;
            }

            using var fHeader = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            using var fBody = new Font("Segoe UI", 8.25f, FontStyle.Regular);
            using var bGold = new SolidBrush(Color.FromArgb(251, 191, 36));
            using var bWhite = new SolidBrush(Color.FromArgb(248, 250, 252));
            using var bGreen = new SolidBrush(Color.FromArgb(110, 231, 183));
            using var bSlate = new SolidBrush(Color.FromArgb(203, 213, 225));

            g.DrawString($"THẺ THÁNG CƯ DÂN: {selectedMonthlyCard.CardCode}", fHeader, bGold, 15, 10);
            g.DrawString($"Chủ xe: {selectedMonthlyCard.OwnerName} | Phòng: {selectedMonthlyCard.RoomNumber} (Xe #{selectedMonthlyCard.VehicleOrderInRoom})", fBody, bWhite, 15, 30);
            g.DrawString($"Biển số: {selectedMonthlyCard.PlateNumber} | Loại xe: {selectedMonthlyCard.VehicleType} | Hạn: {selectedMonthlyCard.ExpireDate:dd/MM/yyyy}", fBody, bGreen, 15, 50);
            g.DrawString($"Gói: {selectedMonthlyCard.PricingPlan} | Phí: {selectedMonthlyCard.TotalPaid:N0}đ | Trạng thái: {selectedMonthlyCard.Status}", fBody, bSlate, 15, 70);

            if (pnlCardMiniPreview.Width > 150)
            {
                var qr = BarcodeService.GenerateQrCode(selectedMonthlyCard.CardCode, 76, 76);
                g.FillRectangle(Brushes.White, pnlCardMiniPreview.Width - 95, 10, 80, 80);
                g.DrawImage(qr, pnlCardMiniPreview.Width - 93, 12, 76, 76);
            }
        }

        private void BtnRegister_Click(object? sender, EventArgs e)
        {
            if (cboRoom.SelectedItem is not ComboBoxItem roomItem) return;
            string plate = txtPlate.Text.Trim();
            string name = txtFullName.Text.Trim();
            if (string.IsNullOrWhiteSpace(plate) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập Họ tên và Biển số xe!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string plan = cboPlan.SelectedItem?.ToString() ?? "Học kỳ 5 tháng";
            string vehType = cboVehicleType.SelectedItem?.ToString() ?? "Xe máy xăng";
            var calc = PricingCalculator.CalculateMonthlyPlanFee(roomItem.Value, plan, vehType);

            int monthsToAdd = plan.Contains("12") ? 12 : (plan.Contains("5") || plan.Contains("Học kỳ") ? 5 : (plan.Contains("3") ? 3 : 1));
            DateTime expDate = DateTime.Now.AddMonths(monthsToAdd);
            string cardCode = $"CARD-{roomItem.Text.Split(' ')[0]}-{plate.Replace("-", "").Replace(".", "").ToUpper()}";

            int? fixedSlotId = null;
            if (cboFixedSlot.SelectedItem is ComboBoxItem slotItem && slotItem.Value > 0)
                fixedSlotId = slotItem.Value;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    using var trans = conn.BeginTransaction();
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = trans;

                    cmd.CommandText = @"
                        INSERT INTO Residents (FullName, StudentID_CCCD, Phone, Email, RoomID)
                        VALUES (@Name, @Id, @Phone, @Email, @RoomID);
                        SELECT SCOPE_IDENTITY();
                    ";
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Id", txtStudentId.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@RoomID", roomItem.Value);
                    long resId = Convert.ToInt64(cmd.ExecuteScalar());

                    cmd.CommandText = @"
                        INSERT INTO Vehicles (PlateNumber, VehicleType, ResidentID, BrandModel)
                        VALUES (@Plate, @Type, @ResID, @Model);
                        SELECT SCOPE_IDENTITY();
                    ";
                    cmd.Parameters.AddWithValue("@Plate", plate);
                    cmd.Parameters.AddWithValue("@Type", vehType);
                    cmd.Parameters.AddWithValue("@ResID", resId);
                    cmd.Parameters.AddWithValue("@Model", "Xe đăng ký tháng");
                    long vehId = Convert.ToInt64(cmd.ExecuteScalar());

                    cmd.CommandText = @"
                        INSERT INTO MonthlyCards (CardCode, VehicleID, VehicleOrderInRoom, IssueDate, ExpireDate, PricingPlan, MonthlyFee, TotalPaid, Status, AssignedSlotID)
                        VALUES (@Code, @VehID, @Order, @Issue, @Expire, @Plan, @Fee, @Total, N'Hoạt động', @SlotID);
                        SELECT SCOPE_IDENTITY();
                    ";
                    cmd.Parameters.AddWithValue("@Code", cardCode);
                    cmd.Parameters.AddWithValue("@VehID", vehId);
                    cmd.Parameters.AddWithValue("@Order", calc.order);
                    cmd.Parameters.AddWithValue("@Issue", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Expire", expDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Plan", plan);
                    cmd.Parameters.AddWithValue("@Fee", calc.monthlyFee);
                    cmd.Parameters.AddWithValue("@Total", calc.totalPaid);
                    cmd.Parameters.AddWithValue("@SlotID", fixedSlotId == null ? DBNull.Value : (object)fixedSlotId);
                    long cardId = Convert.ToInt64(cmd.ExecuteScalar());

                    if (fixedSlotId.HasValue)
                    {
                        cmd.CommandText = "UPDATE ParkingSlots SET Status = 2, AssignedRoomID = @RoomID WHERE SlotID = @SlotID;";
                        cmd.Parameters.AddWithValue("@RoomID", roomItem.Value);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();

                    if (fixedSlotId.HasValue)
                    {
                        EventAggregator.PublishSlotStatusChanged(fixedSlotId.Value, 2, $"Cố định {roomItem.Text.Split(' ')[0]}");
                    }
                }

                EventAggregator.PublishMonthlyCardUpdated();

                var newCard = new MonthlyCard
                {
                    CardCode = cardCode,
                    OwnerName = name,
                    RoomNumber = roomItem.Text.Split(' ')[0],
                    PlateNumber = plate,
                    VehicleType = vehType,
                    PricingPlan = plan,
                    ExpireDate = expDate,
                    VehicleOrderInRoom = calc.order,
                    TotalPaid = calc.totalPaid
                };
                var printDlg = new frmPrintTicket(newCard);
                printDlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng ký vé tháng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRenew_Click(object? sender, EventArgs e)
        {
            if (selectedMonthlyCard == null)
            {
                MessageBox.Show("Vui lòng chọn thẻ cần gia hạn trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime newExp = (selectedMonthlyCard.ExpireDate > DateTime.Now ? selectedMonthlyCard.ExpireDate : DateTime.Now).AddMonths(1);
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE MonthlyCards 
                    SET ExpireDate = @NewExp, Status = 'Hoạt động', TotalPaid = TotalPaid + MonthlyFee 
                    WHERE CardID = @ID;
                ";
                cmd.Parameters.AddWithValue("@NewExp", newExp.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@ID", selectedMonthlyCard.CardID);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Gia hạn thành công thẻ '{selectedMonthlyCard.CardCode}' đến ngày {newExp:dd/MM/yyyy}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMonthlyCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gia hạn thẻ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReissue_Click(object? sender, EventArgs e)
        {
            if (selectedMonthlyCard == null)
            {
                MessageBox.Show("Vui lòng chọn thẻ cần cấp lại trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string newCode = $"CARD-NEW-{DateTime.Now:mmss}-{selectedMonthlyCard.PlateNumber.Replace("-", "").ToUpper()}";
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE MonthlyCards 
                    SET CardCode = @NewCode, TotalPaid = TotalPaid + 20000 
                    WHERE CardID = @ID;
                ";
                cmd.Parameters.AddWithValue("@NewCode", newCode);
                cmd.Parameters.AddWithValue("@ID", selectedMonthlyCard.CardID);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"ĐÃ CẤP LẠI MÃ THẺ MỚI THÀNH CÔNG!\n\nMã QR cũ đã bị vô hiệu hóa.\nMã QR mới: {newCode}\nPhí làm lại thẻ: 20.000 VNĐ", "Cấp lại thẻ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMonthlyCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cấp lại thẻ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSendBulkEmail_Click(object? sender, EventArgs e)
        {
            var items = EmailNotificationService.GetExpiringOrExpiredCards();
            if (items.Count == 0)
            {
                MessageBox.Show("Hiện không có thẻ tháng nào sắp hết hạn hoặc hết hạn cần gửi nhắc nhở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnSendBulkEmail.Enabled = false;
            progEmail.Visible = true;
            progEmail.Value = 0;

            var progress = new Progress<int>(percent => { progEmail.Value = percent; });

            int sent = await EmailNotificationService.SendBulkRemindersAsync(items, progress, status =>
            {
                lblEmailStatus.Text = status;
            });

            btnSendBulkEmail.Enabled = true;
            MessageBox.Show($"Đã gửi thành công {sent} email thông báo nhắc gia hạn thẻ tháng!", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
