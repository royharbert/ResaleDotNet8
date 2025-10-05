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
            inventoryToolStripMenuItem = new ToolStripMenuItem();
            addItemToolStripMenuItem = new ToolStripMenuItem();
            markIemAsSoldToolStripMenuItem = new ToolStripMenuItem();
            removeItemToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            soldItemReportToolStripMenuItem = new ToolStripMenuItem();
            unsoldItemToolStripMenuItem = new ToolStripMenuItem();
            editRecordToolStripMenuItem = new ToolStripMenuItem();
            addItemToolStripMenuItem1 = new ToolStripMenuItem();
            editItemToolStripMenuItem = new ToolStripMenuItem();
            deleteItemToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, inventoryToolStripMenuItem, reportsToolStripMenuItem, editRecordToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1448, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // inventoryToolStripMenuItem
            // 
            inventoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addItemToolStripMenuItem, markIemAsSoldToolStripMenuItem, removeItemToolStripMenuItem });
            inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            inventoryToolStripMenuItem.Size = new Size(69, 20);
            inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // addItemToolStripMenuItem
            // 
            addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            addItemToolStripMenuItem.Size = new Size(168, 22);
            addItemToolStripMenuItem.Text = "Add Item";
            addItemToolStripMenuItem.Click += addItemToolStripMenuItem_Click;
            // 
            // markIemAsSoldToolStripMenuItem
            // 
            markIemAsSoldToolStripMenuItem.Name = "markIemAsSoldToolStripMenuItem";
            markIemAsSoldToolStripMenuItem.Size = new Size(168, 22);
            markIemAsSoldToolStripMenuItem.Text = "Mark Item as Sold";
            markIemAsSoldToolStripMenuItem.Click += markIemAsSoldToolStripMenuItem_Click;
            // 
            // removeItemToolStripMenuItem
            // 
            removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            removeItemToolStripMenuItem.Size = new Size(168, 22);
            removeItemToolStripMenuItem.Text = "Remove Item";
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { soldItemReportToolStripMenuItem, unsoldItemToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(62, 20);
            reportsToolStripMenuItem.Text = " Reports";
            // 
            // soldItemReportToolStripMenuItem
            // 
            soldItemReportToolStripMenuItem.Name = "soldItemReportToolStripMenuItem";
            soldItemReportToolStripMenuItem.Size = new Size(176, 22);
            soldItemReportToolStripMenuItem.Text = "Sold Item Report";
            soldItemReportToolStripMenuItem.Click += soldItemReportToolStripMenuItem_Click;
            // 
            // unsoldItemToolStripMenuItem
            // 
            unsoldItemToolStripMenuItem.Name = "unsoldItemToolStripMenuItem";
            unsoldItemToolStripMenuItem.Size = new Size(176, 22);
            unsoldItemToolStripMenuItem.Text = "Unsold Item Report";
            unsoldItemToolStripMenuItem.Click += unsoldItemToolStripMenuItem_Click;
            // 
            // editRecordToolStripMenuItem
            // 
            editRecordToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addItemToolStripMenuItem1, editItemToolStripMenuItem, deleteItemToolStripMenuItem });
            editRecordToolStripMenuItem.Name = "editRecordToolStripMenuItem";
            editRecordToolStripMenuItem.Size = new Size(79, 20);
            editRecordToolStripMenuItem.Text = "Edit Record";
            editRecordToolStripMenuItem.Click += editRecordToolStripMenuItem_Click;
            // 
            // addItemToolStripMenuItem1
            // 
            addItemToolStripMenuItem1.Name = "addItemToolStripMenuItem1";
            addItemToolStripMenuItem1.Size = new Size(180, 22);
            addItemToolStripMenuItem1.Text = "Add Item";
            addItemToolStripMenuItem1.Click += addItemToolStripMenuItem1_Click;
            // 
            // editItemToolStripMenuItem
            // 
            editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            editItemToolStripMenuItem.Size = new Size(180, 22);
            editItemToolStripMenuItem.Text = "Edit Item";
            editItemToolStripMenuItem.Click += editItemToolStripMenuItem_Click;
            // 
            // deleteItemToolStripMenuItem
            // 
            deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            deleteItemToolStripMenuItem.Size = new Size(180, 22);
            deleteItemToolStripMenuItem.Text = "Delete Item";
            deleteItemToolStripMenuItem.Click += deleteItemToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 779);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
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
        private ToolStripMenuItem inventoryToolStripMenuItem;
        private ToolStripMenuItem addItemToolStripMenuItem;
        private ToolStripMenuItem markIemAsSoldToolStripMenuItem;
        private ToolStripMenuItem removeItemToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem soldItemReportToolStripMenuItem;
        private ToolStripMenuItem unsoldItemToolStripMenuItem;
        private ToolStripMenuItem editRecordToolStripMenuItem;
        private ToolStripMenuItem addItemToolStripMenuItem1;
        private ToolStripMenuItem editItemToolStripMenuItem;
        private ToolStripMenuItem deleteItemToolStripMenuItem;
    }
}