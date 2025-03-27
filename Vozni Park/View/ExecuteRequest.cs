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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

namespace Vozni_Park.View
{
    public partial class ExecuteRequest : Form
    {
        private readonly IRepairerService _repairerService;
        private readonly IServiceTypeService _serviceType;
        private readonly IExecuteRequestService _executeRequest;
        private int idRequest;
        private int idServiceVehicle;
        private readonly int idVehicle;

        private List<string> imageFiles = new List<string>();
        private int currentImageId = 0;

        public ExecuteRequest(string registration, int idServiceType, string description, int idRequest, int idVehicle)
        {
            try
            {
                InitializeComponent();
                _repairerService = new RepairerService();
                _serviceType = new ServiceTypeService();
                _executeRequest = new ExecuteRequestService();
                this.BindCombo();
                this.idRequest = idRequest;
                this.idServiceVehicle = -1;
                this.idVehicle = idVehicle;
                tbReg.Text = registration;
                cmbServiceType.SelectedValue = idServiceType;
                tbDescription.Text = description;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        public ExecuteRequest(string registration, string kilometers, DateTime date, int idServiceType, int idRepairer, string description, int idServiceVehicle, float price, int idVehicle)
        {
            try
            {
                InitializeComponent();
                _repairerService = new RepairerService();
                _serviceType = new ServiceTypeService();
                _executeRequest = new ExecuteRequestService();
                this.BindCombo();
                this.idRequest = -1;
                this.idServiceVehicle = idServiceVehicle;
                this.idVehicle = idVehicle;
                tbReg.Text = registration;
                tbKm.Text = kilometers;
                dtpDate.Value = date;
                cmbServiceType.SelectedValue = idServiceType;
                cmbRepairer.SelectedValue = idRepairer;
                tbDescription.Text = description;
                tbPrice.Text = price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private async void BindCombo()
        {
            try
            {
                List<RepairerDTO> repairers = await _repairerService.GetAllRepairers();
                cmbRepairer.DataSource = repairers;
                cmbRepairer.ValueMember = "Id";
                cmbRepairer.DisplayMember = "Name";

                List<ServiceTypeDTO> serviceTypes = await _serviceType.GetAllServiceTypes();
                cmbServiceType.DataSource = serviceTypes;
                cmbServiceType.ValueMember = "Id";
                cmbServiceType.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void ExecuteRequest_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                LoadImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = dtpDate.Value;
                DateOnly date = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
                float price;
                if (string.IsNullOrWhiteSpace(tbPrice.Text))
                    price = 0;
                else
                    price = float.Parse(tbPrice.Text.ToString());

                if (idServiceVehicle == -1)
                {
                    await _executeRequest.ExecuteRequest(new ExecuteRequestDTO(0, tbReg.Text, tbKm.Text, date, tbDescription.Text, idVehicle, int.Parse(cmbServiceType.SelectedValue.ToString()), int.Parse(cmbRepairer.SelectedValue.ToString()), idRequest, price));
                    idServiceVehicle = await _executeRequest.GetMaxIdExecute();
                    btnAddImage.Enabled = true;
                    btnNext.Enabled = true;
                    btnBefore.Enabled = true;
                    btnDelete.Enabled = true;

                }
                else if (idRequest == -1)
                {
                    await _executeRequest.UpdateExecutedRequest(new ExecuteRequestDTO(idServiceVehicle, tbReg.Text, tbKm.Text, date, tbDescription.Text, idVehicle, int.Parse(cmbServiceType.SelectedValue.ToString()), int.Parse(cmbRepairer.SelectedValue.ToString()), 0, price));
                }
                MessageBox.Show("Uspešno ste izvršili servis");

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

        private async void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                await AddPictures();
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
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete ovu saobraćajnu?", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    if (pictureBox1.Image != null && currentImageId >= 0 && currentImageId < imageFiles.Count)
                    {
                        string fileToDelete = imageFiles[currentImageId];

                        // Prvo oslobodi PictureBox da ne bi bilo problema sa brisanjem
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                        GC.Collect(); // Poziva Garbage Collector
                        GC.WaitForPendingFinalizers(); // Čeka da oslobodi resurse

                        // Obriši fajl sa diska
                        File.Delete(fileToDelete);

                        // Ukloni sliku iz liste
                        imageFiles.RemoveAt(currentImageId);

                        // Pomeranje indeksa: ako je poslednja slika obrisana, idemo nazad
                        if (currentImageId >= imageFiles.Count)
                            currentImageId = Math.Max(0, imageFiles.Count - 1);

                        // Ako još ima slika, prikaži sledeću, inače očisti PictureBox
                        if (imageFiles.Count > 0)
                            LoadImage();
                        else
                            pictureBox1.Image = null; // Nema više slika

                        MessageBox.Show("Uspešno ste obrisali izabranu sliku zahteva");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            try
            {
                Previous_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Next_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async Task AddPictures()
        {
            try
            {
                if (idRequest == -1)
                    idRequest = await _executeRequest.GetRequestIdByServiceVehicleId(idServiceVehicle);

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
                    await _executeRequest.InsertPicture(basePath, idServiceVehicle);
                    LoadImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private Image CorrectImageOrientation(Image img)
        {
            if (Array.IndexOf(img.PropertyIdList, 0x0112) > -1) // 0x0112 je ID za orijentaciju
            {
                var orientation = (int)img.GetPropertyItem(0x0112).Value[0];

                switch (orientation)
                {
                    case 3: // 180 stepeni
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 6: // 90 stepeni udesno
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 8: // 90 stepeni ulevo
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
            }
            return img;
        }

        private async void LoadImage()
        {
            if (idRequest == -1)
                idRequest = await _executeRequest.GetRequestIdByServiceVehicleId(idServiceVehicle);

            string vehicleFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", idVehicle.ToString(), "request", idRequest.ToString());

            if (Directory.Exists(vehicleFolderPath))
            {
                imageFiles = Directory.GetFiles(vehicleFolderPath, "*.*")
                                               .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".bmp") || f.EndsWith(".jpeg"))
                                               .ToList();

                if (imageFiles.Count > 0)
                {
                    currentImageId = 0;
                    ShowImage();
                }
            }
        }

        private void ShowImage()
        {
            if (imageFiles.Count > 0 && currentImageId >= 0 && currentImageId < imageFiles.Count)
            {
                Image originalImage = Image.FromFile(imageFiles[currentImageId]);
                Image correctedImage = CorrectImageOrientation(originalImage);
                pictureBox1.Image = correctedImage;
            }
            else
            {
                MessageBox.Show($"{currentImageId}{imageFiles.Count}");
            }
        }

        private void Next_Click()
        {
            if (currentImageId < imageFiles.Count - 1)
            {
                currentImageId++;
                ShowImage();
            }
        }

        private void Previous_Click()
        {
            if (currentImageId > 0)
            {
                currentImageId--;
                ShowImage();
            }
        }
    }
}
