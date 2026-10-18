namespace SmartParking.UI.UserControls
{
    partial class ucParkingMap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.pnlBadges = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCountEmpty = new System.Windows.Forms.Label();
            this.lblCountOccupied = new System.Windows.Forms.Label();
            this.lblCountReserved = new System.Windows.Forms.Label();
            this.lblCountCharging = new System.Windows.Forms.Label();
            this.lblCountMaint = new System.Windows.Forms.Label();
            this.pnlSearchRow = new System.Windows.Forms.Panel();
            this.lblGuide = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchPlate = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tabZones = new System.Windows.Forms.TabControl();
            this.tabA = new System.Windows.Forms.TabPage();
            this.flowZoneA = new System.Windows.Forms.FlowLayoutPanel();
            this.tabB = new System.Windows.Forms.TabPage();
            this.flowZoneB = new System.Windows.Forms.FlowLayoutPanel();
            this.tabB1 = new System.Windows.Forms.TabPage();
            this.flowZoneB1 = new System.Windows.Forms.FlowLayoutPanel();
            this.blinkTimer = new System.Windows.Forms.Timer(this.components);
            this.grpTop.SuspendLayout();
            this.pnlBadges.SuspendLayout();
            this.pnlSearchRow.SuspendLayout();
            this.tabZones.SuspendLayout();
            this.tabA.SuspendLayout();
            this.tabB.SuspendLayout();
            this.tabB1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTop
            // 
            this.grpTop.BackColor = System.Drawing.Color.White;
            this.grpTop.Controls.Add(this.pnlBadges);
            this.grpTop.Controls.Add(this.pnlSearchRow);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpTop.Location = new System.Drawing.Point(0, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Padding = new System.Windows.Forms.Padding(10, 4, 10, 6);
            this.grpTop.Size = new System.Drawing.Size(1000, 92);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            this.grpTop.Text = "Tìm kiếm vị trí xe & Thống kê trạng thái bãi đỗ";
            // 
            // pnlBadges
            // 
            this.pnlBadges.BackColor = System.Drawing.Color.Transparent;
            this.pnlBadges.Controls.Add(this.lblCountEmpty);
            this.pnlBadges.Controls.Add(this.lblCountOccupied);
            this.pnlBadges.Controls.Add(this.lblCountReserved);
            this.pnlBadges.Controls.Add(this.lblCountCharging);
            this.pnlBadges.Controls.Add(this.lblCountMaint);
            this.pnlBadges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBadges.Location = new System.Drawing.Point(10, 56);
            this.pnlBadges.Name = "pnlBadges";
            this.pnlBadges.Size = new System.Drawing.Size(980, 30);
            this.pnlBadges.TabIndex = 1;
            // 
            // lblCountEmpty
            // 
            this.lblCountEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.lblCountEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountEmpty.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCountEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblCountEmpty.Location = new System.Drawing.Point(3, 0);
            this.lblCountEmpty.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.lblCountEmpty.Name = "lblCountEmpty";
            this.lblCountEmpty.Size = new System.Drawing.Size(115, 26);
            this.lblCountEmpty.TabIndex = 0;
            this.lblCountEmpty.Text = "● Trống: 0";
            this.lblCountEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountOccupied
            // 
            this.lblCountOccupied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblCountOccupied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountOccupied.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCountOccupied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblCountOccupied.Location = new System.Drawing.Point(129, 0);
            this.lblCountOccupied.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.lblCountOccupied.Name = "lblCountOccupied";
            this.lblCountOccupied.Size = new System.Drawing.Size(115, 26);
            this.lblCountOccupied.TabIndex = 1;
            this.lblCountOccupied.Text = "● Đã đỗ: 0";
            this.lblCountOccupied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountReserved
            // 
            this.lblCountReserved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.lblCountReserved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountReserved.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCountReserved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblCountReserved.Location = new System.Drawing.Point(255, 0);
            this.lblCountReserved.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.lblCountReserved.Name = "lblCountReserved";
            this.lblCountReserved.Size = new System.Drawing.Size(115, 26);
            this.lblCountReserved.TabIndex = 2;
            this.lblCountReserved.Text = "● Cố định: 0";
            this.lblCountReserved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountCharging
            // 
            this.lblCountCharging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.lblCountCharging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountCharging.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCountCharging.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.lblCountCharging.Location = new System.Drawing.Point(381, 0);
            this.lblCountCharging.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.lblCountCharging.Name = "lblCountCharging";
            this.lblCountCharging.Size = new System.Drawing.Size(115, 26);
            this.lblCountCharging.TabIndex = 3;
            this.lblCountCharging.Text = "⚡ Đang sạc: 0";
            this.lblCountCharging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountMaint
            // 
            this.lblCountMaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblCountMaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountMaint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCountMaint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCountMaint.Location = new System.Drawing.Point(507, 0);
            this.lblCountMaint.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.lblCountMaint.Name = "lblCountMaint";
            this.lblCountMaint.Size = new System.Drawing.Size(115, 26);
            this.lblCountMaint.TabIndex = 4;
            this.lblCountMaint.Text = "● Bảo trì: 0";
            this.lblCountMaint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSearchRow
            // 
            this.pnlSearchRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchRow.Controls.Add(this.lblGuide);
            this.pnlSearchRow.Controls.Add(this.btnRefresh);
            this.pnlSearchRow.Controls.Add(this.btnSearch);
            this.pnlSearchRow.Controls.Add(this.txtSearchPlate);
            this.pnlSearchRow.Controls.Add(this.lblSearch);
            this.pnlSearchRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchRow.Location = new System.Drawing.Point(10, 22);
            this.pnlSearchRow.Name = "pnlSearchRow";
            this.pnlSearchRow.Size = new System.Drawing.Size(980, 32);
            this.pnlSearchRow.TabIndex = 0;
            // 
            // lblGuide
            // 
            this.lblGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGuide.AutoEllipsis = true;
            this.lblGuide.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblGuide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGuide.Location = new System.Drawing.Point(525, 2);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(450, 28);
            this.lblGuide.TabIndex = 4;
            this.lblGuide.Text = "💡 Chuột phải vào ô đỗ để xem thông tin, điều chuyển hoặc bảo trì ô đỗ";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnRefresh.Location = new System.Drawing.Point(420, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Tải Lại";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(315, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Tìm Vị Trí";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchPlate
            // 
            this.txtSearchPlate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchPlate.Location = new System.Drawing.Point(145, 4);
            this.txtSearchPlate.Name = "txtSearchPlate";
            this.txtSearchPlate.Size = new System.Drawing.Size(160, 23);
            this.txtSearchPlate.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSearch.Location = new System.Drawing.Point(3, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(136, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm xe / Biển số / Ô đỗ:";
            // 
            // tabZones
            // 
            this.tabZones.Controls.Add(this.tabA);
            this.tabZones.Controls.Add(this.tabB);
            this.tabZones.Controls.Add(this.tabB1);
            this.tabZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabZones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabZones.ItemSize = new System.Drawing.Size(170, 34);
            this.tabZones.Location = new System.Drawing.Point(0, 92);
            this.tabZones.Name = "tabZones";
            this.tabZones.SelectedIndex = 0;
            this.tabZones.Size = new System.Drawing.Size(1000, 608);
            this.tabZones.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabZones.TabIndex = 1;
            // 
            // tabA
            // 
            this.tabA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tabA.Controls.Add(this.flowZoneA);
            this.tabA.Location = new System.Drawing.Point(4, 38);
            this.tabA.Name = "tabA";
            this.tabA.Padding = new System.Windows.Forms.Padding(10);
            this.tabA.Size = new System.Drawing.Size(992, 566);
            this.tabA.TabIndex = 0;
            this.tabA.Text = "KHU A: XE MÁY XĂNG";
            // 
            // flowZoneA
            // 
            this.flowZoneA.AutoScroll = true;
            this.flowZoneA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.flowZoneA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowZoneA.Location = new System.Drawing.Point(10, 10);
            this.flowZoneA.Name = "flowZoneA";
            this.flowZoneA.Padding = new System.Windows.Forms.Padding(8);
            this.flowZoneA.Size = new System.Drawing.Size(972, 546);
            this.flowZoneA.TabIndex = 0;
            // 
            // tabB
            // 
            this.tabB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tabB.Controls.Add(this.flowZoneB);
            this.tabB.Location = new System.Drawing.Point(4, 38);
            this.tabB.Name = "tabB";
            this.tabB.Padding = new System.Windows.Forms.Padding(10);
            this.tabB.Size = new System.Drawing.Size(992, 566);
            this.tabB.TabIndex = 1;
            this.tabB.Text = "KHU B: TRẠM SẠC ĐIỆN ⚡";
            // 
            // flowZoneB
            // 
            this.flowZoneB.AutoScroll = true;
            this.flowZoneB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.flowZoneB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowZoneB.Location = new System.Drawing.Point(10, 10);
            this.flowZoneB.Name = "flowZoneB";
            this.flowZoneB.Padding = new System.Windows.Forms.Padding(8);
            this.flowZoneB.Size = new System.Drawing.Size(972, 546);
            this.flowZoneB.TabIndex = 0;
            // 
            // tabB1
            // 
            this.tabB1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tabB1.Controls.Add(this.flowZoneB1);
            this.tabB1.Location = new System.Drawing.Point(4, 38);
            this.tabB1.Name = "tabB1";
            this.tabB1.Padding = new System.Windows.Forms.Padding(10);
            this.tabB1.Size = new System.Drawing.Size(992, 566);
            this.tabB1.TabIndex = 2;
            this.tabB1.Text = "KHU B1: Ô TÔ DƯỚI 9 CHỖ";
            // 
            // flowZoneB1
            // 
            this.flowZoneB1.AutoScroll = true;
            this.flowZoneB1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.flowZoneB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowZoneB1.Location = new System.Drawing.Point(10, 10);
            this.flowZoneB1.Name = "flowZoneB1";
            this.flowZoneB1.Padding = new System.Windows.Forms.Padding(8);
            this.flowZoneB1.Size = new System.Drawing.Size(972, 546);
            this.flowZoneB1.TabIndex = 0;
            // 
            // blinkTimer
            // 
            this.blinkTimer.Interval = 500;
            // 
            // ucParkingMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.tabZones);
            this.Controls.Add(this.grpTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucParkingMap";
            this.Size = new System.Drawing.Size(1000, 700);
            this.grpTop.ResumeLayout(false);
            this.pnlBadges.ResumeLayout(false);
            this.pnlSearchRow.ResumeLayout(false);
            this.pnlSearchRow.PerformLayout();
            this.tabZones.ResumeLayout(false);
            this.tabA.ResumeLayout(false);
            this.tabB.ResumeLayout(false);
            this.tabB1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Panel pnlSearchRow;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchPlate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.FlowLayoutPanel pnlBadges;
        private System.Windows.Forms.Label lblCountEmpty;
        private System.Windows.Forms.Label lblCountOccupied;
        private System.Windows.Forms.Label lblCountReserved;
        private System.Windows.Forms.Label lblCountCharging;
        private System.Windows.Forms.Label lblCountMaint;
        private System.Windows.Forms.TabControl tabZones;
        private System.Windows.Forms.TabPage tabA;
        private System.Windows.Forms.FlowLayoutPanel flowZoneA;
        private System.Windows.Forms.TabPage tabB;
        private System.Windows.Forms.FlowLayoutPanel flowZoneB;
        private System.Windows.Forms.TabPage tabB1;
        private System.Windows.Forms.FlowLayoutPanel flowZoneB1;
        private System.Windows.Forms.Timer blinkTimer;
    }
}
