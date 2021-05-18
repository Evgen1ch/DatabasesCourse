using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Validators;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.UpdateForms
{
    public partial class UpdateProductForm : Form
    {
        private Product _model = new();
        private DatabaseContext _context;
        private ProductValidator _validator = new();
        public UpdateProductForm(DatabaseContext context, int id)
        {
            InitializeComponent();
            _context = context;
            var categories = _context.Categories.ToList();
            _model = _context.Products.Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
            textBoxBarcode.Text = _model.BarCode;
            textBoxMAnufacturer.Text = _model.Manufacturer;
            textBoxName.Text = _model.Name;
            foreach (var category in categories)
                comboBoxCategory.Items.Add(category);
            comboBoxCategory.SelectedItem = _model.Category;
            numericUpDownPrice.Value = _model.Price;
            numericUpDownAmount.Value = _model.Amount;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            
            string barCode = textBoxBarcode.Text.Trim();
            if (_model.BarCode != barCode)
            {
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Somethind went wrong...\nError is: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
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
