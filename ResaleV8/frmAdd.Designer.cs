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
            cboCategory = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 109);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Description";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(125, 106);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(576, 23);
            txtDesc.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 250);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 2;
            label2.Text = "Storage Location";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(125, 212);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(576, 23);
            txtPurchasePrice.TabIndex = 4;
            txtPurchasePrice.Text = "10";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 214);
            label7.Name = "label7";
            label7.Size = new Size(84, 15);
            label7.TabIndex = 12;
            label7.Text = "Purchase Price";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 179);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 14;
            label8.Text = "Purchase Date";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSaveAdd
            // 
            btnSaveAdd.Location = new Point(124, 300);
            btnSaveAdd.Name = "btnSaveAdd";
            btnSaveAdd.Size = new Size(151, 23);
            btnSaveAdd.TabIndex = 6;
            btnSaveAdd.Text = "Save and Add Another";
            btnSaveAdd.UseVisualStyleBackColor = true;
            btnSaveAdd.Click += btnSaveAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(301, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(151, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(478, 300);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(151, 23);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dtpBuy
            // 
            dtpBuy.Location = new Point(125, 177);
            dtpBuy.Name = "dtpBuy";
            dtpBuy.Size = new Size(213, 23);
            dtpBuy.TabIndex = 3;
            // 
            // cboStorage
            // 
            cboStorage.FormattingEnabled = true;
            cboStorage.Location = new Point(125, 248);
            cboStorage.Name = "cboStorage";
            cboStorage.Size = new Size(576, 23);
            cboStorage.TabIndex = 5;
            cboStorage.Leave += comboListMaintenance;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 144);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 22;
            label3.Text = "Quantity";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(125, 142);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(119, 23);
            txtQuantity.TabIndex = 2;
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
            label4.Location = new Point(65, 38);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 24;
            label4.Text = "Item ID";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboCategory
            // 
            cboCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(125, 70);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(576, 23);
            cboCategory.TabIndex = 0;
            cboCategory.Leave += comboListMaintenance;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 74);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 26;
            label5.Text = "Category";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmAdd
            // 
            AcceptButton = btnSaveAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(753, 351);
            Controls.Add(cboCategory);
            Controls.Add(label5);
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
            Load += frmAdd_Load;
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
        private ComboBox cboCategory;
        private Label label5;
    }
}