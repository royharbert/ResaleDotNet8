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
            label1.Location = new Point(47, 99);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "Description";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(143, 89);
            txtDesc.Margin = new Padding(3, 4, 3, 4);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(658, 27);
            txtDesc.TabIndex = 1;
            txtDesc.Text = "Jeans";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 264);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 2;
            label2.Text = "Storage Location";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(143, 217);
            txtPurchasePrice.Margin = new Padding(3, 4, 3, 4);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(658, 27);
            txtPurchasePrice.TabIndex = 10;
            txtPurchasePrice.Text = "10";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 223);
            label7.Name = "label7";
            label7.Size = new Size(103, 20);
            label7.TabIndex = 12;
            label7.Text = "Purchase Price";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 181);
            label8.Name = "label8";
            label8.Size = new Size(103, 20);
            label8.TabIndex = 14;
            label8.Text = "Purchase Date";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSaveAdd
            // 
            btnSaveAdd.Location = new Point(117, 331);
            btnSaveAdd.Margin = new Padding(3, 4, 3, 4);
            btnSaveAdd.Name = "btnSaveAdd";
            btnSaveAdd.Size = new Size(173, 31);
            btnSaveAdd.TabIndex = 16;
            btnSaveAdd.Text = "Save and Add Another";
            btnSaveAdd.UseVisualStyleBackColor = true;
            btnSaveAdd.Click += btnSaveAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(319, 331);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(173, 31);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save and Close";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(521, 331);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(173, 31);
            btnClose.TabIndex = 18;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dtpBuy
            // 
            dtpBuy.Location = new Point(143, 175);
            dtpBuy.Margin = new Padding(3, 4, 3, 4);
            dtpBuy.Name = "dtpBuy";
            dtpBuy.Size = new Size(243, 27);
            dtpBuy.TabIndex = 19;
            // 
            // cboStorage
            // 
            cboStorage.FormattingEnabled = true;
            cboStorage.Location = new Point(143, 260);
            cboStorage.Margin = new Padding(3, 4, 3, 4);
            cboStorage.Name = "cboStorage";
            cboStorage.Size = new Size(658, 28);
            cboStorage.TabIndex = 21;
            cboStorage.Text = "Garage";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 140);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 22;
            label3.Text = "Quantity";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(143, 132);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(135, 27);
            txtQuantity.TabIndex = 23;
            txtQuantity.Text = "1";
            // 
            // txtID
            // 
            txtID.Location = new Point(143, 47);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.Size = new Size(135, 27);
            txtID.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 57);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 24;
            label4.Text = "Item ID";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmAdd
            // 
            AcceptButton = btnSaveAdd;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(861, 420);
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
            Margin = new Padding(3, 4, 3, 4);
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