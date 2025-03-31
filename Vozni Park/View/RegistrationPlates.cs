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
    public partial class RegistrationPlates : Form
    {
        private readonly IRegistrationPlatesService _registrationPlatesService;
        private readonly int _idVehicle;

        public RegistrationPlates()
        {
            _registrationPlatesService = new RegistrationPlatesService();
            InitializeComponent();
        }

        public RegistrationPlates(int _idVehicle)
        {
            this._idVehicle = _idVehicle;
            _registrationPlatesService = new RegistrationPlatesService();
            InitializeComponent();
        }

        private async void BindDataGridView()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<RegistrationPlatesDTO> list = await _registrationPlatesService.GetAllRegistrationPlatesById(_idVehicle);
                dataGridView1.DataSource = list;

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Obriši";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }
        private void RegistrationPlates_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Registration"].HeaderText = "Registracija";
            dataGridView1.Columns["IdVehicle"].Visible = false;
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    
                    await _registrationPlatesService.DeleteRegistrationPlates(id);
                    BindDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }
    }
}
