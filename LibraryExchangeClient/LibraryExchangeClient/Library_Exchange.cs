using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryExchangeClient.BookManagement;

namespace LibraryExchangeClient
{
    public partial class Library_Exchange : Form
    {
        private string guid;
        private string userName;
        private BookManagement.BookManagement proxy;
        private AuthenticationService.AuthenticationService authServ;

        public Library_Exchange()
        {
            InitializeComponent();
            this.ribbonButton3.Click += new System.EventHandler(this.ribbonButton3_Click);
            this.rbtnMyBooksOfInterest.Click += rbtnMyBooksOfInterest_Click;
            this.proxy = new BookManagement.BookManagement();
            this.authServ = new AuthenticationService.AuthenticationService();
        }

        public string Guid
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public BookManagement.BookManagement WebServiceProxy
        {
            get
            {
                return proxy;
            }
        }
        public AuthenticationService.AuthenticationService AuthServiceProxy
        {
            get
            {
                return authServ;
            }
        }

        private void Library_Exchange_Load(object sender, EventArgs e)
        {

        }
        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            EditBooks form = new EditBooks(this);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            this.panel1.Refresh();
            //new EditBooks().ShowDialog();
        }
        private void rbtnMyBooksOfInterest_Click(object sender, EventArgs e)
        {
            MyBooksOfInterest form = new MyBooksOfInterest(this);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            this.panel1.Refresh();
        }
        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("whaaazuup");
            //new AddBook().ShowDialog();
            AddBook form = new AddBook(this);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            this.panel1.Refresh();
        }
        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("whaaazuup");
            //new Search().ShowDialog();
            Search form = new Search(this);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            this.panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ribbonButton2_Click(object sender, System.EventArgs e)
        {
            Authentication form = new Authentication(this);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            this.panel1.Refresh();
        }
    }
}