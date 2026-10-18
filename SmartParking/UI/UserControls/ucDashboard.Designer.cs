namespace SmartParking.UI.UserControls
{
    partial class ucDashboard
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
            this.pnlKpis = new System.Windows.Forms.FlowLayoutPanel();
            this.cardTotalIn = new SmartParking.UI.Common.KpiCard();
            this.cardTodayRev = new SmartParking.UI.Common.KpiCard();
            this.cardExpiring = new SmartParking.UI.Common.KpiCard();
            this.cardAbandoned = new SmartParking.UI.Common.KpiCard();
            this.tableCharts = new System.Windows.Forms.TableLayoutPanel();
            this.grpChart1 = new System.Windows.Forms.GroupBox();
            this.pnlStackedChart = new System.Windows.Forms.Panel();
            this.grpChart2 = new System.Windows.Forms.GroupBox();
            this.pnlHourlyChart = new System.Windows.Forms.Panel();
            this.pnlKpis.SuspendLayout();
            this.tableCharts.SuspendLayout();
            this.grpChart1.SuspendLayout();
            this.grpChart2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKpis
            // 
            this.pnlKpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlKpis.Controls.Add(this.cardTotalIn);
            this.pnlKpis.Controls.Add(this.cardTodayRev);
            this.pnlKpis.Controls.Add(this.cardExpiring);
            this.pnlKpis.Controls.Add(this.cardAbandoned);
            this.pnlKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpis.Location = new System.Drawing.Point(0, 0);
            this.pnlKpis.Name = "pnlKpis";
            this.pnlKpis.Padding = new System.Windows.Forms.Padding(10, 8, 10, 4);
            this.pnlKpis.Size = new System.Drawing.Size(1000, 120);
            this.pnlKpis.TabIndex = 0;
            // 
            // cardTotalIn
            // 
            this.cardTotalIn.BackColor = System.Drawing.Color.White;
            this.cardTotalIn.Location = new System.Drawing.Point(18, 16);
            this.cardTotalIn.Margin = new System.Windows.Forms.Padding(8);
            this.cardTotalIn.Name = "cardTotalIn";
            this.cardTotalIn.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.cardTotalIn.Size = new System.Drawing.Size(230, 95);
            this.cardTotalIn.TabIndex = 0;
            // 
            // cardTodayRev
            // 
            this.cardTodayRev.BackColor = System.Drawing.Color.White;
            this.cardTodayRev.Location = new System.Drawing.Point(264, 16);
            this.cardTodayRev.Margin = new System.Windows.Forms.Padding(8);
            this.cardTodayRev.Name = "cardTodayRev";
            this.cardTodayRev.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.cardTodayRev.Size = new System.Drawing.Size(230, 95);
            this.cardTodayRev.TabIndex = 1;
            // 
            // cardExpiring
            // 
            this.cardExpiring.BackColor = System.Drawing.Color.White;
            this.cardExpiring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardExpiring.Location = new System.Drawing.Point(510, 16);
            this.cardExpiring.Margin = new System.Windows.Forms.Padding(8);
            this.cardExpiring.Name = "cardExpiring";
            this.cardExpiring.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.cardExpiring.Size = new System.Drawing.Size(230, 95);
            this.cardExpiring.TabIndex = 2;
            // 
            // cardAbandoned
            // 
            this.cardAbandoned.BackColor = System.Drawing.Color.White;
            this.cardAbandoned.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardAbandoned.Location = new System.Drawing.Point(756, 16);
            this.cardAbandoned.Margin = new System.Windows.Forms.Padding(8);
            this.cardAbandoned.Name = "cardAbandoned";
            this.cardAbandoned.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.cardAbandoned.Size = new System.Drawing.Size(230, 95);
            this.cardAbandoned.TabIndex = 3;
            // 
            // tableCharts
            // 
            this.tableCharts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tableCharts.ColumnCount = 2;
            this.tableCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableCharts.Controls.Add(this.grpChart1, 0, 0);
            this.tableCharts.Controls.Add(this.grpChart2, 1, 0);
            this.tableCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCharts.Location = new System.Drawing.Point(0, 120);
            this.tableCharts.Name = "tableCharts";
            this.tableCharts.Padding = new System.Windows.Forms.Padding(10);
            this.tableCharts.RowCount = 1;
            this.tableCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCharts.Size = new System.Drawing.Size(1000, 580);
            this.tableCharts.TabIndex = 1;
            // 
            // grpChart1
            // 
            this.grpChart1.BackColor = System.Drawing.Color.White;
            this.grpChart1.Controls.Add(this.pnlStackedChart);
            this.grpChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChart1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpChart1.Location = new System.Drawing.Point(13, 13);
            this.grpChart1.Name = "grpChart1";
            this.grpChart1.Padding = new System.Windows.Forms.Padding(12);
            this.grpChart1.Size = new System.Drawing.Size(435, 554);
            this.grpChart1.TabIndex = 0;
            this.grpChart1.TabStop = false;
            this.grpChart1.Text = "Cơ cấu doanh thu theo nguồn thu";
            // 
            // pnlStackedChart
            // 
            this.pnlStackedChart.BackColor = System.Drawing.Color.White;
            this.pnlStackedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStackedChart.Location = new System.Drawing.Point(12, 34);
            this.pnlStackedChart.Name = "pnlStackedChart";
            this.pnlStackedChart.Size = new System.Drawing.Size(411, 508);
            this.pnlStackedChart.TabIndex = 0;
            // 
            // grpChart2
            // 
            this.grpChart2.BackColor = System.Drawing.Color.White;
            this.grpChart2.Controls.Add(this.pnlHourlyChart);
            this.grpChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChart2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChart2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpChart2.Location = new System.Drawing.Point(454, 13);
            this.grpChart2.Name = "grpChart2";
            this.grpChart2.Padding = new System.Windows.Forms.Padding(12);
            this.grpChart2.Size = new System.Drawing.Size(533, 554);
            this.grpChart2.TabIndex = 1;
            this.grpChart2.TabStop = false;
            this.grpChart2.Text = "Mật độ lưu lượng xe ra vào theo khung giờ trong ngày (24 Giờ)";
            // 
            // pnlHourlyChart
            // 
            this.pnlHourlyChart.BackColor = System.Drawing.Color.White;
            this.pnlHourlyChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHourlyChart.Location = new System.Drawing.Point(12, 34);
            this.pnlHourlyChart.Name = "pnlHourlyChart";
            this.pnlHourlyChart.Size = new System.Drawing.Size(509, 508);
            this.pnlHourlyChart.TabIndex = 0;
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.tableCharts);
            this.Controls.Add(this.pnlKpis);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(1000, 700);
            this.pnlKpis.ResumeLayout(false);
            this.tableCharts.ResumeLayout(false);
            this.grpChart1.ResumeLayout(false);
            this.grpChart2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.FlowLayoutPanel pnlKpis;
        private SmartParking.UI.Common.KpiCard cardTotalIn;
        private SmartParking.UI.Common.KpiCard cardTodayRev;
        private SmartParking.UI.Common.KpiCard cardExpiring;
        private SmartParking.UI.Common.KpiCard cardAbandoned;
        private System.Windows.Forms.TableLayoutPanel tableCharts;
        private System.Windows.Forms.GroupBox grpChart1;
        private System.Windows.Forms.Panel pnlStackedChart;
        private System.Windows.Forms.GroupBox grpChart2;
        private System.Windows.Forms.Panel pnlHourlyChart;
    }
}
