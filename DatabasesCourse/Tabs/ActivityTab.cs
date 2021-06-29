using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.Tabs
{
    public partial class ActivityTab : UserControl, IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }
        public ActivityTab()
        {
            InitializeComponent();
            Context = AppGlobals.Context;
            dgvTable.AutoGenerateColumns = false;
            comboBoxAction.Items.Add(LogAction.Insert.ToString());
            comboBoxAction.Items.Add(LogAction.Update.ToString());
            comboBoxAction.Items.Add(LogAction.Remove.ToString());
            comboBoxAction.Items.Add(LogAction.LogIn.ToString());

            comboBoxUser.DisplayMember = "Id";
        }

        private void ActivityTab_Load(object sender, EventArgs e)
        {
            Context.Log.Load();
            dgvTable.DataSource = Context.Log.Local.ToBindingList();

            var idColumn = dgvTable.Columns["Id"];
            if (idColumn != null)
                dgvTable.Sort(idColumn, ListSortDirection.Ascending);
        }

        private void ActivityTab_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateDataGridView();
                UpdateFilters();
            }
        }

        public void UpdateDataGridView()
        {
            dgvTable.Invalidate();
        }

        public void UpdateFilters()
        {
            var users = Context.Users.ToList();
            foreach (var user in users)
            {
                comboBoxUser.Items.Add(user);
            }
        }
        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            var user = comboBoxUser.SelectedItem as User;
            string action = comboBoxAction.SelectedItem.ToString();
            var date1 = dateTimePicker1.Value;
            var date2 = dateTimePicker2.Value;

            bool filtered = false;
            var resultQuery = Context.Log.AsQueryable();

            if (user != null)
            {
                resultQuery = resultQuery.Where(a => a.UserId == user.Id);
                filtered = true;
            }

            if (!string.IsNullOrEmpty(action))
            {
                resultQuery = resultQuery.Where(a => EF.Functions.Like(a.Action, $"%{action}%"));
                filtered = true;
            }

            if (checkBoxUseDate.Checked)
            {
                resultQuery = resultQuery.Where(a => a.DateTime >= date1 && a.DateTime <= date2);
                filtered = true;
            }

            if (filtered)
                dgvTable.DataSource = resultQuery.ToList();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dgvTable.DataSource = Context.Log.Local.ToBindingList();
        }


    }
}
