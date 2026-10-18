namespace SmartParking.UI.UserControls
{
    partial class ucGateControl
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
            this.pnlLedBanner = new System.Windows.Forms.Panel();
            this.lblLedMessage = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpIn = new System.Windows.Forms.GroupBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.txtQrCardIn = new System.Windows.Forms.TextBox();
            this.lblQrCardIn = new System.Windows.Forms.Label();
            this.cboSuggestedSlot = new System.Windows.Forms.ComboBox();
            this.lblSuggestedSlot = new System.Windows.Forms.Label();
            this.chkChargingIn = new System.Windows.Forms.CheckBox();
            this.cboVehicleTypeIn = new System.Windows.Forms.ComboBox();
            this.lblVehicleTypeIn = new System.Windows.Forms.Label();
            this.txtPlateIn = new System.Windows.Forms.TextBox();
            this.lblPlateIn = new System.Windows.Forms.Label();
            this.btnScanQrIn = new System.Windows.Forms.Button();
            this.btnSnapIn = new System.Windows.Forms.Button();
            this.picCamIn = new System.Windows.Forms.PictureBox();
            this.grpOut = new System.Windows.Forms.GroupBox();
            this.btnLostTicket = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.pnlAmount = new System.Windows.Forms.Panel();
            this.lblBigAmount = new System.Windows.Forms.Label();
            this.lblAmountSub = new System.Windows.Forms.Label();
            this.lblCalcDetailOut = new System.Windows.Forms.Label();
            this.lblCalcTitle = new System.Windows.Forms.Label();
            this.lblDurationOut = new System.Windows.Forms.Label();
            this.lblDurTitle = new System.Windows.Forms.Label();
            this.picCamOut = new System.Windows.Forms.PictureBox();
            this.lblCurrentCamOut = new System.Windows.Forms.Label();
            this.picInCompare = new System.Windows.Forms.PictureBox();
            this.lblCompare = new System.Windows.Forms.Label();
            this.btnFindSessionOut = new System.Windows.Forms.Button();
            this.txtSearchOut = new System.Windows.Forms.TextBox();
            this.lblSearchOut = new System.Windows.Forms.Label();
            this.pnlLedBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamIn)).BeginInit();
            this.grpOut.SuspendLayout();
            this.pnlAmount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLedBanner
            // 
            this.pnlLedBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlLedBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLedBanner.Controls.Add(this.lblLedMessage);
            this.pnlLedBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLedBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlLedBanner.Name = "pnlLedBanner";
            this.pnlLedBanner.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlLedBanner.Size = new System.Drawing.Size(1000, 48);
            this.pnlLedBanner.TabIndex = 0;
            // 
            // lblLedMessage
            // 
            this.lblLedMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLedMessage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLedMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblLedMessage.Location = new System.Drawing.Point(10, 8);
            this.lblLedMessage.Name = "lblLedMessage";
            this.lblLedMessage.Size = new System.Drawing.Size(978, 30);
            this.lblLedMessage.TabIndex = 0;
            this.lblLedMessage.Text = "● CỔNG SẴN SÀNG - MỜI XE VÀO / RA";
            this.lblLedMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 48);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.splitContainer.Panel1.Controls.Add(this.grpIn);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.splitContainer.Panel2.Controls.Add(this.grpOut);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer.Size = new System.Drawing.Size(1000, 652);
            this.splitContainer.SplitterDistance = 495;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 1;
            // 
            // grpIn
            // 
            this.grpIn.BackColor = System.Drawing.Color.White;
            this.grpIn.Controls.Add(this.btnCheckIn);
            this.grpIn.Controls.Add(this.txtQrCardIn);
            this.grpIn.Controls.Add(this.lblQrCardIn);
            this.grpIn.Controls.Add(this.cboSuggestedSlot);
            this.grpIn.Controls.Add(this.lblSuggestedSlot);
            this.grpIn.Controls.Add(this.chkChargingIn);
            this.grpIn.Controls.Add(this.cboVehicleTypeIn);
            this.grpIn.Controls.Add(this.lblVehicleTypeIn);
            this.grpIn.Controls.Add(this.txtPlateIn);
            this.grpIn.Controls.Add(this.lblPlateIn);
            this.grpIn.Controls.Add(this.btnScanQrIn);
            this.grpIn.Controls.Add(this.btnSnapIn);
            this.grpIn.Controls.Add(this.picCamIn);
            this.grpIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpIn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpIn.Location = new System.Drawing.Point(8, 8);
            this.grpIn.Name = "grpIn";
            this.grpIn.Padding = new System.Windows.Forms.Padding(12);
            this.grpIn.Size = new System.Drawing.Size(479, 636);
            this.grpIn.TabIndex = 0;
            this.grpIn.TabStop = false;
            this.grpIn.Text = "LÀN 1: CỔNG VÀO (CHECK-IN)";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(15, 425);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(380, 42);
            this.btnCheckIn.TabIndex = 12;
            this.btnCheckIn.Text = "CHO XE VÀO & MỞ CỔNG";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            // 
            // txtQrCardIn
            // 
            this.txtQrCardIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQrCardIn.Location = new System.Drawing.Point(150, 381);
            this.txtQrCardIn.Name = "txtQrCardIn";
            this.txtQrCardIn.Size = new System.Drawing.Size(245, 23);
            this.txtQrCardIn.TabIndex = 11;
            // 
            // lblQrCardIn
            // 
            this.lblQrCardIn.AutoSize = true;
            this.lblQrCardIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQrCardIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblQrCardIn.Location = new System.Drawing.Point(15, 385);
            this.lblQrCardIn.Name = "lblQrCardIn";
            this.lblQrCardIn.Size = new System.Drawing.Size(111, 15);
            this.lblQrCardIn.TabIndex = 10;
            this.lblQrCardIn.Text = "Mã thẻ tháng / QR:";
            // 
            // cboSuggestedSlot
            // 
            this.cboSuggestedSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuggestedSlot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboSuggestedSlot.FormattingEnabled = true;
            this.cboSuggestedSlot.Location = new System.Drawing.Point(150, 346);
            this.cboSuggestedSlot.Name = "cboSuggestedSlot";
            this.cboSuggestedSlot.Size = new System.Drawing.Size(245, 23);
            this.cboSuggestedSlot.TabIndex = 9;
            // 
            // lblSuggestedSlot
            // 
            this.lblSuggestedSlot.AutoSize = true;
            this.lblSuggestedSlot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSuggestedSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSuggestedSlot.Location = new System.Drawing.Point(15, 350);
            this.lblSuggestedSlot.Name = "lblSuggestedSlot";
            this.lblSuggestedSlot.Size = new System.Drawing.Size(117, 15);
            this.lblSuggestedSlot.TabIndex = 8;
            this.lblSuggestedSlot.Text = "Vị trí ô đỗ gợi ý (*):";
            // 
            // chkChargingIn
            // 
            this.chkChargingIn.AutoSize = true;
            this.chkChargingIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkChargingIn.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.chkChargingIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.chkChargingIn.Location = new System.Drawing.Point(150, 320);
            this.chkChargingIn.Name = "chkChargingIn";
            this.chkChargingIn.Size = new System.Drawing.Size(227, 19);
            this.chkChargingIn.TabIndex = 7;
            this.chkChargingIn.Text = "Cần cắm sạc điện tại trụ (Có phụ thu)";
            this.chkChargingIn.UseVisualStyleBackColor = true;
            // 
            // cboVehicleTypeIn
            // 
            this.cboVehicleTypeIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleTypeIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboVehicleTypeIn.FormattingEnabled = true;
            this.cboVehicleTypeIn.Location = new System.Drawing.Point(150, 286);
            this.cboVehicleTypeIn.Name = "cboVehicleTypeIn";
            this.cboVehicleTypeIn.Size = new System.Drawing.Size(245, 23);
            this.cboVehicleTypeIn.TabIndex = 6;
            // 
            // lblVehicleTypeIn
            // 
            this.lblVehicleTypeIn.AutoSize = true;
            this.lblVehicleTypeIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVehicleTypeIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblVehicleTypeIn.Location = new System.Drawing.Point(15, 290);
            this.lblVehicleTypeIn.Name = "lblVehicleTypeIn";
            this.lblVehicleTypeIn.Size = new System.Drawing.Size(103, 15);
            this.lblVehicleTypeIn.TabIndex = 5;
            this.lblVehicleTypeIn.Text = "Loại phương tiện:";
            // 
            // txtPlateIn
            // 
            this.txtPlateIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlateIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtPlateIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtPlateIn.Location = new System.Drawing.Point(150, 251);
            this.txtPlateIn.Name = "txtPlateIn";
            this.txtPlateIn.Size = new System.Drawing.Size(245, 27);
            this.txtPlateIn.TabIndex = 4;
            this.txtPlateIn.Text = "29B1-555.66";
            // 
            // lblPlateIn
            // 
            this.lblPlateIn.AutoSize = true;
            this.lblPlateIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlateIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPlateIn.Location = new System.Drawing.Point(15, 255);
            this.lblPlateIn.Name = "lblPlateIn";
            this.lblPlateIn.Size = new System.Drawing.Size(126, 15);
            this.lblPlateIn.TabIndex = 3;
            this.lblPlateIn.Text = "Biển số xe nhận diện:";
            // 
            // btnScanQrIn
            // 
            this.btnScanQrIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnScanQrIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScanQrIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnScanQrIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanQrIn.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnScanQrIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnScanQrIn.Location = new System.Drawing.Point(210, 212);
            this.btnScanQrIn.Name = "btnScanQrIn";
            this.btnScanQrIn.Size = new System.Drawing.Size(185, 30);
            this.btnScanQrIn.TabIndex = 2;
            this.btnScanQrIn.Text = "Quẹt Thẻ Nhanh";
            this.btnScanQrIn.UseVisualStyleBackColor = false;
            // 
            // btnSnapIn
            // 
            this.btnSnapIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSnapIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSnapIn.FlatAppearance.BorderSize = 0;
            this.btnSnapIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapIn.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSnapIn.ForeColor = System.Drawing.Color.White;
            this.btnSnapIn.Location = new System.Drawing.Point(15, 212);
            this.btnSnapIn.Name = "btnSnapIn";
            this.btnSnapIn.Size = new System.Drawing.Size(185, 30);
            this.btnSnapIn.TabIndex = 1;
            this.btnSnapIn.Text = "📷 Chụp Camera";
            this.btnSnapIn.UseVisualStyleBackColor = false;
            // 
            // picCamIn
            // 
            this.picCamIn.BackColor = System.Drawing.Color.Black;
            this.picCamIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamIn.Location = new System.Drawing.Point(15, 26);
            this.picCamIn.Name = "picCamIn";
            this.picCamIn.Size = new System.Drawing.Size(380, 180);
            this.picCamIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamIn.TabIndex = 0;
            this.picCamIn.TabStop = false;
            // 
            // grpOut
            // 
            this.grpOut.BackColor = System.Drawing.Color.White;
            this.grpOut.Controls.Add(this.btnLostTicket);
            this.grpOut.Controls.Add(this.btnCheckOut);
            this.grpOut.Controls.Add(this.pnlAmount);
            this.grpOut.Controls.Add(this.lblCalcDetailOut);
            this.grpOut.Controls.Add(this.lblCalcTitle);
            this.grpOut.Controls.Add(this.lblDurationOut);
            this.grpOut.Controls.Add(this.lblDurTitle);
            this.grpOut.Controls.Add(this.picCamOut);
            this.grpOut.Controls.Add(this.lblCurrentCamOut);
            this.grpOut.Controls.Add(this.picInCompare);
            this.grpOut.Controls.Add(this.lblCompare);
            this.grpOut.Controls.Add(this.btnFindSessionOut);
            this.grpOut.Controls.Add(this.txtSearchOut);
            this.grpOut.Controls.Add(this.lblSearchOut);
            this.grpOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOut.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpOut.Location = new System.Drawing.Point(8, 8);
            this.grpOut.Name = "grpOut";
            this.grpOut.Padding = new System.Windows.Forms.Padding(12);
            this.grpOut.Size = new System.Drawing.Size(479, 636);
            this.grpOut.TabIndex = 0;
            this.grpOut.TabStop = false;
            this.grpOut.Text = "LÀN 2: CỔNG RA (CHECK-OUT & THU TIỀN)";
            // 
            // btnLostTicket
            // 
            this.btnLostTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnLostTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLostTicket.FlatAppearance.BorderSize = 0;
            this.btnLostTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLostTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLostTicket.ForeColor = System.Drawing.Color.White;
            this.btnLostTicket.Location = new System.Drawing.Point(275, 360);
            this.btnLostTicket.Name = "btnLostTicket";
            this.btnLostTicket.Size = new System.Drawing.Size(120, 42);
            this.btnLostTicket.TabIndex = 13;
            this.btnLostTicket.Text = "🚨 Mất Vé";
            this.btnLostTicket.UseVisualStyleBackColor = false;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(15, 360);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(250, 42);
            this.btnCheckOut.TabIndex = 12;
            this.btnCheckOut.Text = "THU TIỀN & MỞ CỔNG";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            // 
            // pnlAmount
            // 
            this.pnlAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.pnlAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAmount.Controls.Add(this.lblBigAmount);
            this.pnlAmount.Controls.Add(this.lblAmountSub);
            this.pnlAmount.Location = new System.Drawing.Point(15, 295);
            this.pnlAmount.Name = "pnlAmount";
            this.pnlAmount.Size = new System.Drawing.Size(380, 52);
            this.pnlAmount.TabIndex = 11;
            // 
            // lblBigAmount
            // 
            this.lblBigAmount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBigAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblBigAmount.Location = new System.Drawing.Point(120, 8);
            this.lblBigAmount.Name = "lblBigAmount";
            this.lblBigAmount.Size = new System.Drawing.Size(250, 34);
            this.lblBigAmount.TabIndex = 1;
            this.lblBigAmount.Text = "0 VNĐ";
            this.lblBigAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmountSub
            // 
            this.lblAmountSub.AutoSize = true;
            this.lblAmountSub.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAmountSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblAmountSub.Location = new System.Drawing.Point(10, 18);
            this.lblAmountSub.Name = "lblAmountSub";
            this.lblAmountSub.Size = new System.Drawing.Size(81, 15);
            this.lblAmountSub.TabIndex = 0;
            this.lblAmountSub.Text = "SỐ TIỀN THU:";
            // 
            // lblCalcDetailOut
            // 
            this.lblCalcDetailOut.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCalcDetailOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblCalcDetailOut.Location = new System.Drawing.Point(130, 245);
            this.lblCalcDetailOut.Name = "lblCalcDetailOut";
            this.lblCalcDetailOut.Size = new System.Drawing.Size(265, 40);
            this.lblCalcDetailOut.TabIndex = 10;
            this.lblCalcDetailOut.Text = "Chưa quét xe";
            // 
            // lblCalcTitle
            // 
            this.lblCalcTitle.AutoSize = true;
            this.lblCalcTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCalcTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblCalcTitle.Location = new System.Drawing.Point(15, 245);
            this.lblCalcTitle.Name = "lblCalcTitle";
            this.lblCalcTitle.Size = new System.Drawing.Size(95, 15);
            this.lblCalcTitle.TabIndex = 9;
            this.lblCalcTitle.Text = "Chi tiết tính phí:";
            // 
            // lblDurationOut
            // 
            this.lblDurationOut.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDurationOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblDurationOut.Location = new System.Drawing.Point(130, 215);
            this.lblDurationOut.Name = "lblDurationOut";
            this.lblDurationOut.Size = new System.Drawing.Size(265, 20);
            this.lblDurationOut.TabIndex = 8;
            this.lblDurationOut.Text = "Chưa chọn xe";
            // 
            // lblDurTitle
            // 
            this.lblDurTitle.AutoSize = true;
            this.lblDurTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDurTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblDurTitle.Location = new System.Drawing.Point(15, 215);
            this.lblDurTitle.Name = "lblDurTitle";
            this.lblDurTitle.Size = new System.Drawing.Size(90, 15);
            this.lblDurTitle.TabIndex = 7;
            this.lblDurTitle.Text = "Thời lượng gửi:";
            // 
            // picCamOut
            // 
            this.picCamOut.BackColor = System.Drawing.Color.Black;
            this.picCamOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamOut.Location = new System.Drawing.Point(210, 80);
            this.picCamOut.Name = "picCamOut";
            this.picCamOut.Size = new System.Drawing.Size(185, 125);
            this.picCamOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamOut.TabIndex = 6;
            this.picCamOut.TabStop = false;
            // 
            // lblCurrentCamOut
            // 
            this.lblCurrentCamOut.AutoSize = true;
            this.lblCurrentCamOut.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCurrentCamOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCurrentCamOut.Location = new System.Drawing.Point(210, 60);
            this.lblCurrentCamOut.Name = "lblCurrentCamOut";
            this.lblCurrentCamOut.Size = new System.Drawing.Size(126, 13);
            this.lblCurrentCamOut.TabIndex = 5;
            this.lblCurrentCamOut.Text = "CAMERA RA HIỆN TẠI:";
            // 
            // picInCompare
            // 
            this.picInCompare.BackColor = System.Drawing.Color.Black;
            this.picInCompare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picInCompare.Location = new System.Drawing.Point(15, 80);
            this.picInCompare.Name = "picInCompare";
            this.picInCompare.Size = new System.Drawing.Size(185, 125);
            this.picInCompare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInCompare.TabIndex = 4;
            this.picInCompare.TabStop = false;
            // 
            // lblCompare
            // 
            this.lblCompare.AutoSize = true;
            this.lblCompare.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCompare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCompare.Location = new System.Drawing.Point(15, 60);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(127, 13);
            this.lblCompare.TabIndex = 3;
            this.lblCompare.Text = "ẢNH CAMERA LÚC VÀO:";
            // 
            // btnFindSessionOut
            // 
            this.btnFindSessionOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnFindSessionOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindSessionOut.FlatAppearance.BorderSize = 0;
            this.btnFindSessionOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindSessionOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFindSessionOut.ForeColor = System.Drawing.Color.White;
            this.btnFindSessionOut.Location = new System.Drawing.Point(305, 24);
            this.btnFindSessionOut.Name = "btnFindSessionOut";
            this.btnFindSessionOut.Size = new System.Drawing.Size(90, 28);
            this.btnFindSessionOut.TabIndex = 2;
            this.btnFindSessionOut.Text = "🔍 Quét Ra";
            this.btnFindSessionOut.UseVisualStyleBackColor = false;
            // 
            // txtSearchOut
            // 
            this.txtSearchOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtSearchOut.Location = new System.Drawing.Point(150, 25);
            this.txtSearchOut.Name = "txtSearchOut";
            this.txtSearchOut.Size = new System.Drawing.Size(145, 25);
            this.txtSearchOut.TabIndex = 1;
            this.txtSearchOut.Text = "29B1-555.66";
            // 
            // lblSearchOut
            // 
            this.lblSearchOut.AutoSize = true;
            this.lblSearchOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSearchOut.Location = new System.Drawing.Point(15, 28);
            this.lblSearchOut.Name = "lblSearchOut";
            this.lblSearchOut.Size = new System.Drawing.Size(117, 15);
            this.lblSearchOut.TabIndex = 0;
            this.lblSearchOut.Text = "Biển số / Mã vé ra:";
            // 
            // ucGateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlLedBanner);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucGateControl";
            this.Size = new System.Drawing.Size(1000, 700);
            this.pnlLedBanner.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpIn.ResumeLayout(false);
            this.grpIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamIn)).EndInit();
            this.grpOut.ResumeLayout(false);
            this.grpOut.PerformLayout();
            this.pnlAmount.ResumeLayout(false);
            this.pnlAmount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInCompare)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlLedBanner;
        private System.Windows.Forms.Label lblLedMessage;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpIn;
        private System.Windows.Forms.PictureBox picCamIn;
        private System.Windows.Forms.Button btnSnapIn;
        private System.Windows.Forms.Button btnScanQrIn;
        private System.Windows.Forms.Label lblPlateIn;
        private System.Windows.Forms.TextBox txtPlateIn;
        private System.Windows.Forms.Label lblVehicleTypeIn;
        private System.Windows.Forms.ComboBox cboVehicleTypeIn;
        private System.Windows.Forms.CheckBox chkChargingIn;
        private System.Windows.Forms.Label lblSuggestedSlot;
        private System.Windows.Forms.ComboBox cboSuggestedSlot;
        private System.Windows.Forms.Label lblQrCardIn;
        private System.Windows.Forms.TextBox txtQrCardIn;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.GroupBox grpOut;
        private System.Windows.Forms.Label lblSearchOut;
        private System.Windows.Forms.TextBox txtSearchOut;
        private System.Windows.Forms.Button btnFindSessionOut;
        private System.Windows.Forms.Label lblCompare;
        private System.Windows.Forms.PictureBox picInCompare;
        private System.Windows.Forms.Label lblCurrentCamOut;
        private System.Windows.Forms.PictureBox picCamOut;
        private System.Windows.Forms.Label lblDurTitle;
        private System.Windows.Forms.Label lblDurationOut;
        private System.Windows.Forms.Label lblCalcTitle;
        private System.Windows.Forms.Label lblCalcDetailOut;
        private System.Windows.Forms.Panel pnlAmount;
        private System.Windows.Forms.Label lblAmountSub;
        private System.Windows.Forms.Label lblBigAmount;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnLostTicket;
    }
}
