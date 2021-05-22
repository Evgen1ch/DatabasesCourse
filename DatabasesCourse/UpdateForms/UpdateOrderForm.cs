using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.UpdateForms
{
    public partial class UpdateOrderForm : Form
    {
        private Order _model = new();
        private DatabaseContext Context { get; set; }
        public UpdateOrderForm(DatabaseContext context, int id)
        {
            InitializeComponent();
            Context = context;
            _model = Context.Orders
                .Include(o => o.OrdersProducts)
                    .ThenInclude(op=>op.Product)
                .FirstOrDefault(o => o.Id == id);

        }

        private void UpdateOrderForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
