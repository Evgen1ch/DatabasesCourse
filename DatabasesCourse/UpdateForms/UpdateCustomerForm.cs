using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Validators;

namespace DatabasesCourse.UpdateForms
{
    public partial class UpdateCustomerForm : Form
    {
        private DatabaseContext Context { get; set; }
        private Customer _model = new();
        private int _id;
        private CustomerValidator _validator = new();
        public UpdateCustomerForm(DatabaseContext context, int id)
        {
            InitializeComponent();
            Context = context;
            _id = id;
            _model = Context.Customers.FirstOrDefault(c => c.Id == _id);
            if (_model != null)
            {
                textBoxFirstName.Text = _model.FirstName;
                textBoxLastName.Text = _model.LastName;
                textBoxPhone.Text = _model.PhoneNumber;
            }
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _model.FirstName = textBoxFirstName.Text.Trim();
            _model.LastName = textBoxLastName.Text.Trim();
            _model.PhoneNumber = textBoxPhone.Text.Trim();

            var message = _validator.ValidateWithString(_model);

            if (message.Length > 0)
            {
                MessageBox.Show(message, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Somethind went wrong...\nError is: {ex.Message}.\nInner: {ex.InnerException?.Message}.",
                    @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void UpdateCustomerForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
