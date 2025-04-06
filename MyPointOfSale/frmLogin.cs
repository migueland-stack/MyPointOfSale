using MyPointOfSale.DataAccessSQLServer;
using MyPointOfSale.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPointOfSale
{
    public partial class frmLogin : Form
    {
        private readonly Shop _shop;
        private UserRepository _userRepository;

        public frmLogin(Shop shop)
        {
            InitializeComponent();

            _shop = shop;

            _userRepository = new UserRepository();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "usuario")  
            {
                txtUser.Clear();
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                ClearTxtUser();
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "contraseña")
            {
                txtPass.Clear();
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
                txtPass.PasswordChar = '*';
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                ClearTxtPass();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                User user = new User
                {
                    Username = txtUser.Text,
                    Password = txtPass.Text
                };

                bool isValid = _userRepository.Login(user);
                if (!isValid)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Intente nuevamente.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                    txtUser.Focus();
                    return;
                }

                frmPointOfSale pointOfSale = new frmPointOfSale(_shop);
                pointOfSale.Show();
                pointOfSale.FormClosed += LogOut;
                this.Hide();
            }
        }

        private void ClearFields()
        {
            ClearTxtUser();
            ClearTxtPass();
        }

        private void ClearTxtUser()
        {
            txtUser.Text = "usuario";
            txtUser.ForeColor = Color.Silver;
        }

        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || txtUser.Text == "usuario")
            {
                errorProvider1.SetError(txtUser, "Por favor, ingrese su nombre de usuario.");
                txtUser.Focus();
                return false;
            }
            errorProvider1.SetError(txtUser, string.Empty);

            if (string.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text == "contraseña")
            {
                errorProvider1.SetError(txtPass, "Por favor, ingrese su contraseña.");
                txtPass.Focus();
                return false;
            }
            errorProvider1.SetError(txtPass, string.Empty);

            return true;
        }

        private void ClearTxtPass()
        {
            txtPass.Text = "contraseña";
            txtPass.ForeColor = Color.Silver;
            txtPass.UseSystemPasswordChar = false;
            txtPass.PasswordChar = '\0';
        }

        private void LogOut(object sender, FormClosedEventArgs e)
        {
            ClearFields();
            this.Show();
            txtUser.Focus();
        }
    }
}
