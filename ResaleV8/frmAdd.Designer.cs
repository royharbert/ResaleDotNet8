namespace ResaleV8
{
    partial class frmAdd
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
            label1 = new Label();
            txtDesc = new TextBox();
            label2 = new Label();
            txtPurchasePrice = new TextBox();
            label7 = new Label();
            label8 = new Label();
            btnSaveAdd = new Button();
            btnSave = new Button();
            btnClose = new Button();
            dtpBuy = new DateTimePicker();
            cboStorage = new ComboBox();
            label3 = new Label();
            txtQuantity = new TextBox();
            txtID = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 74);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Description";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(125, 67);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(576, 23);
            txtDesc.TabIndex = 1;
            txtDesc.Text = "Jeans";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 198);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 2;
            label2.Text = "Storage Location";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(125, 163);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(576, 23);
            txtPurchasePrice.TabIndex = 10;
            txtPurchasePrice.Text = "10";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 167);
            label7.Name = "label7";
            label7.Size = new Size(84, 15);
            label7.TabIndex = 12;
            label7.Text = "Purchase Price";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 136);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 14;
            label8.Text = "Purchase Date";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSaveAdd
            // 
            btnSaveAdd.Location = new Point(102, 248);
            btnSaveAdd.Name = "btnSaveAdd";
            btnSaveAdd.Size = new Size(151, 23);
            btnSaveAdd.TabIndex = 16;
            btnSaveAdd.Text = "Save and Add Another";
            btnSaveAdd.UseVisualStyleBackColor = true;
            btnSaveAdd.Click += btnSaveAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(279, 248);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(151, 23);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save and Close";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(456, 248);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(151, 23);
            btnClose.TabIndex = 18;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dtpBuy
            // 
            dtpBuy.Location = new Point(125, 131);
            dtpBuy.Name = "dtpBuy";
            dtpBuy.Size = new Size(213, 23);
            dtpBuy.TabIndex = 19;
            // 
            // cboStorage
            // 
            cboStorage.FormattingEnabled = true;
            cboStorage.Location = new Point(125, 195);
            cboStorage.Name = "cboStorage";
            cboStorage.Size = new Size(576, 23);
            cboStorage.TabIndex = 21;
            cboStorage.Text = "Garage";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 105);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 22;
            label3.Text = "Quantity";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(125, 99);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(119, 23);
            txtQuantity.TabIndex = 23;
            txtQuantity.Text = "1";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(125, 35);
            txtID.Name = "txtID";
            txtID.Size = new Size(119, 23);
            txtID.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 43);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 24;
            label4.Text = "Item ID";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmAdd
            // 
            AcceptButton = btnSaveAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(753, 315);
            Controls.Add(txtID);
            Controls.Add(label4);
            Controls.Add(txtQuantity);
            Controls.Add(label3);
            Controls.Add(cboStorage);
            Controls.Add(dtpBuy);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(btnSaveAdd);
            Controls.Add(label8);
            Controls.Add(txtPurchasePrice);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(txtDesc);
            Controls.Add(label1);
            Name = "frmAdd";
            Text = "Add Item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDesc;
        private Label label2;
        private TextBox txtPurchasePrice;
        private Label label7;
        private Label label8;
        private Button btnSaveAdd;
        private Button btnSave;
        private Button btnClose;
        private DateTimePicker dtpBuy;
        private ComboBox cboStorage;
        private Label label3;
        private TextBox txtQuantity;
        private TextBox txtID;
        private Label label4;
    }
}