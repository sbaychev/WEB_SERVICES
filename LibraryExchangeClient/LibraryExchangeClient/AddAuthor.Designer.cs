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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblDeathDate = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.dtpBirthYear = new System.Windows.Forms.DateTimePicker();
            this.dtpDeathYear = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(11, 18);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(11, 54);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(11, 87);
            this.lblBirthDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(53, 13);
            this.lblBirthDate.TabIndex = 2;
            this.lblBirthDate.Text = "Birth Year";
            // 
            // lblDeathDate
            // 
            this.lblDeathDate.AutoSize = true;
            this.lblDeathDate.Location = new System.Drawing.Point(11, 118);
            this.lblDeathDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeathDate.Name = "lblDeathDate";
            this.lblDeathDate.Size = new System.Drawing.Size(61, 13);
            this.lblDeathDate.TabIndex = 3;
            this.lblDeathDate.Text = "Death Year";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(81, 15);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(144, 20);
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.Text = "First Name...";
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(81, 54);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(144, 20);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.Text = "Last Name...";
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.Location = new System.Drawing.Point(81, 159);
            this.btnAddAuthor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(76, 24);
            this.btnAddAuthor.TabIndex = 8;
            this.btnAddAuthor.Text = "Add Author";
            this.btnAddAuthor.UseVisualStyleBackColor = true;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // dtpBirthYear
            // 
            this.dtpBirthYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthYear.Location = new System.Drawing.Point(81, 87);
            this.dtpBirthYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpBirthYear.Name = "dtpBirthYear";
            this.dtpBirthYear.Size = new System.Drawing.Size(144, 20);
            this.dtpBirthYear.TabIndex = 9;
            this.dtpBirthYear.ValueChanged += new System.EventHandler(this.dtpBirthYear_ValueChanged);
            // 
            // dtpDeathYear
            // 
            this.dtpDeathYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeathYear.Location = new System.Drawing.Point(81, 118);
            this.dtpDeathYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDeathYear.Name = "dtpDeathYear";
            this.dtpDeathYear.Size = new System.Drawing.Size(144, 20);
            this.dtpDeathYear.TabIndex = 10;
            this.dtpDeathYear.ValueChanged += new System.EventHandler(this.dtpDeathYear_ValueChanged);
            // 
            // AddAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 198);
            this.Controls.Add(this.dtpDeathYear);
            this.Controls.Add(this.dtpBirthYear);
            this.Controls.Add(this.btnAddAuthor);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblDeathDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddAuthor";
            this.Text = "AddAuthor";
            this.Load += new System.EventHandler(this.AddAuthor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblDeathDate;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.DateTimePicker dtpBirthYear;
        private System.Windows.Forms.DateTimePicker dtpDeathYear;
    }
}