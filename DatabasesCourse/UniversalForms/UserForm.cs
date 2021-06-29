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
    public partial class UserForm : Form
    {
        private readonly User _userModel;
        private readonly Credentials _credentialsModel;
        private readonly CredentialsValidator _credentialsValidator = new();
        private readonly UserValidator _userValidator = new();
        private DatabaseContext Context { get; set; }
        private FormAction Action { get; set; }
        public UserForm(DatabaseContext context, FormAction action, int id)
        {
            InitializeComponent();
            Context = context;
            Action = action;
            comboBoxRole.Items.Add(Role.Employee);
            comboBoxRole.Items.Add(Role.Manager);
            comboBoxRole.Items.Add(Role.Admin);
            switch (action)
            {
                case FormAction.Create:
                    _userModel = new();
                    _credentialsModel = new();
                    break;
                case FormAction.Update:
                    _userModel = Context.Users.Include(u => u.Credentials).FirstOrDefault(u => u.Id == id);
                    if (_userModel != null)
                    {
                        _credentialsModel = _userModel.Credentials;
                        textBoxFirstName.Text = _userModel.FirstName;
                        textBoxLastName.Text = _userModel.LastName;
                        textBoxEmail.Text = _userModel.Credentials.Email;
                        textBoxPassword.Text = _userModel.Credentials.Password;
                        comboBoxRole.SelectedItem = _userModel.Credentials.Role;
                    }
                    break;
            }


        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _userModel.FirstName = textBoxFirstName.Text.Trim();
            _userModel.LastName = textBoxLastName.Text.Trim();
            _credentialsModel.Email = textBoxEmail.Text.Trim();
            _credentialsModel.Password = textBoxPassword.Text.Trim();
            _credentialsModel.Role = (Role)comboBoxRole.SelectedItem;

            string message = _userValidator.ValidateWithString(_userModel) +
                             _credentialsValidator.ValidateWithString(_credentialsModel);

            if (message.Length > 0)
            {
                MessageBox.Show(message, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Action == FormAction.Create)
                {
                    _userModel.Credentials = _credentialsModel;
                    _credentialsModel.User = _userModel;
                    Context.Credentials.Add(_credentialsModel);
                    Context.Users.Add(_userModel);
                }
                Context.SaveChanges();

                switch (Action)
                {
                    case FormAction.Create:
                        Logger.Log($"User added with Id = {_userModel.Id} and CredentialsId = {_credentialsModel.Id}", LogAction.Insert);
                        break;
                    case FormAction.Update:
                        Logger.Log($"User updated with Id = {_userModel.Id} and CredentialsId = {_credentialsModel.Id}", LogAction.Insert);
                        break;
                }

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
            switch (Action)
            {
                case FormAction.Create:
                    if (!string.IsNullOrEmpty(textBoxFirstName.Text) ||
                        !string.IsNullOrEmpty(textBoxLastName.Text) ||
                        !string.IsNullOrEmpty(textBoxEmail.Text) ||
                        !string.IsNullOrEmpty(textBoxPassword.Text))
                    {
                        var res = MessageBox.Show("Are you sure you want to exit without creating new entry?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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

        private void UserForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
