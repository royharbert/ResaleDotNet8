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
            ((System.ComponentModel.ISupportInitialize)dgvSoldReport).BeginInit();
            SuspendLayout();
            // 
            // dgvSoldReport
            // 
            dgvSoldReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSoldReport.Location = new Point(334, 12);
            dgvSoldReport.Name = "dgvSoldReport";
            dgvSoldReport.RowHeadersWidth = 51;
            dgvSoldReport.Size = new Size(864, 594);
            dgvSoldReport.TabIndex = 0;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(24, 190);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(78, 484);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 29);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export to Excel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // dtpStop
            // 
            dtpStop.Location = new Point(24, 280);
            dtpStop.Name = "dtpStop";
            dtpStop.Size = new Size(250, 27);
            dtpStop.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 161);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 4;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 253);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "End Date";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(78, 519);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 29);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(78, 417);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(140, 29);
            btnRun.TabIndex = 7;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // frmSoldReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 687);
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
            Load += frmSoldReport_Load;
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
    }
}