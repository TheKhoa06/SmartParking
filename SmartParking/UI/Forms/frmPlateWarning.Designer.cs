namespace SmartParking.UI.Forms
{
    partial class frmPlateWarning
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnException = new System.Windows.Forms.Button();
            this.btnCasual = new System.Windows.Forms.Button();
            this.pnlInfoBox = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlTop.Size = new System.Drawing.Size(528, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(428, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚠️ PHÁT HIỆN SAI LỆCH BIỂN SỐ XE";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.btnException);
            this.pnlBody.Controls.Add(this.btnCasual);
            this.pnlBody.Controls.Add(this.pnlInfoBox);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(25);
            this.pnlBody.Size = new System.Drawing.Size(528, 262);
            this.pnlBody.TabIndex = 1;
            // 
            // btnException
            // 
            this.btnException.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnException.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnException.FlatAppearance.BorderSize = 0;
            this.btnException.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnException.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnException.ForeColor = System.Drawing.Color.White;
            this.btnException.Location = new System.Drawing.Point(25, 195);
            this.btnException.Name = "btnException";
            this.btnException.Size = new System.Drawing.Size(470, 38);
            this.btnException.TabIndex = 2;
            this.btnException.Text = "✅  Cho Qua Ngoại Lệ (Sinh viên mượn xe - Vẫn tính Vé tháng)";
            this.btnException.UseVisualStyleBackColor = false;
            // 
            // btnCasual
            // 
            this.btnCasual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCasual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCasual.FlatAppearance.BorderSize = 0;
            this.btnCasual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCasual.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCasual.ForeColor = System.Drawing.Color.White;
            this.btnCasual.Location = new System.Drawing.Point(25, 145);
            this.btnCasual.Name = "btnCasual";
            this.btnCasual.Size = new System.Drawing.Size(470, 38);
            this.btnCasual.TabIndex = 1;
            this.btnCasual.Text = "🎟️  Chuyển Sang Vé Lượt (Thu tiền như khách vãng lai)";
            this.btnCasual.UseVisualStyleBackColor = false;
            // 
            // pnlInfoBox
            // 
            this.pnlInfoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfoBox.Controls.Add(this.lblMsg);
            this.pnlInfoBox.Location = new System.Drawing.Point(25, 15);
            this.pnlInfoBox.Name = "pnlInfoBox";
            this.pnlInfoBox.Size = new System.Drawing.Size(470, 115);
            this.pnlInfoBox.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Padding = new System.Windows.Forms.Padding(12);
            this.lblMsg.Size = new System.Drawing.Size(468, 113);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Chủ thẻ cư dân: Nguyễn Văn A\r\n• Biển số đăng ký thẻ tháng: 29A-123.45\r\n• Biển số " +
    "thực tế trước camera: 30B-999.99\r\n\r\nBảo vệ vui lòng xác nhận phương án xử lý:";
            // 
            // frmPlateWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 322);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlateWarning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cảnh Báo: Biển Số Xe Không Khớp Với Thẻ Tháng";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlInfoBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlInfoBox;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnCasual;
        private System.Windows.Forms.Button btnException;
    }
}
