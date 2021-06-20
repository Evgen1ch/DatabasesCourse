using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.Logging;
using DatabasesCourse.UniversalForms;

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
            Context = AppGlobals.Context;
            Context.Customers.Load();
            dgvTable.AutoGenerateColumns = false;
            dgvTable.DataSource = Context.Customers.Local.ToBindingList();
        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CustomerForm createCustomerForm = new CustomerForm(Context, FormAction.Create, 0);
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
                CustomerForm updateCustomerForm = new CustomerForm(Context, FormAction.Update, id);
                updateCustomerForm.ShowDialog();
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
                var toDelete = Context.Customers.FirstOrDefault(c => c.Id == id);
                if (toDelete != null)
                {
                    try
                    {
                        Context.Customers.Remove(toDelete);
                        Context.SaveChanges();
                        Logger.Log($"Deleted Customer with id = {toDelete.Id}", LogAction.Remove);
                        UpdateDataGridView();
                    }
                    catch (Exception)
                    {
                        //ignore
                    }
                }
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            string phone = textBox1.Text.Trim();
            string last = textBox2.Text.Trim();
            string first = textBox3.Text.Trim();

            var data = Context.Customers.AsEnumerable();

            if (!string.IsNullOrEmpty(phone))
            {
                data = data.Where(c => c.PhoneNumber.Contains(phone));
            }
            if (!string.IsNullOrEmpty(last))
            {
                data = data.Where(c => c.LastName.Contains(last));
            }
            if (!string.IsNullOrEmpty(first))
            {
                data = data.Where(c => c.FirstName.Contains(first));
            }

            dgvTable.DataSource = data.ToList();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dgvTable.DataSource = Context.Customers.Local.ToBindingList();
        }
    }
}
