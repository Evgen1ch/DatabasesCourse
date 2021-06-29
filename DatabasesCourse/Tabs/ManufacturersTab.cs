using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.Logging;
using DatabasesCourse.UniversalForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel.Entities;

namespace DatabasesCourse.Tabs
{
    public partial class ManufacturersTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public ManufacturersTab()
        {
            InitializeComponent();
            dgvTable.AutoGenerateColumns = false;
        }

        private void ManufacturersTab_Load(object sender, EventArgs e)
        {
            Context = AppGlobals.Context;
            Context.Manufacturers.Load();
            dgvTable.DataSource = Context.Manufacturers.Local.ToBindingList();
        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            ManufacturerForm form = new ManufacturerForm(Context, FormAction.Create, 0);
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
                UpdateDataGridView();
        }

        private void buttonUpdate_Click(object sender, System.EventArgs e)
        {
            int id = -1;
            if (dgvTable.CurrentRow?.Index != -1)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow?.Cells["Id"].Value);
            }

            if (id > 0)
            {
                ManufacturerForm form = new ManufacturerForm(Context, FormAction.Update, id);
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                    UpdateDataGridView();
            }
            else
            {
                MessageBox.Show(@"Something went wrong");
            }
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            int id = -1;
            if (dgvTable.CurrentRow?.Index != -1)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow?.Cells["Id"].Value);
            }

            if (id < 1) return;

            var result = MessageBox.Show($@"Are you sure you want ot delete entry with id = {id}");
            if (result == DialogResult.OK)
            {
                var toDelete = Context.Manufacturers.FirstOrDefault(m => m.Id == id);
                if (toDelete != null)
                {
                    try
                    {
                        Context.Manufacturers.Remove(toDelete);
                        Context.SaveChanges();
                        Logger.Log($"Deleted Manufacturer with id = {toDelete.Id}", LogAction.Remove);
                        UpdateDataGridView();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            @"You can not delete manufacturer beacuse you have products of this manufacturer.",
                            @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        var entry = Context.ChangeTracker.Entries<Manufacturer>().FirstOrDefault(c => c.Entity.Id == toDelete.Id && c.State == EntityState.Deleted);
                        entry.State = EntityState.Unchanged;
                    }
                }
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            string name = textBoxSearchName.Text.Trim();
            string country = textBoxSearchCountry.Text.Trim();

            bool filtered = false;
            var resultQuery = Context.Manufacturers.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                resultQuery = resultQuery.Where(m => EF.Functions.Like(m.Name, $"%{name}%"));
                filtered = true;
            }

            if (!string.IsNullOrEmpty(country))
            {
                resultQuery = resultQuery.Where(m => EF.Functions.Like(m.Country, $"%{country}%"));
                filtered = true;
            }

            if (filtered)
                dgvTable.DataSource = resultQuery.ToList();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dgvTable.DataSource = Context.Manufacturers.Local.ToBindingList();
        }

    }
}
