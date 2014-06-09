namespace LibraryExchangeClient
{
    partial class EditBookForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtYearPublished = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblIsbn = new System.Windows.Forms.Label();
            this.lblYearPublished = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.chckMissingAuthor = new System.Windows.Forms.CheckBox();
            this.lblReserved = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnReservedYes = new System.Windows.Forms.RadioButton();
            this.rbtnReservedNo = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(188, 271);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 23);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 271);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtIsbn
            // 
            this.txtIsbn.Location = new System.Drawing.Point(104, 183);
            this.txtIsbn.Margin = new System.Windows.Forms.Padding(2);
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(192, 20);
            this.txtIsbn.TabIndex = 46;
            // 
            // txtYearPublished
            // 
            this.txtYearPublished.Location = new System.Drawing.Point(104, 155);
            this.txtYearPublished.Margin = new System.Windows.Forms.Padding(2);
            this.txtYearPublished.Name = "txtYearPublished";
            this.txtYearPublished.Size = new System.Drawing.Size(192, 20);
            this.txtYearPublished.TabIndex = 45;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(103, 15);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(192, 20);
            this.txtTitle.TabIndex = 44;
            // 
            // lblIsbn
            // 
            this.lblIsbn.AutoSize = true;
            this.lblIsbn.Location = new System.Drawing.Point(12, 186);
            this.lblIsbn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIsbn.Name = "lblIsbn";
            this.lblIsbn.Size = new System.Drawing.Size(32, 13);
            this.lblIsbn.TabIndex = 43;
            this.lblIsbn.Text = "ISBN";
            // 
            // lblYearPublished
            // 
            this.lblYearPublished.AutoSize = true;
            this.lblYearPublished.Location = new System.Drawing.Point(12, 158);
            this.lblYearPublished.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYearPublished.Name = "lblYearPublished";
            this.lblYearPublished.Size = new System.Drawing.Size(78, 13);
            this.lblYearPublished.TabIndex = 42;
            this.lblYearPublished.Text = "Year Published";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(12, 129);
            this.lblGenre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 41;
            this.lblGenre.Text = "Genre";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 100);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 40;
            this.lblType.Text = "Type";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(12, 46);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblAuthor.TabIndex = 39;
            this.lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 38;
            this.lblTitle.Text = "Title";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(104, 97);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(192, 21);
            this.cmbType.TabIndex = 56;
            // 
            // cmbGenre
            // 
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(104, 126);
            this.cmbGenre.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(192, 21);
            this.cmbGenre.TabIndex = 57;
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.FormattingEnabled = true;
            this.cmbAuthor.Location = new System.Drawing.Point(103, 43);
            this.cmbAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(192, 21);
            this.cmbAuthor.TabIndex = 58;
            // 
            // chckMissingAuthor
            // 
            this.chckMissingAuthor.AutoSize = true;
            this.chckMissingAuthor.Location = new System.Drawing.Point(116, 72);
            this.chckMissingAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.chckMissingAuthor.Name = "chckMissingAuthor";
            this.chckMissingAuthor.Size = new System.Drawing.Size(101, 17);
            this.chckMissingAuthor.TabIndex = 59;
            this.chckMissingAuthor.Text = "Missing Author?";
            this.chckMissingAuthor.UseVisualStyleBackColor = true;
            this.chckMissingAuthor.CheckedChanged += new System.EventHandler(this.chckMissingAuthor_CheckedChanged);
            // 
            // lblReserved
            // 
            this.lblReserved.AutoSize = true;
            this.lblReserved.Location = new System.Drawing.Point(12, 214);
            this.lblReserved.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReserved.Name = "lblReserved";
            this.lblReserved.Size = new System.Drawing.Size(53, 13);
            this.lblReserved.TabIndex = 60;
            this.lblReserved.Text = "Reserved";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnReservedYes);
            this.groupBox1.Controls.Add(this.rbtnReservedNo);
            this.groupBox1.Location = new System.Drawing.Point(104, 207);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(103, 46);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserved";
            // 
            // rbtnReservedYes
            // 
            this.rbtnReservedYes.AutoSize = true;
            this.rbtnReservedYes.Checked = true;
            this.rbtnReservedYes.Location = new System.Drawing.Point(7, 21);
            this.rbtnReservedYes.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnReservedYes.Name = "rbtnReservedYes";
            this.rbtnReservedYes.Size = new System.Drawing.Size(43, 17);
            this.rbtnReservedYes.TabIndex = 15;
            this.rbtnReservedYes.TabStop = true;
            this.rbtnReservedYes.Text = "Yes";
            this.rbtnReservedYes.UseVisualStyleBackColor = true;
            // 
            // rbtnReservedNo
            // 
            this.rbtnReservedNo.AutoSize = true;
            this.rbtnReservedNo.Location = new System.Drawing.Point(58, 21);
            this.rbtnReservedNo.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnReservedNo.Name = "rbtnReservedNo";
            this.rbtnReservedNo.Size = new System.Drawing.Size(39, 17);
            this.rbtnReservedNo.TabIndex = 14;
            this.rbtnReservedNo.Text = "No";
            this.rbtnReservedNo.UseVisualStyleBackColor = true;
            // 
            // EditBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 303);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblReserved);
            this.Controls.Add(this.chckMissingAuthor);
            this.Controls.Add(this.cmbAuthor);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.txtYearPublished);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblIsbn);
            this.Controls.Add(this.lblYearPublished);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Name = "EditBookForm";
            this.Text = "Edit Book";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtYearPublished;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.Label lblYearPublished;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.ComboBox cmbAuthor;
        private System.Windows.Forms.CheckBox chckMissingAuthor;
        private System.Windows.Forms.Label lblReserved;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnReservedYes;
        private System.Windows.Forms.RadioButton rbtnReservedNo;
    }
}