namespace SmartParking.UI.Forms
{
    partial class frmLostTicket
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnCaptureFace = new System.Windows.Forms.Button();
            this.picFaceCapture = new System.Windows.Forms.PictureBox();
            this.lblFaceTitle = new System.Windows.Forms.Label();
            this.picInImage = new System.Windows.Forms.PictureBox();
            this.lblInTitle = new System.Windows.Forms.Label();
            this.lstMatchingSessions = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTotalFee = new System.Windows.Forms.Label();
            this.pnlFeeBox = new System.Windows.Forms.Panel();
            this.lblFeeBreakdown = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotesTitle = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhoneTitle = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.lblIdCardTitle = new System.Windows.Forms.Label();
            this.txtFinderName = new System.Windows.Forms.TextBox();
            this.lblFinderNameTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInImage)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlFeeBox.SuspendLayout();
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
            this.pnlTop.Size = new System.Drawing.Size(844, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(395, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚠️ BIÊN BẢN PHÁP LÝ: XỬ LÝ SỰ CỐ MẤT VÉ XE";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.lblSub.Location = new System.Drawing.Point(20, 38);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(437, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Đối chiếu hình ảnh lúc vào, thu thập danh tính CCCD và thu phí phạt theo quy định" +
    "";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.btnCaptureFace);
            this.pnlLeft.Controls.Add(this.picFaceCapture);
            this.pnlLeft.Controls.Add(this.lblFaceTitle);
            this.pnlLeft.Controls.Add(this.picInImage);
            this.pnlLeft.Controls.Add(this.lblInTitle);
            this.pnlLeft.Controls.Add(this.lstMatchingSessions);
            this.pnlLeft.Controls.Add(this.btnSearch);
            this.pnlLeft.Controls.Add(this.txtSearch);
            this.pnlLeft.Controls.Add(this.lblSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 65);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLeft.Size = new System.Drawing.Size(380, 546);
            this.pnlLeft.TabIndex = 1;
            // 
            // btnCaptureFace
            // 
            this.btnCaptureFace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnCaptureFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaptureFace.FlatAppearance.BorderSize = 0;
            this.btnCaptureFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureFace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCaptureFace.ForeColor = System.Drawing.Color.White;
            this.btnCaptureFace.Location = new System.Drawing.Point(225, 415);
            this.btnCaptureFace.Name = "btnCaptureFace";
            this.btnCaptureFace.Size = new System.Drawing.Size(135, 55);
            this.btnCaptureFace.TabIndex = 8;
            this.btnCaptureFace.Text = "📸 Chụp Ảnh\nNhận Xe";
            this.btnCaptureFace.UseVisualStyleBackColor = false;
            // 
            // picFaceCapture
            // 
            this.picFaceCapture.BackColor = System.Drawing.Color.Black;
            this.picFaceCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFaceCapture.Location = new System.Drawing.Point(12, 390);
            this.picFaceCapture.Name = "picFaceCapture";
            this.picFaceCapture.Size = new System.Drawing.Size(200, 110);
            this.picFaceCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFaceCapture.TabIndex = 7;
            this.picFaceCapture.TabStop = false;
            // 
            // lblFaceTitle
            // 
            this.lblFaceTitle.AutoSize = true;
            this.lblFaceTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFaceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblFaceTitle.Location = new System.Drawing.Point(12, 370);
            this.lblFaceTitle.Name = "lblFaceTitle";
            this.lblFaceTitle.Size = new System.Drawing.Size(256, 15);
            this.lblFaceTitle.TabIndex = 6;
            this.lblFaceTitle.Text = "ẢNH CHÂN DUNG NGƯỜI NHẬN XE & CCCD:";
            // 
            // picInImage
            // 
            this.picInImage.BackColor = System.Drawing.Color.Black;
            this.picInImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picInImage.Location = new System.Drawing.Point(12, 185);
            this.picInImage.Name = "picInImage";
            this.picInImage.Size = new System.Drawing.Size(348, 175);
            this.picInImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInImage.TabIndex = 5;
            this.picInImage.TabStop = false;
            // 
            // lblInTitle
            // 
            this.lblInTitle.AutoSize = true;
            this.lblInTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblInTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblInTitle.Location = new System.Drawing.Point(12, 165);
            this.lblInTitle.Name = "lblInTitle";
            this.lblInTitle.Size = new System.Drawing.Size(221, 15);
            this.lblInTitle.TabIndex = 4;
            this.lblInTitle.Text = "ẢNH CHỤP XE LÚC VÀO ĐỂ ĐỐI SOÁT:";
            // 
            // lstMatchingSessions
            // 
            this.lstMatchingSessions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstMatchingSessions.FormattingEnabled = true;
            this.lstMatchingSessions.ItemHeight = 15;
            this.lstMatchingSessions.Location = new System.Drawing.Point(12, 65);
            this.lstMatchingSessions.Name = "lstMatchingSessions";
            this.lstMatchingSessions.Size = new System.Drawing.Size(348, 94);
            this.lstMatchingSessions.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(275, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(12, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSearch.Location = new System.Drawing.Point(12, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(217, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm xe mất vé (Biển số / Giờ vào):";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.btnConfirm);
            this.pnlRight.Controls.Add(this.lblTotalFee);
            this.pnlRight.Controls.Add(this.pnlFeeBox);
            this.pnlRight.Controls.Add(this.txtNotes);
            this.pnlRight.Controls.Add(this.lblNotesTitle);
            this.pnlRight.Controls.Add(this.txtPhone);
            this.pnlRight.Controls.Add(this.lblPhoneTitle);
            this.pnlRight.Controls.Add(this.txtIdCard);
            this.pnlRight.Controls.Add(this.lblIdCardTitle);
            this.pnlRight.Controls.Add(this.txtFinderName);
            this.pnlRight.Controls.Add(this.lblFinderNameTitle);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(380, 65);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRight.Size = new System.Drawing.Size(464, 546);
            this.pnlRight.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(15, 395);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(400, 44);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "✍️  XÁC NHẬN LẬP BIÊN BẢN & MỞ CỔNG";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // lblTotalFee
            // 
            this.lblTotalFee.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTotalFee.Location = new System.Drawing.Point(15, 353);
            this.lblTotalFee.Name = "lblTotalFee";
            this.lblTotalFee.Size = new System.Drawing.Size(400, 32);
            this.lblTotalFee.TabIndex = 9;
            this.lblTotalFee.Text = "TỔNG THANH TOÁN: 30.000 VNĐ";
            // 
            // pnlFeeBox
            // 
            this.pnlFeeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlFeeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFeeBox.Controls.Add(this.lblFeeBreakdown);
            this.pnlFeeBox.Location = new System.Drawing.Point(15, 268);
            this.pnlFeeBox.Name = "pnlFeeBox";
            this.pnlFeeBox.Size = new System.Drawing.Size(400, 75);
            this.pnlFeeBox.TabIndex = 8;
            // 
            // lblFeeBreakdown
            // 
            this.lblFeeBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFeeBreakdown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFeeBreakdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lblFeeBreakdown.Location = new System.Drawing.Point(0, 0);
            this.lblFeeBreakdown.Name = "lblFeeBreakdown";
            this.lblFeeBreakdown.Padding = new System.Windows.Forms.Padding(10);
            this.lblFeeBreakdown.Size = new System.Drawing.Size(398, 73);
            this.lblFeeBreakdown.TabIndex = 0;
            this.lblFeeBreakdown.Text = "CHI TIẾT KHOẢN THU SỰ CỐ:\r\n• Tiền gửi xe theo giờ thực tế:   0 VNĐ\r\n• Tiền phạt m" +
    "ất vé (Quy định):    30.000 VNĐ";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(175, 141);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(240, 55);
            this.txtNotes.TabIndex = 7;
            this.txtNotes.Text = "Khách làm rơi vé lượt trong lúc đi ăn trưa.";
            // 
            // lblNotesTitle
            // 
            this.lblNotesTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblNotesTitle.Location = new System.Drawing.Point(15, 144);
            this.lblNotesTitle.Name = "lblNotesTitle";
            this.lblNotesTitle.Size = new System.Drawing.Size(155, 23);
            this.lblNotesTitle.TabIndex = 6;
            this.lblNotesTitle.Text = "Lý do làm mất vé:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(175, 99);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(240, 23);
            this.txtPhone.TabIndex = 5;
            this.txtPhone.Text = "0988777666";
            // 
            // lblPhoneTitle
            // 
            this.lblPhoneTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPhoneTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPhoneTitle.Location = new System.Drawing.Point(15, 102);
            this.lblPhoneTitle.Name = "lblPhoneTitle";
            this.lblPhoneTitle.Size = new System.Drawing.Size(155, 23);
            this.lblPhoneTitle.TabIndex = 4;
            this.lblPhoneTitle.Text = "Số điện thoại (*):";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdCard.Location = new System.Drawing.Point(175, 57);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(240, 23);
            this.txtIdCard.TabIndex = 3;
            this.txtIdCard.Text = "001202008899";
            // 
            // lblIdCardTitle
            // 
            this.lblIdCardTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblIdCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblIdCardTitle.Location = new System.Drawing.Point(15, 60);
            this.lblIdCardTitle.Name = "lblIdCardTitle";
            this.lblIdCardTitle.Size = new System.Drawing.Size(155, 23);
            this.lblIdCardTitle.TabIndex = 2;
            this.lblIdCardTitle.Text = "Số CCCD / MSSV (*):";
            // 
            // txtFinderName
            // 
            this.txtFinderName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFinderName.Location = new System.Drawing.Point(175, 15);
            this.txtFinderName.Name = "txtFinderName";
            this.txtFinderName.Size = new System.Drawing.Size(240, 23);
            this.txtFinderName.TabIndex = 1;
            this.txtFinderName.Text = "Nguyễn Văn Tuấn";
            // 
            // lblFinderNameTitle
            // 
            this.lblFinderNameTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFinderNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblFinderNameTitle.Location = new System.Drawing.Point(15, 18);
            this.lblFinderNameTitle.Name = "lblFinderNameTitle";
            this.lblFinderNameTitle.Size = new System.Drawing.Size(155, 23);
            this.lblFinderNameTitle.TabIndex = 0;
            this.lblFinderNameTitle.Text = "Họ tên người nhận (*):";
            // 
            // frmLostTicket
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(844, 611);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLostTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Biên Bản Xử Lý Sự Cố Mất Vé Xe - SmartParking";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInImage)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlFeeBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstMatchingSessions;
        private System.Windows.Forms.Label lblInTitle;
        private System.Windows.Forms.PictureBox picInImage;
        private System.Windows.Forms.Label lblFaceTitle;
        private System.Windows.Forms.PictureBox picFaceCapture;
        private System.Windows.Forms.Button btnCaptureFace;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblFinderNameTitle;
        private System.Windows.Forms.TextBox txtFinderName;
        private System.Windows.Forms.Label lblIdCardTitle;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label lblPhoneTitle;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblNotesTitle;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel pnlFeeBox;
        private System.Windows.Forms.Label lblFeeBreakdown;
        private System.Windows.Forms.Label lblTotalFee;
        private System.Windows.Forms.Button btnConfirm;
    }
}
