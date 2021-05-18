using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
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

            if (id != -1)
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

            if (id == -1) return;

            var result = MessageBox.Show($@"Are you sure you want ot delete entry with id = {id}");
            if (result == DialogResult.OK)
            {
                Context.Products.Remove(Context.Products.FirstOrDefault(p => p.Id == id));
                Context.SaveChanges();
                UpdateDataGridView();
            }
        }

        
    }
}
