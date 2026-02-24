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
            lblDBMode = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSoldReport).BeginInit();
            SuspendLayout();
            // 
            // dgvSoldReport
            // 
            dgvSoldReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSoldReport.Location = new Point(381, -3);
            dgvSoldReport.Margin = new Padding(4, 3, 4, 3);
            dgvSoldReport.Name = "dgvSoldReport";
            dgvSoldReport.RowHeadersWidth = 51;
            dgvSoldReport.Size = new Size(2296, 1097);
            dgvSoldReport.TabIndex = 0;
            dgvSoldReport.CellContentDoubleClick += dgvSoldReport_CellContentDoubleClick;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(37, 108);
            dtpStart.Margin = new Padding(4, 3, 4, 3);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(311, 31);
            dtpStart.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.LightYellow;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.icons8_excel_50;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(121, 375);
            btnExport.Margin = new Padding(4, 3, 4, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(156, 113);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export to Excel";
            btnExport.TextAlign = ContentAlignment.BottomCenter;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // dtpStop
            // 
            dtpStop.Location = new Point(37, 222);
            dtpStop.Margin = new Padding(4, 3, 4, 3);
            dtpStop.Name = "dtpStop";
            dtpStop.Size = new Size(311, 31);
            dtpStop.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 73);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 4;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 188);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 5;
            label2.Text = "End Date";
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.Info;
            btnClose.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources._5402366_delete_remove_cross_cancel_close_icon;
            btnClose.Location = new Point(121, 903);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(174, 147);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.LawnGreen;
            btnRun.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(121, 275);
            btnRun.Margin = new Padding(4, 3, 4, 3);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(156, 85);
            btnRun.TabIndex = 7;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(106, 555);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(194, 25);
            label3.TabIndex = 8;
            label3.Text = "Total Revenue in Period";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(113, 715);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(184, 25);
            label4.TabIndex = 9;
            label4.Text = "Total Margin in Period";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(89, 803);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(229, 25);
            label5.TabIndex = 10;
            label5.Text = "Average Margin Percentage";
            // 
            // txtTotRevenue
            // 
            txtTotRevenue.Location = new Point(133, 585);
            txtTotRevenue.Margin = new Padding(4, 3, 4, 3);
            txtTotRevenue.Name = "txtTotRevenue";
            txtTotRevenue.Size = new Size(155, 31);
            txtTotRevenue.TabIndex = 11;
            // 
            // txtAvgPct
            // 
            txtAvgPct.Location = new Point(133, 835);
            txtAvgPct.Margin = new Padding(4, 3, 4, 3);
            txtAvgPct.Name = "txtAvgPct";
            txtAvgPct.Size = new Size(155, 31);
            txtAvgPct.TabIndex = 12;
            // 
            // txtTotMargin
            // 
            txtTotMargin.Location = new Point(133, 743);
            txtTotMargin.Margin = new Padding(4, 3, 4, 3);
            txtTotMargin.Name = "txtTotMargin";
            txtTotMargin.Size = new Size(155, 31);
            txtTotMargin.TabIndex = 13;
            // 
            // txtTotalCost
            // 
            txtTotalCost.Location = new Point(133, 663);
            txtTotalCost.Margin = new Padding(4, 3, 4, 3);
            txtTotalCost.Name = "txtTotalCost";
            txtTotalCost.Size = new Size(155, 31);
            txtTotalCost.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(106, 632);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(205, 25);
            label6.TabIndex = 14;
            label6.Text = "Total Item Cost in Period";
            // 
            // lblDBMode
            // 
            lblDBMode.AutoSize = true;
            lblDBMode.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDBMode.Location = new Point(33, 9);
            lblDBMode.Name = "lblDBMode";
            lblDBMode.Size = new Size(76, 30);
            lblDBMode.TabIndex = 16;
            lblDBMode.Text = "label7";
            // 
            // frmSoldReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2260, 1142);
            Controls.Add(lblDBMode);
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
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSoldReport";
            Text = "Sold Report";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmSoldReport_FormClosing;
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
        private Label lblDBMode;
    }
}