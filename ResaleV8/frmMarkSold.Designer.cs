namespace ResaleV8
{
    partial class frmMarkSold
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
            dtpSaleDate = new DateTimePicker();
            txtSalePrice = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnDone = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // dtpSaleDate
            // 
            dtpSaleDate.Location = new Point(144, 59);
            dtpSaleDate.Name = "dtpSaleDate";
            dtpSaleDate.Size = new Size(200, 23);
            dtpSaleDate.TabIndex = 0;
            // 
            // txtSalePrice
            // 
            txtSalePrice.Location = new Point(144, 109);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(100, 23);
            txtSalePrice.TabIndex = 1;
            // 
            // label1
            // 
            label1.Location = new Point(38, 59);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 3;
            label1.Text = "Date Sold";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(38, 109);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 4;
            label2.Text = "Sale Price";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(117, 199);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(75, 23);
            btnDone.TabIndex = 5;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(212, 199);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // frmMarkSold
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 270);
            Controls.Add(btnClose);
            Controls.Add(btnDone);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSalePrice);
            Controls.Add(dtpSaleDate);
            Name = "frmMarkSold";
            Text = "Mark Item as Sold";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpSaleDate;
        private TextBox txtSalePrice;
        private Label label1;
        private Label label2;
        private Button btnDone;
        private Button btnClose;
    }
}