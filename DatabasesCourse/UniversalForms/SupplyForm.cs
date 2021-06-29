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
    public partial class SupplyForm : Form
    {
        private DatabaseContext Context { get; set; }
        private Supply _model;
        private FormAction Action { get; set; }
        private SupplyValidator _validator = new();
        public SupplyForm(DatabaseContext context, FormAction action, int id)
        {
            InitializeComponent();
            Context = context;
            Action = action;

            var products = Context.Products.ToList();
            foreach (var product in products)
                comboBoxProduct.Items.Add(product);
            comboBoxProduct.DisplayMember = "Name";

            switch (action)
            {
                case FormAction.Create:
                    _model = new();
                    comboBoxProduct.SelectedItem = null;
                    break;
                case FormAction.Update:
                    _model = Context.Supplies.Include(s => s.Product).FirstOrDefault(s => s.Id == id);
                    if (_model != null)
                    {
                        comboBoxProduct.SelectedItem = _model.Product;
                        numericUpDownAmount.Value = _model.Amount;
                    }
                    break;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var product = comboBoxProduct.SelectedItem as Product;
            var amount = (int)numericUpDownAmount.Value;

            _model.Product = product;
            _model.UserId = AppGlobals.CurrentUser.Id;
            _model.DateTime = DateTime.Now;
            switch (Action)
            {
                case FormAction.Update when amount != _model.Amount:
                    var delta = _model.Amount - amount;
                    if (product.Amount - delta < 0)
                    {
                        MessageBox.Show(@"Illegal operation. Product is already sold.");
                        return;
                    }

                    _model.Amount = amount;
                    _model.Product.Amount -= delta;
                    break;
                case FormAction.Create:
                    _model.Amount = amount;
                    _model.Product.Amount += amount;
                    break;
            }


            var message = _validator.ValidateWithString(_model);
            if (message.Length > 0)
            {
                MessageBox.Show(message, @"Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Action == FormAction.Create)
                    Context.Supplies.Add(_model);
                Context.SaveChanges();

                switch (Action)
                {
                    case FormAction.Create:
                        Logger.Log($"Supply inserted with Id = {_model.Id}", LogAction.Insert);
                        break;
                    case FormAction.Update:
                        Logger.Log($"Supply updated with Id = {_model.Id}", LogAction.Insert);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    @$"Somethind went wrong...\nError is: {ex.Message}.\nInner: {ex.InnerException?.Message}.", @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Context.Remove(_model);
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
                    if (comboBoxProduct.SelectedItem != null || numericUpDownAmount.Value != 0)
                    {
                        var res = MessageBox.Show(@"Are you sure you want to exit without creating new entry?", @"Question",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                            this.Close();
                    }
                    break;
                case FormAction.Update:
                    Close();
                    break;
            }
        }
    }
}
