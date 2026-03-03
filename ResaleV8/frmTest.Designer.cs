namespace ResaleV8
{
    partial class frmTest
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            cboInput = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(279, 273);
            button1.Name = "button1";
            button1.Size = new Size(154, 70);
            button1.TabIndex = 0;
            button1.Text = "Run";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 176);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 29);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(358, 176);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(209, 29);
            textBox2.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(279, 362);
            button2.Name = "button2";
            button2.Size = new Size(154, 70);
            button2.TabIndex = 4;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // cboInput
            // 
            cboInput.FormattingEnabled = true;
            cboInput.Items.AddRange(new object[] { "Men's Clothing", "Men''s Clothing", "Men's Cl'othing", "Men''s Cl''othing", "Mens Clothing" });
            cboInput.Location = new Point(105, 66);
            cboInput.Name = "cboInput";
            cboInput.Size = new Size(462, 29);
            cboInput.TabIndex = 5;
            // 
            // frmTest
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 630);
            Controls.Add(cboInput);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmTest";
            Text = "Text";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private ComboBox cboInput;
    }
}