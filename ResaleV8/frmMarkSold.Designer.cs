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
            txtPrice = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtID = new TextBox();
            btnRetrieve = new Button();
            btnSave = new Button();
            lblDaysOwned = new Label();
            lblProfit = new Label();
            SuspendLayout();
            // 
            // dtpSaleDate
            // 
            dtpSaleDate.Location = new Point(151, 133);
            dtpSaleDate.Name = "dtpSaleDate";
            dtpSaleDate.Size = new Size(250, 27);
            dtpSaleDate.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(151, 180);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(250, 27);
            txtPrice.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 138);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 4;
            label1.Text = "Sale Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 183);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 5;
            label2.Text = "Sale Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 227);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 6;
            label3.Text = "Days Owned";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 277);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 7;
            label4.Text = "Profit";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(87, 91);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 9;
            label5.Text = "Item ID";
            // 
            // txtID
            // 
            txtID.Location = new Point(151, 88);
            txtID.Name = "txtID";
            txtID.Size = new Size(250, 27);
            txtID.TabIndex = 0;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new Point(91, 378);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(119, 29);
            btnRetrieve.TabIndex = 5;
            btnRetrieve.Text = "Retrieve Item";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(232, 378);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(119, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblDaysOwned
            // 
            lblDaysOwned.AutoSize = true;
            lblDaysOwned.Location = new Point(151, 229);
            lblDaysOwned.Name = "lblDaysOwned";
            lblDaysOwned.Size = new Size(0, 20);
            lblDaysOwned.TabIndex = 10;
            // 
            // lblProfit
            // 
            lblProfit.AutoSize = true;
            lblProfit.Location = new Point(151, 277);
            lblProfit.Name = "lblProfit";
            lblProfit.Size = new Size(0, 20);
            lblProfit.TabIndex = 11;
            // 
            // frmMarkSold
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 450);
            Controls.Add(lblProfit);
            Controls.Add(lblDaysOwned);
            Controls.Add(btnSave);
            Controls.Add(btnRetrieve);
            Controls.Add(txtID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPrice);
            Controls.Add(dtpSaleDate);
            Name = "frmMarkSold";
            Text = "Mark Item Sold";
            Load += frmMarkSold_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpSaleDate;
        private TextBox txtPrice;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtID;
        private Button btnRetrieve;
        private Button btnSave;
        private Label lblDaysOwned;
        private Label lblProfit;
    }
}