using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.View
{
    public partial class TagReplenishment : Form
    {
        private readonly ITagReplenishmentService _tagReplenishment;
        private readonly int _idTag;
        public TagReplenishment()
        {
            InitializeComponent();
            _tagReplenishment = new TagReplenishmentService();
        }

        public TagReplenishment(string registration, string serialNumber, int idTag)
        {
            InitializeComponent();
            _tagReplenishment = new TagReplenishmentService();
            _idTag = idTag;
            tbReg.Text = registration;
            tbSerialNumber.Text = serialNumber;

        }

        private async void BindDataGridView()
        {
            try
            { 
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<TagReplenishmentTableViewDTO> list = await _tagReplenishment.GetAllTagReplenishmentsForTableView(_idTag);
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
        private void TagReplenishment_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDate.CustomFormat = "dd/MM/yyyy";
                this.BindDataGridView();
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Obriši";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);
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
                if (string.IsNullOrWhiteSpace(tbAmount.Text))
                    MessageBox.Show("Niste uneli sumu koja je uplaćena");
                else
                {
                    string date = dtpDate.Value.ToString("yyyy-MM-dd");
                    await _tagReplenishment.InsertTagReplenishment(new TagReplenishmentDTO(0, date, float.Parse(tbAmount.Text.ToString()), _idTag));

                    this.TagReplenishment_Load(sender, e);
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
                    DialogResult rezultat = MessageBox.Show("Da li želite da obrišete ovo punjenje TAG-a?", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (rezultat == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                        int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                        await _tagReplenishment.DeleteTagReplenishment(id);
                        MessageBox.Show("Uspešno ste obrisali punjenje TAG-a");
                    }
                }

                this.TagReplenishment_Load(sender, e);
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
                dataGridView1.Columns["Date"].HeaderText = "Datum";
                dataGridView1.Columns["Amount"].HeaderText = "Iznos (RSD)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }
    }
}
