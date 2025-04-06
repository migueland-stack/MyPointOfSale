using MyPointOfSale.Models;
using System;
using System.Windows.Forms;

namespace MyPointOfSale
{
    public partial class frmLogin : Form
    {
        private readonly Shop _store;

        public frmLogin(Shop store)
        {
            InitializeComponent();

            _store = store;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
