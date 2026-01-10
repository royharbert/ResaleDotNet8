namespace ResaleV8
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            soldItemReportToolStripMenuItem = new ToolStripMenuItem();
            unsoldItemToolStripMenuItem = new ToolStripMenuItem();
            editRecordToolStripMenuItem = new ToolStripMenuItem();
            addItemToolStripMenuItem1 = new ToolStripMenuItem();
            editItemToolStripMenuItem = new ToolStripMenuItem();
            deleteItemToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            dropDownEditToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            purchaseSourceToolStripMenuItem = new ToolStripMenuItem();
            brandToolStripMenuItem = new ToolStripMenuItem();
            sToolStripMenuItem = new ToolStripMenuItem();
            whereListedToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, reportsToolStripMenuItem, editRecordToolStripMenuItem, dropDownEditToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(2069, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(270, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { soldItemReportToolStripMenuItem, unsoldItemToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(94, 29);
            reportsToolStripMenuItem.Text = " Reports";
            // 
            // soldItemReportToolStripMenuItem
            // 
            soldItemReportToolStripMenuItem.Name = "soldItemReportToolStripMenuItem";
            soldItemReportToolStripMenuItem.Size = new Size(269, 34);
            soldItemReportToolStripMenuItem.Text = "Sold Item Report";
            soldItemReportToolStripMenuItem.Click += soldItemReportToolStripMenuItem_Click;
            // 
            // unsoldItemToolStripMenuItem
            // 
            unsoldItemToolStripMenuItem.Name = "unsoldItemToolStripMenuItem";
            unsoldItemToolStripMenuItem.Size = new Size(269, 34);
            unsoldItemToolStripMenuItem.Text = "Unsold Item Report";
            unsoldItemToolStripMenuItem.Click += unsoldItemToolStripMenuItem_Click;
            // 
            // editRecordToolStripMenuItem
            // 
            editRecordToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addItemToolStripMenuItem1, editItemToolStripMenuItem, deleteItemToolStripMenuItem, searchToolStripMenuItem });
            editRecordToolStripMenuItem.Name = "editRecordToolStripMenuItem";
            editRecordToolStripMenuItem.Size = new Size(208, 29);
            editRecordToolStripMenuItem.Text = "Inventory Maintenance";
            editRecordToolStripMenuItem.Click += editRecordToolStripMenuItem_Click;
            // 
            // addItemToolStripMenuItem1
            // 
            addItemToolStripMenuItem1.Name = "addItemToolStripMenuItem1";
            addItemToolStripMenuItem1.Size = new Size(205, 34);
            addItemToolStripMenuItem1.Text = "Add Item";
            addItemToolStripMenuItem1.Click += addItemToolStripMenuItem1_Click;
            // 
            // editItemToolStripMenuItem
            // 
            editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            editItemToolStripMenuItem.Size = new Size(205, 34);
            editItemToolStripMenuItem.Text = "Edit Item";
            editItemToolStripMenuItem.Click += editItemToolStripMenuItem_Click;
            // 
            // deleteItemToolStripMenuItem
            // 
            deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            deleteItemToolStripMenuItem.Size = new Size(205, 34);
            deleteItemToolStripMenuItem.Text = "Delete Item";
            deleteItemToolStripMenuItem.Click += deleteItemToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(205, 34);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // dropDownEditToolStripMenuItem
            // 
            dropDownEditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriesToolStripMenuItem, purchaseSourceToolStripMenuItem, brandToolStripMenuItem, sToolStripMenuItem, whereListedToolStripMenuItem });
            dropDownEditToolStripMenuItem.Name = "dropDownEditToolStripMenuItem";
            dropDownEditToolStripMenuItem.Size = new Size(156, 29);
            dropDownEditToolStripMenuItem.Text = "Drop Down Edit";
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(255, 34);
            categoriesToolStripMenuItem.Text = "Categories";
            categoriesToolStripMenuItem.Click += categoriesToolStripMenuItem_Click;
            // 
            // purchaseSourceToolStripMenuItem
            // 
            purchaseSourceToolStripMenuItem.Name = "purchaseSourceToolStripMenuItem";
            purchaseSourceToolStripMenuItem.Size = new Size(255, 34);
            purchaseSourceToolStripMenuItem.Text = "Purchase Source";
            purchaseSourceToolStripMenuItem.Click += purchaseSourceToolStripMenuItem_Click;
            // 
            // brandToolStripMenuItem
            // 
            brandToolStripMenuItem.Name = "brandToolStripMenuItem";
            brandToolStripMenuItem.Size = new Size(255, 34);
            brandToolStripMenuItem.Text = "Brand";
            brandToolStripMenuItem.Click += brandToolStripMenuItem_Click;
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(255, 34);
            sToolStripMenuItem.Text = "Storage Locations";
            sToolStripMenuItem.Click += sToolStripMenuItem_Click;
            // 
            // whereListedToolStripMenuItem
            // 
            whereListedToolStripMenuItem.Name = "whereListedToolStripMenuItem";
            whereListedToolStripMenuItem.Size = new Size(255, 34);
            whereListedToolStripMenuItem.Text = "Where Listed";
            whereListedToolStripMenuItem.Click += whereListedToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2069, 1298);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmMain";
            Text = "Resale Database";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem soldItemReportToolStripMenuItem;
        private ToolStripMenuItem unsoldItemToolStripMenuItem;
        private ToolStripMenuItem editRecordToolStripMenuItem;
        private ToolStripMenuItem addItemToolStripMenuItem1;
        private ToolStripMenuItem editItemToolStripMenuItem;
        private ToolStripMenuItem deleteItemToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem dropDownEditToolStripMenuItem;
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private ToolStripMenuItem purchaseSourceToolStripMenuItem;
        private ToolStripMenuItem brandToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem whereListedToolStripMenuItem;
    }
}