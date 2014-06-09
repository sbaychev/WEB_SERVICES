namespace LibraryExchangeClient
{
    partial class AddAuthor
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
            this.label1FirstName = new System.Windows.Forms.Label();
            this.label1LastName = new System.Windows.Forms.Label();
            this.label1BirthDate = new System.Windows.Forms.Label();
            this.label2DeathDate = new System.Windows.Forms.Label();
            this.textBox1FirstName = new System.Windows.Forms.TextBox();
            this.textBox2LastName = new System.Windows.Forms.TextBox();
            this.button1AddAuthor = new System.Windows.Forms.Button();
            this.dateTimePicker1BirthYear = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDeathYear = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1FirstName
            // 
            this.label1FirstName.AutoSize = true;
            this.label1FirstName.Location = new System.Drawing.Point(29, 39);
            this.label1FirstName.Name = "label1FirstName";
            this.label1FirstName.Size = new System.Drawing.Size(76, 17);
            this.label1FirstName.TabIndex = 0;
            this.label1FirstName.Text = "First Name";
            // 
            // label1LastName
            // 
            this.label1LastName.AutoSize = true;
            this.label1LastName.Location = new System.Drawing.Point(29, 84);
            this.label1LastName.Name = "label1LastName";
            this.label1LastName.Size = new System.Drawing.Size(76, 17);
            this.label1LastName.TabIndex = 1;
            this.label1LastName.Text = "Last Name";
            // 
            // label1BirthDate
            // 
            this.label1BirthDate.AutoSize = true;
            this.label1BirthDate.Location = new System.Drawing.Point(29, 124);
            this.label1BirthDate.Name = "label1BirthDate";
            this.label1BirthDate.Size = new System.Drawing.Size(71, 17);
            this.label1BirthDate.TabIndex = 2;
            this.label1BirthDate.Text = "Birth Year";
            // 
            // label2DeathDate
            // 
            this.label2DeathDate.AutoSize = true;
            this.label2DeathDate.Location = new System.Drawing.Point(29, 163);
            this.label2DeathDate.Name = "label2DeathDate";
            this.label2DeathDate.Size = new System.Drawing.Size(80, 17);
            this.label2DeathDate.TabIndex = 3;
            this.label2DeathDate.Text = "Death Year";
            // 
            // textBox1FirstName
            // 
            this.textBox1FirstName.Location = new System.Drawing.Point(170, 36);
            this.textBox1FirstName.Name = "textBox1FirstName";
            this.textBox1FirstName.Size = new System.Drawing.Size(97, 22);
            this.textBox1FirstName.TabIndex = 4;
            this.textBox1FirstName.Text = "First Name...";
            this.textBox1FirstName.TextChanged += new System.EventHandler(this.textBox1FirstName_TextChanged);
            // 
            // textBox2LastName
            // 
            this.textBox2LastName.Location = new System.Drawing.Point(170, 79);
            this.textBox2LastName.Name = "textBox2LastName";
            this.textBox2LastName.Size = new System.Drawing.Size(97, 22);
            this.textBox2LastName.TabIndex = 5;
            this.textBox2LastName.Text = "Last Name...";
            // 
            // button1AddAuthor
            // 
            this.button1AddAuthor.Location = new System.Drawing.Point(84, 213);
            this.button1AddAuthor.Name = "button1AddAuthor";
            this.button1AddAuthor.Size = new System.Drawing.Size(101, 30);
            this.button1AddAuthor.TabIndex = 8;
            this.button1AddAuthor.Text = "Add Author";
            this.button1AddAuthor.UseVisualStyleBackColor = true;
            this.button1AddAuthor.Click += new System.EventHandler(this.button1AddAuthor_Click);
            // 
            // dateTimePicker1BirthYear
            // 
            this.dateTimePicker1BirthYear.Location = new System.Drawing.Point(170, 124);
            this.dateTimePicker1BirthYear.Name = "dateTimePicker1BirthYear";
            this.dateTimePicker1BirthYear.Size = new System.Drawing.Size(85, 22);
            this.dateTimePicker1BirthYear.TabIndex = 9;
            this.dateTimePicker1BirthYear.ValueChanged += new System.EventHandler(this.dateTimePicker1BirthYear_ValueChanged);
            // 
            // dateTimePickerDeathYear
            // 
            this.dateTimePickerDeathYear.Location = new System.Drawing.Point(170, 163);
            this.dateTimePickerDeathYear.Name = "dateTimePickerDeathYear";
            this.dateTimePickerDeathYear.Size = new System.Drawing.Size(85, 22);
            this.dateTimePickerDeathYear.TabIndex = 10;
            this.dateTimePickerDeathYear.ValueChanged += new System.EventHandler(this.dateTimePickerDeathYear_ValueChanged);
            // 
            // AddAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 274);
            this.Controls.Add(this.dateTimePickerDeathYear);
            this.Controls.Add(this.dateTimePicker1BirthYear);
            this.Controls.Add(this.button1AddAuthor);
            this.Controls.Add(this.textBox2LastName);
            this.Controls.Add(this.textBox1FirstName);
            this.Controls.Add(this.label2DeathDate);
            this.Controls.Add(this.label1BirthDate);
            this.Controls.Add(this.label1LastName);
            this.Controls.Add(this.label1FirstName);
            this.Name = "AddAuthor";
            this.Text = "AddAuthor";
            this.Load += new System.EventHandler(this.AddAuthor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1FirstName;
        private System.Windows.Forms.Label label1LastName;
        private System.Windows.Forms.Label label1BirthDate;
        private System.Windows.Forms.Label label2DeathDate;
        private System.Windows.Forms.TextBox textBox1FirstName;
        private System.Windows.Forms.TextBox textBox2LastName;
        private System.Windows.Forms.Button button1AddAuthor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1BirthYear;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeathYear;
    }
}