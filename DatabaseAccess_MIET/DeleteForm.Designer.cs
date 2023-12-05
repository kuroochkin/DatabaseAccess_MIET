namespace DatabaseAccess_MIET
{
    partial class DeleteForm
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
            DeleteIdTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 41);
            label1.Name = "label1";
            label1.Size = new Size(220, 15);
            label1.TabIndex = 0;
            label1.Text = "Выберите ИД, который хотите удалить";
            // 
            // DeleteIdTextBox
            // 
            DeleteIdTextBox.Location = new Point(62, 84);
            DeleteIdTextBox.Name = "DeleteIdTextBox";
            DeleteIdTextBox.Size = new Size(134, 23);
            DeleteIdTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(89, 133);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Удалить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DeleteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 229);
            Controls.Add(button1);
            Controls.Add(DeleteIdTextBox);
            Controls.Add(label1);
            Name = "DeleteForm";
            Text = "DeleteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox DeleteIdTextBox;
        private Button button1;
    }
}