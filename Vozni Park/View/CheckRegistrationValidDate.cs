using System.Globalization;
using Vozni_Park.DTOs;
using Vozni_Park.Helpers;
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.View
{
    public partial class CheckRegistrationValidDate : Form
    {
        private readonly IMineService _mineService;
        private readonly IVehicleService _vehicleService;

        public CheckRegistrationValidDate()
        {
            InitializeComponent();
            _mineService = new MineService();
            _vehicleService = new VehicleService();
        }

        private void CheckRegistrationValidDate_Load(object sender, EventArgs e)
        {
            BindCombo();
            BindDataGridView(-1);
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        }

        private async void BindCombo()
        {
            try
            {
                List<MineDTO> mines = await _mineService.GetAllMines();
                cmbMines.DataSource = mines;
                cmbMines.ValueMember = "Id";
                cmbMines.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }

        private async void BindDataGridView(int idMine)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<VehicleRegistrationTableViewDTO> list = await _vehicleService.CheckVehicleValueDate(idMine);
                dataGridView1.DataSource = list;


                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Registruj";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);

                DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
                buttonColumn2.HeaderText = " ";
                buttonColumn2.Text = "Prikaži";
                buttonColumn2.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn2);

                DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
                buttonColumn3.HeaderText = " ";
                buttonColumn3.Text = "Ne registruje se";
                buttonColumn3.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }

        private void FillDataGridViewByMine()
        {
            string idMineStringCheck = cmbMines.SelectedValue.ToString();
            int idMine;

            if (int.TryParse(idMineStringCheck, out idMine))
            {
                this.BindDataGridView(idMine);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            FillDataGridViewByMine();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Brand"].HeaderText = "Marka";
                dataGridView1.Columns["DateTo"].HeaderText = "Datum isteka registracije";
                dataGridView1.Columns["State"].HeaderText = "Ispravnost";
                dataGridView1.Columns["Owner"].HeaderText = "Vlasnik";
                dataGridView1.Columns["Mine"].HeaderText = "Rudnik";
                dataGridView1.Columns["Registration"].HeaderText = "Registracija";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            TablePrinter printer = new TablePrinter(dataGridView1, 9);
            printer.PrintTable();
        }

        private async void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 8)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    string dateTo = selectedRow.Cells["DateTo"].Value.ToString();

                    await _vehicleService.RegistrateVehicle(id, dateTo);
                    MessageBox.Show("Uspešno ste registrovali vozilo");
                    FillDataGridViewByMine();
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == 9)
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

                if (e.RowIndex >= 0 && e.ColumnIndex == 10)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    string dateTo = "1900-01-01";

                    await _vehicleService.RegistrateVehicle(id, dateTo);
                    MessageBox.Show("Uspešno ste uklonili vozilo iz tabele registracije");
                    FillDataGridViewByMine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške, {ex.Message}");
            }
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
