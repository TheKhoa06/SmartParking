namespace SmartParking.UI.Forms
{
    partial class frmQuickReceipt
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.picQr = new System.Windows.Forms.PictureBox();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lblDetailVal = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblChargingVal = new System.Windows.Forms.Label();
            this.lblChargingTitle = new System.Windows.Forms.Label();
            this.lblDurationVal = new System.Windows.Forms.Label();
            this.lblDurationTitle = new System.Windows.Forms.Label();
            this.lblCheckOutVal = new System.Windows.Forms.Label();
            this.lblCheckOutTitle = new System.Windows.Forms.Label();
            this.lblCheckInVal = new System.Windows.Forms.Label();
            this.lblCheckInTitle = new System.Windows.Forms.Label();
            this.lblSlotVal = new System.Windows.Forms.Label();
            this.lblSlotTitle = new System.Windows.Forms.Label();
            this.lblVehTypeVal = new System.Windows.Forms.Label();
            this.lblVehTypeTitle = new System.Windows.Forms.Label();
            this.lblPlateVal = new System.Windows.Forms.Label();
            this.lblPlateTitle = new System.Windows.Forms.Label();
            this.lblTransCodeVal = new System.Windows.Forms.Label();
            this.lblTransCodeTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblSub);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlTop.Size = new System.Drawing.Size(414, 70);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHIẾU THANH TOÁN GỬI XE";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.lblSub.Location = new System.Drawing.Point(20, 38);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(277, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "KTX & Chung cư Sinh viên - Ban Quản Lý Tòa Nhà";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.btnPrint);
            this.pnlContent.Controls.Add(this.picQr);
            this.pnlContent.Controls.Add(this.lblTotalVal);
            this.pnlContent.Controls.Add(this.lblTotalTitle);
            this.pnlContent.Controls.Add(this.pnlLine);
            this.pnlContent.Controls.Add(this.lblDetailVal);
            this.pnlContent.Controls.Add(this.lblDetailTitle);
            this.pnlContent.Controls.Add(this.lblChargingVal);
            this.pnlContent.Controls.Add(this.lblChargingTitle);
            this.pnlContent.Controls.Add(this.lblDurationVal);
            this.pnlContent.Controls.Add(this.lblDurationTitle);
            this.pnlContent.Controls.Add(this.lblCheckOutVal);
            this.pnlContent.Controls.Add(this.lblCheckOutTitle);
            this.pnlContent.Controls.Add(this.lblCheckInVal);
            this.pnlContent.Controls.Add(this.lblCheckInTitle);
            this.pnlContent.Controls.Add(this.lblSlotVal);
            this.pnlContent.Controls.Add(this.lblSlotTitle);
            this.pnlContent.Controls.Add(this.lblVehTypeVal);
            this.pnlContent.Controls.Add(this.lblVehTypeTitle);
            this.pnlContent.Controls.Add(this.lblPlateVal);
            this.pnlContent.Controls.Add(this.lblPlateTitle);
            this.pnlContent.Controls.Add(this.lblTransCodeVal);
            this.pnlContent.Controls.Add(this.lblTransCodeTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlContent.Size = new System.Drawing.Size(414, 471);
            this.pnlContent.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(25, 415);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(364, 38);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "🖨️  In Phiếu / Đóng";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // picQr
            // 
            this.picQr.Location = new System.Drawing.Point(145, 290);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(115, 115);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQr.TabIndex = 21;
            this.picQr.TabStop = false;
            // 
            // lblTotalVal
            // 
            this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTotalVal.Location = new System.Drawing.Point(175, 256);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(214, 23);
            this.lblTotalVal.TabIndex = 20;
            this.lblTotalVal.Text = "0 VNĐ";
            this.lblTotalVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(25, 256);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(145, 23);
            this.lblTotalTitle.TabIndex = 19;
            this.lblTotalTitle.Text = "TỔNG THANH TOÁN:";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlLine.Location = new System.Drawing.Point(25, 246);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(364, 1);
            this.pnlLine.TabIndex = 18;
            // 
            // lblDetailVal
            // 
            this.lblDetailVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetailVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDetailVal.Location = new System.Drawing.Point(175, 218);
            this.lblDetailVal.Name = "lblDetailVal";
            this.lblDetailVal.Size = new System.Drawing.Size(214, 23);
            this.lblDetailVal.TabIndex = 17;
            this.lblDetailVal.Text = "-";
            this.lblDetailVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(25, 218);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(145, 23);
            this.lblDetailTitle.TabIndex = 16;
            this.lblDetailTitle.Text = "Chi tiết tính phí:";
            // 
            // lblChargingVal
            // 
            this.lblChargingVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChargingVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChargingVal.Location = new System.Drawing.Point(175, 192);
            this.lblChargingVal.Name = "lblChargingVal";
            this.lblChargingVal.Size = new System.Drawing.Size(214, 23);
            this.lblChargingVal.TabIndex = 15;
            this.lblChargingVal.Text = "Không";
            this.lblChargingVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblChargingTitle
            // 
            this.lblChargingTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChargingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChargingTitle.Location = new System.Drawing.Point(25, 192);
            this.lblChargingTitle.Name = "lblChargingTitle";
            this.lblChargingTitle.Size = new System.Drawing.Size(145, 23);
            this.lblChargingTitle.TabIndex = 14;
            this.lblChargingTitle.Text = "Dịch vụ sạc điện ⚡:";
            // 
            // lblDurationVal
            // 
            this.lblDurationVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDurationVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDurationVal.Location = new System.Drawing.Point(175, 166);
            this.lblDurationVal.Name = "lblDurationVal";
            this.lblDurationVal.Size = new System.Drawing.Size(214, 23);
            this.lblDurationVal.TabIndex = 13;
            this.lblDurationVal.Text = "0h 0p";
            this.lblDurationVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDurationTitle
            // 
            this.lblDurationTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDurationTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDurationTitle.Location = new System.Drawing.Point(25, 166);
            this.lblDurationTitle.Name = "lblDurationTitle";
            this.lblDurationTitle.Size = new System.Drawing.Size(145, 23);
            this.lblDurationTitle.TabIndex = 12;
            this.lblDurationTitle.Text = "Thời lượng gửi:";
            // 
            // lblCheckOutVal
            // 
            this.lblCheckOutVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckOutVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCheckOutVal.Location = new System.Drawing.Point(175, 140);
            this.lblCheckOutVal.Name = "lblCheckOutVal";
            this.lblCheckOutVal.Size = new System.Drawing.Size(214, 23);
            this.lblCheckOutVal.TabIndex = 11;
            this.lblCheckOutVal.Text = "01/01/2026 00:00";
            this.lblCheckOutVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCheckOutTitle
            // 
            this.lblCheckOutTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckOutTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCheckOutTitle.Location = new System.Drawing.Point(25, 140);
            this.lblCheckOutTitle.Name = "lblCheckOutTitle";
            this.lblCheckOutTitle.Size = new System.Drawing.Size(145, 23);
            this.lblCheckOutTitle.TabIndex = 10;
            this.lblCheckOutTitle.Text = "Thời gian ra:";
            // 
            // lblCheckInVal
            // 
            this.lblCheckInVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckInVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCheckInVal.Location = new System.Drawing.Point(175, 114);
            this.lblCheckInVal.Name = "lblCheckInVal";
            this.lblCheckInVal.Size = new System.Drawing.Size(214, 23);
            this.lblCheckInVal.TabIndex = 9;
            this.lblCheckInVal.Text = "01/01/2026 00:00";
            this.lblCheckInVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCheckInTitle
            // 
            this.lblCheckInTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckInTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCheckInTitle.Location = new System.Drawing.Point(25, 114);
            this.lblCheckInTitle.Name = "lblCheckInTitle";
            this.lblCheckInTitle.Size = new System.Drawing.Size(145, 23);
            this.lblCheckInTitle.TabIndex = 8;
            this.lblCheckInTitle.Text = "Thời gian vào:";
            // 
            // lblSlotVal
            // 
            this.lblSlotVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSlotVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSlotVal.Location = new System.Drawing.Point(175, 88);
            this.lblSlotVal.Name = "lblSlotVal";
            this.lblSlotVal.Size = new System.Drawing.Size(214, 23);
            this.lblSlotVal.TabIndex = 7;
            this.lblSlotVal.Text = "A-01";
            this.lblSlotVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSlotTitle
            // 
            this.lblSlotTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSlotTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSlotTitle.Location = new System.Drawing.Point(25, 88);
            this.lblSlotTitle.Name = "lblSlotTitle";
            this.lblSlotTitle.Size = new System.Drawing.Size(145, 23);
            this.lblSlotTitle.TabIndex = 6;
            this.lblSlotTitle.Text = "Vị trí đỗ:";
            // 
            // lblVehTypeVal
            // 
            this.lblVehTypeVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVehTypeVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblVehTypeVal.Location = new System.Drawing.Point(175, 62);
            this.lblVehTypeVal.Name = "lblVehTypeVal";
            this.lblVehTypeVal.Size = new System.Drawing.Size(214, 23);
            this.lblVehTypeVal.TabIndex = 5;
            this.lblVehTypeVal.Text = "Xe máy";
            this.lblVehTypeVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVehTypeTitle
            // 
            this.lblVehTypeTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVehTypeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVehTypeTitle.Location = new System.Drawing.Point(25, 62);
            this.lblVehTypeTitle.Name = "lblVehTypeTitle";
            this.lblVehTypeTitle.Size = new System.Drawing.Size(145, 23);
            this.lblVehTypeTitle.TabIndex = 4;
            this.lblVehTypeTitle.Text = "Loại phương tiện:";
            // 
            // lblPlateVal
            // 
            this.lblPlateVal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPlateVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPlateVal.Location = new System.Drawing.Point(175, 36);
            this.lblPlateVal.Name = "lblPlateVal";
            this.lblPlateVal.Size = new System.Drawing.Size(214, 23);
            this.lblPlateVal.TabIndex = 3;
            this.lblPlateVal.Text = "29A-123.45";
            this.lblPlateVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPlateTitle
            // 
            this.lblPlateTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPlateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPlateTitle.Location = new System.Drawing.Point(25, 36);
            this.lblPlateTitle.Name = "lblPlateTitle";
            this.lblPlateTitle.Size = new System.Drawing.Size(145, 23);
            this.lblPlateTitle.TabIndex = 2;
            this.lblPlateTitle.Text = "Biển số xe:";
            // 
            // lblTransCodeVal
            // 
            this.lblTransCodeVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransCodeVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTransCodeVal.Location = new System.Drawing.Point(175, 10);
            this.lblTransCodeVal.Name = "lblTransCodeVal";
            this.lblTransCodeVal.Size = new System.Drawing.Size(214, 23);
            this.lblTransCodeVal.TabIndex = 1;
            this.lblTransCodeVal.Text = "#000001";
            this.lblTransCodeVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTransCodeTitle
            // 
            this.lblTransCodeTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransCodeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTransCodeTitle.Location = new System.Drawing.Point(25, 10);
            this.lblTransCodeTitle.Name = "lblTransCodeTitle";
            this.lblTransCodeTitle.Size = new System.Drawing.Size(145, 23);
            this.lblTransCodeTitle.TabIndex = 0;
            this.lblTransCodeTitle.Text = "Mã giao dịch:";
            // 
            // frmQuickReceipt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 541);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuickReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phiếu Thanh Toán Dịch Vụ Gửi Xe - SmartParking";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTransCodeTitle;
        private System.Windows.Forms.Label lblTransCodeVal;
        private System.Windows.Forms.Label lblPlateTitle;
        private System.Windows.Forms.Label lblPlateVal;
        private System.Windows.Forms.Label lblVehTypeTitle;
        private System.Windows.Forms.Label lblVehTypeVal;
        private System.Windows.Forms.Label lblSlotTitle;
        private System.Windows.Forms.Label lblSlotVal;
        private System.Windows.Forms.Label lblCheckInTitle;
        private System.Windows.Forms.Label lblCheckInVal;
        private System.Windows.Forms.Label lblCheckOutTitle;
        private System.Windows.Forms.Label lblCheckOutVal;
        private System.Windows.Forms.Label lblDurationTitle;
        private System.Windows.Forms.Label lblDurationVal;
        private System.Windows.Forms.Label lblChargingTitle;
        private System.Windows.Forms.Label lblChargingVal;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailVal;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.Button btnPrint;
    }
}
