namespace DatabaseAccess_MIET
{
    partial class ParametrForm
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
            ParametrTextBox = new TextBox();
            button1 = new Button();
            listView1 = new ListView();
            label1 = new Label();
            SuspendLayout();
            // 
            // ParametrTextBox
            // 
            ParametrTextBox.Location = new Point(22, 99);
            ParametrTextBox.Name = "ParametrTextBox";
            ParametrTextBox.Size = new Size(143, 23);
            ParametrTextBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(288, 234);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 1;
            button1.Text = "Выполнить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(193, 33);
            listView1.Name = "listView1";
            listView1.Size = new Size(499, 148);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 72);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 3;
            label1.Text = "Введите параметр";
            // 
            // ParametrForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 280);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(button1);
            Controls.Add(ParametrTextBox);
            Name = "ParametrForm";
            Text = "ParametrForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ParametrTextBox;
        private Button button1;
        private ListView listView1;
        private Label label1;
    }
}