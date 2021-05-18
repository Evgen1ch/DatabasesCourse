using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.UpdateForms;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.Tabs
{
    public partial class UsersTab : UserControl, IDataGridViewViewer
    {
        private class UserDatabaseProjection
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }
        public DatabaseContext Context { get; set; }
        public UsersTab()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Context = new DatabaseContext();
            Context.Users.Load();
            var users = from user
                in Context.Users 
                select new { user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Credentials.Email,
                    user.Credentials.Password,
                    user.Credentials.Role
                };
            
            dgvTable.DataSource = users.ToList();

        }

        public void UpdateDataGridView()
        {
            var users = from user
                    in Context.Users
                select new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Credentials.Email,
                    user.Credentials.Password,
                    user.Credentials.Role
                };
            dgvTable.DataSource = users.ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CreateUserForm createProductForm = new CreateUserForm(Context);
            var res = createProductForm.ShowDialog();
            UpdateDataGridView();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (dgvTable.CurrentRow?.Index != -1)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow?.Cells["Id"].Value);
            }

            if (id != -1)
            {
                UpdateUserForm updateProductForm = new UpdateUserForm(Context, id);
                var res = updateProductForm.ShowDialog();
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (dgvTable.CurrentRow?.Index != -1)
            {
                id = Convert.ToInt32(dgvTable.CurrentRow?.Cells["Id"].Value);
            }

            if (id == -1) return;

            var result = MessageBox.Show($@"Are you sure you want ot delete entry with id = {id}");
            if (result == DialogResult.OK)
            {
                Context.Users.Remove(Context.Users.FirstOrDefault(u => u.Id == id));
                Context.SaveChanges();
                UpdateDataGridView();
            }
        }
    }
}
