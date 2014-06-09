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
        public Library_Exchange()
        {
            InitializeComponent();
        }
        private void Library_Exchange_Load(object sender, EventArgs e)
        {

        }
        private void ribbon1_Click(object sender, EventArgs e)
        {
        }
        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("whaaazuup");
            new AddBook().ShowDialog();

        }
    }
}