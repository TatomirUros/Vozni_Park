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
    public partial class Owner : Form
    {
        private readonly IOwnerService _ownerService;
        public Owner()
        {
            InitializeComponent();
            _ownerService = new OwnerService();
        }
        private async void BindCombo()
        {
            try
            {
                List<OwnerDTO> owners = await _ownerService.GetAllOwners();
                cmbName.DataSource = owners;
                cmbName.ValueMember = "Id";
                cmbName.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Owner_Load(object sender, EventArgs e)
        {
            this.BindCombo();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void UpdateComboBoxInVehicle()
        {
            try
            {
                foreach (Form otvorenaForma in Application.OpenForms)
                {
                    // Proverite ime forme i uradite nešto sa njom
                    if (otvorenaForma is Vehicle)
                    {
                        // Ovo je Form2, uradite nešto sa njom
                        // Na primer, zatvorite je:
                        Vehicle vehicle = (Vehicle)otvorenaForma;
                        vehicle.BindCombo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void btnInsert_Click_1(object sender, EventArgs e)
        {
            try
            {
                await _ownerService.InsertOwner(tbName.Text.ToString());
                this.BindCombo();
                tbName.Clear();
                MessageBox.Show("Uspešno ste uneli vlasnika");
                UpdateComboBoxInVehicle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete vlasnika? \nBrisanjem ovog vlasnika brišete i sva vozila koja se nalaze u njegovom posedu", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _ownerService.DeleteOwner(int.Parse(cmbName.SelectedValue.ToString()));
                    this.BindCombo();
                    MessageBox.Show("Uspešno ste obrisali vlasnika");
                    UpdateComboBoxInVehicle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite naziv vlasnika?", "Potvrda promene", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _ownerService.UpdateOwner(int.Parse(cmbName.SelectedValue.ToString()), tbName.Text.ToString());
                    this.BindCombo();
                    tbName.Clear();
                    MessageBox.Show("Uspešno ste promenili naziv vlasnika");
                    UpdateComboBoxInVehicle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
