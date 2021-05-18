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
using DatabasesCourse.Validators;

namespace DatabasesCourse.CreateForms
{
    public partial class CreateCustomerForm : Form
    {
        private DatabaseContext Context { get; set; }
        private Customer _model = new();
        private CustomerValidator _validator = new();
        public CreateCustomerForm(DatabaseContext context)
        {
            InitializeComponent();
            Context = context;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '+') && (((sender as TextBox).Text.IndexOf('+') > -1) || (sender as TextBox).Text.Length > 0))
            {
                e.Handled = true;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _model.FirstName = textBoxFirstName.Text.Trim();
            _model.LastName = textBoxLastName.Text.Trim();
            _model.PhoneNumber = textBoxPhone.Text.Trim();
            _model.DateTimeRegistered = DateTime.Now;

            var message = _validator.ValidateWithString(_model);
            if (message.Length > 0)
            {
                MessageBox.Show(message, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Context.Customers.Add(_model);
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
            if (!string.IsNullOrEmpty(textBoxFirstName.Text) ||
                !string.IsNullOrEmpty(textBoxLastName.Text) ||
                !string.IsNullOrEmpty(textBoxPhone.Text) )
            {
                var res = MessageBox.Show(@"Are you sure you want to exit without creating new entry?", 
                    @"Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
    }
}
