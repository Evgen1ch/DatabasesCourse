using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.CreateForms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.UpdateForms;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.Tabs
{
    public partial class UsersTab : UserControl, IDataGridViewViewer
    {
        private class UserProjection
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }

            public UserProjection(int id, string first, string last, string email, string password, Role role)
            {
                Id = id;
                FirstName = first;
                LastName = last;
                Email = email;
                Password = password;
                Role = role;
            }
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
            //var users = from user
            //    in Context.Users 
            //    select new { user.Id,
            //        user.FirstName,
            //        user.LastName,
            //        user.Credentials.Email,
            //        user.Credentials.Password,
            //        user.Credentials.Role
            //    };
            
            //dgvTable.DataSource = users.ToList();
            LoadTableData();

            comboBoxRole.Items.Add(Role.Employee);
            comboBoxRole.Items.Add(Role.Manager);
            comboBoxRole.Items.Add(Role.Admin);
        }

        public void UpdateDataGridView()
        {
            //var users = from user
            //        in Context.Users
            //    select new
            //    {
            //        user.Id,
            //        user.FirstName,
            //        user.LastName,
            //        user.Credentials.Email,
            //        user.Credentials.Password,
            //        user.Credentials.Role
            //    };
            //dgvTable.DataSource = users.ToList();
            LoadTableData();
        }

        private void LoadTableData()
        {
            dgvTable.DataSource = (from x in Context.Users
                select new UserProjection(x.Id, x.FirstName, x.LastName, x.Credentials.Email, x.Credentials.Password,
                    x.Credentials.Role)).ToList();
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

            if (id < 1) return;

            var result = MessageBox.Show($@"Are you sure you want ot delete entry with id = {id}");
            if (result == DialogResult.OK)
            {
                Context.Users.Remove(Context.Users.FirstOrDefault(u => u.Id == id));
                Context.SaveChanges();
                UpdateDataGridView();
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text.Trim();
            var email = textBoxEmail.Text.Trim();
            Role? role = (Role?)comboBoxRole.SelectedItem;

            bool filtered = false;
            var data = Context.Users.Include(u=>u.Credentials).AsEnumerable();
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(u => (u.FirstName + " " + u.LastName).ToLower().Contains(name.ToLower()));
                filtered = true;
            }

            if (!string.IsNullOrEmpty(email))
            {
                data = data.Where(u => u.Credentials.Email.Contains(email));
                filtered = true;
            }

            if (role != null)
            {
                data = data.Where(u => u.Credentials.Role == role);
                filtered = true;
            }

            if (filtered)
            {
                dgvTable.DataSource = (from x in data
                    select new UserProjection(x.Id, x.FirstName, x.LastName, x.Credentials.Email,
                        x.Credentials.Password, x.Credentials.Role)).ToList();
                comboBoxRole.SelectedItem = null;
            }
                
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            LoadTableData();
        }
    }
}
