using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.UniversalForms;

namespace DatabasesCourse.Tabs
{
    public partial class CategoriesTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public CategoriesTab()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Context = AppGlobals.Context;
            Context.Categories.Load();

            dgvTable.AutoGenerateColumns = false;
            dgvTable.DataSource = Context.Categories.Local.ToBindingList();

            Sort();
        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();

        }

        public void Sort()
        {
            var idCol = dgvTable.Columns["Id"];
            if (idCol != null)
                dgvTable.Sort(idCol, ListSortDirection.Ascending);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CategoryForm form = new CategoryForm(Context, FormAction.Create, 0);
            form.ShowDialog();
            UpdateDataGridView();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (dgvTable.CurrentRow?.Index != -1)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow?.Cells["Id"].Value);
            }

            if (id != -1)
            {
                CategoryForm updateProductForm = new CategoryForm(Context, FormAction.Update, id);
                updateProductForm.ShowDialog();
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
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
                var toRemove = Context.Categories.FirstOrDefault(c => c.Id == id);
                if (toRemove != null)
                {
                    try
                    {
                        Context.Categories.Remove(toRemove);
                        Context.SaveChanges();
                        Logger.Log($"Category deleted with id = {toRemove.Id}", LogAction.Remove);
                        UpdateDataGridView();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"You can not delete category beacuse you have products of this category.",
                            @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        var entry = Context.ChangeTracker.Entries<Category>().FirstOrDefault(c=>c.Entity.Id == toRemove.Id && c.State == EntityState.Deleted);
                        entry.State = EntityState.Unchanged;
                        Sort();
                    }
                }
            }
        }
    }
}
