using MyPointOfSale.Models;
using MyPointOfSale.Models.Share;
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

        private void frmPointOfSale_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblUserEmail.Text = UserLoginCache.Email;
            lblUserName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            lblUserRol.Text = UserLoginCache.Position;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea ", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
