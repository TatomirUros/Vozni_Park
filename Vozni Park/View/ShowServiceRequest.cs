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
    public partial class ShowServiceRequest : Form
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly int idRequest;
        private List<string> imageFiles = new List<string>();
        private int currentImageId = 0;
        public ShowServiceRequest(int idRequest)
        {
            InitializeComponent();
            _serviceRequestService = new ServiceRequestService();
            this.idRequest = idRequest;
        }

        private async void ShowServiceRequest_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestShowDetailsDTO request = await _serviceRequestService.GetRequestForRequestId(idRequest);
                tbNumberOfRequest.Text = request.NumberOfRequest;
                tbDescription.Text = request.Description;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                LoadImage();
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
                AddPictures();
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

                        MessageBox.Show("Slika uspešno obrisana.");
                    }
                }
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

        private async Task AddPictures()
        {
            try
            {

                int idVehicle = await _serviceRequestService.GetVehicleIdForRequestId(idRequest);
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp|Svi fajlovi|*.*";
                openFileDialog.Multiselect = true; // Omogućite odabir više slika

                string basePath = Path.Combine("images", idVehicle.ToString(), "receipt", idRequest.ToString()); // Samo "vehicle" folder dodat ovde

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
                    await _serviceRequestService.InsertPicture(basePath, idVehicle);
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
            int idVehicle = await _serviceRequestService.GetVehicleIdForRequestId(idRequest);
            string vehicleFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", idVehicle.ToString(), "receipt", idRequest.ToString());

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
