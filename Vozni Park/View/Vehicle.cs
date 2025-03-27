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
using Vozni_Park.Services.Interfaces;
using Vozni_Park.Services;
using System.Windows.Forms.VisualStyles;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Vozni_Park.Context;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Vozni_Park.View
{
    public partial class Vehicle : Form
    {
        private readonly IOwnerService _ownerService;
        private readonly IMineService _mineService;
        private readonly IVehicleService _vehicleService;
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IStateService _stateService;
        private List<string> imageFiles = new List<string>();
        private int currentImageId = 0;
        private string checkOtherVehicleForPictures = "";
        public Vehicle()
        {
            InitializeComponent();
            _ownerService = new OwnerService();
            _mineService = new MineService();
            _vehicleService = new VehicleService();
            _categoryService = new CategoryService();
            _subcategoryService = new SubcategoryService();
            _stateService = new StateService();
        }

        public async void BindCombo()
        {
            try
            {
                List<OwnerDTO> owners = await _ownerService.GetAllOwners();
                cmbOwner.DataSource = owners;
                cmbOwner.ValueMember = "Id";
                cmbOwner.DisplayMember = "Name";
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
                List<StateDTO> states = await _stateService.GetAllStates();
                cmbVehicleState.DataSource = states;
                cmbVehicleState.ValueMember = "Id";
                cmbVehicleState.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void Vehicle_Load(object sender, EventArgs e)
        {
            tbFind.Focus();
            tbFind.Select();
            rbRegYes.Checked = true;
            BindCombo();
            dtpDate.CustomFormat = "dd/MM/yyyy";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            lbNumberOfRequests.Visible = false;
            btnAddImage.Enabled = false;
            btnDeleteImage.Enabled = false;
            btnBefore.Enabled = false;
            btnNext.Enabled = false;
            btnRequest.Enabled = false;
            btnServiceVehicle.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnShowCertifivate.Enabled = false;
            btnShowAllRegistrationPlates.Enabled = false;
        }
        private async void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbReg.Text))
                    MessageBox.Show("Polje za registraciju nije popunjeno. \nOvo polje je obavezno");
                else
                {
                    if (rbRegYes.Checked || rbRegWas.Checked)
                    {
                        DateOnly date = DateOnly.FromDateTime(dtpDate.Value);
                        await _vehicleService.InsertVehicle(new VehicleDTO(0, tbBrand.Text, tbModel.Text, tbKm.Text, int.Parse(cmbOwner.SelectedValue.ToString()), int.Parse(cmbMine.SelectedValue.ToString()), int.Parse(cmbCategory.SelectedValue.ToString()), int.Parse(cmbSubcategory.SelectedValue.ToString()), tbReg.Text, date, int.Parse(cmbVehicleState.SelectedValue.ToString()), tbTireDimension.Text));
                    }
                    else
                    {
                        DateOnly date = DateOnly.MinValue;
                        await _vehicleService.InsertVehicle(new VehicleDTO(0, tbBrand.Text, tbModel.Text, tbKm.Text, int.Parse(cmbOwner.SelectedValue.ToString()), int.Parse(cmbMine.SelectedValue.ToString()), int.Parse(cmbCategory.SelectedValue.ToString()), int.Parse(cmbSubcategory.SelectedValue.ToString()), tbReg.Text, date, int.Parse(cmbVehicleState.SelectedValue.ToString()), tbTireDimension.Text));
                    }
                    tbBrand.Clear();
                    tbModel.Clear();
                    tbReg.Clear();
                    tbKm.Clear();
                    tbTireDimension.Clear();
                    dtpDate.Value = DateTime.Now;
                    pictureBox1.Image = null;

                    MessageBox.Show("Uspešno ste uneli novo vozilo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite podatke o vozilu?", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    int id = await _vehicleService.GetVehicleIdByRegistration(tbReg.Text);
                    DateOnly date = DateOnly.FromDateTime(dtpDate.Value);
                    if (id != -1)
                        await _vehicleService.UpdateVehicle(new VehicleDTO(id, tbBrand.Text, tbModel.Text, tbKm.Text, int.Parse(cmbOwner.SelectedValue.ToString()), int.Parse(cmbMine.SelectedValue.ToString()), int.Parse(cmbCategory.SelectedValue.ToString()), int.Parse(cmbSubcategory.SelectedValue.ToString()), tbReg.Text, date, int.Parse(cmbVehicleState.SelectedValue.ToString()), tbTireDimension.Text));
                    await FindAll();

                    MessageBox.Show("Uspešno ste promenili podatke o vozilu");
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
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete izabrano vozilo? \nBrisanjem ovog vozila brišete sve slike, servise i zahteve za to vozilo", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    int id = await _vehicleService.GetVehicleIdByRegistration(tbReg.Text);
                    if (id != -1)
                        await _vehicleService.DeleteVehicle(id);

                    MessageBox.Show("Uspešno ste obrisali vozilo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async Task FindAll()
        {
            try
            {
                VehicleDTO vehicle = await _vehicleService.GetVehicleByRegistration(tbFind.Text);
                if (vehicle != null)
                {
                    DateTime now = DateTime.Now;
                    DateTime dateTo = new DateTime(vehicle.DateTo.Year, vehicle.DateTo.Month, vehicle.DateTo.Day);
                    tbBrand.Text = vehicle.Brand;
                    tbModel.Text = vehicle.Model;
                    tbKm.Text = vehicle.Kilometers;
                    cmbOwner.SelectedValue = vehicle.IdOwner;
                    cmbMine.SelectedValue = vehicle.IdMine;
                    cmbCategory.SelectedValue = vehicle.IdCategory;
                    cmbSubcategory.SelectedValue = vehicle.IdSubcategory;
                    cmbVehicleState.SelectedValue = vehicle.IdState;
                    tbReg.Text = vehicle.Registration;
                    tbTireDimension.Text = vehicle.TireDimension;


                    if (dateTo == DateTime.MinValue)
                    {
                        dtpDate.Value = dtpDate.MinDate;
                        rbRegNo.Checked = true;
                    }
                    else if (dateTo < now)
                    {
                        dtpDate.Value = dateTo;
                        rbRegWas.Checked = true;
                    }
                    else if (dateTo > now)
                    {
                        dtpDate.Value = dateTo;
                        rbRegYes.Checked = true;
                    }
                }
                else
                {
                    tbBrand.Clear();
                    tbModel.Clear();
                    tbReg.Clear();
                    tbKm.Clear();
                    tbTireDimension.Clear();
                    dtpDate.Value = DateTime.Now;
                    pictureBox1.Image = null;

                    lbNumberOfRequests.Visible = false;
                    btnAddImage.Enabled = false;
                    btnDeleteImage.Enabled = false;
                    btnBefore.Enabled = false;
                    btnNext.Enabled = false;
                    btnRequest.Enabled = false;
                    btnServiceVehicle.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnShowCertifivate.Enabled = false;
                    btnShowAllRegistrationPlates.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        public async Task FindWithId(int id)
        {
            try
            {
                VehicleDTO vehicle = await _vehicleService.GetVehicleById(id);
                if (vehicle != null)
                {
                    DateTime now = DateTime.Now;
                    DateTime dateTo = new DateTime(vehicle.DateTo.Year, vehicle.DateTo.Month, vehicle.DateTo.Day);
                    tbBrand.Text = vehicle.Brand;
                    tbModel.Text = vehicle.Model;
                    tbKm.Text = vehicle.Kilometers;
                    cmbOwner.SelectedValue = vehicle.IdOwner;
                    cmbMine.SelectedValue = vehicle.IdMine;
                    cmbCategory.SelectedValue = vehicle.IdCategory;
                    cmbSubcategory.SelectedValue = vehicle.IdSubcategory;
                    cmbVehicleState.SelectedValue = vehicle.IdState;
                    tbTireDimension.Text = vehicle.TireDimension;
                    tbReg.Text = vehicle.Registration;
                    tbFind.Text = vehicle.Registration;

                    if (dateTo == DateTime.MinValue)
                    {
                        dtpDate.Value = dtpDate.MinDate;
                        rbRegNo.Checked = true;
                    }
                    else if (dateTo < now)
                    {
                        dtpDate.Value = dateTo;
                        rbRegWas.Checked = true;
                    }
                    else if (dateTo > now)
                    {
                        dtpDate.Value = dateTo;
                        rbRegYes.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void tbFind_TextChangedAsync(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbFind.Text))
                {
                    tbBrand.Clear();
                    tbModel.Clear();
                    tbReg.Clear();
                    tbKm.Clear();
                    tbTireDimension.Clear();
                    dtpDate.Value = DateTime.Now;
                    pictureBox1.Image = null;

                    lbNumberOfRequests.Visible = false;
                    btnAddImage.Enabled = false;
                    btnDeleteImage.Enabled = false;
                    btnBefore.Enabled = false;
                    btnNext.Enabled = false;
                    btnRequest.Enabled = false;
                    btnServiceVehicle.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnShowCertifivate.Enabled = false;
                    btnShowAllRegistrationPlates.Enabled = false;
                }
                else
                {
                    await FindAll();

                    if (!checkOtherVehicleForPictures.Equals(tbReg.Text))
                        pictureBox1.Image = null;

                    if (!string.IsNullOrWhiteSpace(tbReg.Text))
                    {
                        LoadImage();
                        await WriteLabelForRequests();
                        lbNumberOfRequests.Visible = true;
                        btnAddImage.Enabled = true;
                        btnDeleteImage.Enabled = true;
                        btnBefore.Enabled = true;
                        btnNext.Enabled = true;
                        btnRequest.Enabled = true;
                        btnServiceVehicle.Enabled = true;
                        btnDelete.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnShowCertifivate.Enabled = true;
                        btnShowAllRegistrationPlates.Enabled = true;
                    }
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
            int vehicleId = await FindId();
            string vehicleFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", vehicleId.ToString(), "vehicle");

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

        public async Task WriteLabelForRequests()
        {
            try
            {
                int id = await FindId();
                int numberOfRequests = await _vehicleService.CheckVehicleCorrectness(id);
                if (numberOfRequests > 1)
                {
                    lbNumberOfRequests.Text = "Ovo vozilo ima " + numberOfRequests.ToString() + " zahteva za servisom";
                    lbNumberOfRequests.Visible = true;
                    lbNumberOfRequests.ForeColor = Color.Red;
                }
                else if (numberOfRequests == 1)
                {
                    lbNumberOfRequests.Text = "Ovo vozilo ima " + numberOfRequests.ToString() + " zahtev za servisom";
                    lbNumberOfRequests.Visible = true;
                    lbNumberOfRequests.ForeColor = Color.Red;
                }
                else if (numberOfRequests == 0)
                {
                    lbNumberOfRequests.Text = "Ovo vozilo nema zahteve za servisiom";
                    lbNumberOfRequests.Visible = true;
                    lbNumberOfRequests.ForeColor = Color.Green;
                }
                else
                {
                    lbNumberOfRequests.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private async Task<int> FindId()
        {
            try
            {
                string registration = tbFind.Text;
                int id = -1;
                id = await _vehicleService.GetVehicleIdByRegistration(registration);
                if (id == -1)
                {
                    registration = tbReg.Text;
                    if (registration.Length >= 9)
                        id = await _vehicleService.GetVehicleIdByRegistration(registration);
                }
                return id;
            }
            catch (Exception ex)
            {
                return -1;
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "marka";
                string columnValue = tbBrand.Text;
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili marku vozila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateModel_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "model";
                string columnValue = tbModel.Text;
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili model vozila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateKm_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "kilometraza";
                string columnValue = tbKm.Text;
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili kilometražu vozila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "idVlasnika";
                string columnValue = cmbOwner.SelectedValue.ToString();
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili valsnika vozila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateMine_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "idRudnika";
                string columnValue = cmbMine.SelectedValue.ToString();
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili rudnik kome pripada vozilo");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateReg_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "registracija";
                string columnValue = tbReg.Text;
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili registraciju vozila");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateDate_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "datumDoKada";
                string columnValue = dtpDate.Value.ToString("yyyy-MM-dd");
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili datum do kada važi registracija vozila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnShowCertifivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbReg.Text))
                {
                    int id = await _vehicleService.GetVehicleIdByRegistration(tbReg.Text);
                    if (id != -1)
                    {
                        Certificate certificate = new Certificate(id);
                        certificate.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                int id = await _vehicleService.GetVehicleIdByRegistration(tbReg.Text);
                ServiceRequest request = new ServiceRequest(id, tbBrand.Text, tbModel.Text, tbReg.Text);

                request.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnServiceVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = await _vehicleService.GetVehicleIdByRegistration(tbReg.Text);
                ServiceVehicle service = new ServiceVehicle(id, tbBrand.Text, tbModel.Text, tbReg.Text);

                service.Show();
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

                int idVehicle = await FindId();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp|Svi fajlovi|*.*";
                openFileDialog.Multiselect = true; // Omogućite odabir više slika

                string basePath = Path.Combine("images", idVehicle.ToString(), "vehicle"); // Samo "vehicle" folder dodat ovde

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
                    await _vehicleService.InsertPicturesPath(basePath, idVehicle);
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
        private async void btnDeleteImage_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške pri brisanju slike, probajte ponovo za par trenutaka ako ni to ne radi pokrenite ponovo program");
            }
        }

        private void tAGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Tag)
                    {
                        // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                        form.BringToFront();
                        form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                        return;
                    }
                }
                Tag tag = new Tag();
                tag.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void rudniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Mine)
                    {
                        // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                        form.BringToFront();
                        form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                        return;
                    }
                }

                Mine mine = new Mine();
                mine.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void vlasniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Owner)
                    {
                        // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                        form.BringToFront();
                        form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                        return;
                    }
                }
                Owner owner = new Owner();
                owner.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void serviseriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Repairer)
                    {
                        // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                        form.BringToFront();
                        form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                        return;
                    }
                }
                Repairer repairer = new Repairer();
                repairer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void tipServisaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is ServiceType)
                    {
                        // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                        form.BringToFront();
                        form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                        return;
                    }
                }
                ServiceType serviceType = new ServiceType();
                serviceType.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbBrand.Clear();
            tbModel.Clear();
            tbReg.Clear();
            tbKm.Clear();
            tbFind.Clear();
            tbTireDimension.Clear();
            dtpDate.Value = DateTime.Now;
            pictureBox1.Image = null;
        }

        private void Vehicle_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppDbContext.CloseConnection();
            Application.Exit();

        }

        private void tabelarniPrikazVozilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is TableOfVehicles)
                {
                    // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                    form.BringToFront();
                    form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                    return;
                }
            }
            TableOfVehicles tableOfVehicles = new TableOfVehicles();
            tableOfVehicles.Show();
        }

        private void validnostRegistracijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is CheckRegistrationValidDate)
                {
                    // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                    form.BringToFront();
                    form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                    return;
                }
            }
            CheckRegistrationValidDate checkRegistrationValidDate = new CheckRegistrationValidDate();
            checkRegistrationValidDate.Show();
        }

        private void btnShowImage_Click(object sender, EventArgs e)
        {
            string fileToShow = imageFiles[currentImageId];
            Process.Start(new ProcessStartInfo(fileToShow) { UseShellExecute = true });
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

        private async void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "idKategorije";
                string columnValue = cmbCategory.SelectedValue.ToString();
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);

                columnName = "idPotkategorije";
                columnValue = cmbSubcategory.SelectedValue.ToString();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);

                MessageBox.Show("Uspešno ste promenili kategoriju i potkategoriju vozila");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateSubcategory_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "idPotkategorije";
                string columnValue = cmbSubcategory.SelectedValue.ToString();
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili potkategoriju vozila");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void kategorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Category)
                    {
                        // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                        form.BringToFront();
                        form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                        return;
                    }
                }
                Category category = new Category();
                category.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void potkategorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Subcategory)
                    {
                        // Ako forma postoji, dovodi je u fokus i vraća se iz metode
                        form.BringToFront();
                        form.WindowState = FormWindowState.Normal; // U slučaju da je minimizovana
                        return;
                    }
                }
                Subcategory subcategory = new Subcategory();
                subcategory.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private async void btnUpdateState_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "idStanja";
                string columnValue = cmbVehicleState.SelectedValue.ToString();
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili stanje vozila");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnShowAllRegistrationPlates_Click(object sender, EventArgs e)
        {
            try
            {
                int idVehicle = await _vehicleService.GetVehicleIdByRegistration(tbReg.Text);
                RegistrationPlates registrationPlates = new RegistrationPlates(idVehicle);
                registrationPlates.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdateTireDimension_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = "dimenzijeGuma";
                string columnValue = tbTireDimension.Text;
                int id = await FindId();

                await _vehicleService.UpdatePartVehicle(id, columnName, columnValue);
                MessageBox.Show("Uspešno ste promenili dimenzije guma vozila");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
    }
}
