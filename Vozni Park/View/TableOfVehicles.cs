using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.DTOs;
using Vozni_Park.Helpers;
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.View
{
    public partial class TableOfVehicles : Form
    {
        private readonly IMineService _mineService;
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IOwnerService _ownerService;
        private readonly IStateService _stateService;
        private readonly IVehicleService _vehicleService;
        public TableOfVehicles()
        {
            InitializeComponent();
            _mineService = new MineService();
            _categoryService = new CategoryService();
            _subcategoryService = new SubcategoryService();
            _vehicleService = new VehicleService();
            _ownerService = new OwnerService();
            _stateService = new StateService();
        }

        public async void BindCombo()
        {
            try
            {
                List<MineDTO> mines = await _mineService.GetAllMines();
                cmbMine.DataSource = mines;
                cmbMine.ValueMember = "Id";
                cmbMine.DisplayMember = "Name";
                List<CategoryDTO> categories = await _categoryService.GetAllCategories();
                cmbCategory.DataSource = categories;
                cmbCategory.ValueMember = "Id";
                cmbCategory.DisplayMember = "Name";
                List<SubcategoryDTO> subcategories = await _subcategoryService.GetAllSubcategoriesByCategoryId(1);
                cmbSubcategory.DataSource = subcategories;
                cmbSubcategory.ValueMember = "Id";
                cmbSubcategory.DisplayMember = "Name";
                List<OwnerDTO> owners = await _ownerService.GetAllOwners();
                cmbOwner.DataSource = owners;
                cmbOwner.ValueMember = "Id";
                cmbOwner.DisplayMember = "Name";
                List<StateDTO> states = await _stateService.GetAllStates();
                cmbState.DataSource = states;
                cmbState.ValueMember = "Id";
                cmbState.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void BindDataGridView(int idMine, int idCategory, int idSubcategory, int idOwner, int idState)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<VehicleTableViewDTO> list = await _vehicleService.GetVehiclesByParameters(idMine, idCategory, idSubcategory, idOwner, idState);
                dataGridView1.DataSource = list;

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Prikazi";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void TabelOfVehicles_Load(object sender, EventArgs e)
        {
            BindCombo();
            BindDataGridView(-1, -1, -1, -1, -1);
        }

        private async void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out int categoryId))
            {
                // Uspešno parsirano
                Console.WriteLine($"Uspešno parsirano: {categoryId}");
            }
            else
            {
                // Neuspešno parsiranje
                Console.WriteLine("Ne može da se konvertuje u int. Postavi podrazumevanu vrednost.");
                categoryId = 1; // Ili neka druga podrazumevana vrednost
            }

            List<SubcategoryDTO> subcategories = await _subcategoryService.GetAllSubcategoriesByCategoryId(categoryId);
            cmbSubcategory.DataSource = subcategories;
            cmbSubcategory.ValueMember = "Id";
            cmbSubcategory.DisplayMember = "Name";
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Brand"].HeaderText = "Marka";
                dataGridView1.Columns["Kilometers"].HeaderText = "Kilometraža";
                dataGridView1.Columns["DateTo"].HeaderText = "Datum isteka registracije";
                dataGridView1.Columns["State"].HeaderText = "Ispravnost";
                dataGridView1.Columns["Owner"].HeaderText = "Vlasnik";
                dataGridView1.Columns["Mine"].HeaderText = "Rudnik";
                dataGridView1.Columns["Registration"].HeaderText = "Registracija";
                dataGridView1.Columns["Category"].HeaderText = "Kategorija";
                dataGridView1.Columns["Subcategory"].HeaderText = "Potkategorija";
                dataGridView1.Columns["TireDimension"].HeaderText = "Dimenzija guma";
                dataGridView1.Columns["DateTo"].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 12)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                    var openForms = Application.OpenForms;
                    var targetForm = openForms.OfType<Vehicle>().FirstOrDefault();
                    if (targetForm != null)
                    {
                        targetForm.Focus();
                        await targetForm.FindWithId(id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int idMine = -1;
                if (cbMine.Checked)
                    if (!int.TryParse(cmbMine.SelectedValue.ToString(), out idMine))
                        Console.WriteLine("True");

                int idCategory = -1;
                if (cbCategory.Checked)
                    if (!int.TryParse(cmbCategory.SelectedValue.ToString(), out idCategory))
                        Console.WriteLine("True");

                int idSubcategory = -1;
                if (cbSubcategory.Checked)
                    if (!int.TryParse(cmbSubcategory.SelectedValue.ToString(), out idSubcategory))
                        Console.WriteLine("True");

                int idOwner = -1;
                if (cbOwner.Checked)
                    if (!int.TryParse(cmbOwner.SelectedValue.ToString(), out idOwner))
                        Console.WriteLine("True");

                int idState = -1;
                if (cbState.Checked)
                    if (!int.TryParse(cmbState.SelectedValue.ToString(), out idState))
                        Console.WriteLine("True");

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<VehicleTableViewDTO> list = await _vehicleService.GetVehiclesByParameters(idMine, idCategory, idSubcategory, idOwner, idState);
                dataGridView1.DataSource = list;

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Prikazi";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            TablePrinter printer = new TablePrinter(dataGridView1, 11);
            printer.PrintTable();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowNumber = (e.RowIndex + 1).ToString(); // Dobijamo redni broj (indeks kreće od 0, pa +1)

                e.Graphics.DrawString(
                    rowNumber, // Tekst koji crtamo (broj reda)
                    dataGridView1.Font, // Font koji koristi DataGridView
                    brush, // Četkica kojom crtamo (boja teksta)
                    e.RowBounds.Location.X + 12, // X koordinata gde ispisujemo broj (pomereno malo udesno)
                    e.RowBounds.Location.Y + 4 // Y koordinata (pomereno malo nadole)
                );
            }
        }
    }
}
