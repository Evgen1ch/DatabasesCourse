using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.UpdateForms;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.Tabs
{
    public partial class ProductsTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public ProductsTab()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Context = new DatabaseContext();
            Context.Products.Include(p => p.Category).Load();

            dgvTable.DataSource = Context.Products.Local.ToBindingList();
            var categories = Context.Categories.ToList();
            foreach (var category in categories)
            {
                comboBox1.Items.Add(category);
            }
        }



        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CreateProductForm createProductForm = new CreateProductForm(Context);
            var res = createProductForm.ShowDialog();
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
                UpdateProductForm updateProductForm = new UpdateProductForm(Context, id);
                var res = updateProductForm.ShowDialog();
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
            if(dgvTable.CurrentRow?.Index != -1)
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
                    Context.Products.Remove(toDelete);
                    Context.SaveChanges();
                    UpdateDataGridView();
                }
            }
        }

        public void SetUserView()
        {
            Role role = Global.CurrentUser.Credentials.Role;
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
                    buttonAdd.Visible = true;
                    buttonDelete.Visible = false;
                    buttonUpdate.Visible = false;
                    break;
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string man = textBoxManufacturer.Text.Trim();

            bool filtered = false;
            var data = Context.Products.Include(p=>p.Category).AsEnumerable();
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(c => c.Name.Contains(name));
                filtered = true;
                textBox1.Text = string.Empty;
            }

            if (comboBox1.SelectedItem != null)
            {
                data = data.Where(c => c.CategoryId == (comboBox1.SelectedItem as Category).Id);
                filtered = true;
                //comboBox1.SelectedItem = null;
            }

            if (!string.IsNullOrEmpty(man))
            {
                data = data.Where(c => c.Manufacturer.Contains(man));
                filtered = true;
                textBoxManufacturer.Text = string.Empty;
            }


            if (filtered)
                dgvTable.DataSource = data.ToList();

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dgvTable.DataSource = Context.Products.Local.ToBindingList();
            comboBox1.SelectedItem = null;
        }
    }
}
