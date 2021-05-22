using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;

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
            _model = Context.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == id);
            dgvProducts.AutoGenerateColumns = false;

        }

        private void DetailsOrderForm_Load(object sender, System.EventArgs e)
        {
            var products = _model.Products;
            var op = from orderProduct in _model.OrdersProducts
                join p in products on orderProduct.ProductId equals p.Id
                select new{p.Id, p.Name, p.Price, orderProduct.Amount };

            dgvProducts.DataSource = op.ToList();
        }
    }
}
