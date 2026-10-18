namespace SmartParking.UI.UserControls
{
    partial class ucResidentMonthly
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
            this.split = new System.Windows.Forms.SplitContainer();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.grpEmail = new System.Windows.Forms.GroupBox();
            this.lblEmailStatus = new System.Windows.Forms.Label();
            this.progEmail = new System.Windows.Forms.ProgressBar();
            this.btnSendBulkEmail = new System.Windows.Forms.Button();
            this.btnReissue = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblFeeSummary = new System.Windows.Forms.Label();
            this.cboFixedSlot = new System.Windows.Forms.ComboBox();
            this.lblFixedSlot = new System.Windows.Forms.Label();
            this.cboPlan = new System.Windows.Forms.ComboBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cboVehicleType = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblPlate = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblQuotaWarning = new System.Windows.Forms.Label();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.dgvCards = new System.Windows.Forms.DataGridView();
            this.pnlCardMiniPreview = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearchGrid = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.grpLeft.SuspendLayout();
            this.grpEmail.SuspendLayout();
            this.grpRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.AutoScroll = true;
            this.split.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.split.Panel1.Controls.Add(this.grpLeft);
            this.split.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // split.Panel2
            // 
            this.split.Panel2.AutoScroll = true;
            this.split.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.split.Panel2.Controls.Add(this.grpRight);
            this.split.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.split.Size = new System.Drawing.Size(1100, 700);
            this.split.SplitterDistance = 460;
            this.split.SplitterWidth = 8;
            this.split.TabIndex = 0;
            // 
            // grpLeft
            // 
            this.grpLeft.BackColor = System.Drawing.Color.White;
            this.grpLeft.Controls.Add(this.grpEmail);
            this.grpLeft.Controls.Add(this.btnReissue);
            this.grpLeft.Controls.Add(this.btnRenew);
            this.grpLeft.Controls.Add(this.btnRegister);
            this.grpLeft.Controls.Add(this.lblFeeSummary);
            this.grpLeft.Controls.Add(this.cboFixedSlot);
            this.grpLeft.Controls.Add(this.lblFixedSlot);
            this.grpLeft.Controls.Add(this.cboPlan);
            this.grpLeft.Controls.Add(this.lblPlan);
            this.grpLeft.Controls.Add(this.cboVehicleType);
            this.grpLeft.Controls.Add(this.lblVehicleType);
            this.grpLeft.Controls.Add(this.txtPlate);
            this.grpLeft.Controls.Add(this.lblPlate);
            this.grpLeft.Controls.Add(this.txtEmail);
            this.grpLeft.Controls.Add(this.lblEmail);
            this.grpLeft.Controls.Add(this.txtPhone);
            this.grpLeft.Controls.Add(this.lblPhone);
            this.grpLeft.Controls.Add(this.txtStudentId);
            this.grpLeft.Controls.Add(this.lblStudentId);
            this.grpLeft.Controls.Add(this.txtFullName);
            this.grpLeft.Controls.Add(this.lblFullName);
            this.grpLeft.Controls.Add(this.lblQuotaWarning);
            this.grpLeft.Controls.Add(this.cboRoom);
            this.grpLeft.Controls.Add(this.lblRoom);
            this.grpLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLeft.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpLeft.Location = new System.Drawing.Point(8, 8);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Padding = new System.Windows.Forms.Padding(12);
            this.grpLeft.Size = new System.Drawing.Size(427, 600);
            this.grpLeft.TabIndex = 0;
            this.grpLeft.TabStop = false;
            this.grpLeft.Text = "ĐĂNG KÝ & QUẢN LÝ VÉ THÁNG CƯ DÂN";
            // 
            // grpEmail
            // 
            this.grpEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.grpEmail.Controls.Add(this.lblEmailStatus);
            this.grpEmail.Controls.Add(this.progEmail);
            this.grpEmail.Controls.Add(this.btnSendBulkEmail);
            this.grpEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.grpEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.grpEmail.Location = new System.Drawing.Point(15, 485);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(385, 96);
            this.grpEmail.TabIndex = 23;
            this.grpEmail.TabStop = false;
            this.grpEmail.Text = "Nhắc gia hạn tự động qua Email";
            // 
            // lblEmailStatus
            // 
            this.lblEmailStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEmailStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblEmailStatus.Location = new System.Drawing.Point(12, 70);
            this.lblEmailStatus.Name = "lblEmailStatus";
            this.lblEmailStatus.Size = new System.Drawing.Size(360, 18);
            this.lblEmailStatus.TabIndex = 2;
            this.lblEmailStatus.Text = "Hệ thống sẵn sàng gửi email thông báo";
            // 
            // progEmail
            // 
            this.progEmail.Location = new System.Drawing.Point(12, 52);
            this.progEmail.Name = "progEmail";
            this.progEmail.Size = new System.Drawing.Size(360, 12);
            this.progEmail.TabIndex = 1;
            this.progEmail.Visible = false;
            // 
            // btnSendBulkEmail
            // 
            this.btnSendBulkEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSendBulkEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendBulkEmail.FlatAppearance.BorderSize = 0;
            this.btnSendBulkEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendBulkEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSendBulkEmail.ForeColor = System.Drawing.Color.White;
            this.btnSendBulkEmail.Location = new System.Drawing.Point(12, 20);
            this.btnSendBulkEmail.Name = "btnSendBulkEmail";
            this.btnSendBulkEmail.Size = new System.Drawing.Size(220, 26);
            this.btnSendBulkEmail.TabIndex = 0;
            this.btnSendBulkEmail.Text = "📧 Gửi Email Nhắc Hết Hạn";
            this.btnSendBulkEmail.UseVisualStyleBackColor = false;
            // 
            // btnReissue
            // 
            this.btnReissue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnReissue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReissue.FlatAppearance.BorderSize = 0;
            this.btnReissue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReissue.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnReissue.ForeColor = System.Drawing.Color.White;
            this.btnReissue.Location = new System.Drawing.Point(15, 442);
            this.btnReissue.Name = "btnReissue";
            this.btnReissue.Size = new System.Drawing.Size(385, 32);
            this.btnReissue.TabIndex = 22;
            this.btnReissue.Text = "🔄 Cấp Lại Mã Thẻ / Đổi Phương Tiện (+20.000đ)";
            this.btnReissue.UseVisualStyleBackColor = false;
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRenew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenew.FlatAppearance.BorderSize = 0;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.Location = new System.Drawing.Point(215, 398);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(185, 36);
            this.btnRenew.TabIndex = 21;
            this.btnRenew.Text = "💳 Gia Hạn Thẻ";
            this.btnRenew.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(15, 398);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(185, 36);
            this.btnRegister.TabIndex = 20;
            this.btnRegister.Text = "➕ Đăng Ký & In Thẻ";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // lblFeeSummary
            // 
            this.lblFeeSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblFeeSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFeeSummary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFeeSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblFeeSummary.Location = new System.Drawing.Point(15, 355);
            this.lblFeeSummary.Name = "lblFeeSummary";
            this.lblFeeSummary.Size = new System.Drawing.Size(385, 30);
            this.lblFeeSummary.TabIndex = 19;
            this.lblFeeSummary.Text = "Tổng tiền thanh toán: 0 VNĐ";
            this.lblFeeSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboFixedSlot
            // 
            this.cboFixedSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFixedSlot.Enabled = false;
            this.cboFixedSlot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFixedSlot.FormattingEnabled = true;
            this.cboFixedSlot.Location = new System.Drawing.Point(160, 316);
            this.cboFixedSlot.Name = "cboFixedSlot";
            this.cboFixedSlot.Size = new System.Drawing.Size(240, 23);
            this.cboFixedSlot.TabIndex = 18;
            // 
            // lblFixedSlot
            // 
            this.lblFixedSlot.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFixedSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFixedSlot.Location = new System.Drawing.Point(15, 320);
            this.lblFixedSlot.Name = "lblFixedSlot";
            this.lblFixedSlot.Size = new System.Drawing.Size(140, 18);
            this.lblFixedSlot.TabIndex = 17;
            this.lblFixedSlot.Text = "Gán ô cố định (Ô tô):";
            // 
            // cboPlan
            // 
            this.cboPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboPlan.FormattingEnabled = true;
            this.cboPlan.Items.AddRange(new object[] {
            "1 tháng (0% giảm)",
            "3 tháng (Giảm 5%)",
            "Học kỳ 5 tháng (Giảm 10%)",
            "12 tháng (Giảm 20%)"});
            this.cboPlan.Location = new System.Drawing.Point(160, 284);
            this.cboPlan.Name = "cboPlan";
            this.cboPlan.Size = new System.Drawing.Size(240, 23);
            this.cboPlan.TabIndex = 16;
            // 
            // lblPlan
            // 
            this.lblPlan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPlan.Location = new System.Drawing.Point(15, 288);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(140, 18);
            this.lblPlan.TabIndex = 15;
            this.lblPlan.Text = "Gói cước gửi xe (*):";
            // 
            // cboVehicleType
            // 
            this.cboVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboVehicleType.FormattingEnabled = true;
            this.cboVehicleType.Items.AddRange(new object[] {
            "Xe máy xăng",
            "Xe máy điện",
            "Xe đạp",
            "Ô tô"});
            this.cboVehicleType.Location = new System.Drawing.Point(160, 252);
            this.cboVehicleType.Name = "cboVehicleType";
            this.cboVehicleType.Size = new System.Drawing.Size(240, 23);
            this.cboVehicleType.TabIndex = 14;
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblVehicleType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblVehicleType.Location = new System.Drawing.Point(15, 256);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(140, 18);
            this.lblVehicleType.TabIndex = 13;
            this.lblVehicleType.Text = "Loại phương tiện (*):";
            // 
            // txtPlate
            // 
            this.txtPlate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtPlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtPlate.Location = new System.Drawing.Point(160, 220);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(240, 24);
            this.txtPlate.TabIndex = 12;
            this.txtPlate.Text = "29B1-999.11";
            // 
            // lblPlate
            // 
            this.lblPlate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPlate.Location = new System.Drawing.Point(15, 224);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(140, 18);
            this.lblPlate.TabIndex = 11;
            this.lblPlate.Text = "Biển số đăng ký (*):";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(160, 188);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 23);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Text = "long.lh@student.edu.vn";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblEmail.Location = new System.Drawing.Point(15, 192);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(140, 18);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email nhận tin (*):";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(160, 156);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(240, 23);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.Text = "0988666777";
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPhone.Location = new System.Drawing.Point(15, 160);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(140, 18);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Số điện thoại (*):";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStudentId.Location = new System.Drawing.Point(160, 124);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(240, 23);
            this.txtStudentId.TabIndex = 6;
            this.txtStudentId.Text = "SV202409";
            // 
            // lblStudentId
            // 
            this.lblStudentId.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStudentId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblStudentId.Location = new System.Drawing.Point(15, 128);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(140, 18);
            this.lblStudentId.TabIndex = 5;
            this.lblStudentId.Text = "Mã SV / CCCD (*):";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.Location = new System.Drawing.Point(160, 92);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(240, 23);
            this.txtFullName.TabIndex = 4;
            this.txtFullName.Text = "Lê Hoàng Long";
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFullName.Location = new System.Drawing.Point(15, 96);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(140, 18);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Họ tên sinh viên (*):";
            // 
            // lblQuotaWarning
            // 
            this.lblQuotaWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.lblQuotaWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuotaWarning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblQuotaWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.lblQuotaWarning.Location = new System.Drawing.Point(15, 58);
            this.lblQuotaWarning.Name = "lblQuotaWarning";
            this.lblQuotaWarning.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQuotaWarning.Size = new System.Drawing.Size(385, 26);
            this.lblQuotaWarning.TabIndex = 2;
            this.lblQuotaWarning.Text = "Đang kiểm tra định mức xe của phòng...";
            this.lblQuotaWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboRoom
            // 
            this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(160, 24);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(240, 23);
            this.cboRoom.TabIndex = 1;
            // 
            // lblRoom
            // 
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblRoom.Location = new System.Drawing.Point(15, 28);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(140, 18);
            this.lblRoom.TabIndex = 0;
            this.lblRoom.Text = "Phòng / Căn hộ (*):";
            // 
            // grpRight
            // 
            this.grpRight.BackColor = System.Drawing.Color.White;
            this.grpRight.Controls.Add(this.dgvCards);
            this.grpRight.Controls.Add(this.pnlCardMiniPreview);
            this.grpRight.Controls.Add(this.pnlSearch);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRight.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpRight.Location = new System.Drawing.Point(8, 8);
            this.grpRight.Name = "grpRight";
            this.grpRight.Padding = new System.Windows.Forms.Padding(10);
            this.grpRight.Size = new System.Drawing.Size(616, 684);
            this.grpRight.TabIndex = 0;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "DANH SÁCH THẺ THÁNG ĐANG QUẢN LÝ";
            // 
            // dgvCards
            // 
            this.dgvCards.BackgroundColor = System.Drawing.Color.White;
            this.dgvCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCards.Location = new System.Drawing.Point(10, 66);
            this.dgvCards.MultiSelect = false;
            this.dgvCards.Name = "dgvCards";
            this.dgvCards.ReadOnly = true;
            this.dgvCards.RowHeadersVisible = false;
            this.dgvCards.RowHeadersWidth = 51;
            this.dgvCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCards.Size = new System.Drawing.Size(596, 508);
            this.dgvCards.TabIndex = 1;
            // 
            // pnlCardMiniPreview
            // 
            this.pnlCardMiniPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlCardMiniPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardMiniPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCardMiniPreview.Location = new System.Drawing.Point(10, 574);
            this.pnlCardMiniPreview.Name = "pnlCardMiniPreview";
            this.pnlCardMiniPreview.Padding = new System.Windows.Forms.Padding(8);
            this.pnlCardMiniPreview.Size = new System.Drawing.Size(596, 100);
            this.pnlCardMiniPreview.TabIndex = 2;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.txtSearchGrid);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(10, 27);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(596, 39);
            this.pnlSearch.TabIndex = 0;
            // 
            // txtSearchGrid
            // 
            this.txtSearchGrid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchGrid.Location = new System.Drawing.Point(85, 8);
            this.txtSearchGrid.Name = "txtSearchGrid";
            this.txtSearchGrid.Size = new System.Drawing.Size(280, 23);
            this.txtSearchGrid.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSearch.Location = new System.Drawing.Point(8, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Lọc nhanh:";
            // 
            // ucResidentMonthly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.split);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucResidentMonthly";
            this.Size = new System.Drawing.Size(1100, 700);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.grpLeft.ResumeLayout(false);
            this.grpLeft.PerformLayout();
            this.grpEmail.ResumeLayout(false);
            this.grpRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label lblQuotaWarning;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cboVehicleType;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cboPlan;
        private System.Windows.Forms.Label lblFixedSlot;
        private System.Windows.Forms.ComboBox cboFixedSlot;
        private System.Windows.Forms.Label lblFeeSummary;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnReissue;
        private System.Windows.Forms.GroupBox grpEmail;
        private System.Windows.Forms.Button btnSendBulkEmail;
        private System.Windows.Forms.ProgressBar progEmail;
        private System.Windows.Forms.Label lblEmailStatus;
        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchGrid;
        private System.Windows.Forms.DataGridView dgvCards;
        private System.Windows.Forms.Panel pnlCardMiniPreview;
    }
}
