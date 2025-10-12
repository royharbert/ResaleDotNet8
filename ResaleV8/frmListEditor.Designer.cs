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
            ((System.ComponentModel.ISupportInitialize)dgvEditor).BeginInit();
            SuspendLayout();
            // 
            // dgvEditor
            // 
            dgvEditor.AllowUserToAddRows = false;
            dgvEditor.AllowUserToDeleteRows = false;
            dgvEditor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditor.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEditor.Location = new Point(6, 36);
            dgvEditor.Margin = new Padding(3, 2, 3, 2);
            dgvEditor.Name = "dgvEditor";
            dgvEditor.ReadOnly = true;
            dgvEditor.RowHeadersWidth = 51;
            dgvEditor.Size = new Size(253, 600);
            dgvEditor.TabIndex = 0;
            dgvEditor.CellMouseClick += dgvEditor_CellMouseClick;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 11F);
            btnClose.Image = Properties.Resources._5402366_delete_remove_cross_cancel_close_icon;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(430, 555);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(116, 80);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtItem
            // 
            txtItem.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItem.Location = new Point(379, 193);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(233, 27);
            txtItem.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F);
            btnDelete.Image = Properties.Resources._9004852_trash_delete_bin_remove_icon__1_;
            btnDelete.Location = new Point(496, 259);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(116, 135);
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
            btnModify.ImageAlign = ContentAlignment.TopCenter;
            btnModify.Location = new Point(379, 259);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(116, 135);
            btnModify.TabIndex = 4;
            btnModify.Text = "Modify";
            btnModify.TextAlign = ContentAlignment.BottomCenter;
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // frmListEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 647);
            Controls.Add(btnModify);
            Controls.Add(btnDelete);
            Controls.Add(txtItem);
            Controls.Add(btnClose);
            Controls.Add(dgvEditor);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmListEditor";
            Text = "Drop Down List Editor";
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
    }
}