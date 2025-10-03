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
            dgvUnsold.Location = new Point(18, 8);
            dgvUnsold.Margin = new Padding(3, 2, 3, 2);
            dgvUnsold.Name = "dgvUnsold";
            dgvUnsold.RowHeadersWidth = 51;
            dgvUnsold.Size = new Size(1137, 409);
            dgvUnsold.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(877, 552);
            btnExport.Margin = new Padding(3, 2, 3, 2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(112, 22);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export to Excel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1043, 552);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 22);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtTotalCost
            // 
            txtTotalCost.Location = new Point(144, 487);
            txtTotalCost.Name = "txtTotalCost";
            txtTotalCost.Size = new Size(83, 23);
            txtTotalCost.TabIndex = 3;
            // 
            // txtAvgAge
            // 
            txtAvgAge.Location = new Point(329, 487);
            txtAvgAge.Name = "txtAvgAge";
            txtAvgAge.Size = new Size(83, 23);
            txtAvgAge.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 460);
            label1.Name = "label1";
            label1.Size = new Size(146, 15);
            label1.TabIndex = 5;
            label1.Text = "Total Cost of Unsold Items";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(286, 460);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 6;
            label2.Text = "Average Age of Unsold Items";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 460);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 8;
            label3.Text = "Total Unsold Items";
            // 
            // txtItemTotal
            // 
            txtItemTotal.Location = new Point(529, 487);
            txtItemTotal.Name = "txtItemTotal";
            txtItemTotal.Size = new Size(83, 23);
            txtItemTotal.TabIndex = 7;
            // 
            // frmUnsoldReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 585);
            Controls.Add(label3);
            Controls.Add(txtItemTotal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAvgAge);
            Controls.Add(txtTotalCost);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(dgvUnsold);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmUnsoldReport";
            Text = "Unsold Items";
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