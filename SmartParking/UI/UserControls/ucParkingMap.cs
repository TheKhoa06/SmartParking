using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.Services;
using SmartParking.UI.Common;

namespace SmartParking.UI.UserControls
{
    public partial class ucParkingMap : UserControl
    {
        private int blinkTicksRemaining = 0;
        private SlotControl? currentlyBlinkingSlot = null;
        private readonly Dictionary<int, SlotControl> slotControlsMap = new();

        public ucParkingMap()
        {
            InitializeComponent();

            btnSearch.Click += BtnSearch_Click;
            btnRefresh.Click += (s, e) => LoadSlotsFromDatabase();
            txtSearchPlate.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnSearch_Click(s, e); };
            blinkTimer.Interval = 400;
            blinkTimer.Tick += BlinkTimer_Tick;

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            EventAggregator.SlotStatusChanged += OnSlotStatusChanged;
            LoadSlotsFromDatabase();
        }

        public void LoadSlotsFromDatabase()
        {
            slotControlsMap.Clear();
            flowZoneA.SuspendLayout();
            flowZoneB.SuspendLayout();
            flowZoneB1.SuspendLayout();

            flowZoneA.Controls.Clear();
            flowZoneB.Controls.Clear();
            flowZoneB1.Controls.Clear();

            int countEmpty = 0, countOcc = 0, countRes = 0, countCharge = 0, countMaint = 0;

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ParkingSlots ORDER BY SlotID ASC;";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var slot = new ParkingSlot
                    {
                        SlotID = reader.GetInt32(0),
                        SlotCode = reader["SlotCode"].ToString()!,
                        Zone = reader["Zone"].ToString()!,
                        SlotType = reader["SlotType"].ToString()!,
                        Status = Convert.ToInt32(reader["Status"]),
                        AssignedRoomID = reader["AssignedRoomID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["AssignedRoomID"]),
                        CurrentPlate = reader["CurrentPlate"]?.ToString(),
                        OccupiedSince = reader["OccupiedSince"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(reader["OccupiedSince"].ToString())
                    };

                    switch (slot.Status)
                    {
                        case 0: countEmpty++; break;
                        case 1: countOcc++; break;
                        case 2: countRes++; break;
                        case 3: countCharge++; break;
                        case 4: countMaint++; break;
                    }

                    var ctrl = new SlotControl(slot);
                    ctrl.Click += (s, e) => ShowSlotDetails(slot);
                    AttachContextMenu(ctrl, slot);

                    slotControlsMap[slot.SlotID] = ctrl;

                    if (slot.Zone == "A") flowZoneA.Controls.Add(ctrl);
                    else if (slot.Zone == "B") flowZoneB.Controls.Add(ctrl);
                    else if (slot.Zone == "B1") flowZoneB1.Controls.Add(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách ô đỗ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblCountEmpty.Text = $"🟢 Trống: {countEmpty}";
            lblCountOccupied.Text = $"🔴 Có xe: {countOcc}";
            lblCountReserved.Text = $"🟡 Cố định: {countRes}";
            lblCountCharging.Text = $"🔵 Sạc điện: {countCharge}";
            lblCountMaint.Text = $"⚪ Bảo trì: {countMaint}";

            flowZoneA.ResumeLayout();
            flowZoneB.ResumeLayout();
            flowZoneB1.ResumeLayout();
        }

        private void AttachContextMenu(SlotControl ctrl, ParkingSlot slot)
        {
            var menu = new ContextMenuStrip();
            menu.Font = new Font("Segoe UI", 9.5f);

            var itemDetails = new ToolStripMenuItem("📄 Xem chi tiết ô đỗ");
            itemDetails.Click += (s, e) => ShowSlotDetails(slot);
            menu.Items.Add(itemDetails);

            if (slot.Status == 1 || slot.Status == 3)
            {
                var itemMove = new ToolStripMenuItem("🔄 Di chuyển xe sang ô khác...");
                itemMove.Click += (s, e) => MoveVehicleToAnotherSlot(slot);
                menu.Items.Add(itemMove);
            }

            if (slot.Status == 0)
            {
                var itemMaintain = new ToolStripMenuItem("🛠️ Báo bảo trì ô này");
                itemMaintain.Click += (s, e) => SetSlotMaintenance(slot, true);
                menu.Items.Add(itemMaintain);
            }
            else if (slot.Status == 4)
            {
                var itemRestore = new ToolStripMenuItem("✅ Mở lại ô hoạt động");
                itemRestore.Click += (s, e) => SetSlotMaintenance(slot, false);
                menu.Items.Add(itemRestore);
            }

            ctrl.ContextMenuStrip = menu;
        }

        private void ShowSlotDetails(ParkingSlot slot)
        {
            string statusStr = slot.Status switch
            {
                0 => "Đang trống - Sẵn sàng nhận xe",
                1 => "Đang có xe đỗ",
                2 => "Ô cố định cư dân (Hiện vắng chủ)",
                3 => "Trạm sạc đang có xe cắm sạc điện ⚡",
                4 => "Đang bảo trì / khóa",
                _ => "Không xác định"
            };

            string details = $"Mã ô: {slot.SlotCode}\n" +
                             $"Khu vực: Khu {slot.Zone} ({slot.SlotType})\n" +
                             $"Trạng thái: {statusStr}\n" +
                             $"Biển số đang đỗ: {(string.IsNullOrWhiteSpace(slot.CurrentPlate) ? "(Không có)" : slot.CurrentPlate)}\n" +
                             $"Thời gian đỗ: {(slot.OccupiedSince.HasValue ? slot.OccupiedSince.Value.ToString("dd/MM/yyyy HH:mm:ss") : "N/A")}";

            MessageBox.Show(details, $"Chi tiết ô đỗ {slot.SlotCode}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MoveVehicleToAnotherSlot(ParkingSlot currentSlot)
        {
            string targetCode = Microsoft.VisualBasic.Interaction.InputBox(
                $"Nhập mã ô đích muốn chuyển xe {currentSlot.CurrentPlate} đến (VD: A-05):",
                "Di chuyển vị trí đỗ xe",
                "");

            if (string.IsNullOrWhiteSpace(targetCode)) return;

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT SlotID, Status FROM ParkingSlots WHERE SlotCode = @Code;";
                cmd.Parameters.AddWithValue("@Code", targetCode.Trim().ToUpper());
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int targetSlotId = reader.GetInt32(0);
                    int targetStatus = Convert.ToInt32(reader["Status"]);
                    if (targetStatus != 0)
                    {
                        MessageBox.Show($"Ô đích {targetCode} không trống (Trạng thái khác 0)! Vui lòng chọn ô trống.", "Lỗi chuyển ô", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    reader.Close();
                    using var trans = conn.BeginTransaction();
                    using var updateCmd = conn.CreateCommand();
                    updateCmd.Transaction = trans;

                    updateCmd.CommandText = "UPDATE ParkingSlots SET Status = 0, CurrentPlate = NULL, OccupiedSince = NULL WHERE SlotID = @OldID;";
                    updateCmd.Parameters.AddWithValue("@OldID", currentSlot.SlotID);
                    updateCmd.ExecuteNonQuery();

                    updateCmd.CommandText = "UPDATE ParkingSlots SET Status = @NewStatus, CurrentPlate = @Plate, OccupiedSince = @Occ WHERE SlotID = @NewID;";
                    updateCmd.Parameters.AddWithValue("@NewStatus", currentSlot.Status);
                    updateCmd.Parameters.AddWithValue("@Plate", currentSlot.CurrentPlate ?? "");
                    updateCmd.Parameters.AddWithValue("@Occ", currentSlot.OccupiedSince?.ToString("yyyy-MM-dd HH:mm:ss") ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    updateCmd.Parameters.AddWithValue("@NewID", targetSlotId);
                    updateCmd.ExecuteNonQuery();

                    updateCmd.CommandText = "UPDATE ParkingSessions SET SlotID = @NewID WHERE SlotID = @OldID AND Status = 0;";
                    updateCmd.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show($"Đã di chuyển xe {currentSlot.CurrentPlate} từ {currentSlot.SlotCode} sang {targetCode.ToUpper()} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSlotsFromDatabase();
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy ô đỗ mã {targetCode}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện chuyển ô: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetSlotMaintenance(ParkingSlot slot, bool isMaintenance)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE ParkingSlots SET Status = @Status WHERE SlotID = @ID;";
                cmd.Parameters.AddWithValue("@Status", isMaintenance ? 4 : 0);
                cmd.Parameters.AddWithValue("@ID", slot.SlotID);
                cmd.ExecuteNonQuery();

                EventAggregator.PublishSlotStatusChanged(slot.SlotID, isMaintenance ? 4 : 0, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật bảo trì: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string query = txtSearchPlate.Text.Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Vui lòng nhập biển số hoặc mã ô đỗ cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SlotControl? matchControl = null;
            foreach (var kvp in slotControlsMap)
            {
                var s = kvp.Value.SlotData;
                if (s.SlotCode.Equals(query, StringComparison.OrdinalIgnoreCase) ||
                    (!string.IsNullOrEmpty(s.CurrentPlate) && s.CurrentPlate.ToUpper().Contains(query)))
                {
                    matchControl = kvp.Value;
                    break;
                }
            }

            if (matchControl != null)
            {
                if (matchControl.SlotData.Zone == "A") tabZones.SelectedIndex = 0;
                else if (matchControl.SlotData.Zone == "B") tabZones.SelectedIndex = 1;
                else if (matchControl.SlotData.Zone == "B1") tabZones.SelectedIndex = 2;

                (matchControl.Parent as ScrollableControl)?.ScrollControlIntoView(matchControl);

                if (currentlyBlinkingSlot != null)
                {
                    currentlyBlinkingSlot.IsBlinking = false;
                    currentlyBlinkingSlot.ToggleBlink();
                }

                currentlyBlinkingSlot = matchControl;
                currentlyBlinkingSlot.IsBlinking = true;
                blinkTicksRemaining = 12;
                blinkTimer.Start();
            }
            else
            {
                MessageBox.Show($"Không tìm thấy xe hoặc ô đỗ nào khớp với từ khóa '{query}'!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BlinkTimer_Tick(object? sender, EventArgs e)
        {
            if (currentlyBlinkingSlot != null)
            {
                currentlyBlinkingSlot.ToggleBlink();
                blinkTicksRemaining--;
                if (blinkTicksRemaining <= 0)
                {
                    blinkTimer.Stop();
                    currentlyBlinkingSlot.IsBlinking = false;
                    currentlyBlinkingSlot = null;
                }
            }
        }

        private void OnSlotStatusChanged(int slotId, int newStatus, string? newPlate)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnSlotStatusChanged(slotId, newStatus, newPlate)));
                return;
            }

            if (slotControlsMap.TryGetValue(slotId, out var ctrl))
            {
                ctrl.SlotData.Status = newStatus;
                ctrl.SlotData.CurrentPlate = newPlate;
                if (newStatus == 0) ctrl.SlotData.OccupiedSince = null;
                else if (newStatus == 1 || newStatus == 3) ctrl.SlotData.OccupiedSince = DateTime.Now;
                ctrl.UpdateData(ctrl.SlotData);
            }
        }
    }
}
