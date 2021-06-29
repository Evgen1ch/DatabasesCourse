using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Logging;
using DatabasesCourse.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.UniversalForms
{
    public partial class ProductForm : Form
    {
        private DatabaseContext Context { get; set; }
        private readonly Product _model;
        private FormAction Action { get; set; }

        private readonly ProductValidator _validator = new();
        public ProductForm(DatabaseContext context, FormAction action, int id)
        {
            InitializeComponent();
            Context = context;
            Action = action;

            var categories = Context.Categories.ToList();
            foreach (var category in categories)
                comboBoxCategory.Items.Add(category);
            var manufacturers = Context.Manufacturers.ToList();
            foreach (var manufacturer in manufacturers)
                comboBoxManufacturer.Items.Add(manufacturer);

            comboBoxManufacturer.DisplayMember = "Name";

            switch (action)
            {
                case FormAction.Create:
                    _model = new();
                    break;
                case FormAction.Update:
                    _model = Context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Manufacturer)
                        .FirstOrDefault(p => p.Id == id);
                    if (_model != null)
                    {
                        textBoxBarcode.Text = _model.BarCode;
                        textBoxName.Text = _model.Name;
                        comboBoxCategory.SelectedItem = _model.Category;
                        comboBoxManufacturer.SelectedItem = _model.Manufacturer;
                        numericUpDownPrice.Value = _model.Price;
                    }
                    break;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string barcode = textBoxBarcode.Text.Trim();
            var manufacturer = comboBoxManufacturer.SelectedItem as Manufacturer;
            var name = textBoxName.Text.Trim();
            var category = comboBoxCategory.SelectedItem as Category;
            var price = numericUpDownPrice.Value;

            if (Action == FormAction.Create || _model.BarCode != barcode)
            {
                var codes = (from product in Context.Products where product.BarCode == barcode select product.BarCode).Count();
                if (codes > 0)
                {
                    MessageBox.Show(@"Product with same barcode is existing. Please check your input.", "DB Operation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _model.BarCode = barcode;
            _model.Manufacturer = manufacturer;
            _model.Name = name;
            _model.Category = category;
            _model.Price = price;

            var message = _validator.ValidateWithString(_model);
            if (message.Length > 0)
            {
                MessageBox.Show(message, @"Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Action == FormAction.Create)
                    Context.Products.Add(_model);
                Context.SaveChanges();

                switch (Action)
                {
                    case FormAction.Create:
                        Logger.Log($"Product inserted with Id = {_model.Id}", LogAction.Insert);
                        break;
                    case FormAction.Update:
                        Logger.Log($"Product updated with Id = {_model.Id}", LogAction.Update);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Somethind went wrong...\nError is: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            switch (Action)
            {
                case FormAction.Create:
                    if (!string.IsNullOrEmpty(textBoxBarcode.Text) ||
                        !string.IsNullOrEmpty(textBoxName.Text) ||
                        comboBoxCategory.SelectedItem != null ||
                        comboBoxManufacturer.SelectedItem != null ||
                        numericUpDownPrice.Value != 0)
                    {
                        var res = MessageBox.Show(@"Are you sure you want to exit without creating new entry?",
                            @"Question",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                            Close();
                    }
                    break;
                case FormAction.Update:
                    Close();
                    break;
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
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
