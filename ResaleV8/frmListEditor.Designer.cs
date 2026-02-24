namespace ResaleV8
{
    partial class frmListEditor
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
            dgvEditor = new DataGridView();
            btnClose = new Button();
            txtItem = new TextBox();
            btnDelete = new Button();
            btnModify = new Button();
            label1 = new Label();
            lblDBMode = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEditor).BeginInit();
            SuspendLayout();
            // 
            // dgvEditor
            // 
            dgvEditor.AllowUserToAddRows = false;
            dgvEditor.AllowUserToDeleteRows = false;
            dgvEditor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditor.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEditor.Location = new Point(9, 60);
            dgvEditor.Margin = new Padding(4);
            dgvEditor.Name = "dgvEditor";
            dgvEditor.ReadOnly = true;
            dgvEditor.RowHeadersWidth = 51;
            dgvEditor.Size = new Size(361, 1000);
            dgvEditor.TabIndex = 0;
            dgvEditor.CellMouseClick += dgvEditor_CellMouseClick;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 11F);
            btnClose.Image = Properties.Resources._5402366_delete_remove_cross_cancel_close_icon;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(614, 925);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(166, 134);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtItem
            // 
            txtItem.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItem.Location = new Point(541, 321);
            txtItem.Margin = new Padding(4, 5, 4, 5);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(332, 37);
            txtItem.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F);
            btnDelete.Image = Properties.Resources._9004852_trash_delete_bin_remove_icon__1_;
            btnDelete.Location = new Point(709, 501);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(166, 225);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.BottomCenter;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnModify
            // 
            btnModify.Font = new Font("Segoe UI", 11F);
            btnModify.Image = Properties.Resources._408050_pencil_art_drawing_edit_modify_icon;
            btnModify.Location = new Point(541, 501);
            btnModify.Margin = new Padding(4, 5, 4, 5);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(166, 225);
            btnModify.TabIndex = 4;
            btnModify.Text = "Modify";
            btnModify.TextAlign = ContentAlignment.BottomCenter;
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(495, 152);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(442, 100);
            label1.TabIndex = 5;
            label1.Text = "Click on item to edit or delete.\r\nItem will appear in text box.\r\nIf editing, make changes in text box and click \"Modify\"\r\nIf deleting simply click delete.";
            // 
            // lblDBMode
            // 
            lblDBMode.AutoSize = true;
            lblDBMode.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDBMode.Location = new Point(142, 16);
            lblDBMode.Name = "lblDBMode";
            lblDBMode.Size = new Size(76, 30);
            lblDBMode.TabIndex = 17;
            lblDBMode.Text = "label7";
            // 
            // frmListEditor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 1079);
            Controls.Add(lblDBMode);
            Controls.Add(label1);
            Controls.Add(btnModify);
            Controls.Add(btnDelete);
            Controls.Add(txtItem);
            Controls.Add(btnClose);
            Controls.Add(dgvEditor);
            Margin = new Padding(4);
            Name = "frmListEditor";
            Text = "Drop Down List Editor";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmListEditor_FormClosing;
            Load += frmListEditor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEditor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEditor;
        private Button btnClose;
        private TextBox txtItem;
        private Button btnDelete;
        private Button btnModify;
        private Label label1;
        private Label lblDBMode;
    }
}