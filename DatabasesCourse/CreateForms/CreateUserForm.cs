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
    public partial class CreateUserForm : Form
    {
        private User _userModel = new();
        private Credentials _credentialsModel = new();
        private CredentialsValidator _credentialsValidator = new();
        private DatabaseContext Context { get; set; }
        public CreateUserForm(DatabaseContext context)
        {
            InitializeComponent();
            Context = context;
            comboBoxRole.Items.Add(Role.Employee);
            comboBoxRole.Items.Add(Role.Manager);
            comboBoxRole.Items.Add(Role.Admin);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _userModel.FirstName = textBoxFirstName.Text.Trim();
            _userModel.LastName = textBoxLastName.Text.Trim();

            _credentialsModel.Email = textBoxEmail.Text.Trim();
            _credentialsModel.Password = textBoxPassword.Text.Trim();
            _credentialsModel.Role = (Role)comboBoxRole.SelectedItem;

            string message = _credentialsValidator.ValidateWithString(_credentialsModel);
            if (message.Length > 0)
            {
                MessageBox.Show(message, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _userModel.Credentials = _credentialsModel;
                _credentialsModel.User = _userModel;
                Context.Credentials.Add(_credentialsModel);
                Context.Users.Add(_userModel);
                Context.SaveChanges();
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
            if (!string.IsNullOrEmpty(textBoxFirstName.Text) ||
                !string.IsNullOrEmpty(textBoxLastName.Text) ||
                !string.IsNullOrEmpty(textBoxEmail.Text) ||
                !string.IsNullOrEmpty(textBoxPassword.Text))
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

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
