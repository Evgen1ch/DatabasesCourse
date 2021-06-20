using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.CreateForms
{
    public partial class CreateOrderForm : Form
    {
        private Product _selectedProduct;
        private Product _selectedItemsProduct;

        private readonly Order _model = new();

        readonly Dictionary<Product, int> _selectedList = new();

        private DatabaseContext Context { get; set; }

        public CreateOrderForm(DatabaseContext context)
        {
            InitializeComponent();
            Context = context;
            dgvProducts.AutoGenerateColumns = false;
            dgvSelectedItems.AutoGenerateColumns = false;
        }

        public void UpdateDataGridView()
        {
            dgvProducts.DataSource = Context.Products.ToList();
            dgvSelectedItems.DataSource = _selectedList.Keys.ToList();
            foreach (DataGridViewRow row in dgvSelectedItems.Rows)
            {
                row.Cells["Count"].Value = _selectedList[row.DataBoundItem as Product];
            }
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
                _model.OrdersProducts.Add(new OrderProduct { Product = i.Key, Amount = i.Value , Price = i.Key.Price});
                i.Key.Amount -= i.Value;
            }

            if (comboBoxCustomer.SelectedItem != null)
            {
                _model.Customer = comboBoxCustomer.SelectedItem as Customer;
            }

            _model.DateTime = DateTime.Now;
            _model.UserId = AppGlobals.CurrentUser.Id;

            try
            {
                Context.Orders.Add(_model);
                Context.SaveChanges();
                Logger.Log($"Order added with Id = {_model.Id}", LogAction.Insert);
            }
            catch (Exception ex)
            {
                string message = $"Exception occurred: {ex.Message}.";
                if (ex.InnerException != null)
                {
                    message += $"\nInner exception: {ex.InnerException.Message}";
                }

                MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvProducts.CurrentRow == null) return;

            _selectedProduct = dgvProducts.CurrentRow.DataBoundItem as Product;

            if (_selectedProduct == null) return;

            labelSelectedInfo.Text = _selectedProduct.Name;

            numericUpDownAmount.Maximum = _selectedProduct.Amount;
            numericUpDownAmount.Value = Convert.ToInt32(numericUpDownAmount.Maximum > 0);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null) return;

            int amount = (int)numericUpDownAmount.Value;

            if (amount == 0) return;

            if (_selectedList.ContainsKey(_selectedProduct))
            {
                _selectedList[_selectedProduct] += amount;
            }
            else
            {
                _selectedList.Add(_selectedProduct, amount);
            }

            dgvSelectedItems.DataSource = _selectedList.Keys.ToList();
            foreach (DataGridViewRow row in dgvSelectedItems.Rows)
            {
                row.Cells["Count"].Value = _selectedList[row.DataBoundItem as Product];
            }
            //update limit
            numericUpDownAmount.Maximum = _selectedProduct.Amount - _selectedList[_selectedProduct];
            dgvProducts.Invalidate();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (_selectedItemsProduct == null) return;
            _selectedList.Remove(_selectedItemsProduct);
            _selectedItemsProduct = null;
            UpdateDataGridView();
        }

        private void buttonRemoveOne_Click(object sender, EventArgs e)
        {
            if (_selectedItemsProduct == null) return;

            if (_selectedList[_selectedItemsProduct] == 1)
            {
                _selectedList.Remove(_selectedItemsProduct);
                _selectedItemsProduct = null;
            }

            else
                _selectedList[_selectedItemsProduct]--;
            UpdateDataGridView();
        }

        private void dgvSelectedItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSelectedItems.CurrentRow == null) return;

            _selectedItemsProduct = dgvSelectedItems.CurrentRow.DataBoundItem as Product;
        }
    }
}
