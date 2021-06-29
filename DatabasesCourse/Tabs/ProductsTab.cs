using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Logging;
using DatabasesCourse.UniversalForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.Tabs
{
    public partial class ProductsTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public ProductsTab()
        {
            InitializeComponent();
            dgvTable.AutoGenerateColumns = false;
        }

        private void ProductsTab_Load(object sender, EventArgs e)
        {
            Context = AppGlobals.Context;
            Context.Products.Include(p => p.Category).Load();

            dgvTable.DataSource = Context.Products.Local.ToBindingList();

            UpdateFilters();
        }

        private void ProductsTab_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                UpdateFilters();
        }

        public void UpdateFilters()
        {
            if (Context == null) return;
            comboBoxCategory.Items.Clear();
            comboBoxManufacturer.Items.Clear();
            var categories = Context.Categories.ToList();
            foreach (var category in categories)
            {
                comboBoxCategory.Items.Add(category);
            }
            var manufacturers = Context.Manufacturers.ToList();
            foreach (var manufacturer in manufacturers)
            {
                comboBoxManufacturer.Items.Add(manufacturer);
                comboBoxManufacturer.DisplayMember = "Name";
            }
        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm(Context, FormAction.Create, 0);
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

            if (id > 0)
            {
                ProductForm form = new ProductForm(Context, FormAction.Update, id);
                form.ShowDialog();
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show(@"Something went wrong");
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
                var toDelete = Context.Products.FirstOrDefault(p => p.Id == id);
                if (toDelete != null)
                {
                    try
                    {
                        Context.Products.Remove(toDelete);
                        Context.SaveChanges();
                        Logger.Log($"Deleted Product with id = {toDelete.Id}", LogAction.Remove);
                        UpdateDataGridView();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"You can not delete product beacuse you have orders with this products.",
                            @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        var entry = Context.ChangeTracker.Entries<Product>().FirstOrDefault(c => c.Entity.Id == toDelete.Id && c.State == EntityState.Deleted);
                        entry.State = EntityState.Unchanged;
                    }
                }
            }
        }

        public void SetUserView()
        {
            Role role = AppGlobals.CurrentUser.Credentials.Role;
            switch (role)
            {
                case Role.Admin:
                    buttonAdd.Visible = true;
                    buttonDelete.Visible = true;
                    buttonUpdate.Visible = true;
                    break;
                case Role.Manager:
                    buttonAdd.Visible = true;
                    buttonDelete.Visible = false;
                    buttonUpdate.Visible = true;
                    break;
                case Role.Employee:
                    buttonAdd.Visible = false;
                    buttonDelete.Visible = false;
                    buttonUpdate.Visible = false;
                    break;
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            var man = comboBoxManufacturer.SelectedItem as Manufacturer;
            var cat = comboBoxCategory.SelectedItem as Category;

            bool filtered = false;
            var data = Context.Products.Include(p => p.Category).AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(c => EF.Functions.Like(c.Name, $"%{name}%"));
                filtered = true;
                textBox1.Text = string.Empty;
            }
            if (cat != null)
            {
                data = data.Where(c => c.CategoryId == cat.Id);
                filtered = true;
                comboBoxCategory.SelectedItem = null;
            }
            if (man != null)
            {
                data = data.Where(c => c.Manufacturer.Id == man.Id);
                filtered = true;
                comboBoxManufacturer.SelectedItem = null;
            }

            if (filtered)
                dgvTable.DataSource = data.ToList();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dgvTable.DataSource = Context.Products.Local.ToBindingList();
            comboBoxCategory.SelectedItem = null;
        }

    }
}
