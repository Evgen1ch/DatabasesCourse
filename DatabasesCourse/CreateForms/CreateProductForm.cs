using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Validators;

namespace DatabasesCourse.CreateForms
{
    public partial class CreateProductForm : Form
    {
        private Product _model = new Product();
        private DatabaseContext _context;
        private ProductValidator _validator = new ProductValidator();
        public CreateProductForm(DatabaseContext context)
        {
            InitializeComponent();
            _context = context;
            var categories = _context.Categories.ToList();
            foreach (var category in categories)
            {
                this.comboBoxCategory.Items.Add(category);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string barCode = textBoxBarcode.Text.Trim();
            var codes = (from product 
                in _context.Products 
                where product.BarCode == barCode 
                select product.BarCode)
                .Count();

            if (codes > 0)
            {
                MessageBox.Show("Product with same barcode is existing. Please check your input.", "DB Operation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _model.BarCode = barCode;
            _model.Manufacturer = textBoxMAnufacturer.Text.Trim();
            _model.Name = textBoxName.Text.Trim();
            _model.Category = comboBoxCategory.SelectedItem as Category;
            _model.Price = numericUpDownPrice.Value;
            _model.Amount = (int)numericUpDownAmount.Value;

            var message = _validator.ValidateWithString(_model);

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context.Products.Add(_model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Somethind went wrong...\nError is: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxBarcode.Text) ||
                !string.IsNullOrEmpty(textBoxMAnufacturer.Text) ||
                !string.IsNullOrEmpty(textBoxName.Text) ||
                comboBoxCategory.SelectedItem != null ||
                numericUpDownPrice.Value != 0 ||
                numericUpDownAmount.Value != 0)
            {
                var res = MessageBox.Show("Are you sure you want to exit without creating new entry?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
        

        private void textBoxBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
