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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllItems));
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
            dtpBuy = new DateTimePicker();
            dtpSaleDate = new DateTimePicker();
            btnSave = new Button();
            btnAddAnother = new Button();
            btnClose = new Button();
            btnRetrieve = new Button();
            btnDelete = new Button();
            lblTask = new Label();
            btnSearch = new Button();
            label13 = new Label();
            label14 = new Label();
            cboStorage = new ComboBox();
            cboBrand = new ComboBox();
            cboPurchaseSource = new ComboBox();
            cboWhereListed = new ComboBox();
            dtpDateListed = new DateTimePicker();
            label12 = new Label();
            label15 = new Label();
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
            txtID.Size = new Size(338, 34);
            txtID.TabIndex = 0;
            txtID.Tag = "ItemID";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(35, 155);
            label2.Name = "label2";
            label2.Size = new Size(200, 25);
            label2.TabIndex = 2;
            label2.Text = "Category";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(242, 236);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(338, 34);
            txtDesc.TabIndex = 3;
            txtDesc.Tag = "ItemDesc";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(36, 239);
            label3.Name = "label3";
            label3.Size = new Size(200, 25);
            label3.TabIndex = 4;
            label3.Text = "Description";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(242, 316);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(338, 34);
            txtQuantity.TabIndex = 5;
            txtQuantity.Tag = "Quantity";
            txtQuantity.Text = "1";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(36, 321);
            label4.Name = "label4";
            label4.Size = new Size(200, 25);
            label4.TabIndex = 6;
            label4.Text = "Quantity";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(36, 360);
            label5.Name = "label5";
            label5.Size = new Size(200, 25);
            label5.TabIndex = 8;
            label5.Text = "Purchase Date";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(242, 394);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(338, 34);
            txtPurchasePrice.TabIndex = 7;
            txtPurchasePrice.Tag = "PurchasePrice";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(36, 398);
            label6.Name = "label6";
            label6.Size = new Size(200, 25);
            label6.TabIndex = 10;
            label6.Text = "Purchase Price";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 11.25F);
            label7.Location = new Point(36, 599);
            label7.Name = "label7";
            label7.Size = new Size(200, 25);
            label7.TabIndex = 12;
            label7.Text = "Sale Date";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(243, 557);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(338, 34);
            txtPrice.TabIndex = 9;
            txtPrice.Tag = "SalePrice";
            txtPrice.Leave += txtPrice_Leave;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(36, 562);
            label8.Name = "label8";
            label8.Size = new Size(200, 25);
            label8.TabIndex = 14;
            label8.Text = "Sale Price";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 11.25F);
            label9.Location = new Point(36, 440);
            label9.Name = "label9";
            label9.Size = new Size(200, 25);
            label9.TabIndex = 16;
            label9.Text = "Storage Location";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtProfit
            // 
            txtProfit.Enabled = false;
            txtProfit.Location = new Point(243, 635);
            txtProfit.Name = "txtProfit";
            txtProfit.Size = new Size(338, 34);
            txtProfit.TabIndex = 11;
            txtProfit.Tag = "Profit";
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 11.25F);
            label10.Location = new Point(37, 640);
            label10.Name = "label10";
            label10.Size = new Size(200, 25);
            label10.TabIndex = 18;
            label10.Text = "Profit";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDaysHeld
            // 
            txtDaysHeld.Enabled = false;
            txtDaysHeld.Location = new Point(243, 674);
            txtDaysHeld.Name = "txtDaysHeld";
            txtDaysHeld.Size = new Size(338, 34);
            txtDaysHeld.TabIndex = 12;
            txtDaysHeld.Tag = "ProductAge";
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 11.25F);
            label11.Location = new Point(37, 679);
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
            cboCategory.Size = new Size(339, 36);
            cboCategory.TabIndex = 1;
            cboCategory.Tag = "Category";
            cboCategory.Leave += cboCategory_Leave;
            // 
            // dtpBuy
            // 
            dtpBuy.Location = new Point(242, 355);
            dtpBuy.Name = "dtpBuy";
            dtpBuy.Size = new Size(338, 34);
            dtpBuy.TabIndex = 6;
            dtpBuy.Tag = "PurchaseDate";
            // 
            // dtpSaleDate
            // 
            dtpSaleDate.Location = new Point(243, 596);
            dtpSaleDate.Name = "dtpSaleDate";
            dtpSaleDate.Size = new Size(338, 34);
            dtpSaleDate.TabIndex = 10;
            dtpSaleDate.Tag = "SaleDate";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 255, 192);
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(742, 185);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(190, 58);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddAnother
            // 
            btnAddAnother.BackColor = Color.FromArgb(192, 255, 192);
            btnAddAnother.Image = Properties.Resources._8666610_plus_square_icon;
            btnAddAnother.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddAnother.Location = new Point(742, 253);
            btnAddAnother.Name = "btnAddAnother";
            btnAddAnother.Size = new Size(190, 50);
            btnAddAnother.TabIndex = 15;
            btnAddAnother.Text = "Add Another";
            btnAddAnother.TextAlign = ContentAlignment.MiddleRight;
            btnAddAnother.UseVisualStyleBackColor = false;
            btnAddAnother.Click += btnAddAnother_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(192, 255, 192);
            btnClose.Image = Properties.Resources._5402366_delete_remove_cross_cancel_close_icon;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(742, 478);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(190, 50);
            btnClose.TabIndex = 18;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.MiddleRight;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnRetrieve
            // 
            btnRetrieve.BackColor = Color.FromArgb(192, 255, 192);
            btnRetrieve.Image = Properties.Resources._8140873_pos_billing_retrieve_download_revoke_icon;
            btnRetrieve.ImageAlign = ContentAlignment.MiddleLeft;
            btnRetrieve.Location = new Point(742, 123);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(190, 50);
            btnRetrieve.TabIndex = 13;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.TextAlign = ContentAlignment.MiddleRight;
            btnRetrieve.UseVisualStyleBackColor = false;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 255, 192);
            btnDelete.Image = Properties.Resources._8666786_x_octagon_delete_icon;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(742, 318);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(190, 50);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete Item";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = false;
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
            btnSearch.BackColor = Color.FromArgb(192, 255, 192);
            btnSearch.Image = Properties.Resources._8666693_search_icon;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(742, 386);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(190, 50);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Search";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 11.25F);
            label13.Location = new Point(33, 204);
            label13.Name = "label13";
            label13.Size = new Size(200, 25);
            label13.TabIndex = 25;
            label13.Text = "Purchase Source";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 11.25F);
            label14.Location = new Point(36, 285);
            label14.Name = "label14";
            label14.Size = new Size(200, 25);
            label14.TabIndex = 26;
            label14.Text = "Brand";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboStorage
            // 
            cboStorage.FormattingEnabled = true;
            cboStorage.Location = new Point(242, 433);
            cboStorage.Name = "cboStorage";
            cboStorage.Size = new Size(338, 36);
            cboStorage.TabIndex = 8;
            cboStorage.Leave += cboStorage_Leave;
            // 
            // cboBrand
            // 
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboBrand.FormattingEnabled = true;
            cboBrand.Location = new Point(242, 275);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(338, 36);
            cboBrand.TabIndex = 4;
            cboBrand.Tag = "Brand";
            cboBrand.Leave += cboBrand_Leave;
            // 
            // cboPurchaseSource
            // 
            cboPurchaseSource.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPurchaseSource.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboPurchaseSource.FormattingEnabled = true;
            cboPurchaseSource.Location = new Point(242, 196);
            cboPurchaseSource.Name = "cboPurchaseSource";
            cboPurchaseSource.Size = new Size(339, 36);
            cboPurchaseSource.TabIndex = 2;
            cboPurchaseSource.Tag = "Category";
            cboPurchaseSource.Leave += cboPurchaseSource_Leave_1;
            // 
            // cboWhereListed
            // 
            cboWhereListed.FormattingEnabled = true;
            cboWhereListed.Location = new Point(243, 475);
            cboWhereListed.Name = "cboWhereListed";
            cboWhereListed.Size = new Size(338, 36);
            cboWhereListed.TabIndex = 27;
            cboWhereListed.Tag = "WhereListed";
            cboWhereListed.Leave += cboWhereListed_Leave;
            // 
            // dtpDateListed
            // 
            dtpDateListed.Location = new Point(242, 517);
            dtpDateListed.Name = "dtpDateListed";
            dtpDateListed.Size = new Size(339, 34);
            dtpDateListed.TabIndex = 28;
            dtpDateListed.Tag = "ListingDate";
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 11.25F);
            label12.Location = new Point(37, 486);
            label12.Name = "label12";
            label12.Size = new Size(200, 25);
            label12.TabIndex = 29;
            label12.Text = "Where Listed";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Font = new Font("Segoe UI", 11.25F);
            label15.Location = new Point(37, 525);
            label15.Name = "label15";
            label15.Size = new Size(200, 25);
            label15.TabIndex = 30;
            label15.Text = "Date Listed";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmAllItems
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 866);
            Controls.Add(label15);
            Controls.Add(label12);
            Controls.Add(dtpDateListed);
            Controls.Add(cboWhereListed);
            Controls.Add(cboPurchaseSource);
            Controls.Add(cboBrand);
            Controls.Add(cboStorage);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(btnSearch);
            Controls.Add(lblTask);
            Controls.Add(btnDelete);
            Controls.Add(btnRetrieve);
            Controls.Add(btnClose);
            Controls.Add(btnAddAnother);
            Controls.Add(btnSave);
            Controls.Add(dtpSaleDate);
            Controls.Add(dtpBuy);
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
        public static ComboBox cboCategory;
        private DateTimePicker dtpBuy;
        private DateTimePicker dtpSaleDate;
        private Button btnSave;
        private Button btnAddAnother;
        private Button btnClose;
        private Button btnRetrieve;
        private Button btnDelete;
        private Label lblTask;
        private Button btnSearch;
        private Label label13;
        private Label label14;
        public static ComboBox cboStorage;
        public static ComboBox cboBrand;
        public static ComboBox cboPurchaseSource;
        public static ComboBox cboWhereListed;
        private DateTimePicker dtpDateListed;
        private Label label12;
        private Label label15;
    }
}