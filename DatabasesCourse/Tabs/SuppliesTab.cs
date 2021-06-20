using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.UniversalForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.Tabs
{
    public partial class SuppliesTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public SuppliesTab()
        {
            InitializeComponent();
            Context = AppGlobals.Context;

            dgvTable.AutoGenerateColumns = false;
            comboBoxUser.DisplayMember = "Id";
            comboBoxProduct.DisplayMember = "Name";
        }
        private void SuppliesTab_Load(object sender, EventArgs e)
        {
            Context.Supplies.Load();
            dgvTable.DataSource = Context.Supplies.Local.ToBindingList();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                UpdateDataGridView();
                UpdateFilters();
            }
        }


        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        public void UpdateFilters()
        {
            comboBoxUser.Items.Clear();
            comboBoxProduct.Items.Clear();
            var users = Context.Users.ToList();
            var products = Context.Products.ToList();
            foreach (var user in users)
            {
                comboBoxUser.Items.Add(user);
            }

            foreach (var product in products)
            {
                comboBoxProduct.Items.Add(product);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SupplyForm form = new SupplyForm(Context, FormAction.Create, 0);
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
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
                SupplyForm form = new SupplyForm(Context, FormAction.Update, id);
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                    UpdateDataGridView();
            }
            else
            {
                MessageBox.Show(@"Something went wrong");
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            var user = comboBoxUser.SelectedItem as User;
            var product = comboBoxProduct.SelectedItem as Product;
            bool useDate = checkBoxDate.Checked;
            var date1 = dateTimePicker1.Value;
            var date2 = dateTimePicker2.Value;

            bool filtered = false;
            var resultQuery = Context.Supplies.AsQueryable();

            if (user != null)
            {
                resultQuery = resultQuery.Where(s => s.UserId == user.Id);
                filtered = true;
            }

            if (product != null)
            {
                resultQuery = resultQuery.Where(s => s.ProductId == product.Id);
                filtered = true;
            }

            if (useDate)
            {
                resultQuery =
                    resultQuery.Where(s => s.DateTime >= date1 && s.DateTime <= date2);
                filtered = true;
            }

            MessageBox.Show($@"Query is: {resultQuery.ToQueryString()}");
            if (filtered)
                dgvTable.DataSource = resultQuery.ToList();

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dgvTable.DataSource = Context.Supplies.Local.ToBindingList();
        }
    }
}
