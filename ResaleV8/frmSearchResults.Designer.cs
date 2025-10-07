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
            ((System.ComponentModel.ISupportInitialize)dgvSearchresults).BeginInit();
            SuspendLayout();
            // 
            // dgvSearchresults
            // 
            dgvSearchresults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchresults.Location = new Point(0, 24);
            dgvSearchresults.Name = "dgvSearchresults";
            dgvSearchresults.Size = new Size(1512, 527);
            dgvSearchresults.TabIndex = 0;
            dgvSearchresults.RowHeaderMouseDoubleClick += dgvSearchresults_RowHeaderMouseDoubleClick;
            // 
            // btnExport
            // 
            btnExport.BackColor = SystemColors.Info;
            btnExport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.icons8_excel_50;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(735, 583);
            btnExport.Margin = new Padding(3, 2, 3, 2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(112, 94);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export to Excel";
            btnExport.TextAlign = ContentAlignment.BottomCenter;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // frmSearchResults
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 705);
            Controls.Add(btnExport);
            Controls.Add(dgvSearchresults);
            Name = "frmSearchResults";
            Text = "Search Results";
            Load += frmSearchResults_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSearchresults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSearchresults;
        private Button btnExport;
    }
}