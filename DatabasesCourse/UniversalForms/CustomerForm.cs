using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Logging;
using DatabasesCourse.Validators;

namespace DatabasesCourse.UniversalForms
{
    public partial class CustomerForm : Form
    {
        private DatabaseContext Context { get; set; }
        private Customer _model = new();
        private CustomerValidator _validator = new();
        private FormAction Action { get; set; }
        public CustomerForm(DatabaseContext context, FormAction action, int id)
        {
            InitializeComponent();
            Context = context;
            Action = action;

            switch (action)
            {
                case FormAction.Create:
                    _model = new();
                    break;
                case FormAction.Update:
                    _model = Context.Customers.FirstOrDefault(c => c.Id == id);
                    if (_model != null)
                    {
                        textBoxFirstName.Text = _model.FirstName;
                        textBoxLastName.Text = _model.LastName;
                        textBoxPhone.Text = _model.PhoneNumber;
                    }
                    break;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _model.FirstName = textBoxFirstName.Text.Trim();
            _model.LastName = textBoxLastName.Text.Trim();
            _model.PhoneNumber = textBoxPhone.Text.Trim();
            if(Action == FormAction.Create)
                _model.DateTimeRegistered = DateTime.Now;

            var message = _validator.ValidateWithString(_model);
            if (message.Length > 0)
            {
                MessageBox.Show(message, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if(Action == FormAction.Create)
                    Context.Customers.Add(_model);
                Context.SaveChanges();
                switch (Action)
                {
                    case FormAction.Create:
                        Logger.Log($"Customer added with Id = {_model.Id}", LogAction.Insert);
                        break;
                    case FormAction.Update:
                        Logger.Log($"Customer updated with Id = {_model.Id}", LogAction.Insert);
                        break;
                }
                
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
            switch (Action)
            {
                case FormAction.Create:
                    if (!string.IsNullOrEmpty(textBoxFirstName.Text) ||
                        !string.IsNullOrEmpty(textBoxLastName.Text) ||
                        !string.IsNullOrEmpty(textBoxPhone.Text))
                    {
                        var res = MessageBox.Show(@"Are you sure you want to exit without creating new entry?",
                            @"Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                            this.Close();
                    }
                    else
                        this.Close();
                    break;
                case FormAction.Update:
                    Close();
                    break;
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one + at the start
            if ((e.KeyChar == '+') && (((sender as TextBox).Text.IndexOf('+') > -1) || (sender as TextBox).Text.Length > 0))
            {
                e.Handled = true;
            }
        }
    }
}
