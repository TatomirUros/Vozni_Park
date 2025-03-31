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
using static System.Windows.Forms.DataFormats;

namespace Vozni_Park.View
{
    public partial class ServiceType : Form
    {
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceType()
        {
            InitializeComponent();
            _serviceTypeService = new ServiceTypeService();
        }
        private async void BindCombo()
        {
            try
            {
                List<ServiceTypeDTO> mines = await _serviceTypeService.GetAllServiceTypes();
                cmbName.DataSource = mines;
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
                await _serviceTypeService.InsertServiceType(tbName.Text.ToString());
                this.BindCombo();
                tbName.Clear();
                MessageBox.Show("Uspešno ste uneli tip servisa");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške , {ex.Message}");
            }
        }

        private void ServiceType_Load(object sender, EventArgs e)
        {
            this.BindCombo();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete tip servisa? \nBrisanjem ovog tipa servisa brišete i sve servise i zahteve ovog tipa", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _serviceTypeService.DeleteServiceType(int.Parse(cmbName.SelectedValue.ToString()));
                    this.BindCombo();

                    MessageBox.Show("Uspešno ste obrisali tip servisa");
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
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite naziv tipu servisa?", "Potvrda promene", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _serviceTypeService.UpdateServiceType(int.Parse(cmbName.SelectedValue.ToString()), tbName.Text.ToString());
                    this.BindCombo();
                    tbName.Clear();
                    MessageBox.Show("Uspešno ste promenili naziv tipu servisa");
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
