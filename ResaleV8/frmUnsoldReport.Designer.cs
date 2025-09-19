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
            ((System.ComponentModel.ISupportInitialize)dgvUnsold).BeginInit();
            SuspendLayout();
            // 
            // dgvUnsold
            // 
            dgvUnsold.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnsold.Location = new Point(20, 10);
            dgvUnsold.Name = "dgvUnsold";
            dgvUnsold.RowHeadersWidth = 51;
            dgvUnsold.Size = new Size(1299, 545);
            dgvUnsold.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(524, 576);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(128, 29);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export to Excel";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 576);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(128, 29);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmUnsoldReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1331, 617);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(dgvUnsold);
            Name = "frmUnsoldReport";
            Text = "Unsold Items";
            Load += frmUnsoldReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUnsold).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUnsold;
        private Button btnExport;
        private Button btnClose;
    }
}