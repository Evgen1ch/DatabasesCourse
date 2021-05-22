using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.UpdateForms;
using Microsoft.EntityFrameworkCore;

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
            Context = new DatabaseContext();
            Context.Categories.Load();

            dgvTable.AutoGenerateColumns = false;
            dgvTable.DataSource = Context.Categories.Local.ToBindingList();
        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CreateCategoryForm createProductForm = new CreateCategoryForm(Context);
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

            if (id != -1)
            {
                UpdateCategoryForm updateProductForm = new UpdateCategoryForm(Context, id);
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
            if (dgvTable.CurrentRow?.Index != -1)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow?.Cells["Id"].Value);
            }

            if (id < 1) return;

            var result = MessageBox.Show($@"Are you sure you want ot delete entry with id = {id}");
            if (result == DialogResult.OK)
            {
                Context.Categories.Remove(Context.Categories.FirstOrDefault(c => c.Id == id));
                Context.SaveChanges();
                UpdateDataGridView();
            }
        }
    }
}
