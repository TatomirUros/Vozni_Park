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
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.View
{
    public partial class Category : Form
    {
        private readonly ICategoryService _categoryService;

        public Category()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }

        private async void BindCombo()
        {
            try
            {
                List<CategoryDTO> categories = await _categoryService.GetAllCategories();
                cmbName.DataSource = categories;
                cmbName.ValueMember = "Id";
                cmbName.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void Category_Load(object sender, EventArgs e)
        {
            this.BindCombo();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                await _categoryService.InsertCategory(tbName.Text.ToString());
                this.BindCombo();
                tbName.Clear();
                MessageBox.Show("Uspešno ste uneli kategoriju");
                UpdateComboBoxInVehicle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite naziv kategorije?", "Potvrdi promenu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _categoryService.UpdateCategory(int.Parse(cmbName.SelectedValue.ToString()), tbName.Text.ToString());
                    this.BindCombo();
                    tbName.Clear();
                    MessageBox.Show("Uspešno ste promenili naziv kategorije");
                    UpdateComboBoxInVehicle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete kategoriju? \nBrisanjem ove kategorije sve potkategorije ce se obrisati i sva vozila koja se nalaze u njoj ce se prebaciti u nedefinisanu kategoriju i potkategoriju", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _categoryService.DeleteCategory(int.Parse(cmbName.SelectedValue.ToString()));
                    this.BindCombo();

                    MessageBox.Show("Uspešno ste obrisali kategoriju");
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
