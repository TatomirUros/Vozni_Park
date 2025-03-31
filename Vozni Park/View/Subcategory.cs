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
    public partial class Subcategory : Form
    {
        private readonly ISubcategoryService _subcategoryService;
        private readonly ICategoryService _categoryService;
        public Subcategory()
        {
            InitializeComponent();
            _subcategoryService = new SubcategoryService();
            _categoryService = new CategoryService();
        }
        private async void BindCombo()
        {
            try
            {
                List<SubcategoryDTO> subcategories = await _subcategoryService.GetAllSubcategories();
                cmbName.DataSource = subcategories;
                cmbName.ValueMember = "Id";
                cmbName.DisplayMember = "Name";

                List<CategoryDTO> categories = await _categoryService.GetAllCategories();
                cmbCategory.DataSource = categories;
                cmbCategory.ValueMember = "Id";
                cmbCategory.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
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
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }
        private void Subcategory_Load(object sender, EventArgs e)
        {
            this.BindCombo();
            btnInsert.Enabled = false;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite potkategoriju?", "Potvrdi promenu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _subcategoryService.UpdateSubcategory(int.Parse(cmbName.SelectedValue.ToString()), tbName.Text.ToString(), int.Parse(cmbCategory.SelectedValue.ToString()));
                    this.BindCombo();
                    tbName.Clear();
                    MessageBox.Show("Uspešno ste promenili potkategoriju");
                    UpdateComboBoxInVehicle();
                }
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
                await _subcategoryService.InsertSubcategory(tbName.Text.ToString(), int.Parse(cmbCategory.SelectedValue.ToString()));
                this.BindCombo();
                tbName.Clear();
                MessageBox.Show("Uspešno ste uneli potkategoriju");
                UpdateComboBoxInVehicle();
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
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete potkategoriju? \nBrisanjem ove potkategorije sva vozila koja se nalaze u njoj ce se prebaciti u nedefinisanu kategoriju i potkategoriju", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _subcategoryService.DeleteSubcategory(int.Parse(cmbName.SelectedValue.ToString()));
                    this.BindCombo();

                    MessageBox.Show("Uspešno ste obrisali potkategoriju");
                    UpdateComboBoxInVehicle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                btnInsert.Enabled = false;
            }
            else
            {
                btnInsert.Enabled = true;
            }
        }

        private async void cmbName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int subcategoryId = 0;
            if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out subcategoryId))
            {
                subcategoryId = int.Parse(cmbName.SelectedValue.ToString());

                int categoryId = await _subcategoryService.GetCategoryIdBySubcategoryId(subcategoryId);

                cmbCategory.SelectedValue = categoryId;
            }
        }
    }
}
