using MyPointOfSale.Models;
using System;
using System.Windows.Forms;

namespace MyPointOfSale
{
    public partial class frmPointOfSale : Form
    {
        private readonly Shop _store;

        public frmPointOfSale(Shop store)
        {
            InitializeComponent();

            _store = store;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
