namespace ResaleV8
{
    partial class frmAllItems
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
            txtID = new TextBox();
            label2 = new Label();
            txtDesc = new TextBox();
            label3 = new Label();
            txtQuantity = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtPurchasePrice = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtPrice = new TextBox();
            label8 = new Label();
            label9 = new Label();
            txtProfit = new TextBox();
            label10 = new Label();
            txtDaysHeld = new TextBox();
            label11 = new Label();
            cboCategory = new ComboBox();
            cboStorage = new ComboBox();
            dtpBuy = new DateTimePicker();
            dtpSaleDate = new DateTimePicker();
            btnSave = new Button();
            btnAddAnother = new Button();
            btnClose = new Button();
            btnRetrieve = new Button();
            btnDelete = new Button();
            lblTask = new Label();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(36, 119);
            label1.Name = "label1";
            label1.Size = new Size(200, 25);
            label1.TabIndex = 0;
            label1.Text = "Item ID#";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(242, 115);
            txtID.Name = "txtID";
            txtID.Size = new Size(338, 29);
            txtID.TabIndex = 0;
            txtID.Tag = "ItemID";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(36, 154);
            label2.Name = "label2";
            label2.Size = new Size(200, 25);
            label2.TabIndex = 2;
            label2.Text = "Category";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(242, 195);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(338, 29);
            txtDesc.TabIndex = 2;
            txtDesc.Tag = "ItemDesc";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(36, 195);
            label3.Name = "label3";
            label3.Size = new Size(200, 25);
            label3.TabIndex = 4;
            label3.Text = "Description";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(242, 234);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(338, 29);
            txtQuantity.TabIndex = 3;
            txtQuantity.Tag = "Quantity";
            txtQuantity.Text = "1";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(36, 234);
            label4.Name = "label4";
            label4.Size = new Size(200, 25);
            label4.TabIndex = 6;
            label4.Text = "Quantity";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(36, 273);
            label5.Name = "label5";
            label5.Size = new Size(200, 25);
            label5.TabIndex = 8;
            label5.Text = "Purchase Date";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(242, 311);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(338, 29);
            txtPurchasePrice.TabIndex = 5;
            txtPurchasePrice.Tag = "PurchasePrice";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(36, 311);
            label6.Name = "label6";
            label6.Size = new Size(200, 25);
            label6.TabIndex = 10;
            label6.Text = "Purchase Price";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 11.25F);
            label7.Location = new Point(35, 429);
            label7.Name = "label7";
            label7.Size = new Size(200, 25);
            label7.TabIndex = 12;
            label7.Text = "Sale Date";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(241, 390);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(338, 29);
            txtPrice.TabIndex = 8;
            txtPrice.Tag = "SalePrice";
            txtPrice.Leave += txtPrice_Leave;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(35, 392);
            label8.Name = "label8";
            label8.Size = new Size(200, 25);
            label8.TabIndex = 14;
            label8.Text = "Sale Price";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 11.25F);
            label9.Location = new Point(36, 353);
            label9.Name = "label9";
            label9.Size = new Size(200, 25);
            label9.TabIndex = 16;
            label9.Text = "Storage Location";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtProfit
            // 
            txtProfit.Enabled = false;
            txtProfit.Location = new Point(242, 470);
            txtProfit.Name = "txtProfit";
            txtProfit.Size = new Size(338, 29);
            txtProfit.TabIndex = 9;
            txtProfit.Tag = "Profit";
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 11.25F);
            label10.Location = new Point(36, 470);
            label10.Name = "label10";
            label10.Size = new Size(200, 25);
            label10.TabIndex = 18;
            label10.Text = "Profit";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDaysHeld
            // 
            txtDaysHeld.Enabled = false;
            txtDaysHeld.Location = new Point(242, 509);
            txtDaysHeld.Name = "txtDaysHeld";
            txtDaysHeld.Size = new Size(338, 29);
            txtDaysHeld.TabIndex = 10;
            txtDaysHeld.Tag = "ProductAge";
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 11.25F);
            label11.Location = new Point(36, 509);
            label11.Name = "label11";
            label11.Size = new Size(200, 25);
            label11.TabIndex = 20;
            label11.Text = "Days Held";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboCategory
            // 
            cboCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(242, 154);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(339, 29);
            cboCategory.TabIndex = 1;
            cboCategory.Tag = "Category";
            cboCategory.Leave += cboCategory_Leave;
            // 
            // cboStorage
            // 
            cboStorage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboStorage.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboStorage.FormattingEnabled = true;
            cboStorage.Location = new Point(242, 349);
            cboStorage.Name = "cboStorage";
            cboStorage.Size = new Size(337, 29);
            cboStorage.TabIndex = 6;
            // 
            // dtpBuy
            // 
            dtpBuy.Location = new Point(242, 273);
            dtpBuy.Name = "dtpBuy";
            dtpBuy.Size = new Size(338, 29);
            dtpBuy.TabIndex = 4;
            dtpBuy.Tag = "PurchaseDate";
            // 
            // dtpSaleDate
            // 
            dtpSaleDate.Location = new Point(241, 429);
            dtpSaleDate.Name = "dtpSaleDate";
            dtpSaleDate.Size = new Size(338, 29);
            dtpSaleDate.TabIndex = 7;
            dtpSaleDate.Tag = "SaleDate";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(790, 180);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(149, 50);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddAnother
            // 
            btnAddAnother.Location = new Point(790, 245);
            btnAddAnother.Name = "btnAddAnother";
            btnAddAnother.Size = new Size(149, 50);
            btnAddAnother.TabIndex = 13;
            btnAddAnother.Text = "Add Another";
            btnAddAnother.UseVisualStyleBackColor = true;
            btnAddAnother.Click += btnAddAnother_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(790, 470);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(149, 50);
            btnClose.TabIndex = 14;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new Point(790, 115);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(149, 50);
            btnRetrieve.TabIndex = 11;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(790, 310);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(149, 50);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Delete Item";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // lblTask
            // 
            lblTask.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTask.Location = new Point(389, 33);
            lblTask.Name = "lblTask";
            lblTask.Size = new Size(276, 41);
            lblTask.TabIndex = 22;
            lblTask.Text = "label12";
            lblTask.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(790, 378);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(149, 50);
            btnSearch.TabIndex = 23;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // frmAllItems
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 630);
            Controls.Add(btnSearch);
            Controls.Add(lblTask);
            Controls.Add(btnDelete);
            Controls.Add(btnRetrieve);
            Controls.Add(btnClose);
            Controls.Add(btnAddAnother);
            Controls.Add(btnSave);
            Controls.Add(dtpSaleDate);
            Controls.Add(dtpBuy);
            Controls.Add(cboStorage);
            Controls.Add(cboCategory);
            Controls.Add(txtDaysHeld);
            Controls.Add(label11);
            Controls.Add(txtProfit);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtPrice);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtPurchasePrice);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtQuantity);
            Controls.Add(label4);
            Controls.Add(txtDesc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtID);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmAllItems";
            Text = "Resale Items";
            Load += frmAllItems_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtID;
        private Label label2;
        private TextBox txtDesc;
        private Label label3;
        private TextBox txtQuantity;
        private Label label4;
        private Label label5;
        private TextBox txtPurchasePrice;
        private Label label6;
        private Label label7;
        private TextBox txtPrice;
        private Label label8;
        private Label label9;
        private TextBox txtProfit;
        private Label label10;
        private TextBox txtDaysHeld;
        private Label label11;
        private ComboBox cboCategory;
        private ComboBox cboStorage;
        private DateTimePicker dtpBuy;
        private DateTimePicker dtpSaleDate;
        private Button btnSave;
        private Button btnAddAnother;
        private Button btnClose;
        private Button btnRetrieve;
        private Button btnDelete;
        private Label lblTask;
        private Button btnSearch;
    }
}