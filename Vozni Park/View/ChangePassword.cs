using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.Helpers;

namespace Vozni_Park.View
{
    public partial class ChangePassword : Form
    {
        private readonly LoginHelper _login;
        public ChangePassword()
        {
            InitializeComponent();
            _login = new LoginHelper();
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                int id = await _login.CheckForExistence(tbUsername.Text, tbOldPassword.Text);
                if (id != -1)
                {
                    if (tbNewPassword.Text.Equals(tbCheckNewPassword.Text))
                    {
                        await _login.ChangePassword(id, tbNewPassword.Text);
                        MessageBox.Show("Uspešno ste promenili šifru");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Nova šifra se mora poklapati sa ponovljenom šifrom");
                }
                else
                    MessageBox.Show("Korisnik sa ovim korisničkim imenom i šifrom ne postoji");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }
    }
}
