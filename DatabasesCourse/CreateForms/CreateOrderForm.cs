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

namespace DatabasesCourse.CreateForms
{
    public partial class CreateOrderForm : Form
    {
        private Product _selectedProduct;
        private Order _model = new();

        Dictionary<Product, int> _selectedList = new Dictionary<Product, int>();

        private DatabaseContext Context { get; set; }

        private List<Product> Products { get; set; }
        public CreateOrderForm(DatabaseContext context)
        {
            InitializeComponent();
            Context = context;
            dgvProducts.AutoGenerateColumns = false;
            //dgvSelectedItems.AutoGenerateColumns = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var products = Context.Products.ToList();
            dgvProducts.DataSource = products;

            if (dgvProducts.CurrentRow != null)
            {
                _selectedProduct = dgvProducts.CurrentRow.DataBoundItem as Product;
                if (_selectedProduct != null)
                {
                    labelSelectedInfo.Text = _selectedProduct.Name;
                } 
            }

            var customers = Context.Customers.ToList();
            foreach (var customer in customers)
            {
                comboBoxCustomer.Items.Add(customer);
            }

            //todo load user
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (_selectedList.Count < 1)
            {
                MessageBox.Show(@"Select oner or more products please");
                return;
            }

            foreach (var i in _selectedList)
            {
                _model.TotalCost += i.Key.Price * i.Value;
                _model.OrdersProducts.Add(new OrderProduct { Product = i.Key, Amount = i.Value});
            }

            if (comboBoxCustomer.SelectedItem != null)
            {
                _model.Customer = comboBoxCustomer.SelectedItem as Customer;
            }

            _model.DateTime = DateTime.Now;
            _model.UserId = Global.CurrentUser.Id;

            try
            {
                Context.Orders.Add(_model);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = $"Exception occurred: {ex.Message}.";
                if (ex.InnerException != null)
                {
                    message += $"\nInner exception: {ex.InnerException.Message}";
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
           
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProducts.CurrentRow == null) return;

            _selectedProduct = dgvProducts.CurrentRow.DataBoundItem as Product;

            if (_selectedProduct == null) return;

            labelSelectedInfo.Text = _selectedProduct.Name;

            numericUpDownAmount.Maximum = _selectedProduct.Amount;
            numericUpDownAmount.Value = 1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null) return;

            int amount = (int)numericUpDownAmount.Value;

            if(amount == 0) return;

            
            int id = _selectedProduct.Id;

            if (_selectedList.ContainsKey(_selectedProduct))
            {
                _selectedList[_selectedProduct] += amount;
            }
            else
            {
                _selectedList.Add(_selectedProduct, amount);
            }
            
            _selectedProduct.Amount -= amount;
            DataTable table = new DataTable();
            dgvSelectedItems.DataSource = _selectedList.Keys.ToList();
            //update limit
            numericUpDownAmount.Maximum = _selectedProduct.Amount;
            dgvProducts.Invalidate();
        }
    }
}
