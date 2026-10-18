namespace SmartParking.UI.Forms
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHandover = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPricing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMapItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResidentItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDashItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbanItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.toolBtnMap = new System.Windows.Forms.ToolStripButton();
            this.toolBtnGate = new System.Windows.Forms.ToolStripButton();
            this.toolBtnResident = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDash = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAban = new System.Windows.Forms.ToolStripButton();
            this.toolBtnHist = new System.Windows.Forms.ToolStripButton();
            this.toolSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnHandover = new System.Windows.Forms.ToolStripButton();
            this.toolBtnReload = new System.Windows.Forms.ToolStripButton();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.statusLblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusLblDb = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblVersionBadge = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblSecOperate = new System.Windows.Forms.Label();
            this.btnNavMap = new System.Windows.Forms.Button();
            this.btnNavGate = new System.Windows.Forms.Button();
            this.btnNavResident = new System.Windows.Forms.Button();
            this.lblSecReports = new System.Windows.Forms.Label();
            this.btnNavDash = new System.Windows.Forms.Button();
            this.btnNavAbandoned = new System.Windows.Forms.Button();
            this.btnNavHist = new System.Windows.Forms.Button();
            this.lblSecAdmin = new System.Windows.Forms.Label();
            this.btnNavPrice = new System.Windows.Forms.Button();
            this.btnNavStaff = new System.Windows.Forms.Button();
            this.pnlBottomUser = new System.Windows.Forms.Panel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblUName = new System.Windows.Forms.Label();
            this.lblURole = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.lblModuleSubtitle = new System.Windows.Forms.Label();
            this.pnlOnlineBadge = new System.Windows.Forms.Panel();
            this.lblOnline = new System.Windows.Forms.Label();
            this.btnHandover = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlNavList = new System.Windows.Forms.Panel();
            this.pnlHeaderRight = new System.Windows.Forms.Panel();
            this.mnuMain.SuspendLayout();
            this.toolMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlNavList.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlBottomUser.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlHeaderRight.SuspendLayout();
            this.pnlOnlineBadge.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.Color.White;
            this.mnuMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuOperate,
            this.mnuReports,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.mnuMain.Size = new System.Drawing.Size(1364, 29);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHandover,
            this.mnuPricing,
            this.mnuStaff,
            this.mnuSep1,
            this.mnuLogout,
            this.mnuExit});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(95, 21);
            this.mnuSystem.Text = "Hệ Thống (&H)";
            // 
            // mnuHandover
            // 
            this.mnuHandover.Name = "mnuHandover";
            this.mnuHandover.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuHandover.Size = new System.Drawing.Size(301, 22);
            this.mnuHandover.Text = "✍️ Bàn giao ca trực (&B)...";
            // 
            // mnuPricing
            // 
            this.mnuPricing.Name = "mnuPricing";
            this.mnuPricing.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPricing.Size = new System.Drawing.Size(301, 22);
            this.mnuPricing.Text = "⚙️ Cấu hình biểu phí động (&P)...";
            // 
            // mnuStaff
            // 
            this.mnuStaff.Name = "mnuStaff";
            this.mnuStaff.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mnuStaff.Size = new System.Drawing.Size(301, 22);
            this.mnuStaff.Text = "🛡️ Quản lý tài khoản nhân viên (&U)...";
            // 
            // mnuSep1
            // 
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Size = new System.Drawing.Size(298, 6);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuLogout.Size = new System.Drawing.Size(301, 22);
            this.mnuLogout.Text = "🚪 Đăng xuất (&L)...";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(301, 22);
            this.mnuExit.Text = "❌ Thoát chương trình (&X)";
            // 
            // mnuOperate
            // 
            this.mnuOperate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMapItem,
            this.mnuGateItem,
            this.mnuResidentItem});
            this.mnuOperate.Name = "mnuOperate";
            this.mnuOperate.Size = new System.Drawing.Size(91, 21);
            this.mnuOperate.Text = "Vận Hành (&V)";
            // 
            // mnuMapItem
            // 
            this.mnuMapItem.Name = "mnuMapItem";
            this.mnuMapItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuMapItem.Size = new System.Drawing.Size(242, 22);
            this.mnuMapItem.Text = "🗺️ Sơ đồ bãi xe 5 màu (&M)";
            // 
            // mnuGateItem
            // 
            this.mnuGateItem.Name = "mnuGateItem";
            this.mnuGateItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuGateItem.Size = new System.Drawing.Size(242, 22);
            this.mnuGateItem.Text = "🚦 Kiểm soát cổng Vào/Ra (&G)";
            // 
            // mnuResidentItem
            // 
            this.mnuResidentItem.Name = "mnuResidentItem";
            this.mnuResidentItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuResidentItem.Size = new System.Drawing.Size(242, 22);
            this.mnuResidentItem.Text = "👥 Cư dân & Vé tháng KTX (&R)";
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDashItem,
            this.mnuAbanItem,
            this.mnuHistItem});
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(89, 21);
            this.mnuReports.Text = "Báo Cáo (&B)";
            // 
            // mnuDashItem
            // 
            this.mnuDashItem.Name = "mnuDashItem";
            this.mnuDashItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuDashItem.Size = new System.Drawing.Size(268, 22);
            this.mnuDashItem.Text = "📊 Dashboard phân tích KPI (&D)";
            // 
            // mnuAbanItem
            // 
            this.mnuAbanItem.Name = "mnuAbanItem";
            this.mnuAbanItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuAbanItem.Size = new System.Drawing.Size(268, 22);
            this.mnuAbanItem.Text = "⚠️ Cảnh báo xe bỏ quên >72h (&A)";
            // 
            // mnuHistItem
            // 
            this.mnuHistItem.Name = "mnuHistItem";
            this.mnuHistItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuHistItem.Size = new System.Drawing.Size(268, 22);
            this.mnuHistItem.Text = "📜 Lịch sử & Xuất Excel (&H)";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.mnuGuide});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(88, 21);
            this.mnuHelp.Text = "Trợ Giúp (&T)";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(359, 22);
            this.mnuAbout.Text = "ℹ️ Thông tin phần mềm SmartParking Pro (&A)...";
            // 
            // mnuGuide
            // 
            this.mnuGuide.Name = "mnuGuide";
            this.mnuGuide.Size = new System.Drawing.Size(359, 22);
            this.mnuGuide.Text = "📖 Hướng dẫn đồ án môn Lập Trình Trực Quan (&G)...";
            // 
            // toolMain
            // 
            this.toolMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.toolMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnMap,
            this.toolBtnGate,
            this.toolBtnResident,
            this.toolBtnDash,
            this.toolBtnAban,
            this.toolBtnHist,
            this.toolSep1,
            this.toolBtnHandover,
            this.toolBtnReload});
            this.toolMain.Location = new System.Drawing.Point(0, 29);
            this.toolMain.Name = "toolMain";
            this.toolMain.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.toolMain.Size = new System.Drawing.Size(1364, 31);
            this.toolMain.TabIndex = 1;
            this.toolMain.Text = "toolStrip1";
            // 
            // toolBtnMap
            // 
            this.toolBtnMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnMap.Name = "toolBtnMap";
            this.toolBtnMap.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnMap.Size = new System.Drawing.Size(117, 20);
            this.toolBtnMap.Text = "🗺️ Sơ Đồ Bãi Xe";
            // 
            // toolBtnGate
            // 
            this.toolBtnGate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnGate.Name = "toolBtnGate";
            this.toolBtnGate.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnGate.Size = new System.Drawing.Size(134, 20);
            this.toolBtnGate.Text = "🚦 Kiểm Soát Cổng";
            // 
            // toolBtnResident
            // 
            this.toolBtnResident.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnResident.Name = "toolBtnResident";
            this.toolBtnResident.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnResident.Size = new System.Drawing.Size(123, 20);
            this.toolBtnResident.Text = "👥 Vé Tháng KTX";
            // 
            // toolBtnDash
            // 
            this.toolBtnDash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnDash.Name = "toolBtnDash";
            this.toolBtnDash.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnDash.Size = new System.Drawing.Size(125, 20);
            this.toolBtnDash.Text = "📊 Dashboard KPI";
            // 
            // toolBtnAban
            // 
            this.toolBtnAban.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnAban.Name = "toolBtnAban";
            this.toolBtnAban.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnAban.Size = new System.Drawing.Size(116, 20);
            this.toolBtnAban.Text = "⚠️ Xe Quá Hạn";
            // 
            // toolBtnHist
            // 
            this.toolBtnHist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnHist.Name = "toolBtnHist";
            this.toolBtnHist.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnHist.Size = new System.Drawing.Size(125, 20);
            this.toolBtnHist.Text = "📜 Lịch Sử && Excel";
            // 
            // toolSep1
            // 
            this.toolSep1.Name = "toolSep1";
            this.toolSep1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolBtnHandover
            // 
            this.toolBtnHandover.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnHandover.Name = "toolBtnHandover";
            this.toolBtnHandover.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnHandover.Size = new System.Drawing.Size(94, 20);
            this.toolBtnHandover.Text = "✍️ Giao Ca";
            // 
            // toolBtnReload
            // 
            this.toolBtnReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.toolBtnReload.Name = "toolBtnReload";
            this.toolBtnReload.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolBtnReload.Size = new System.Drawing.Size(91, 20);
            this.toolBtnReload.Text = "🔄 Tải Lại";
            // 
            // statusMain
            // 
            this.statusMain.BackColor = System.Drawing.Color.White;
            this.statusMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblState,
            this.statusSep1,
            this.statusLblDb,
            this.statusSep2,
            this.statusLblUser,
            this.statusLblTime});
            this.statusMain.Location = new System.Drawing.Point(0, 819);
            this.statusMain.Name = "statusMain";
            this.statusMain.Padding = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.statusMain.Size = new System.Drawing.Size(1364, 25);
            this.statusMain.TabIndex = 2;
            this.statusMain.Text = "statusStrip1";
            // 
            // statusLblState
            // 
            this.statusLblState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusLblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.statusLblState.Name = "statusLblState";
            this.statusLblState.Size = new System.Drawing.Size(126, 19);
            this.statusLblState.Text = "🟢 Sẵn sàng phục vụ";
            // 
            // statusSep1
            // 
            this.statusSep1.Name = "statusSep1";
            this.statusSep1.Size = new System.Drawing.Size(6, 19);
            // 
            // statusLblDb
            // 
            this.statusLblDb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.statusLblDb.Name = "statusLblDb";
            this.statusLblDb.Size = new System.Drawing.Size(248, 19);
            this.statusLblDb.Text = "💾 SQL Server: Đã kết nối (SmartParkingDB)";
            // 
            // statusSep2
            // 
            this.statusSep2.Name = "statusSep2";
            this.statusSep2.Size = new System.Drawing.Size(6, 19);
            // 
            // statusLblUser
            // 
            this.statusLblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusLblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.statusLblUser.Name = "statusLblUser";
            this.statusLblUser.Size = new System.Drawing.Size(200, 19);
            this.statusLblUser.Text = "👤 Nhân viên: Quản Trị Viên (Admin)";
            // 
            // statusLblTime
            // 
            this.statusLblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.statusLblTime.Name = "statusLblTime";
            this.statusLblTime.Size = new System.Drawing.Size(760, 19);
            this.statusLblTime.Spring = true;
            this.statusLblTime.Text = "00:00:00  01/01/2026";
            this.statusLblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.pnlNavList);
            this.pnlSidebar.Controls.Add(this.pnlBottomUser);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(265, 759);
            this.pnlSidebar.TabIndex = 3;
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlBrand.Controls.Add(this.lblBrandSub);
            this.pnlBrand.Controls.Add(this.lblVersionBadge);
            this.pnlBrand.Controls.Add(this.lblLogo);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Padding = new System.Windows.Forms.Padding(18, 15, 18, 15);
            this.pnlBrand.Size = new System.Drawing.Size(265, 85);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(16, 18);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(161, 23);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🅿️ SMARTPARKING";
            // 
            // lblVersionBadge
            // 
            this.lblVersionBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblVersionBadge.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblVersionBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblVersionBadge.Location = new System.Drawing.Point(190, 19);
            this.lblVersionBadge.Name = "lblVersionBadge";
            this.lblVersionBadge.Size = new System.Drawing.Size(58, 20);
            this.lblVersionBadge.TabIndex = 1;
            this.lblVersionBadge.Text = "PRO v2.0";
            this.lblVersionBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblBrandSub.Location = new System.Drawing.Point(18, 48);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(211, 13);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "Hệ thống quản lý bãi xe KTX & Chung cư";
            // 
            // pnlNavList
            // 
            this.pnlNavList.AutoScroll = true;
            this.pnlNavList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlNavList.Controls.Add(this.btnNavStaff);
            this.pnlNavList.Controls.Add(this.btnNavPrice);
            this.pnlNavList.Controls.Add(this.lblSecAdmin);
            this.pnlNavList.Controls.Add(this.btnNavHist);
            this.pnlNavList.Controls.Add(this.btnNavAbandoned);
            this.pnlNavList.Controls.Add(this.btnNavDash);
            this.pnlNavList.Controls.Add(this.lblSecReports);
            this.pnlNavList.Controls.Add(this.btnNavResident);
            this.pnlNavList.Controls.Add(this.btnNavGate);
            this.pnlNavList.Controls.Add(this.btnNavMap);
            this.pnlNavList.Controls.Add(this.lblSecOperate);
            this.pnlNavList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavList.Location = new System.Drawing.Point(0, 85);
            this.pnlNavList.Name = "pnlNavList";
            this.pnlNavList.Size = new System.Drawing.Size(265, 564);
            this.pnlNavList.TabIndex = 1;
            // 
            // lblSecOperate
            // 
            this.lblSecOperate.AutoSize = true;
            this.lblSecOperate.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSecOperate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSecOperate.Location = new System.Drawing.Point(20, 15);
            this.lblSecOperate.Name = "lblSecOperate";
            this.lblSecOperate.Size = new System.Drawing.Size(107, 12);
            this.lblSecOperate.TabIndex = 1;
            this.lblSecOperate.Text = "VẬN HÀNH BÃI XE";
            // 
            // btnNavMap
            // 
            this.btnNavMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMap.FlatAppearance.BorderSize = 0;
            this.btnNavMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavMap.Location = new System.Drawing.Point(15, 38);
            this.btnNavMap.Name = "btnNavMap";
            this.btnNavMap.Size = new System.Drawing.Size(235, 44);
            this.btnNavMap.TabIndex = 2;
            this.btnNavMap.Text = "  🗺️  Sơ Đồ Bãi Xe (Huân)";
            this.btnNavMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMap.UseVisualStyleBackColor = false;
            // 
            // btnNavGate
            // 
            this.btnNavGate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavGate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavGate.FlatAppearance.BorderSize = 0;
            this.btnNavGate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavGate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavGate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavGate.Location = new System.Drawing.Point(15, 86);
            this.btnNavGate.Name = "btnNavGate";
            this.btnNavGate.Size = new System.Drawing.Size(235, 44);
            this.btnNavGate.TabIndex = 3;
            this.btnNavGate.Text = "  🚦  Kiểm Soát Cổng (Khoa)";
            this.btnNavGate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavGate.UseVisualStyleBackColor = false;
            // 
            // btnNavResident
            // 
            this.btnNavResident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavResident.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavResident.FlatAppearance.BorderSize = 0;
            this.btnNavResident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavResident.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavResident.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavResident.Location = new System.Drawing.Point(15, 134);
            this.btnNavResident.Name = "btnNavResident";
            this.btnNavResident.Size = new System.Drawing.Size(235, 44);
            this.btnNavResident.TabIndex = 4;
            this.btnNavResident.Text = "  👥  Cư Dân & Vé Tháng (Hưng)";
            this.btnNavResident.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavResident.UseVisualStyleBackColor = false;
            // 
            // lblSecReports
            // 
            this.lblSecReports.AutoSize = true;
            this.lblSecReports.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSecReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSecReports.Location = new System.Drawing.Point(20, 188);
            this.lblSecReports.Name = "lblSecReports";
            this.lblSecReports.Size = new System.Drawing.Size(117, 12);
            this.lblSecReports.TabIndex = 5;
            this.lblSecReports.Text = "BÁO CÁO & THỐNG KÊ";
            // 
            // btnNavDash
            // 
            this.btnNavDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavDash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDash.FlatAppearance.BorderSize = 0;
            this.btnNavDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDash.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavDash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavDash.Location = new System.Drawing.Point(15, 211);
            this.btnNavDash.Name = "btnNavDash";
            this.btnNavDash.Size = new System.Drawing.Size(235, 44);
            this.btnNavDash.TabIndex = 6;
            this.btnNavDash.Text = "  📊  Dashboard KPI (Vinh)";
            this.btnNavDash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDash.UseVisualStyleBackColor = false;
            // 
            // btnNavAbandoned
            // 
            this.btnNavAbandoned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavAbandoned.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAbandoned.FlatAppearance.BorderSize = 0;
            this.btnNavAbandoned.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAbandoned.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavAbandoned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavAbandoned.Location = new System.Drawing.Point(15, 259);
            this.btnNavAbandoned.Name = "btnNavAbandoned";
            this.btnNavAbandoned.Size = new System.Drawing.Size(235, 44);
            this.btnNavAbandoned.TabIndex = 7;
            this.btnNavAbandoned.Text = "  ⚠️  Xe Quá Hạn > 72h (Vinh)";
            this.btnNavAbandoned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAbandoned.UseVisualStyleBackColor = false;
            // 
            // btnNavHist
            // 
            this.btnNavHist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHist.FlatAppearance.BorderSize = 0;
            this.btnNavHist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHist.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavHist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavHist.Location = new System.Drawing.Point(15, 307);
            this.btnNavHist.Name = "btnNavHist";
            this.btnNavHist.Size = new System.Drawing.Size(235, 44);
            this.btnNavHist.TabIndex = 8;
            this.btnNavHist.Text = "  📜  Lịch Sử & Excel (Vinh)";
            this.btnNavHist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavHist.UseVisualStyleBackColor = false;
            // 
            // lblSecAdmin
            // 
            this.lblSecAdmin.AutoSize = true;
            this.lblSecAdmin.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSecAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSecAdmin.Location = new System.Drawing.Point(20, 361);
            this.lblSecAdmin.Name = "lblSecAdmin";
            this.lblSecAdmin.Size = new System.Drawing.Size(127, 12);
            this.lblSecAdmin.TabIndex = 9;
            this.lblSecAdmin.Text = "CẤU HÌNH QUẢN TRỊ";
            // 
            // btnNavPrice
            // 
            this.btnNavPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavPrice.FlatAppearance.BorderSize = 0;
            this.btnNavPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavPrice.Location = new System.Drawing.Point(15, 384);
            this.btnNavPrice.Name = "btnNavPrice";
            this.btnNavPrice.Size = new System.Drawing.Size(235, 44);
            this.btnNavPrice.TabIndex = 10;
            this.btnNavPrice.Text = "  ⚙️  Biểu Phí & Luật (Hưng)";
            this.btnNavPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPrice.UseVisualStyleBackColor = false;
            // 
            // btnNavStaff
            // 
            this.btnNavStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStaff.FlatAppearance.BorderSize = 0;
            this.btnNavStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStaff.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnNavStaff.Location = new System.Drawing.Point(15, 432);
            this.btnNavStaff.Name = "btnNavStaff";
            this.btnNavStaff.Size = new System.Drawing.Size(235, 44);
            this.btnNavStaff.TabIndex = 11;
            this.btnNavStaff.Text = "  🛡️  Quản Lý Nhân Viên (Huân)";
            this.btnNavStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStaff.UseVisualStyleBackColor = false;
            // 
            // pnlBottomUser
            // 
            this.pnlBottomUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlBottomUser.Controls.Add(this.btnLogout);
            this.pnlBottomUser.Controls.Add(this.lblURole);
            this.pnlBottomUser.Controls.Add(this.lblUName);
            this.pnlBottomUser.Controls.Add(this.lblAvatar);
            this.pnlBottomUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomUser.Location = new System.Drawing.Point(0, 649);
            this.pnlBottomUser.Name = "pnlBottomUser";
            this.pnlBottomUser.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBottomUser.Size = new System.Drawing.Size(265, 110);
            this.pnlBottomUser.TabIndex = 12;
            // 
            // lblAvatar
            // 
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblAvatar.Location = new System.Drawing.Point(14, 15);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(36, 36);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "👑";
            // 
            // lblUName
            // 
            this.lblUName.AutoEllipsis = true;
            this.lblUName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUName.ForeColor = System.Drawing.Color.White;
            this.lblUName.Location = new System.Drawing.Point(56, 14);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(190, 20);
            this.lblUName.TabIndex = 1;
            this.lblUName.Text = "Quản Trị Viên (Admin)";
            // 
            // lblURole
            // 
            this.lblURole.AutoSize = true;
            this.lblURole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblURole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblURole.Location = new System.Drawing.Point(58, 35);
            this.lblURole.Name = "lblURole";
            this.lblURole.Size = new System.Drawing.Size(117, 13);
            this.lblURole.TabIndex = 2;
            this.lblURole.Text = "● Admin (Trực tuyến)";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnLogout.Location = new System.Drawing.Point(15, 65);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(235, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblModuleSubtitle);
            this.pnlHeader.Controls.Add(this.lblModuleTitle);
            this.pnlHeader.Controls.Add(this.pnlHeaderRight);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(265, 60);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1099, 65);
            this.pnlHeader.TabIndex = 4;
            // 
            // pnlHeaderRight
            // 
            this.pnlHeaderRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderRight.Controls.Add(this.lblClock);
            this.pnlHeaderRight.Controls.Add(this.btnHandover);
            this.pnlHeaderRight.Controls.Add(this.pnlOnlineBadge);
            this.pnlHeaderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHeaderRight.Location = new System.Drawing.Point(645, 0);
            this.pnlHeaderRight.Name = "pnlHeaderRight";
            this.pnlHeaderRight.Size = new System.Drawing.Size(434, 65);
            this.pnlHeaderRight.TabIndex = 2;
            // 
            // pnlOnlineBadge
            // 
            this.pnlOnlineBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.pnlOnlineBadge.Controls.Add(this.lblOnline);
            this.pnlOnlineBadge.Location = new System.Drawing.Point(10, 14);
            this.pnlOnlineBadge.Name = "pnlOnlineBadge";
            this.pnlOnlineBadge.Size = new System.Drawing.Size(110, 36);
            this.pnlOnlineBadge.TabIndex = 0;
            // 
            // lblOnline
            // 
            this.lblOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOnline.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.lblOnline.Location = new System.Drawing.Point(0, 0);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(110, 36);
            this.lblOnline.TabIndex = 0;
            this.lblOnline.Text = "🟢 Trực tuyến";
            this.lblOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHandover
            // 
            this.btnHandover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnHandover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHandover.FlatAppearance.BorderSize = 0;
            this.btnHandover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandover.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHandover.ForeColor = System.Drawing.Color.White;
            this.btnHandover.Location = new System.Drawing.Point(130, 14);
            this.btnHandover.Name = "btnHandover";
            this.btnHandover.Size = new System.Drawing.Size(100, 36);
            this.btnHandover.TabIndex = 1;
            this.btnHandover.Text = "✍️ Giao Ca";
            this.btnHandover.UseVisualStyleBackColor = false;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblClock.Location = new System.Drawing.Point(240, 22);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(171, 19);
            this.lblClock.TabIndex = 2;
            this.lblClock.Text = "00:00:00  01/01/2026";
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.AutoEllipsis = true;
            this.lblModuleTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblModuleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblModuleTitle.Location = new System.Drawing.Point(25, 12);
            this.lblModuleTitle.MaximumSize = new System.Drawing.Size(600, 26);
            this.lblModuleTitle.Name = "lblModuleTitle";
            this.lblModuleTitle.Size = new System.Drawing.Size(600, 25);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "SƠ ĐỒ BÃI XE THỜI GIAN THỰC";
            // 
            // lblModuleSubtitle
            // 
            this.lblModuleSubtitle.AutoEllipsis = true;
            this.lblModuleSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblModuleSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblModuleSubtitle.Location = new System.Drawing.Point(27, 38);
            this.lblModuleSubtitle.MaximumSize = new System.Drawing.Size(600, 20);
            this.lblModuleSubtitle.Name = "lblModuleSubtitle";
            this.lblModuleSubtitle.Size = new System.Drawing.Size(600, 18);
            this.lblModuleSubtitle.TabIndex = 1;
            this.lblModuleSubtitle.Text = "Trực quan hóa 5 màu - Tìm xe chớp nháy & Điều phối vị trí đỗ";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(265, 125);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContent.Size = new System.Drawing.Size(1099, 694);
            this.pnlContent.TabIndex = 5;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1364, 844);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.statusMain);
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(1180, 740);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Bãi Xe Thông Minh KTX & Chung Cư (SmartParking Pro)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlNavList.ResumeLayout(false);
            this.pnlNavList.PerformLayout();
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlBottomUser.ResumeLayout(false);
            this.pnlBottomUser.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeaderRight.ResumeLayout(false);
            this.pnlHeaderRight.PerformLayout();
            this.pnlOnlineBadge.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuHandover;
        private System.Windows.Forms.ToolStripMenuItem mnuPricing;
        private System.Windows.Forms.ToolStripMenuItem mnuStaff;
        private System.Windows.Forms.ToolStripSeparator mnuSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuOperate;
        private System.Windows.Forms.ToolStripMenuItem mnuMapItem;
        private System.Windows.Forms.ToolStripMenuItem mnuGateItem;
        private System.Windows.Forms.ToolStripMenuItem mnuResidentItem;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuDashItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbanItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHistItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuGuide;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton toolBtnMap;
        private System.Windows.Forms.ToolStripButton toolBtnGate;
        private System.Windows.Forms.ToolStripButton toolBtnResident;
        private System.Windows.Forms.ToolStripButton toolBtnDash;
        private System.Windows.Forms.ToolStripButton toolBtnAban;
        private System.Windows.Forms.ToolStripButton toolBtnHist;
        private System.Windows.Forms.ToolStripSeparator toolSep1;
        private System.Windows.Forms.ToolStripButton toolBtnHandover;
        private System.Windows.Forms.ToolStripButton toolBtnReload;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel statusLblState;
        private System.Windows.Forms.ToolStripSeparator statusSep1;
        private System.Windows.Forms.ToolStripStatusLabel statusLblDb;
        private System.Windows.Forms.ToolStripSeparator statusSep2;
        private System.Windows.Forms.ToolStripStatusLabel statusLblUser;
        private System.Windows.Forms.ToolStripStatusLabel statusLblTime;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblVersionBadge;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Label lblSecOperate;
        private System.Windows.Forms.Button btnNavMap;
        private System.Windows.Forms.Button btnNavGate;
        private System.Windows.Forms.Button btnNavResident;
        private System.Windows.Forms.Label lblSecReports;
        private System.Windows.Forms.Button btnNavDash;
        private System.Windows.Forms.Button btnNavAbandoned;
        private System.Windows.Forms.Button btnNavHist;
        private System.Windows.Forms.Label lblSecAdmin;
        private System.Windows.Forms.Button btnNavPrice;
        private System.Windows.Forms.Button btnNavStaff;
        private System.Windows.Forms.Panel pnlBottomUser;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Label lblURole;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.Label lblModuleSubtitle;
        private System.Windows.Forms.Panel pnlOnlineBadge;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.Button btnHandover;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel pnlNavList;
        private System.Windows.Forms.Panel pnlHeaderRight;
    }
}
