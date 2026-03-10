namespace ResaleV8
{
    partial class frmImportSalesReport
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
            label2 = new Label();
            txtStart = new TextBox();
            txtStop = new TextBox();
            pBar = new ProgressBar();
            btnGo = new Button();
            btnClose = new Button();
            txtBundle = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 103);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Start Row";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 138);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Stop Row";
            // 
            // txtStart
            // 
            txtStart.Location = new Point(392, 100);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(51, 23);
            txtStart.TabIndex = 2;
            // 
            // txtStop
            // 
            txtStop.Location = new Point(392, 134);
            txtStop.Name = "txtStop";
            txtStop.Size = new Size(51, 23);
            txtStop.TabIndex = 3;
            // 
            // pBar
            // 
            pBar.Location = new Point(103, 345);
            pBar.Name = "pBar";
            pBar.Size = new Size(617, 36);
            pBar.TabIndex = 4;
            // 
            // btnGo
            // 
            btnGo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGo.Location = new Point(288, 182);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(71, 48);
            btnGo.TabIndex = 5;
            btnGo.Text = "Go";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(403, 182);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(71, 48);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtBundle
            // 
            txtBundle.Location = new Point(392, 65);
            txtBundle.Name = "txtBundle";
            txtBundle.Size = new Size(51, 23);
            txtBundle.TabIndex = 8;
            txtBundle.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(283, 68);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 7;
            label3.Text = "Bundle Discount";
            // 
            // frmImportSalesReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBundle);
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(btnGo);
            Controls.Add(pBar);
            Controls.Add(txtStop);
            Controls.Add(txtStart);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmImportSalesReport";
            Text = "Poshmark Sales Report Import";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtStart;
        private TextBox txtStop;
        private ProgressBar pBar;
        private Button btnGo;
        private Button btnClose;
        private TextBox txtBundle;
        private Label label3;
    }
}