namespace SmartParking.UI.Forms
{
    partial class frmShiftHandover
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotesTitle = new System.Windows.Forms.Label();
            this.txtNextStaff = new System.Windows.Forms.TextBox();
            this.lblNextStaffTitle = new System.Windows.Forms.Label();
            this.lblCashAmount = new System.Windows.Forms.Label();
            this.lblCashTitle = new System.Windows.Forms.Label();
            this.lblOutCount = new System.Windows.Forms.Label();
            this.lblOutTitle = new System.Windows.Forms.Label();
            this.lblInCount = new System.Windows.Forms.Label();
            this.lblInTitle = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblEndTitle = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblStartTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
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
            this.pnlTop.Size = new System.Drawing.Size(544, 70);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÀN GIAO CA TRỰC BẢO VỆ";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.lblSub.Location = new System.Drawing.Point(20, 40);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(206, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Bảo vệ chốt ca: Quản Trị Viên (admin)";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.btnConfirm);
            this.pnlBody.Controls.Add(this.txtNotes);
            this.pnlBody.Controls.Add(this.lblNotesTitle);
            this.pnlBody.Controls.Add(this.txtNextStaff);
            this.pnlBody.Controls.Add(this.lblNextStaffTitle);
            this.pnlBody.Controls.Add(this.lblCashAmount);
            this.pnlBody.Controls.Add(this.lblCashTitle);
            this.pnlBody.Controls.Add(this.lblOutCount);
            this.pnlBody.Controls.Add(this.lblOutTitle);
            this.pnlBody.Controls.Add(this.lblInCount);
            this.pnlBody.Controls.Add(this.lblInTitle);
            this.pnlBody.Controls.Add(this.lblEndTime);
            this.pnlBody.Controls.Add(this.lblEndTitle);
            this.pnlBody.Controls.Add(this.lblStartTime);
            this.pnlBody.Controls.Add(this.lblStartTitle);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 70);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlBody.Size = new System.Drawing.Size(544, 421);
            this.pnlBody.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(200, 335);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(280, 42);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "✍️  Xác Nhận Ký Bàn Giao Ca";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(200, 260);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(280, 55);
            this.txtNotes.TabIndex = 13;
            // 
            // lblNotesTitle
            // 
            this.lblNotesTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblNotesTitle.Location = new System.Drawing.Point(20, 263);
            this.lblNotesTitle.Name = "lblNotesTitle";
            this.lblNotesTitle.Size = new System.Drawing.Size(175, 23);
            this.lblNotesTitle.TabIndex = 12;
            this.lblNotesTitle.Text = "Ghi chú bàn giao:";
            // 
            // txtNextStaff
            // 
            this.txtNextStaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNextStaff.Location = new System.Drawing.Point(200, 220);
            this.txtNextStaff.Name = "txtNextStaff";
            this.txtNextStaff.Size = new System.Drawing.Size(280, 23);
            this.txtNextStaff.TabIndex = 11;
            // 
            // lblNextStaffTitle
            // 
            this.lblNextStaffTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNextStaffTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblNextStaffTitle.Location = new System.Drawing.Point(20, 223);
            this.lblNextStaffTitle.Name = "lblNextStaffTitle";
            this.lblNextStaffTitle.Size = new System.Drawing.Size(175, 23);
            this.lblNextStaffTitle.TabIndex = 10;
            this.lblNextStaffTitle.Text = "Bảo vệ nhận ca (*):";
            // 
            // lblCashAmount
            // 
            this.lblCashAmount.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCashAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblCashAmount.Location = new System.Drawing.Point(200, 180);
            this.lblCashAmount.Name = "lblCashAmount";
            this.lblCashAmount.Size = new System.Drawing.Size(280, 25);
            this.lblCashAmount.TabIndex = 9;
            this.lblCashAmount.Text = "0 VNĐ";
            // 
            // lblCashTitle
            // 
            this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCashTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCashTitle.Location = new System.Drawing.Point(20, 183);
            this.lblCashTitle.Name = "lblCashTitle";
            this.lblCashTitle.Size = new System.Drawing.Size(175, 23);
            this.lblCashTitle.TabIndex = 8;
            this.lblCashTitle.Text = "Tiền mặt thực thu:";
            // 
            // lblOutCount
            // 
            this.lblOutCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblOutCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblOutCount.Location = new System.Drawing.Point(200, 140);
            this.lblOutCount.Name = "lblOutCount";
            this.lblOutCount.Size = new System.Drawing.Size(280, 23);
            this.lblOutCount.TabIndex = 7;
            this.lblOutCount.Text = "0 lượt xe";
            // 
            // lblOutTitle
            // 
            this.lblOutTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblOutTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblOutTitle.Location = new System.Drawing.Point(20, 143);
            this.lblOutTitle.Name = "lblOutTitle";
            this.lblOutTitle.Size = new System.Drawing.Size(175, 23);
            this.lblOutTitle.TabIndex = 6;
            this.lblOutTitle.Text = "Lượt xe RA:";
            // 
            // lblInCount
            // 
            this.lblInCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblInCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblInCount.Location = new System.Drawing.Point(200, 100);
            this.lblInCount.Name = "lblInCount";
            this.lblInCount.Size = new System.Drawing.Size(280, 23);
            this.lblInCount.TabIndex = 5;
            this.lblInCount.Text = "0 lượt xe";
            // 
            // lblInTitle
            // 
            this.lblInTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblInTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblInTitle.Location = new System.Drawing.Point(20, 103);
            this.lblInTitle.Name = "lblInTitle";
            this.lblInTitle.Size = new System.Drawing.Size(175, 23);
            this.lblInTitle.TabIndex = 4;
            this.lblInTitle.Text = "Lượt xe VÀO:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndTime.Location = new System.Drawing.Point(200, 60);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(280, 23);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = "01/01/2026 00:00:00";
            // 
            // lblEndTitle
            // 
            this.lblEndTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEndTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblEndTitle.Location = new System.Drawing.Point(20, 63);
            this.lblEndTitle.Name = "lblEndTitle";
            this.lblEndTitle.Size = new System.Drawing.Size(175, 23);
            this.lblEndTitle.TabIndex = 2;
            this.lblEndTitle.Text = "Thời gian kết thúc:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblStartTime.Location = new System.Drawing.Point(200, 20);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(280, 23);
            this.lblStartTime.TabIndex = 1;
            this.lblStartTime.Text = "01/01/2026 00:00:00";
            // 
            // lblStartTitle
            // 
            this.lblStartTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblStartTitle.Location = new System.Drawing.Point(20, 23);
            this.lblStartTitle.Name = "lblStartTitle";
            this.lblStartTitle.Size = new System.Drawing.Size(175, 23);
            this.lblStartTitle.TabIndex = 0;
            this.lblStartTitle.Text = "Bắt đầu ca trực:";
            // 
            // frmShiftHandover
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 491);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShiftHandover";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bàn Giao Ca Trực Bảo Vệ - Chốt Doanh Thu Tiền Mặt";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblStartTitle;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTitle;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblInTitle;
        private System.Windows.Forms.Label lblInCount;
        private System.Windows.Forms.Label lblOutTitle;
        private System.Windows.Forms.Label lblOutCount;
        private System.Windows.Forms.Label lblCashTitle;
        private System.Windows.Forms.Label lblCashAmount;
        private System.Windows.Forms.Label lblNextStaffTitle;
        private System.Windows.Forms.TextBox txtNextStaff;
        private System.Windows.Forms.Label lblNotesTitle;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnConfirm;
    }
}
