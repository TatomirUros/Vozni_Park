using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.DTOs;
using Vozni_Park.Services.Interfaces;
using Vozni_Park.Services;

namespace Vozni_Park.View
{
    public partial class Repairer : Form
    {
        private readonly IRepairerService _repairerService;
        public Repairer()
        {
            InitializeComponent();
            _repairerService = new RepairerService();
        }
        private async void BindCombo()
        {
            try
            {
                List<RepairerDTO> repairers = await _repairerService.GetAllRepairers();
                cmbName.DataSource = repairers;
                cmbName.ValueMember = "Id";
                cmbName.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                await _repairerService.InsertRepairer(tbName.Text.ToString());
                this.BindCombo();
                tbName.Clear();
                MessageBox.Show("Uspešno ste uneli servis");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete servis? \nBrisanjem ovog servisa brišete i informacije o svim servisima koje su oni uradili", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _repairerService.DeleteRepairer(int.Parse(cmbName.SelectedValue.ToString()));
                    this.BindCombo();

                    MessageBox.Show("Uspešno ste obrisali servis");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite naziv servisa?", "Potvrda promene", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _repairerService.UpdateRepairer(int.Parse(cmbName.SelectedValue.ToString()), tbName.Text.ToString());
                    this.BindCombo();
                    tbName.Clear();
                    MessageBox.Show("Uspešno ste promenili naziv servisa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }

        private void Repairer_Load(object sender, EventArgs e)
        {
            this.BindCombo();

            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnInsert.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }
    }
}
