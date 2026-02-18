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
            txtListPrice = new TextBox();
            label16 = new Label();
            txtCostOfSale = new TextBox();
            label17 = new Label();
            txtSKU = new TextBox();
            label18 = new Label();
            txtDiscountPct = new TextBox();
            label19 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(89, 116);
            label1.Name = "label1";
            label1.Size = new Size(210, 32);
            label1.TabIndex = 0;
            label1.Text = "Item ID#";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(320, 116);
            txtID.Name = "txtID";
            txtID.Size = new Size(394, 29);
            txtID.TabIndex = 0;
            txtID.Tag = "ItemID";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(89, 214);
            label2.Name = "label2";
            label2.Size = new Size(210, 32);
            label2.TabIndex = 2;
            label2.Text = "Category";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(320, 260);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(394, 29);
            txtDesc.TabIndex = 3;
            txtDesc.Tag = "ItemDesc";
            txtDesc.TextChanged += txtDesc_TextChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(88, 263);
            label3.Name = "label3";
            label3.Size = new Size(210, 32);
            label3.TabIndex = 4;
            label3.Text = "Description";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(320, 407);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(394, 29);
            txtQuantity.TabIndex = 6;
            txtQuantity.Tag = "Quantity";
            txtQuantity.Text = "1";
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(89, 410);
            label4.Name = "label4";
            label4.Size = new Size(210, 32);
            label4.TabIndex = 6;
            label4.Text = "Quantity";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(89, 361);
            label5.Name = "label5";
            label5.Size = new Size(210, 32);
            label5.TabIndex = 8;
            label5.Text = "Purchase Date";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(322, 455);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(394, 29);
            txtPurchasePrice.TabIndex = 7;
            txtPurchasePrice.Tag = "PurchasePrice";
            txtPurchasePrice.TextChanged += txtPurchasePrice_TextChanged;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(91, 456);
            label6.Name = "label6";
            label6.Size = new Size(210, 32);
            label6.TabIndex = 10;
            label6.Text = "Purchase Price";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 11.25F);
            label7.Location = new Point(726, 444);
            label7.Name = "label7";
            label7.Size = new Size(146, 27);
            label7.TabIndex = 12;
            label7.Text = "Sale Date";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(879, 246);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(415, 29);
            txtPrice.TabIndex = 12;
            txtPrice.Tag = "SalePrice";
            txtPrice.TextChanged += txtPrice_TextChanged;
            txtPrice.Leave += txtPrice_Leave;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(726, 248);
            label8.Name = "label8";
            label8.Size = new Size(146, 27);
            label8.TabIndex = 14;
            label8.Text = "Sale Price";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 11.25F);
            label9.Location = new Point(89, 616);
            label9.Name = "label9";
            label9.Size = new Size(210, 32);
            label9.TabIndex = 16;
            label9.Text = "Storage Location";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtProfit
            // 
            txtProfit.Enabled = false;
            txtProfit.Location = new Point(876, 505);
            txtProfit.Name = "txtProfit";
            txtProfit.Size = new Size(415, 29);
            txtProfit.TabIndex = 14;
            txtProfit.Tag = "Profit";
            txtProfit.TextChanged += txtProfit_TextChanged;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 11.25F);
            label10.Location = new Point(724, 508);
            label10.Name = "label10";
            label10.Size = new Size(146, 27);
            label10.TabIndex = 18;
            label10.Text = "Profit";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDaysHeld
            // 
            txtDaysHeld.Enabled = false;
            txtDaysHeld.Location = new Point(876, 572);
            txtDaysHeld.Name = "txtDaysHeld";
            txtDaysHeld.Size = new Size(415, 29);
            txtDaysHeld.TabIndex = 15;
            txtDaysHeld.Tag = "ProductAge";
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 11.25F);
            label11.Location = new Point(726, 573);
            label11.Name = "label11";
            label11.Size = new Size(146, 27);
            label11.TabIndex = 20;
            label11.Text = "Days Held";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboCategory
            // 
            cboCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(321, 212);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(395, 29);
            cboCategory.Sorted = true;
            cboCategory.TabIndex = 2;
            cboCategory.Tag = "Category";
            cboCategory.TextUpdate += cboCategory_TextUpdate;
            cboCategory.Leave += cboCategory_Leave;
            // 
            // dtpBuy
            // 
            dtpBuy.Location = new Point(320, 359);
            dtpBuy.Name = "dtpBuy";
            dtpBuy.Size = new Size(394, 29);
            dtpBuy.TabIndex = 5;
            dtpBuy.Tag = "PurchaseDate";
            dtpBuy.ValueChanged += dtpBuy_ValueChanged;
            // 
            // dtpSaleDate
            // 
            dtpSaleDate.Location = new Point(879, 442);
            dtpSaleDate.Name = "dtpSaleDate";
            dtpSaleDate.Size = new Size(415, 29);
            dtpSaleDate.TabIndex = 13;
            dtpSaleDate.Tag = "SaleDate";
            dtpSaleDate.ValueChanged += dtpSaleDate_ValueChanged;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 255, 192);
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(1388, 279);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(190, 58);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(192, 255, 192);
            btnClose.Image = Properties.Resources._5402366_delete_remove_cross_cancel_close_icon;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(1388, 615);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(190, 50);
            btnClose.TabIndex = 20;
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
            btnRetrieve.Location = new Point(1388, 214);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(190, 50);
            btnRetrieve.TabIndex = 16;
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
            btnDelete.Location = new Point(1388, 353);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(190, 50);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete Item";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // lblTask
            // 
            lblTask.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTask.Location = new Point(652, 20);
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
            btnSearch.Location = new Point(1388, 421);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(190, 50);
            btnSearch.TabIndex = 19;
            btnSearch.Text = "Search";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 11.25F);
            label13.Location = new Point(88, 311);
            label13.Name = "label13";
            label13.Size = new Size(210, 32);
            label13.TabIndex = 25;
            label13.Text = "Purchase Source";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 11.25F);
            label14.Location = new Point(88, 166);
            label14.Name = "label14";
            label14.Size = new Size(210, 32);
            label14.TabIndex = 26;
            label14.Text = "Brand";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboStorage
            // 
            cboStorage.FormattingEnabled = true;
            cboStorage.Location = new Point(320, 615);
            cboStorage.Name = "cboStorage";
            cboStorage.Size = new Size(394, 29);
            cboStorage.Sorted = true;
            cboStorage.TabIndex = 9;
            cboStorage.TextChanged += cboStorage_TextChanged;
            cboStorage.Leave += cboStorage_Leave;
            // 
            // cboBrand
            // 
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboBrand.FormattingEnabled = true;
            cboBrand.Location = new Point(320, 164);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(394, 29);
            cboBrand.Sorted = true;
            cboBrand.TabIndex = 1;
            cboBrand.Tag = "Brand";
            cboBrand.TextChanged += cboBrand_TextChanged;
            cboBrand.Leave += cboBrand_Leave;
            // 
            // cboPurchaseSource
            // 
            cboPurchaseSource.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPurchaseSource.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboPurchaseSource.FormattingEnabled = true;
            cboPurchaseSource.Location = new Point(320, 308);
            cboPurchaseSource.Name = "cboPurchaseSource";
            cboPurchaseSource.Size = new Size(395, 29);
            cboPurchaseSource.Sorted = true;
            cboPurchaseSource.TabIndex = 4;
            cboPurchaseSource.Tag = "Category";
            cboPurchaseSource.TextChanged += cboPurchaseSource_TextChanged;
            cboPurchaseSource.Leave += cboPurchaseSource_Leave_1;
            // 
            // cboWhereListed
            // 
            cboWhereListed.FormattingEnabled = true;
            cboWhereListed.Location = new Point(320, 506);
            cboWhereListed.Name = "cboWhereListed";
            cboWhereListed.Size = new Size(394, 29);
            cboWhereListed.Sorted = true;
            cboWhereListed.TabIndex = 8;
            cboWhereListed.Tag = "WhereListed";
            cboWhereListed.TextChanged += cboWhereListed_TextChanged;
            cboWhereListed.Leave += cboWhereListed_Leave;
            // 
            // dtpDateListed
            // 
            dtpDateListed.Location = new Point(322, 666);
            dtpDateListed.Name = "dtpDateListed";
            dtpDateListed.Size = new Size(395, 29);
            dtpDateListed.TabIndex = 10;
            dtpDateListed.Tag = "ListingDate";
            dtpDateListed.ValueChanged += dtpDateListed_ValueChanged;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 11.25F);
            label12.Location = new Point(89, 510);
            label12.Name = "label12";
            label12.Size = new Size(210, 32);
            label12.TabIndex = 29;
            label12.Text = "Where Listed";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Font = new Font("Segoe UI", 11.25F);
            label15.Location = new Point(92, 670);
            label15.Name = "label15";
            label15.Size = new Size(210, 30);
            label15.TabIndex = 30;
            label15.Text = "Date Listed";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtListPrice
            // 
            txtListPrice.Location = new Point(321, 718);
            txtListPrice.Name = "txtListPrice";
            txtListPrice.Size = new Size(394, 29);
            txtListPrice.TabIndex = 11;
            txtListPrice.Tag = "ListPrice";
            txtListPrice.TextChanged += txtListPrice_TextChanged;
            // 
            // label16
            // 
            label16.Font = new Font("Segoe UI", 11.25F);
            label16.Location = new Point(90, 720);
            label16.Name = "label16";
            label16.Size = new Size(210, 30);
            label16.TabIndex = 32;
            label16.Text = "List Price";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCostOfSale
            // 
            txtCostOfSale.Location = new Point(876, 311);
            txtCostOfSale.Name = "txtCostOfSale";
            txtCostOfSale.Size = new Size(415, 29);
            txtCostOfSale.TabIndex = 33;
            txtCostOfSale.Tag = "SalePrice";
            txtCostOfSale.TextChanged += txtCostOfSale_TextChanged;
            txtCostOfSale.Leave += txtCostOfSale_Leave;
            // 
            // label17
            // 
            label17.Font = new Font("Segoe UI", 11.25F);
            label17.Location = new Point(723, 313);
            label17.Name = "label17";
            label17.Size = new Size(146, 27);
            label17.TabIndex = 34;
            label17.Text = "Cost of Sale";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSKU
            // 
            txtSKU.Location = new Point(323, 559);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(394, 29);
            txtSKU.TabIndex = 35;
            txtSKU.Tag = "ListerSKU";
            txtSKU.TextChanged += txtSKU_TextChanged;
            // 
            // label18
            // 
            label18.Font = new Font("Segoe UI", 11.25F);
            label18.Location = new Point(92, 561);
            label18.Name = "label18";
            label18.Size = new Size(210, 30);
            label18.TabIndex = 36;
            label18.Text = "Lister SKU";
            label18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDiscountPct
            // 
            txtDiscountPct.Location = new Point(879, 374);
            txtDiscountPct.Name = "txtDiscountPct";
            txtDiscountPct.Size = new Size(415, 29);
            txtDiscountPct.TabIndex = 37;
            txtDiscountPct.Tag = "DiscountPct";
            txtDiscountPct.TextChanged += txtDiscountPct_TextChanged;
            // 
            // label19
            // 
            label19.Font = new Font("Segoe UI", 11.25F);
            label19.Location = new Point(726, 376);
            label19.Name = "label19";
            label19.Size = new Size(146, 27);
            label19.TabIndex = 38;
            label19.Text = "Discount %";
            label19.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmAllItems
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1630, 786);
            Controls.Add(txtDiscountPct);
            Controls.Add(label19);
            Controls.Add(txtSKU);
            Controls.Add(label18);
            Controls.Add(txtCostOfSale);
            Controls.Add(label17);
            Controls.Add(txtListPrice);
            Controls.Add(label16);
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
            WindowState = FormWindowState.Maximized;
            Activated += frmAllItems_Activated;
            FormClosing += frmAllItems_FormClosing;
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
        private DateTimePicker dtpBuy;
        private DateTimePicker dtpSaleDate;
        private Button btnSave;
        private Button btnClose;
        private Button btnRetrieve;
        private Button btnDelete;
        private Label lblTask;
        private Button btnSearch;
        private Label label13;
        private Label label14;
        private DateTimePicker dtpDateListed;
        private Label label12;
        private Label label15;
        private TextBox txtListPrice;
        private Label label16;
        public ComboBox cboCategory;
        public ComboBox cboStorage;
        public ComboBox cboBrand;
        public ComboBox cboPurchaseSource;
        public ComboBox cboWhereListed;
        private TextBox txtCostOfSale;
        private Label label17;
        private TextBox txtSKU;
        private Label label18;
        private TextBox txtDiscountPct;
        private Label label19;
    }
}