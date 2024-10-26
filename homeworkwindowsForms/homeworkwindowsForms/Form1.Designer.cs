
namespace homeworkwindowsForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 214);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1080, 349);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.YellowGreen;
            button1.Location = new Point(403, 33);
            button1.Name = "button1";
            button1.Size = new Size(322, 106);
            button1.TabIndex = 1;
            button1.Text = "drop";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Location = new Point(770, 33);
            button2.Name = "button2";
            button2.Size = new Size(322, 106);
            button2.TabIndex = 2;
            button2.Text = "get";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 33);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 3;
            label1.Text = "Auto";
            label1.Click += this.label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 64);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 4;
            label2.Text = "Mark";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 92);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Speed";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 124);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 6;
            label4.Text = "Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 153);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 7;
            label5.Text = "Color";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 591);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
