using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Vozni_Park.DTOs;
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.View
{
    public partial class Tag : Form
    {
        private readonly ITagService _tagService;
        private int _idTag;
        public Tag()
        {
            InitializeComponent();
            _tagService = new TagService();
        }
        private async void BindDataGridView()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<TagTableViewDTO> list = await _tagService.GetAllTagsForTableView();
                dataGridView1.DataSource = list;
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
                if (string.IsNullOrWhiteSpace(tbReg.Text) || string.IsNullOrWhiteSpace(tbSerialNumber.Text))
                    MessageBox.Show("Niste popunili sva polja");

                else
                {
                    await _tagService.InsertTag(new TagDTO(0, tbReg.Text, tbSerialNumber.Text));
                    this.Tag_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rezultat = MessageBox.Show("Da li želite da promenite informacije o TAG-u?", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _tagService.UpdateTag(new TagDTO(_idTag, tbReg.Text, tbSerialNumber.Text));
                    this.Tag_Load(sender, e);
                    MessageBox.Show("Uspešno ste promenili informacije o TAG-u");
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
                DialogResult rezultat = MessageBox.Show("Da li želite da obrišete TAG? \nBrisanjem TAG-a brišete i sve informacije o dopunjavanju istog", "Potvrda brisanja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    await _tagService.DeleteTag(_idTag);
                    this.Tag_Load(sender, e);
                    MessageBox.Show("Uspešno ste obrisali TAG");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private async void tbFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbFind.Text))
                {
                    btnDelete.Enabled = false;
                    btnFind.Enabled = false;
                    btnUpdate.Enabled = false;

                    tbSerialNumber.Clear();
                    tbReg.Clear();
                }
                else
                {
                    TagDTO tag = await _tagService.GetTagIdByRegistration(tbFind.Text);
                    if (tag != null)
                    {
                        _idTag = tag.Id;
                        tbReg.Text = tag.Registration;
                        tbSerialNumber.Text = tag.SerialNumber;
                    }
                    if (!string.IsNullOrWhiteSpace(tbReg.Text))
                    {
                        btnDelete.Enabled = true;
                        btnFind.Enabled = true;
                        btnUpdate.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void Tag_Load(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnUpdate.Enabled = false;

                this.BindDataGridView();
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = " ";
                buttonColumn.Text = "Detalji";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    string registration = selectedRow.Cells["Registration"].Value.ToString();
                    string serialNumber = selectedRow.Cells["SerialNumber"].Value.ToString();

                    TagReplenishment tagReplenishment = new TagReplenishment(registration, serialNumber, id);

                    tagReplenishment.Show();

                }

                this.Tag_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                TagReplenishment tagReplenishment = new TagReplenishment(tbReg.Text, tbSerialNumber.Text, _idTag);
                tagReplenishment.Show();
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
                dataGridView1.Columns["Registration"].HeaderText = "Registracija";
                dataGridView1.Columns["SerialNumber"].HeaderText = "Serijski broj";
                dataGridView1.Columns["Date"].HeaderText = "Datum poslednjeg punjenja";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške");
            }

        }
    }
}
