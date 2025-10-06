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
            dgvSoldReport.Location = new Point(334, 12);
            dgvSoldReport.Name = "dgvSoldReport";
            dgvSoldReport.RowHeadersWidth = 51;
            dgvSoldReport.Size = new Size(1200, 877);
            dgvSoldReport.TabIndex = 0;
            dgvSoldReport.RowHeaderMouseDoubleClick += dgvSoldReport_RowHeaderMouseDoubleClick;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(38, 190);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.LightYellow;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.icons8_excel_50;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(105, 402);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(125, 91);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export to Excel";
            btnExport.TextAlign = ContentAlignment.BottomCenter;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // dtpStop
            // 
            dtpStop.Location = new Point(38, 280);
            dtpStop.Name = "dtpStop";
            dtpStop.Size = new Size(250, 27);
            dtpStop.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 161);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 4;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 253);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "End Date";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 11F);
            btnClose.Location = new Point(105, 825);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 64);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.LawnGreen;
            btnRun.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(105, 322);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(125, 68);
            btnRun.TabIndex = 7;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 547);
            label3.Name = "label3";
            label3.Size = new Size(164, 20);
            label3.TabIndex = 8;
            label3.Text = "Total Revenue in Period";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(98, 674);
            label4.Name = "label4";
            label4.Size = new Size(155, 20);
            label4.TabIndex = 9;
            label4.Text = "Total Margin in Period";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(79, 745);
            label5.Name = "label5";
            label5.Size = new Size(192, 20);
            label5.TabIndex = 10;
            label5.Text = "Average Margin Percentage";
            // 
            // txtTotRevenue
            // 
            txtTotRevenue.Location = new Point(114, 570);
            txtTotRevenue.Name = "txtTotRevenue";
            txtTotRevenue.Size = new Size(125, 27);
            txtTotRevenue.TabIndex = 11;
            // 
            // txtAvgPct
            // 
            txtAvgPct.Location = new Point(114, 771);
            txtAvgPct.Name = "txtAvgPct";
            txtAvgPct.Size = new Size(125, 27);
            txtAvgPct.TabIndex = 12;
            // 
            // txtTotMargin
            // 
            txtTotMargin.Location = new Point(114, 697);
            txtTotMargin.Name = "txtTotMargin";
            txtTotMargin.Size = new Size(125, 27);
            txtTotMargin.TabIndex = 13;
            // 
            // txtTotalCost
            // 
            txtTotalCost.Location = new Point(114, 633);
            txtTotalCost.Name = "txtTotalCost";
            txtTotalCost.Size = new Size(125, 27);
            txtTotalCost.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(93, 608);
            label6.Name = "label6";
            label6.Size = new Size(171, 20);
            label6.TabIndex = 14;
            label6.Text = "Total Item Cost in Period";
            // 
            // frmSoldReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1413, 913);
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