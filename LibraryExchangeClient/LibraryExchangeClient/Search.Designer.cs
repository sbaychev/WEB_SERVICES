namespace LibraryExchangeClient
{
    partial class Search
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
            this.textBox1Author = new System.Windows.Forms.TextBox();
            this.textBox2Type = new System.Windows.Forms.TextBox();
            this.textBox3Genre = new System.Windows.Forms.TextBox();
            this.button1Search = new System.Windows.Forms.Button();
            this.textBox1Title = new System.Windows.Forms.TextBox();
            this.radioButton1Author = new System.Windows.Forms.RadioButton();
            this.radioButton2Title = new System.Windows.Forms.RadioButton();
            this.radioButton3Type = new System.Windows.Forms.RadioButton();
            this.radioButton4Genre = new System.Windows.Forms.RadioButton();
            this.radioButton5None = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridViewBooks = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1Author
            // 
            this.textBox1Author.Location = new System.Drawing.Point(84, 33);
            this.textBox1Author.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1Author.Name = "textBox1Author";
            this.textBox1Author.Size = new System.Drawing.Size(127, 20);
            this.textBox1Author.TabIndex = 4;
            // 
            // textBox2Type
            // 
            this.textBox2Type.Location = new System.Drawing.Point(84, 95);
            this.textBox2Type.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2Type.Name = "textBox2Type";
            this.textBox2Type.Size = new System.Drawing.Size(127, 20);
            this.textBox2Type.TabIndex = 5;
            // 
            // textBox3Genre
            // 
            this.textBox3Genre.Location = new System.Drawing.Point(84, 127);
            this.textBox3Genre.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3Genre.Name = "textBox3Genre";
            this.textBox3Genre.Size = new System.Drawing.Size(127, 20);
            this.textBox3Genre.TabIndex = 6;
            // 
            // button1Search
            // 
            this.button1Search.Location = new System.Drawing.Point(62, 202);
            this.button1Search.Margin = new System.Windows.Forms.Padding(2);
            this.button1Search.Name = "button1Search";
            this.button1Search.Size = new System.Drawing.Size(87, 33);
            this.button1Search.TabIndex = 8;
            this.button1Search.Text = "Search";
            this.button1Search.UseVisualStyleBackColor = true;
            this.button1Search.Click += new System.EventHandler(this.button1Search_Click);
            // 
            // textBox1Title
            // 
            this.textBox1Title.Location = new System.Drawing.Point(84, 65);
            this.textBox1Title.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1Title.Name = "textBox1Title";
            this.textBox1Title.Size = new System.Drawing.Size(127, 20);
            this.textBox1Title.TabIndex = 10;
            // 
            // radioButton1Author
            // 
            this.radioButton1Author.AutoSize = true;
            this.radioButton1Author.Location = new System.Drawing.Point(0, 24);
            this.radioButton1Author.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1Author.Name = "radioButton1Author";
            this.radioButton1Author.Size = new System.Drawing.Size(56, 17);
            this.radioButton1Author.TabIndex = 11;
            this.radioButton1Author.Text = "Author";
            this.radioButton1Author.UseVisualStyleBackColor = true;
            this.radioButton1Author.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton2Title
            // 
            this.radioButton2Title.AutoSize = true;
            this.radioButton2Title.Location = new System.Drawing.Point(0, 56);
            this.radioButton2Title.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2Title.Name = "radioButton2Title";
            this.radioButton2Title.Size = new System.Drawing.Size(45, 17);
            this.radioButton2Title.TabIndex = 12;
            this.radioButton2Title.Text = "Title";
            this.radioButton2Title.UseVisualStyleBackColor = true;
            this.radioButton2Title.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton3Type
            // 
            this.radioButton3Type.AutoSize = true;
            this.radioButton3Type.Location = new System.Drawing.Point(0, 88);
            this.radioButton3Type.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3Type.Name = "radioButton3Type";
            this.radioButton3Type.Size = new System.Drawing.Size(49, 17);
            this.radioButton3Type.TabIndex = 13;
            this.radioButton3Type.Text = "Type";
            this.radioButton3Type.UseVisualStyleBackColor = true;
            this.radioButton3Type.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton4Genre
            // 
            this.radioButton4Genre.AutoSize = true;
            this.radioButton4Genre.Location = new System.Drawing.Point(0, 120);
            this.radioButton4Genre.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton4Genre.Name = "radioButton4Genre";
            this.radioButton4Genre.Size = new System.Drawing.Size(54, 17);
            this.radioButton4Genre.TabIndex = 14;
            this.radioButton4Genre.Text = "Genre";
            this.radioButton4Genre.UseVisualStyleBackColor = true;
            this.radioButton4Genre.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton5None
            // 
            this.radioButton5None.AutoSize = true;
            this.radioButton5None.Checked = true;
            this.radioButton5None.Location = new System.Drawing.Point(0, 152);
            this.radioButton5None.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton5None.Name = "radioButton5None";
            this.radioButton5None.Size = new System.Drawing.Size(51, 17);
            this.radioButton5None.TabIndex = 15;
            this.radioButton5None.TabStop = true;
            this.radioButton5None.Text = "None";
            this.radioButton5None.UseVisualStyleBackColor = true;
            this.radioButton5None.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1Author);
            this.groupBox1.Controls.Add(this.radioButton5None);
            this.groupBox1.Controls.Add(this.radioButton2Title);
            this.groupBox1.Controls.Add(this.radioButton4Genre);
            this.groupBox1.Controls.Add(this.radioButton3Type);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(71, 176);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by";
            // 
            // gridViewBooks
            // 
            this.gridViewBooks.AllowUserToAddRows = false;
            this.gridViewBooks.AllowUserToDeleteRows = false;
            this.gridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewBooks.Location = new System.Drawing.Point(228, 10);
            this.gridViewBooks.Name = "gridViewBooks";
            this.gridViewBooks.ReadOnly = true;
            this.gridViewBooks.Size = new System.Drawing.Size(644, 225);
            this.gridViewBooks.TabIndex = 17;
            this.gridViewBooks.DoubleClick += gridViewBooks_DoubleClick;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 245);
            this.Controls.Add(this.gridViewBooks);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1Title);
            this.Controls.Add(this.button1Search);
            this.Controls.Add(this.textBox3Genre);
            this.Controls.Add(this.textBox2Type);
            this.Controls.Add(this.textBox1Author);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Search";
            this.Text = "Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1Author;
        private System.Windows.Forms.TextBox textBox2Type;
        private System.Windows.Forms.TextBox textBox3Genre;
        private System.Windows.Forms.Button button1Search;
        private System.Windows.Forms.TextBox textBox1Title;
        private System.Windows.Forms.RadioButton radioButton1Author;
        private System.Windows.Forms.RadioButton radioButton2Title;
        private System.Windows.Forms.RadioButton radioButton3Type;
        private System.Windows.Forms.RadioButton radioButton4Genre;
        private System.Windows.Forms.RadioButton radioButton5None;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridViewBooks;
    }
}