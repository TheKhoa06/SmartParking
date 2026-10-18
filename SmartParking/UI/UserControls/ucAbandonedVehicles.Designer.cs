namespace SmartParking.UI.UserControls
{
    partial class ucAbandonedVehicles
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
            this.dgvAbandoned = new System.Windows.Forms.DataGridView();
            this.pnlSummaryBox = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlTopActions = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLocateSlot = new System.Windows.Forms.Button();
            this.pnlOuter.SuspendLayout();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbandoned)).BeginInit();
            this.pnlSummaryBox.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTopActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOuter
            // 
            this.pnlOuter.Controls.Add(this.grpMain);
            this.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOuter.Location = new System.Drawing.Point(0, 0);
            this.pnlOuter.Name = "pnlOuter";
            this.pnlOuter.Padding = new System.Windows.Forms.Padding(12);
            this.pnlOuter.Size = new System.Drawing.Size(1000, 650);
            this.pnlOuter.TabIndex = 0;
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.White;
            this.grpMain.Controls.Add(this.dgvAbandoned);
            this.grpMain.Controls.Add(this.pnlSummaryBox);
            this.grpMain.Controls.Add(this.pnlTop);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpMain.Location = new System.Drawing.Point(12, 12);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(12);
            this.grpMain.Size = new System.Drawing.Size(976, 626);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = " RÀ SOÁT XE VÉ LƯỢT LƯU BÃI LÂU NGÀY (> 72 GIỜ) ";
            // 
            // dgvAbandoned
            // 
            this.dgvAbandoned.BackgroundColor = System.Drawing.Color.White;
            this.dgvAbandoned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvAbandoned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbandoned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAbandoned.Location = new System.Drawing.Point(12, 121);
            this.dgvAbandoned.MultiSelect = false;
            this.dgvAbandoned.Name = "dgvAbandoned";
            this.dgvAbandoned.ReadOnly = true;
            this.dgvAbandoned.RowHeadersVisible = false;
            this.dgvAbandoned.RowHeadersWidth = 51;
            this.dgvAbandoned.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbandoned.Size = new System.Drawing.Size(952, 493);
            this.dgvAbandoned.TabIndex = 2;
            // 
            // pnlSummaryBox
            // 
            this.pnlSummaryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlSummaryBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummaryBox.Controls.Add(this.lblSummary);
            this.pnlSummaryBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummaryBox.Location = new System.Drawing.Point(12, 85);
            this.pnlSummaryBox.Name = "pnlSummaryBox";
            this.pnlSummaryBox.Padding = new System.Windows.Forms.Padding(8);
            this.pnlSummaryBox.Size = new System.Drawing.Size(952, 36);
            this.pnlSummaryBox.TabIndex = 1;
            // 
            // lblSummary
            // 
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lblSummary.Location = new System.Drawing.Point(8, 8);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(934, 18);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Đang rà soát dữ liệu lưu bãi...";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.lblSub);
            this.pnlTop.Controls.Add(this.pnlTopActions);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(12, 35);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(952, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlTopActions
            // 
            this.pnlTopActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopActions.Controls.Add(this.btnLocateSlot);
            this.pnlTopActions.Controls.Add(this.btnRefresh);
            this.pnlTopActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTopActions.Location = new System.Drawing.Point(672, 0);
            this.pnlTopActions.Name = "pnlTopActions";
            this.pnlTopActions.Size = new System.Drawing.Size(280, 50);
            this.pnlTopActions.TabIndex = 1;
            // 
            // lblSub
            // 
            this.lblSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSub.Location = new System.Drawing.Point(0, 0);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(672, 50);
            this.lblSub.TabIndex = 0;
            this.lblSub.Text = "Phát hiện các xe lưu bãi quá 3 ngày (màu cam) hoặc quá 7 ngày (màu đỏ) để phối hợp kiểm tra an ninh.";
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(5, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 32);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "🔄 Quét Lại Hầm";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnLocateSlot
            // 
            this.btnLocateSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnLocateSlot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocateSlot.FlatAppearance.BorderSize = 0;
            this.btnLocateSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocateSlot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLocateSlot.ForeColor = System.Drawing.Color.White;
            this.btnLocateSlot.Location = new System.Drawing.Point(145, 9);
            this.btnLocateSlot.Name = "btnLocateSlot";
            this.btnLocateSlot.Size = new System.Drawing.Size(130, 32);
            this.btnLocateSlot.TabIndex = 1;
            this.btnLocateSlot.Text = "🎯 Định Vị Ô Đỗ";
            this.btnLocateSlot.UseVisualStyleBackColor = false;
            // 
            // ucAbandonedVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlOuter);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucAbandonedVehicles";
            this.Size = new System.Drawing.Size(1000, 650);
            this.pnlOuter.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbandoned)).EndInit();
            this.pnlSummaryBox.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlOuter;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.DataGridView dgvAbandoned;
        private System.Windows.Forms.Panel pnlSummaryBox;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlTopActions;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLocateSlot;
    }
}
