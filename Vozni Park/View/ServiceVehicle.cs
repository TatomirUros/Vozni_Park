using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.Services.Interfaces;
using Vozni_Park.Services;
using Vozni_Park.DTOs;
using System.Reflection;
using static System.Windows.Forms.DataFormats;
using System.Globalization;

namespace Vozni_Park.View
{
    public partial class ServiceVehicle : Form
    {
        private readonly IServiceVehicleService _serviceVehicle;
        private readonly IServiceTypeService _typeService;
        private readonly IRepairerService _repairerService;

        private readonly int idVehicle;


        public ServiceVehicle()
        {
            InitializeComponent();
            _serviceVehicle = new ServiceVehicleService();
            _typeService = new ServiceTypeService();
            _repairerService = new RepairerService();

        }

        public ServiceVehicle(int idVehicle, string Brand, string Model, string Registration)
        {
            InitializeComponent();
            _serviceVehicle = new ServiceVehicleService();
            _typeService = new ServiceTypeService();
            _repairerService = new RepairerService();

            this.idVehicle = idVehicle;
            tbBrand.Text = Brand;
            tbModel.Text = Model;
            tbReg.Text = Registration;
            this.BindDataGridView();

        }

        private async void BindDataGridView()
        {
            try
            { 
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<ServiceVehicleTableViewDTO> list = await _serviceVehicle.GetAllRequestsForVehicle(idVehicle);
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }
        private void ServiceVehicle_Load(object sender, EventArgs e)
        {
            try
            { 
                this.BindDataGridView();
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Izmeni";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);

                DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
                buttonColumn2.HeaderText = "  ";
                buttonColumn2.Text = "Obriši";
                buttonColumn2.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn2);

                DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
                buttonColumn3.HeaderText = "  ";
                buttonColumn3.Text = "Prikaži zahtev";
                buttonColumn3.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn3);

                DataGridViewButtonColumn buttonColumn4 = new DataGridViewButtonColumn();
                buttonColumn4.HeaderText = "  ";
                buttonColumn4.Text = "Prikaži račun";
                buttonColumn4.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn4);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.RowIndex >= 0 && e.ColumnIndex == 7)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int idServiceType = await _typeService.GetServiceTypeIdByName(selectedRow.Cells["NameServiceType"].Value.ToString());
                    int idServiceVehicle = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    string kilometers = selectedRow.Cells["Kilometers"].Value.ToString();
                    string dateString = selectedRow.Cells["Date"].Value.ToString();
                    float cena = float.Parse(selectedRow.Cells["Price"].Value.ToString());
                    DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture); ;
                    string description = selectedRow.Cells["Description"].Value.ToString();
                    int idRepairer = await _repairerService.GetRepairerIdByName(selectedRow.Cells["NameRepairer"].Value.ToString());

                    ExecuteRequest forma = new ExecuteRequest(tbReg.Text, kilometers, date, idServiceType, idRepairer, description, idServiceVehicle, cena, idVehicle);
                    forma.ShowDialog();

                }

                if (e.RowIndex >= 0 && e.ColumnIndex == 8)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                    DialogResult rezultat = MessageBox.Show("Da li želite da obrišete servis? \n Ovaj servis će se vrtiti u zahteve ", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (rezultat == DialogResult.Yes)
                    {
                        await _serviceVehicle.DeleteServiceVehicle(id);
                        MessageBox.Show("Uspešno ste vratili servis u zahteve");

                        foreach (Form otvorenaForma in Application.OpenForms)
                        {
                            // Proverite ime forme i uradite nešto sa njom
                            if (otvorenaForma is Vehicle)
                            {
                                // Ovo je Form2, uradite nešto sa njom
                                // Na primer, zatvorite je:
                                Vehicle vehicle = (Vehicle)otvorenaForma;
                                await vehicle.WriteLabelForRequests();
                            }
                        }
                    }
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == 9)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    int serviceRequestId = await _serviceVehicle.GetServiceRequestIdForServiceId(id);
                    ShowServiceRequest showServiceRequest = new ShowServiceRequest(serviceRequestId);

                    showServiceRequest.Show();
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == 10)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int idServiceType = await _typeService.GetServiceTypeIdByName(selectedRow.Cells["NameServiceType"].Value.ToString());
                    int idServiceVehicle = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    string kilometers = selectedRow.Cells["Kilometers"].Value.ToString();
                    string dateString = selectedRow.Cells["Date"].Value.ToString();
                    float cena = float.Parse(selectedRow.Cells["Price"].Value.ToString());
                    DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    string description = selectedRow.Cells["Description"].Value.ToString();
                    int idRepairer = await _repairerService.GetRepairerIdByName(selectedRow.Cells["NameRepairer"].Value.ToString());

                    ExecuteRequest forma = new ExecuteRequest(tbReg.Text, kilometers, date, idServiceType, idRepairer, description, idServiceVehicle, cena, idVehicle);
                    forma.ShowDialog();
                }

                this.ServiceVehicle_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            { 
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Date"].HeaderText = "Datum";
                dataGridView1.Columns["Kilometers"].HeaderText = "Kilometraža";
                dataGridView1.Columns["NameServiceType"].HeaderText = "Tip servisa";
                dataGridView1.Columns["NameRepairer"].HeaderText = "Serviser";
                dataGridView1.Columns["Description"].HeaderText = "Opis servisa";
                dataGridView1.Columns["Price"].HeaderText = "Cena";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }
    }
}
