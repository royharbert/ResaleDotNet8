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
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSellThru).BeginInit();
            SuspendLayout();
            // 
            // dgvSellThru
            // 
            dgvSellThru.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSellThru.Location = new Point(724, 5);
            dgvSellThru.Margin = new Padding(4, 5, 4, 5);
            dgvSellThru.Name = "dgvSellThru";
            dgvSellThru.RowHeadersWidth = 62;
            dgvSellThru.Size = new Size(964, 874);
            dgvSellThru.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.GradientActiveCaption;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources._8666786_x_octagon_delete_icon;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(1116, 896);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(204, 83);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmSellThru
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2260, 991);
            Controls.Add(btnClose);
            Controls.Add(dgvSellThru);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmSellThru";
            Text = "Sell Thru List";
            WindowState = FormWindowState.Maximized;
            Load += frmSellThru_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSellThru).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSellThru;
        private Button btnClose;
    }
}