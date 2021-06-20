using DatabasesCourse.DatabaseModel;
using DatabasesCourse.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CenterToParent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CenterToParent();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            DatabaseContext db = AppGlobals.Context;
            var res = db.Users
                .Include(u => u.Credentials)
                .FirstOrDefault(u =>
                    u.Credentials.Email == email && u.Credentials.Password == password);

            if (res != null)
            {
                AppGlobals.CurrentUser = res;
                Logger.Log($"User logged in with Id = {res.Id}", LogAction.LogIn);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.\nCheck your Email and password and try again.");
            }
        }
    }
}
