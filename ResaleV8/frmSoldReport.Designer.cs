namespace ResaleV8
{
    partial class frmSoldReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSoldReport = new DataGridView();
            dtpStart = new DateTimePicker();
            btnExport = new Button();
            dtpStop = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnClose = new Button();
            btnRun = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTotRevenue = new TextBox();
            txtAvgPct = new TextBox();
            txtTotMargin = new TextBox();
            txtTotalCost = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSoldReport).BeginInit();
            SuspendLayout();
            // 
            // dgvSoldReport
            // 
            dgvSoldReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSoldReport.Location = new Point(292, 9);
            dgvSoldReport.Margin = new Padding(3, 2, 3, 2);
            dgvSoldReport.Name = "dgvSoldReport";
            dgvSoldReport.RowHeadersWidth = 51;
            dgvSoldReport.Size = new Size(1225, 658);
            dgvSoldReport.TabIndex = 0;
            dgvSoldReport.RowHeaderMouseDoubleClick += dgvSoldReport_RowHeaderMouseDoubleClick;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(33, 142);
            dtpStart.Margin = new Padding(3, 2, 3, 2);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(219, 23);
            dtpStart.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.LightYellow;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.icons8_excel_50;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(92, 302);
            btnExport.Margin = new Padding(3, 2, 3, 2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(109, 68);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export to Excel";
            btnExport.TextAlign = ContentAlignment.BottomCenter;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // dtpStop
            // 
            dtpStop.Location = new Point(33, 210);
            dtpStop.Margin = new Padding(3, 2, 3, 2);
            dtpStop.Name = "dtpStop";
            dtpStop.Size = new Size(219, 23);
            dtpStop.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 121);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 4;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 190);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 5;
            label2.Text = "End Date";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 11F);
            btnClose.Location = new Point(92, 619);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(122, 48);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.LawnGreen;
            btnRun.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(92, 242);
            btnRun.Margin = new Padding(3, 2, 3, 2);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(109, 51);
            btnRun.TabIndex = 7;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 410);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 8;
            label3.Text = "Total Revenue in Period";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(86, 506);
            label4.Name = "label4";
            label4.Size = new Size(124, 15);
            label4.TabIndex = 9;
            label4.Text = "Total Margin in Period";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 559);
            label5.Name = "label5";
            label5.Size = new Size(153, 15);
            label5.TabIndex = 10;
            label5.Text = "Average Margin Percentage";
            // 
            // txtTotRevenue
            // 
            txtTotRevenue.Location = new Point(100, 428);
            txtTotRevenue.Margin = new Padding(3, 2, 3, 2);
            txtTotRevenue.Name = "txtTotRevenue";
            txtTotRevenue.Size = new Size(110, 23);
            txtTotRevenue.TabIndex = 11;
            // 
            // txtAvgPct
            // 
            txtAvgPct.Location = new Point(100, 578);
            txtAvgPct.Margin = new Padding(3, 2, 3, 2);
            txtAvgPct.Name = "txtAvgPct";
            txtAvgPct.Size = new Size(110, 23);
            txtAvgPct.TabIndex = 12;
            // 
            // txtTotMargin
            // 
            txtTotMargin.Location = new Point(100, 523);
            txtTotMargin.Margin = new Padding(3, 2, 3, 2);
            txtTotMargin.Name = "txtTotMargin";
            txtTotMargin.Size = new Size(110, 23);
            txtTotMargin.TabIndex = 13;
            // 
            // txtTotalCost
            // 
            txtTotalCost.Location = new Point(100, 475);
            txtTotalCost.Margin = new Padding(3, 2, 3, 2);
            txtTotalCost.Name = "txtTotalCost";
            txtTotalCost.Size = new Size(110, 23);
            txtTotalCost.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(81, 456);
            label6.Name = "label6";
            label6.Size = new Size(137, 15);
            label6.TabIndex = 14;
            label6.Text = "Total Item Cost in Period";
            // 
            // frmSoldReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1529, 685);
            Controls.Add(txtTotalCost);
            Controls.Add(label6);
            Controls.Add(txtTotMargin);
            Controls.Add(txtAvgPct);
            Controls.Add(txtTotRevenue);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnRun);
            Controls.Add(btnClose);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpStop);
            Controls.Add(btnExport);
            Controls.Add(dtpStart);
            Controls.Add(dgvSoldReport);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSoldReport";
            Text = "Sold Report";
            WindowState = FormWindowState.Maximized;
            Load += frmSoldReport_Load;
            Leave += frmSoldReport_Leave;
            ((System.ComponentModel.ISupportInitialize)dgvSoldReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSoldReport;
        private DateTimePicker dtpStart;
        private Button btnExport;
        private DateTimePicker dtpStop;
        private Label label1;
        private Label label2;
        private Button btnClose;
        private Button btnRun;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTotRevenue;
        private TextBox txtAvgPct;
        private TextBox txtTotMargin;
        private TextBox txtTotalCost;
        private Label label6;
    }
}