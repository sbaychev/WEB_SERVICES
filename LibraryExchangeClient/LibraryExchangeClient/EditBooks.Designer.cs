namespace LibraryExchangeClient
{
    partial class EditBooks
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
            this.gridViewBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewBooks
            // 
            this.gridViewBooks.AllowUserToAddRows = false;
            this.gridViewBooks.AllowUserToDeleteRows = false;
            this.gridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewBooks.Location = new System.Drawing.Point(12, 12);
            this.gridViewBooks.Name = "gridViewBooks";
            this.gridViewBooks.ReadOnly = true;
            this.gridViewBooks.Size = new System.Drawing.Size(859, 225);
            this.gridViewBooks.TabIndex = 18;
            this.gridViewBooks.DoubleClick += gridViewBooks_DoubleClick;
            // 
            // EditBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 254);
            this.Controls.Add(this.gridViewBooks);
            this.Name = "EditBooks";
            this.Text = "Edit Books";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewBooks;
    }
}