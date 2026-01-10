namespace ResaleV8
{
    partial class frmUnsoldReport
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
            dgvUnsold = new DataGridView();
            btnExport = new Button();
            btnClose = new Button();
            txtTotalCost = new TextBox();
            txtAvgAge = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtItemTotal = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUnsold).BeginInit();
            SuspendLayout();
            // 
            // dgvUnsold
            // 
            dgvUnsold.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnsold.Location = new Point(26, 14);
            dgvUnsold.Margin = new Padding(4, 4, 4, 4);
            dgvUnsold.Name = "dgvUnsold";
            dgvUnsold.RowHeadersWidth = 51;
            dgvUnsold.Size = new Size(1859, 681);
            dgvUnsold.TabIndex = 0;
            dgvUnsold.CellClick += dgvUnsold_CellClick;
            dgvUnsold.RowHeaderMouseDoubleClick += dgvUnsold_RowHeaderMouseDoubleClick;
            // 
            // btnExport
            // 
            btnExport.BackColor = SystemColors.Info;
            btnExport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.icons8_excel_50;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(1190, 745);
            btnExport.Margin = new Padding(4, 4, 4, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(160, 156);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export to Excel";
            btnExport.TextAlign = ContentAlignment.BottomCenter;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1490, 920);
            btnClose.Margin = new Padding(4, 4, 4, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(160, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtTotalCost
            // 
            txtTotalCost.Location = new Point(206, 811);
            txtTotalCost.Margin = new Padding(4, 5, 4, 5);
            txtTotalCost.Name = "txtTotalCost";
            txtTotalCost.Size = new Size(116, 31);
            txtTotalCost.TabIndex = 3;
            // 
            // txtAvgAge
            // 
            txtAvgAge.Location = new Point(470, 811);
            txtAvgAge.Margin = new Padding(4, 5, 4, 5);
            txtAvgAge.Name = "txtAvgAge";
            txtAvgAge.Size = new Size(116, 31);
            txtAvgAge.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 766);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(222, 25);
            label1.TabIndex = 5;
            label1.Text = "Total Cost of Unsold Items";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 766);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(246, 25);
            label2.TabIndex = 6;
            label2.Text = "Average Age of Unsold Items";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(740, 766);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(159, 25);
            label3.TabIndex = 8;
            label3.Text = "Total Unsold Items";
            // 
            // txtItemTotal
            // 
            txtItemTotal.Location = new Point(756, 811);
            txtItemTotal.Margin = new Padding(4, 5, 4, 5);
            txtItemTotal.Name = "txtItemTotal";
            txtItemTotal.Size = new Size(116, 31);
            txtItemTotal.TabIndex = 7;
            // 
            // frmUnsoldReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1901, 975);
            Controls.Add(label3);
            Controls.Add(txtItemTotal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAvgAge);
            Controls.Add(txtTotalCost);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(dgvUnsold);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmUnsoldReport";
            Text = "Unsold Items";
            WindowState = FormWindowState.Maximized;
            Load += frmUnsoldReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUnsold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUnsold;
        private Button btnExport;
        private Button btnClose;
        private TextBox txtTotalCost;
        private TextBox txtAvgAge;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtItemTotal;
    }
}