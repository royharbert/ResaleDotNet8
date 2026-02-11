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
            dgvSellThru.Location = new Point(507, 3);
            dgvSellThru.Name = "dgvSellThru";
            dgvSellThru.RowHeadersWidth = 62;
            dgvSellThru.Size = new Size(675, 524);
            dgvSellThru.TabIndex = 0;
            dgvSellThru.ColumnHeaderMouseClick += dgvSellThru_ColumnHeaderMouseClick;
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.GradientActiveCaption;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources._8666786_x_octagon_delete_icon;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(780, 532);
            btnClose.Margin = new Padding(2, 2, 2, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(233, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmSellThru
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 595);
            Controls.Add(btnClose);
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
        private Button btnClose;
    }
}