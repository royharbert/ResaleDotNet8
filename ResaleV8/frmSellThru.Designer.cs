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
            components = new System.ComponentModel.Container();
            dgvSellThru = new DataGridView();
            btnClose = new Button();
            zgc = new ZedGraph.ZedGraphControl();
            lblDBMode = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSellThru).BeginInit();
            SuspendLayout();
            // 
            // dgvSellThru
            // 
            dgvSellThru.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSellThru.Location = new Point(1296, 0);
            dgvSellThru.Margin = new Padding(4, 5, 4, 5);
            dgvSellThru.Name = "dgvSellThru";
            dgvSellThru.RowHeadersWidth = 62;
            dgvSellThru.Size = new Size(964, 992);
            dgvSellThru.TabIndex = 0;
            dgvSellThru.ColumnHeaderMouseClick += dgvSellThru_ColumnHeaderMouseClick;
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.GradientActiveCaption;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources._8666786_x_octagon_delete_icon;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(1310, 1102);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(333, 83);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // zgc
            // 
            zgc.Font = new Font("Segoe UI", 3.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            zgc.Location = new Point(6, 5);
            zgc.Margin = new Padding(3, 2, 3, 2);
            zgc.Name = "zgc";
            zgc.ScrollGrace = 0D;
            zgc.ScrollMaxX = 0D;
            zgc.ScrollMaxY = 0D;
            zgc.ScrollMaxY2 = 0D;
            zgc.ScrollMinX = 0D;
            zgc.ScrollMinY = 0D;
            zgc.ScrollMinY2 = 0D;
            zgc.Size = new Size(511, 1287);
            zgc.TabIndex = 3;
            zgc.UseExtendedPrintDialog = true;
            // 
            // lblDBMode
            // 
            lblDBMode.AutoSize = true;
            lblDBMode.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDBMode.Location = new Point(214, 1342);
            lblDBMode.Name = "lblDBMode";
            lblDBMode.Size = new Size(76, 30);
            lblDBMode.TabIndex = 17;
            lblDBMode.Text = "label7";
            // 
            // frmSellThru
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2260, 1448);
            Controls.Add(lblDBMode);
            Controls.Add(zgc);
            Controls.Add(btnClose);
            Controls.Add(dgvSellThru);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmSellThru";
            Text = "Sell Thru List";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmSellThru_FormClosing;
            Load += frmSellThru_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSellThru).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSellThru;
        private Button btnClose;
        private ZedGraph.ZedGraphControl zgc;
        private Label lblDBMode;
    }
}