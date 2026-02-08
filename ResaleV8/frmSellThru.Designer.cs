namespace ResaleV8
{
    partial class frmSellThru
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
            dgvSellThru = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSellThru).BeginInit();
            SuspendLayout();
            // 
            // dgvSellThru
            // 
            dgvSellThru.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSellThru.Location = new Point(507, 3);
            dgvSellThru.Name = "dgvSellThru";
            dgvSellThru.Size = new Size(675, 889);
            dgvSellThru.TabIndex = 0;
            // 
            // frmSellThru
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1688, 891);
            Controls.Add(dgvSellThru);
            Name = "frmSellThru";
            Text = "Sell Thru List";
            WindowState = FormWindowState.Maximized;
            Load += frmSellThru_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSellThru).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSellThru;
    }
}