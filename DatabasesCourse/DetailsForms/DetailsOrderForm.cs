using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.DetailsForms
{
    public partial class DetailsOrderForm : Form
    {
        private Order _model;
        private DatabaseContext Context { get; set; }
        public DetailsOrderForm(DatabaseContext context, int id)
        {
            InitializeComponent();
            CenterToParent();
            Context = context;
            _model = Context.Orders
                .Include(o => o.Products)
                .Include(o => o.Customer)
                .Include(o => o.User)
                .FirstOrDefault(o => o.Id == id);
            dgvProducts.AutoGenerateColumns = false;

        }

        private void DetailsOrderForm_Load(object sender, System.EventArgs e)
        {
            var products = _model.Products;
            var op = from orderProduct in _model.OrdersProducts
                     join p in products on orderProduct.ProductId equals p.Id
                     select new { p.Id, p.Name, orderProduct.Price, orderProduct.Amount };

            dgvProducts.DataSource = op.ToList();

            if (_model.Customer != null)
                labelCustomerValue.Text =
                    _model.Customer.FirstName + @" " + _model.Customer.LastName + @" " + _model.Customer.PhoneNumber;
            if (_model.User != null)
                labelUserValue.Text = _model.User.FirstName + @" " + _model.User.LastName + @". Id = " + _model.UserId;
            labelTotalCostValue.Text = Convert.ToSingle(_model.TotalCost).ToString(CultureInfo.InvariantCulture);
        }
    }
}
