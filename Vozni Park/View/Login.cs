using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.Context;
using Vozni_Park.Helpers;
using Vozni_Park.Repository;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Vozni_Park.View
{
    public partial class Login : Form
    {
        private readonly LoginHelper _login;
        public Login()
        {
            _login = new LoginHelper();
            InitializeComponent();
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                int check = await _login.CheckForExistence(tbUserName.Text, tbPassword.Text);
                if (check != -1)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.Show();

                    this.Hide();
                }
                else
                    MessageBox.Show("Pogrešna kombinacija šifre i korisničkog imena");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbPassword.Focus();
            tbPassword.Select();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnLogIn_Click(sender, e);
            }
        }
    }
}
