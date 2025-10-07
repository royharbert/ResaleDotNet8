namespace ResaleV8
{
    partial class frmSearchResults
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
            dgvSearchresults = new DataGridView();
            btnExport = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSearchresults).BeginInit();
            SuspendLayout();
            // 
            // dgvSearchresults
            // 
            dgvSearchresults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchresults.Location = new Point(0, 32);
            dgvSearchresults.Margin = new Padding(3, 4, 3, 4);
            dgvSearchresults.Name = "dgvSearchresults";
            dgvSearchresults.RowHeadersWidth = 51;
            dgvSearchresults.Size = new Size(1728, 703);
            dgvSearchresults.TabIndex = 0;
            dgvSearchresults.RowHeaderMouseDoubleClick += dgvSearchresults_RowHeaderMouseDoubleClick;
            // 
            // btnExport
            // 
            btnExport.BackColor = SystemColors.Info;
            btnExport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.icons8_excel_50;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(840, 777);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(128, 125);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export to Excel";
            btnExport.TextAlign = ContentAlignment.BottomCenter;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.Info;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.Image = Properties.Resources._5402366_delete_remove_cross_cancel_close_icon;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(1586, 777);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(128, 125);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += button1_Click;
            // 
            // frmSearchResults
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1742, 940);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(dgvSearchresults);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmSearchResults";
            Text = "Search Results";
            Load += frmSearchResults_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSearchresults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSearchresults;
        private Button btnExport;
        private Button btnClose;
    }
}