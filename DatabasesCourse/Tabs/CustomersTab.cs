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
    public partial class CustomersTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public CustomersTab()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Context = new DatabaseContext();
            Context.Customers.Load();
            //var customers = from customer 
            //    in Context.Customers 
            //    select new { customer.Id,
            //        customer.FirstName,
            //        customer.LastName,
            //        customer.PhoneNumber,
            //        customer.DateTimeRegistered };

            //dgvTable.DataSource = customers.ToList();
            dgvTable.AutoGenerateColumns = false;
            dgvTable.DataSource = Context.Customers.Local.ToBindingList();
        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CreateCustomerForm createCustomerForm = new CreateCustomerForm(Context);
            var res = createCustomerForm.ShowDialog();
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
                UpdateCustomerForm updateProductForm = new UpdateCustomerForm(Context, id);
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

            if (id == -1) return;

            var result = MessageBox.Show($@"Are you sure you want ot delete entry with id = {id}");
            if (result == DialogResult.OK)
            {
                Context.Customers.Remove(Context.Customers.FirstOrDefault(c => c.Id == id));
                Context.SaveChanges();
                UpdateDataGridView();
            }
        }
    }
}
