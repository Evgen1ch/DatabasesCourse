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
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            using (DatabaseContext db = new DatabaseContext())
            {
                var res = db.Users
                    .Include(u => u.Credentials).FirstOrDefault(u =>
                        u.Credentials.Email == email && u.Credentials.Password == password);
                if (res != null)
                {
                    Global.CurrentUser = res;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"Invalid username or password");
                }
            }
        }
    }
}
