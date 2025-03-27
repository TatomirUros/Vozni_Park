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
using System.Windows.Forms.VisualStyles;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using Application = System.Windows.Forms.Application;

namespace Vozni_Park.View
{
    public partial class ServiceRequest : Form
    {
        private readonly IServiceTypeService _typeService;
        private readonly IServiceRequestService _serviceRequset;
        private readonly int idVehicle;


        public ServiceRequest()
        {
            InitializeComponent();
            _typeService = new ServiceTypeService();
            _serviceRequset = new ServiceRequestService();
        }

        public ServiceRequest(int idVehicle, string Brand, string Model, string Registration)
        {
            InitializeComponent();
            _typeService = new ServiceTypeService();
            _serviceRequset = new ServiceRequestService();
            this.idVehicle = idVehicle;
            tbBrand.Text = Brand;
            tbModel.Text = Model;
            tbReg.Text = Registration;
        }

        public ServiceRequest(int idVehicle, string Brand, string Model, string Registration, int idServiceType, string Name, string Description)
        {
            InitializeComponent();
            _typeService = new ServiceTypeService();
            _serviceRequset = new ServiceRequestService();
            this.idVehicle = idVehicle;
            tbBrand.Text = Brand;
            tbModel.Text = Model;
            tbReg.Text = Registration;
            tbNumber.Text = Name;
            tbDescription.Text = Description;
            cmbTypService.SelectedValue = idServiceType;
        }
        private async void BindCombo()
        {
            try
            {
                cmbTypService.DataSource = null;
                List<ServiceTypeDTO> owners = await _typeService.GetAllServiceTypes();
                cmbTypService.DataSource = owners;
                cmbTypService.ValueMember = "Id";
                cmbTypService.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void BindDataGridView()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<ServiceRequestTableViewDTO> list = await _serviceRequset.GetAllRequestsForVehicle(idVehicle);
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private void ServiceRequest_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindCombo();

                this.BindDataGridView();
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Ispuni";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);

                DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
                buttonColumn2.HeaderText = "  ";
                buttonColumn2.Text = "Obriši";
                buttonColumn2.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn2);

                DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
                buttonColumn3.HeaderText = "  ";
                buttonColumn3.Text = "Pregled zahteva";
                buttonColumn3.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn3);

                DataGridViewButtonColumn buttonColumn4 = new DataGridViewButtonColumn();
                buttonColumn4.HeaderText = "  ";
                buttonColumn4.Text = "Dodaj slike";
                buttonColumn4.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                await _serviceRequset.InsertServiceRequest(new ServiceRequestDTO(0, tbNumber.Text, tbDescription.Text, idVehicle, int.Parse(cmbTypService.SelectedValue.ToString())));

                this.ServiceRequest_Load(sender, e);

                tbDescription.Clear();
                tbNumber.Clear();

                
                foreach (Form otvorenaForma in Application.OpenForms)
                {
                    if (otvorenaForma is Vehicle)
                    {
                        Vehicle vehicle = (Vehicle)otvorenaForma;
                        await vehicle.WriteLabelForRequests();
                    }
                }
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
                if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int idServiceType = await _typeService.GetServiceTypeIdByName(selectedRow.Cells["NameServiceType"].Value.ToString());
                    int idRequest = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                    ExecuteRequest forma = new ExecuteRequest(tbReg.Text, idServiceType, tbDescription.Text, idRequest, idVehicle);
                    forma.ShowDialog();
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                    DialogResult rezultat = MessageBox.Show("Da li želite da obrišete zahtev?", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (rezultat == DialogResult.Yes)
                    {
                        await _serviceRequset.DeleteServiceRequest(id);
                        MessageBox.Show("Uspešno ste obrisali zahteve");

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
                if (e.RowIndex >= 0 && e.ColumnIndex == 5)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                    ShowServiceRequest showServiceRequest = new ShowServiceRequest(id);
                    
                    showServiceRequest.Show();
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    int idRequest = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    await AddPictures(idRequest);
                   
                    MessageBox.Show("Uspešno ste dodali slike zahteva");                   
                }

                this.ServiceRequest_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["NameRequest"].HeaderText = "Zahtev";
                dataGridView1.Columns["NameServiceType"].HeaderText = "Tip servisa";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private async Task AddPictures(int idRequest)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp|Svi fajlovi|*.*";
                openFileDialog.Multiselect = true; // Omogućite odabir više slika

                string basePath = Path.Combine("images", idVehicle.ToString(), "request", idRequest.ToString()); // Samo "request" folder dodat ovde

                // Kreiraj folder ako ne postoji
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int i = 0;
                    foreach (string picturePath in openFileDialog.FileNames)
                    {
                        i++;
                        string extension = Path.GetExtension(picturePath);
                        string fileName = $"{idVehicle}_{DateTime.Now:yyyyMMdd_HHmmss_fff}_{i}{extension}";
                        string newPath = Path.Combine(basePath, fileName);

                        // Kopiramo sliku na novu lokaciju
                        File.Copy(picturePath, newPath, true);

                    }
                    // Čuvamo putanju u bazi
                    await _serviceRequset.InsertPicture(basePath, idRequest);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
    }
}
