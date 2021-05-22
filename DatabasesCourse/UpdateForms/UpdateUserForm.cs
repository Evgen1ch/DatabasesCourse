using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Validators;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.UpdateForms
{
    public partial class UpdateUserForm : Form
    {
        private User _userModel;
        private CredentialsValidator _credentialsValidator = new();
        private DatabaseContext Context { get; set; }
        public UpdateUserForm(DatabaseContext context, int id)
        {
            InitializeComponent();
            Context = context;
            comboBoxRole.Items.Add(Role.Employee);
            comboBoxRole.Items.Add(Role.Manager);
            comboBoxRole.Items.Add(Role.Admin);

            _userModel = Context.Users.Include(u => u.Credentials).FirstOrDefault(u => u.Id == id);

            if (_userModel != null)
            {
                textBoxFirstName.Text = _userModel.FirstName;
                textBoxLastName.Text = _userModel.LastName;
                textBoxEmail.Text = _userModel.Credentials.Email;
                textBoxPassword.Text = _userModel.Credentials.Password;
                comboBoxRole.SelectedItem = _userModel.Credentials.Role;
            }
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _userModel.FirstName = textBoxFirstName.Text.Trim();
            _userModel.LastName = textBoxLastName.Text.Trim();
            _userModel.Credentials.Email = textBoxEmail.Text.Trim();
            _userModel.Credentials.Password = textBoxPassword.Text.Trim();
            _userModel.Credentials.Role = (Role)comboBoxRole.SelectedItem;

            string message = _credentialsValidator.ValidateWithString(_userModel.Credentials);
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
                MessageBox.Show($@"Somethind went wrong...\nError is: {ex.Message}", @"Error", MessageBoxButtons.OK,
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
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void UpdateUserForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
