namespace SmartParking.UI.Forms
{
    partial class frmPrintTicket
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
            this.pnlCardPreview = new System.Windows.Forms.Panel();
            this.lblCode = new System.Windows.Forms.Label();
            this.picQr = new System.Windows.Forms.PictureBox();
            this.lblExpire = new System.Windows.Forms.Label();
            this.lblPlateVal = new System.Windows.Forms.Label();
            this.lblPlateTitle = new System.Windows.Forms.Label();
            this.lblRoomVal = new System.Windows.Forms.Label();
            this.lblRoomTitle = new System.Windows.Forms.Label();
            this.lblOwnerVal = new System.Windows.Forms.Label();
            this.lblOwnerTitle = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlCardPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlTop.Size = new System.Drawing.Size(534, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MẪU THẺ THÀNH VIÊN GỬI XE THÔNG MINH";
            // 
            // pnlCardPreview
            // 
            this.pnlCardPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlCardPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardPreview.Controls.Add(this.lblCode);
            this.pnlCardPreview.Controls.Add(this.picQr);
            this.pnlCardPreview.Controls.Add(this.lblExpire);
            this.pnlCardPreview.Controls.Add(this.lblPlateVal);
            this.pnlCardPreview.Controls.Add(this.lblPlateTitle);
            this.pnlCardPreview.Controls.Add(this.lblRoomVal);
            this.pnlCardPreview.Controls.Add(this.lblRoomTitle);
            this.pnlCardPreview.Controls.Add(this.lblOwnerVal);
            this.pnlCardPreview.Controls.Add(this.lblOwnerTitle);
            this.pnlCardPreview.Controls.Add(this.pnlLine);
            this.pnlCardPreview.Controls.Add(this.lblSub);
            this.pnlCardPreview.Controls.Add(this.lblBrand);
            this.pnlCardPreview.Location = new System.Drawing.Point(32, 85);
            this.pnlCardPreview.Name = "pnlCardPreview";
            this.pnlCardPreview.Size = new System.Drawing.Size(470, 250);
            this.pnlCardPreview.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.White;
            this.lblCode.Location = new System.Drawing.Point(310, 202);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(150, 18);
            this.lblCode.TabIndex = 11;
            this.lblCode.Text = "CARD-00000";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picQr
            // 
            this.picQr.BackColor = System.Drawing.Color.White;
            this.picQr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQr.Location = new System.Drawing.Point(325, 75);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(120, 120);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQr.TabIndex = 10;
            this.picQr.TabStop = false;
            // 
            // lblExpire
            // 
            this.lblExpire.AutoSize = true;
            this.lblExpire.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblExpire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.lblExpire.Location = new System.Drawing.Point(15, 222);
            this.lblExpire.Name = "lblExpire";
            this.lblExpire.Size = new System.Drawing.Size(193, 13);
            this.lblExpire.TabIndex = 9;
            this.lblExpire.Text = "Hạn sử dụng: 01/01/2026 (Gói 1 tháng)";
            // 
            // lblPlateVal
            // 
            this.lblPlateVal.AutoSize = true;
            this.lblPlateVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPlateVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblPlateVal.Location = new System.Drawing.Point(15, 182);
            this.lblPlateVal.Name = "lblPlateVal";
            this.lblPlateVal.Size = new System.Drawing.Size(139, 17);
            this.lblPlateVal.TabIndex = 8;
            this.lblPlateVal.Text = "29A-123.45 (Xe máy)";
            // 
            // lblPlateTitle
            // 
            this.lblPlateTitle.AutoSize = true;
            this.lblPlateTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblPlateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(185)))), ((int)(((byte)(205)))));
            this.lblPlateTitle.Location = new System.Drawing.Point(15, 166);
            this.lblPlateTitle.Name = "lblPlateTitle";
            this.lblPlateTitle.Size = new System.Drawing.Size(60, 12);
            this.lblPlateTitle.TabIndex = 7;
            this.lblPlateTitle.Text = "BIỂN SỐ XE";
            // 
            // lblRoomVal
            // 
            this.lblRoomVal.AutoSize = true;
            this.lblRoomVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRoomVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(36)))));
            this.lblRoomVal.Location = new System.Drawing.Point(15, 142);
            this.lblRoomVal.Name = "lblRoomVal";
            this.lblRoomVal.Size = new System.Drawing.Size(155, 17);
            this.lblRoomVal.TabIndex = 6;
            this.lblRoomVal.Text = "P.A101 (Xe định mức #1)";
            // 
            // lblRoomTitle
            // 
            this.lblRoomTitle.AutoSize = true;
            this.lblRoomTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblRoomTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(185)))), ((int)(((byte)(205)))));
            this.lblRoomTitle.Location = new System.Drawing.Point(15, 126);
            this.lblRoomTitle.Name = "lblRoomTitle";
            this.lblRoomTitle.Size = new System.Drawing.Size(104, 12);
            this.lblRoomTitle.TabIndex = 5;
            this.lblRoomTitle.Text = "PHÒNG KTX / CĂN HỘ";
            // 
            // lblOwnerVal
            // 
            this.lblOwnerVal.AutoSize = true;
            this.lblOwnerVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOwnerVal.ForeColor = System.Drawing.Color.White;
            this.lblOwnerVal.Location = new System.Drawing.Point(15, 102);
            this.lblOwnerVal.Name = "lblOwnerVal";
            this.lblOwnerVal.Size = new System.Drawing.Size(117, 17);
            this.lblOwnerVal.TabIndex = 4;
            this.lblOwnerVal.Text = "NGUYỄN VĂN A";
            // 
            // lblOwnerTitle
            // 
            this.lblOwnerTitle.AutoSize = true;
            this.lblOwnerTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblOwnerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(185)))), ((int)(((byte)(205)))));
            this.lblOwnerTitle.Location = new System.Drawing.Point(15, 86);
            this.lblOwnerTitle.Name = "lblOwnerTitle";
            this.lblOwnerTitle.Size = new System.Drawing.Size(65, 12);
            this.lblOwnerTitle.TabIndex = 3;
            this.lblOwnerTitle.Text = "CHỦ SỞ HỮU";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.pnlLine.Location = new System.Drawing.Point(15, 52);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(438, 2);
            this.pnlLine.TabIndex = 2;
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.lblSub.Location = new System.Drawing.Point(18, 34);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(217, 12);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "HỆ THỐNG QUẢN LÝ XE KÝ TÚC XÁ & CĂN HỘ";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(15, 12);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(325, 20);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "🅿️ SMARTPARKING PRO - THẺ THÀNH VIÊN";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(110, 360);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(200, 38);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "🖨️  Xuất In Thẻ Nhựa";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(325, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmPrintTicket
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 441);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlCardPreview);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "In Thẻ Gửi Xe KTX & Chung Cư - SmartParking";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCardPreview.ResumeLayout(false);
            this.pnlCardPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCardPreview;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lblOwnerTitle;
        private System.Windows.Forms.Label lblOwnerVal;
        private System.Windows.Forms.Label lblRoomTitle;
        private System.Windows.Forms.Label lblRoomVal;
        private System.Windows.Forms.Label lblPlateTitle;
        private System.Windows.Forms.Label lblPlateVal;
        private System.Windows.Forms.Label lblExpire;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}
