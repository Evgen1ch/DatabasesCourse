using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DetailsForms;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.Tabs
{
    public partial class OrdersTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public OrdersTab()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Context = new DatabaseContext();
            Context.Orders.Load();
            var orders = from order 
                in Context.Orders 
                select new { order.Id,
                    order.DateTime,
                    order.TotalCost,
                    order.Customer.FirstName,
                    order.Customer.LastName,
                    order.Customer.PhoneNumber,
                    order.UserId };

            dgvTable.DataSource = orders.ToList();

        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
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
    }
}
