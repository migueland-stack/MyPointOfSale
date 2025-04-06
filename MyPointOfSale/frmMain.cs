using MyPointOfSale.Models;
using System;
using System.Windows.Forms;

namespace MyPointOfSale
{
    public partial class frmMain : Form
    {
        private readonly frmLogin _login;
        private readonly frmPointOfSale _pointOfSale;
        private readonly Shop _store;

        public frmMain(Shop store)
        {
            InitializeComponent();

            _store = store;
            _login = new frmLogin(store);
            _pointOfSale = new frmPointOfSale(_store);
        }

        private void tsmPointOfSale_Click(object sender, EventArgs e)
        {
            _pointOfSale.MdiParent = this;
            _pointOfSale.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _login.MdiParent = this;
            _login.Show();
        }
    }
}
