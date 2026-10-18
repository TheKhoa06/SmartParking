namespace SmartParking.UI.UserControls
{
    partial class ucHistory
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
            this.pnlOuter = new System.Windows.Forms.Panel();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.GroupBox();
            this.picOut = new System.Windows.Forms.PictureBox();
            this.picIn = new System.Windows.Forms.PictureBox();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblPlate = new System.Windows.Forms.Label();
            this.pnlOuter.SuspendLayout();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOuter
            // 
            this.pnlOuter.Controls.Add(this.grpMain);
            this.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOuter.Location = new System.Drawing.Point(0, 0);
            this.pnlOuter.Name = "pnlOuter";
            this.pnlOuter.Padding = new System.Windows.Forms.Padding(12);
            this.pnlOuter.Size = new System.Drawing.Size(1080, 650);
            this.pnlOuter.TabIndex = 0;
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.White;
            this.grpMain.Controls.Add(this.dgvHistory);
            this.grpMain.Controls.Add(this.pnlBottom);
            this.grpMain.Controls.Add(this.pnlTop);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpMain.Location = new System.Drawing.Point(12, 12);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(12);
            this.grpMain.Size = new System.Drawing.Size(1056, 626);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = " TRA CỨU LỊCH SỬ GỬI XE & XUẤT BÁO CÁO DOANH THU EXCEL ";
            // 
            // dgvHistory
            // 
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(12, 85);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(1032, 339);
            this.dgvHistory.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.picOut);
            this.pnlBottom.Controls.Add(this.picIn);
            this.pnlBottom.Controls.Add(this.lblImageInfo);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pnlBottom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnlBottom.Location = new System.Drawing.Point(12, 424);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(1032, 190);
            this.pnlBottom.TabIndex = 2;
            this.pnlBottom.TabStop = false;
            this.pnlBottom.Text = " HÌNH ẢNH CAMERA ĐỐI SOÁT LÚC VÀO / RA CỦA LƯỢT XE ĐƯỢC CHỌN ";
            // 
            // picOut
            // 
            this.picOut.BackColor = System.Drawing.Color.Black;
            this.picOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOut.Location = new System.Drawing.Point(280, 38);
            this.picOut.Name = "picOut";
            this.picOut.Size = new System.Drawing.Size(250, 140);
            this.picOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOut.TabIndex = 2;
            this.picOut.TabStop = false;
            // 
            // picIn
            // 
            this.picIn.BackColor = System.Drawing.Color.Black;
            this.picIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIn.Location = new System.Drawing.Point(15, 38);
            this.picIn.Name = "picIn";
            this.picIn.Size = new System.Drawing.Size(250, 140);
            this.picIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIn.TabIndex = 1;
            this.picIn.TabStop = false;
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblImageInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblImageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblImageInfo.Location = new System.Drawing.Point(10, 30);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(1012, 20);
            this.lblImageInfo.TabIndex = 0;
            this.lblImageInfo.Text = "Chọn một lượt xe trong bảng để đối soát hình ảnh vào/ra:";
            // 
            // pnlTop
            // 
            this.pnlTop.AutoScroll = true;
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.btnExportExcel);
            this.pnlTop.Controls.Add(this.btnFilter);
            this.pnlTop.Controls.Add(this.dtpTo);
            this.pnlTop.Controls.Add(this.lblTo);
            this.pnlTop.Controls.Add(this.dtpFrom);
            this.pnlTop.Controls.Add(this.lblFrom);
            this.pnlTop.Controls.Add(this.cboStatus);
            this.pnlTop.Controls.Add(this.lblStatus);
            this.pnlTop.Controls.Add(this.txtPlate);
            this.pnlTop.Controls.Add(this.lblPlate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(12, 35);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1032, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(875, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(150, 30);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "📊 Xuất Excel 3-Sheet";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(745, 10);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 30);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "🔍 Lọc Dữ Liệu";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(625, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(105, 27);
            this.dtpTo.TabIndex = 7;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTo.Location = new System.Drawing.Point(585, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 20);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "Đến:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(470, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(105, 27);
            this.dtpFrom.TabIndex = 5;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblFrom.Location = new System.Drawing.Point(405, 15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(69, 20);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Đang trong bãi",
            "Đã ra an toàn",
            "Mất vé / Sự cố"});
            this.cboStatus.Location = new System.Drawing.Point(258, 12);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(135, 28);
            this.cboStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblStatus.Location = new System.Drawing.Point(185, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(84, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // txtPlate
            // 
            this.txtPlate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPlate.Location = new System.Drawing.Point(62, 12);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(110, 27);
            this.txtPlate.TabIndex = 1;
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblPlate.Location = new System.Drawing.Point(4, 15);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(65, 20);
            this.lblPlate.TabIndex = 0;
            this.lblPlate.Text = "Biển số:";
            // 
            // ucHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlOuter);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucHistory";
            this.Size = new System.Drawing.Size(1080, 650);
            this.pnlOuter.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlOuter;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.GroupBox pnlBottom;
        private System.Windows.Forms.PictureBox picOut;
        private System.Windows.Forms.PictureBox picIn;
        private System.Windows.Forms.Label lblImageInfo;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label lblPlate;
    }
}
