

namespace LibraryExchangeClient
{
    partial class AddBook
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1Title = new System.Windows.Forms.TextBox();
            this.comboBox1Type = new System.Windows.Forms.ComboBox();
            this.textBox4Year = new System.Windows.Forms.TextBox();
            this.textBox5ISBN = new System.Windows.Forms.TextBox();
            this.comboBox2Genre = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1Author = new System.Windows.Forms.CheckBox();
            this.comboBox1Author = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Genre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Year Published";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "ISBN";
            // 
            // textBox1Title
            // 
            this.textBox1Title.Location = new System.Drawing.Point(154, 12);
            this.textBox1Title.Name = "textBox1Title";
            this.textBox1Title.Size = new System.Drawing.Size(114, 22);
            this.textBox1Title.TabIndex = 6;
            this.textBox1Title.Text = "Title....";
            this.textBox1Title.TextChanged += new System.EventHandler(this.textBox1Title_TextChanged);
            // 
            // comboBox1Type
            // 
            this.comboBox1Type.FormattingEnabled = true;
            this.comboBox1Type.Location = new System.Drawing.Point(154, 108);
            this.comboBox1Type.Name = "comboBox1Type";
            this.comboBox1Type.Size = new System.Drawing.Size(114, 24);
            this.comboBox1Type.TabIndex = 9;
            this.comboBox1Type.SelectedIndexChanged += new System.EventHandler(this.comboBox1Type_SelectedIndexChanged);
            // 
            // textBox4Year
            // 
            this.textBox4Year.Location = new System.Drawing.Point(154, 179);
            this.textBox4Year.Name = "textBox4Year";
            this.textBox4Year.Size = new System.Drawing.Size(114, 22);
            this.textBox4Year.TabIndex = 10;
            this.textBox4Year.Text = "Year Published...";
            this.textBox4Year.TextChanged += new System.EventHandler(this.textBox4Year_TextChanged);
            // 
            // textBox5ISBN
            // 
            this.textBox5ISBN.Location = new System.Drawing.Point(154, 215);
            this.textBox5ISBN.Name = "textBox5ISBN";
            this.textBox5ISBN.Size = new System.Drawing.Size(114, 22);
            this.textBox5ISBN.TabIndex = 11;
            this.textBox5ISBN.Text = "XXX-X-XX-XXXXXX-X";
            this.textBox5ISBN.TextChanged += new System.EventHandler(this.textBox5ISBN_TextChanged);
            // 
            // comboBox2Genre
            // 
            this.comboBox2Genre.FormattingEnabled = true;
            this.comboBox2Genre.Location = new System.Drawing.Point(154, 140);
            this.comboBox2Genre.Name = "comboBox2Genre";
            this.comboBox2Genre.Size = new System.Drawing.Size(114, 24);
            this.comboBox2Genre.TabIndex = 12;
            this.comboBox2Genre.SelectedIndexChanged += new System.EventHandler(this.comboBox2Genre_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1Author
            // 
            this.checkBox1Author.AutoSize = true;
            this.checkBox1Author.Location = new System.Drawing.Point(154, 81);
            this.checkBox1Author.Name = "checkBox1Author";
            this.checkBox1Author.Size = new System.Drawing.Size(131, 21);
            this.checkBox1Author.TabIndex = 14;
            this.checkBox1Author.Text = "Missing Author?";
            this.checkBox1Author.UseVisualStyleBackColor = true;
            this.checkBox1Author.CheckedChanged += new System.EventHandler(this.checkBox1Author_CheckedChanged);
            // 
            // comboBox1Author
            // 
            this.comboBox1Author.FormattingEnabled = true;
            this.comboBox1Author.Location = new System.Drawing.Point(154, 49);
            this.comboBox1Author.Name = "comboBox1Author";
            this.comboBox1Author.Size = new System.Drawing.Size(114, 24);
            this.comboBox1Author.TabIndex = 15;
            this.comboBox1Author.SelectedIndexChanged += new System.EventHandler(this.comboBox1Author_SelectedIndexChanged);
            // 
            // AddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 335);
            this.Controls.Add(this.comboBox1Author);
            this.Controls.Add(this.checkBox1Author);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2Genre);
            this.Controls.Add(this.textBox5ISBN);
            this.Controls.Add(this.textBox4Year);
            this.Controls.Add(this.comboBox1Type);
            this.Controls.Add(this.textBox1Title);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddBook";
            this.Text = "AddBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1Title;
        private System.Windows.Forms.ComboBox comboBox1Type;
        private System.Windows.Forms.TextBox textBox4Year;
        private System.Windows.Forms.TextBox textBox5ISBN;
        private System.Windows.Forms.ComboBox comboBox2Genre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1Author;
        private System.Windows.Forms.ComboBox comboBox1Author;

    }
}