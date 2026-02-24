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
            lblDBMode = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSearchresults).BeginInit();
            SuspendLayout();
            // 
            // dgvSearchresults
            // 
            dgvSearchresults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchresults.Location = new Point(0, 40);
            dgvSearchresults.Margin = new Padding(4, 5, 4, 5);
            dgvSearchresults.Name = "dgvSearchresults";
            dgvSearchresults.RowHeadersWidth = 51;
            dgvSearchresults.Size = new Size(2160, 879);
            dgvSearchresults.TabIndex = 0;
            dgvSearchresults.CellContentDoubleClick += dgvSearchresults_CellContentDoubleClick;
            dgvSearchresults.RowHeaderMouseDoubleClick += dgvSearchresults_RowHeaderMouseDoubleClick;
            // 
            // btnExport
            // 
            btnExport.BackColor = SystemColors.Info;
            btnExport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.icons8_excel_50;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(1050, 971);
            btnExport.Margin = new Padding(4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(160, 156);
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
            btnClose.Location = new Point(1982, 971);
            btnClose.Margin = new Padding(4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(160, 156);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += button1_Click;
            // 
            // lblDBMode
            // 
            lblDBMode.AutoSize = true;
            lblDBMode.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDBMode.Location = new Point(863, 1041);
            lblDBMode.Name = "lblDBMode";
            lblDBMode.Size = new Size(76, 30);
            lblDBMode.TabIndex = 17;
            lblDBMode.Text = "label7";
            // 
            // frmSearchResults
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2178, 1175);
            Controls.Add(lblDBMode);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(dgvSearchresults);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmSearchResults";
            Text = "Search Results";
            FormClosing += frmSearchResults_FormClosing;
            Load += frmSearchResults_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSearchresults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSearchresults;
        private Button btnExport;
        private Button btnClose;
        private Label lblDBMode;
    }
}