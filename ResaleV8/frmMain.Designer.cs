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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, inventoryToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1655, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // inventoryToolStripMenuItem
            // 
            inventoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addItemToolStripMenuItem, markIemAsSoldToolStripMenuItem, removeItemToolStripMenuItem });
            inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            inventoryToolStripMenuItem.Size = new Size(84, 24);
            inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // addItemToolStripMenuItem
            // 
            addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            addItemToolStripMenuItem.Size = new Size(224, 26);
            addItemToolStripMenuItem.Text = "Add Item";
            addItemToolStripMenuItem.Click += addItemToolStripMenuItem_Click;
            // 
            // markIemAsSoldToolStripMenuItem
            // 
            markIemAsSoldToolStripMenuItem.Name = "markIemAsSoldToolStripMenuItem";
            markIemAsSoldToolStripMenuItem.Size = new Size(224, 26);
            markIemAsSoldToolStripMenuItem.Text = "Mark Iem as sold";
            markIemAsSoldToolStripMenuItem.Click += markIemAsSoldToolStripMenuItem_Click;
            // 
            // removeItemToolStripMenuItem
            // 
            removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            removeItemToolStripMenuItem.Size = new Size(224, 26);
            removeItemToolStripMenuItem.Text = "Remove Item";
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { soldItemReportToolStripMenuItem, unsoldItemToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(78, 24);
            reportsToolStripMenuItem.Text = " Reports";
            // 
            // soldItemReportToolStripMenuItem
            // 
            soldItemReportToolStripMenuItem.Name = "soldItemReportToolStripMenuItem";
            soldItemReportToolStripMenuItem.Size = new Size(221, 26);
            soldItemReportToolStripMenuItem.Text = "Sold Item Report";
            soldItemReportToolStripMenuItem.Click += soldItemReportToolStripMenuItem_Click;
            // 
            // unsoldItemToolStripMenuItem
            // 
            unsoldItemToolStripMenuItem.Name = "unsoldItemToolStripMenuItem";
            unsoldItemToolStripMenuItem.Size = new Size(221, 26);
            unsoldItemToolStripMenuItem.Text = "Unsold Item Report";
            unsoldItemToolStripMenuItem.Click += unsoldItemToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 1039);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
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
    }
}