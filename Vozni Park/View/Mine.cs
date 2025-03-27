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
    public partial class Mine : Form
    {
        private readonly IMineService _mineService;

        public Mine()
        {
            InitializeComponent();
            _mineService = new MineService();
        }
        private async void BindCombo()
        {
            try
            {
                List<MineDTO> mines = await _mineService.GetAllMines();
                cmbName.DataSource = mines;
                cmbName.ValueMember = "Id";
                cmbName.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void UpdateComboBoxInVehicle()
        {
            try
            {
                foreach (Form otvorenaForma in Application.OpenForms)
                {
                    if (otvorenaForma is Vehicle)
                    {
                        Vehicle vehicle = (Vehicle)otvorenaForma;
                        vehicle.BindCombo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                await _mineService.InsertMine(tbName.Text.ToString());
                this.BindCombo();
                tbName.Clear();
                MessageBox.Show("Uspešno ste uneli rudnik");
                UpdateComboBoxInVehicle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private void Mine_Load(object sender, EventArgs e)
        {
            this.BindCombo();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite naziv rudnika?", "Potvrda promene", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _mineService.UpdateMine(int.Parse(cmbName.SelectedValue.ToString()), tbName.Text.ToString());
                    this.BindCombo();
                    tbName.Clear();
                    MessageBox.Show("Uspešno ste promenili naziv rudnika");
                    UpdateComboBoxInVehicle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete rudnik? \nBrisanjem ovog rudnika brišete i sva vozila koja se nalaze u njemu", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _mineService.DeleteMine(int.Parse(cmbName.SelectedValue.ToString()));
                    this.BindCombo();

                    MessageBox.Show("Uspešno ste obrisali rudnik");
                    UpdateComboBoxInVehicle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
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
