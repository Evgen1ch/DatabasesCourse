using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.DetailsForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.Logging;

namespace DatabasesCourse.Tabs
{
    public partial class OrdersTab : UserControl, IDataGridViewViewer
    {
        private class OrderProjection
        {
            public int Id { get; set; }
            public DateTime DateTime { get; set; }
            public decimal TotalCost { get; set; }
            public string CustomerFirstName { get; set; }
            public string CustomerLastName { get; set; }
            public string CustomerPhone { get; set; }
            public int? UserId { get; set; }
            public OrderProjection(int id, DateTime dt, decimal totalCost, string firstn, string lastn, string phone, int? userId)
            {
                Id = id;
                DateTime = dt;
                TotalCost = totalCost;
                CustomerFirstName = firstn;
                CustomerLastName = lastn;
                CustomerPhone = phone;
                UserId = userId;
            }
        }

        private class ComboboxUserItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        public DatabaseContext Context { get; set; }
        public OrdersTab()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Context = AppGlobals.Context;
            Context.Orders.Load();
            LoadTableData();

            var users = Context.Users.ToList();
            foreach (var user in users)
            {
                comboBox1.Items.Add(new ComboboxUserItem { Text = user.FirstName + user.LastName, Value = user });
            }
            dateTimePicker1.Value = DateTime.Now.AddDays(-30);
            dateTimePicker1.MaxDate = DateTime.Today;
        }

        public void UpdateDataGridView()
        {
            LoadTableData();
        }

        private void LoadTableData()
        {
            dgvTable.DataSource = (from order
                    in Context.Orders
                                   select new OrderProjection(order.Id, order.DateTime, order.TotalCost, order.Customer.FirstName, order.Customer.LastName,
                                                      order.Customer.PhoneNumber, order.UserId)).ToList();
        }

        private void dgvTable_DoubleClick(object sender, EventArgs e)
        {
            int id = -1;
            if (dgvTable.CurrentRow?.Index != -1)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow?.Cells["Id"].Value);
            }

            if (id is -1 or 0) return;

            //todo order details
            DetailsOrderForm detailsOrderForm = new DetailsOrderForm(Context, id);
            var result = detailsOrderForm.ShowDialog();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CreateOrderForm createProductForm = new CreateOrderForm(Context);
            createProductForm.ShowDialog();
            UpdateDataGridView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (dgvTable.CurrentRow != null)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow.Cells["Id"].Value);
            }

            if (id < 1) return;

            var result = MessageBox.Show($@"Are you sure you want ot delete entry with id = {id}");
            if (result == DialogResult.OK)
            {
                var orderToDelete = Context.Orders.FirstOrDefault(c => c.Id == id);
                if (orderToDelete != null)
                {
                    try
                    {
                        Context.Orders.Remove(orderToDelete);
                        Context.SaveChanges();
                        Logger.Log($"Deleted Order with id = {orderToDelete.Id}", LogAction.Remove);
                        UpdateDataGridView();
                    }
                    catch (Exception)
                    {
                        //ignore
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
                    break;
                case Role.Manager:
                    buttonAdd.Visible = true;
                    buttonDelete.Visible = false;
                    break;
                case Role.Employee:
                    buttonAdd.Visible = true;
                    buttonDelete.Visible = false;
                    break;
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            var phone = textBox1.Text.Trim();
            var lastname = textBoxCustomerLastname.Text.Trim();
            var user = (comboBox1.SelectedItem as ComboboxUserItem)?.Value as User;

            var data = Context.Orders
                .Include(o => o.User)
                .Include(o => o.Customer)
                .AsQueryable();
            bool filtered = false;
            if (!string.IsNullOrEmpty(phone))
            {
                data = data.Where(o => o.Customer.PhoneNumber.Contains(phone));
                filtered = true;
            }

            if (!string.IsNullOrEmpty(lastname))
            {
                data = data.Where(o => o.Customer.LastName.Contains(lastname));
                filtered = true;
            }

            if (user != null)
            {
                data = data.Where(o => o.UserId == user.Id);
                filtered = true;
            }

            var date1 = dateTimePicker1.Value;
            var date2 = dateTimePicker2.Value;

            if (date1 < date2 && checkBoxUseDate.Checked)
            {
                data = data.Where(o => o.DateTime >= date1 && o.DateTime <= date2);
                filtered = true;
            }

            if (filtered)
            {
                dgvTable.DataSource = (from x in data
                                       select new OrderProjection(x.Id, x.DateTime, x.TotalCost, x.Customer.FirstName, x.Customer.LastName,
                                           x.Customer.PhoneNumber, x.UserId)).ToList();
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            LoadTableData();
        }


    }
}
