using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.View
{
    public partial class Certificate : Form
    {
        private readonly ICertificateService _certificateService;
        private readonly int id;
        private List<string> imageFiles = new List<string>();
        private int currentImageId = 0;
        public Certificate()
        {
            InitializeComponent();
            _certificateService = new CertificateService();
        }

        public Certificate(int id)
        {
            InitializeComponent();
            this.id = id;
            _certificateService = new CertificateService();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private async Task AddPictures()
        {
            try
            {

                int idVehicle = id;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp|Svi fajlovi|*.*";
                openFileDialog.Multiselect = true; // Omogućite odabir više slika

                string basePath = Path.Combine("images", idVehicle.ToString(), "certificate"); // Samo "vehicle" folder dodat ovde

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
                    await _certificateService.UpdatePicture(basePath, idVehicle);
                    LoadImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private async void btnNew_Click(object sender, EventArgs e)
        {
            await AddPictures();
        }
        private void btnDelete_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadImage()
        {
            int vehicleId = id;
            string vehicleFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", vehicleId.ToString(), "certificate");

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

        private async void Certificate_Load(object sender, EventArgs e)
        {
            try
            {
                LoadImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Certificate_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Form forma in Application.OpenForms)
                {
                    if (forma is Vehicle)
                    {
                        forma.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Previous_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void PrintOriginalImageFromPictureBox(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Nema slike za štampanje!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Image originalImage = pictureBox.Image; // Uzimamo originalnu sliku

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                // Prilagodimo sliku veličini papira, ali bez menjanja originalnih dimenzija
                Rectangle printArea = e.MarginBounds;

                float scale = Math.Min((float)printArea.Width / originalImage.Width, (float)printArea.Height / originalImage.Height);
                int scaledWidth = (int)(originalImage.Width * scale);
                int scaledHeight = (int)(originalImage.Height * scale);

                // Centriramo sliku na papiru
                int offsetX = (printArea.Width - scaledWidth) / 2;
                int offsetY = (printArea.Height - scaledHeight) / 2;

                e.Graphics.DrawImage(originalImage, printArea.Left + offsetX, printArea.Top + offsetY, scaledWidth, scaledHeight);
            };

            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOriginalImageFromPictureBox(pictureBox1);
        }

        private void btnShowImage_Click(object sender, EventArgs e)
        {
            string fileToShow = imageFiles[currentImageId];
            Process.Start(new ProcessStartInfo(fileToShow) { UseShellExecute = true });
        }
    }
}
