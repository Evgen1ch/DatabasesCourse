using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Tabs;

namespace DatabasesCourse
{
    public partial class MainForm : Form
    {
        private List<Control> _tabs;
        
        public MainForm()
        {
            InitializeComponent();
            buttonUsers.Visible = buttonUsers.Enabled = false;
            buttonCategories.Visible = buttonCategories.Enabled = false;
            buttonStat1.Visible = buttonStat1.Enabled = false;
            buttonCustomers.Visible = buttonCustomers.Enabled = false;
            buttonOrders.Visible = buttonOrders.Enabled = false;
            buttonProducts.Visible = buttonProducts.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Login();

            _tabs = new List<Control>
            {
                productsTab,
                categoriesTab,
                ordersTab,
                customersTab,
                usersTab,
                statisticsTab,
            };
        }

        public void HideTabs()
        {
            _tabs.ForEach(ui => ui.Visible = false);
            buttonProducts.BackColor = SystemColors.ButtonShadow;
            buttonCategories.BackColor = SystemColors.ButtonShadow;
            buttonOrders.BackColor = SystemColors.ButtonShadow;
            buttonCustomers.BackColor = SystemColors.ButtonShadow;
            buttonUsers.BackColor = SystemColors.ButtonShadow;
        }

        public void ToggleTab(UserControl tab)
        {
            if (tab.Visible == false)
            {
                HideTabs();
                tab.Visible = true;
                Color pressedButtonColor = Color.FromArgb(100, 100, 100);
                if (productsTab.Visible)
                    buttonProducts.BackColor = pressedButtonColor;
                if (categoriesTab.Visible)
                    buttonCategories.BackColor = pressedButtonColor;
                if (ordersTab.Visible)
                    buttonOrders.BackColor = pressedButtonColor;
                if (customersTab.Visible)
                    buttonCustomers.BackColor = pressedButtonColor;
                if (usersTab.Visible)
                    buttonUsers.BackColor = pressedButtonColor;
            }
            else
            {
                tab.Visible = false;
                buttonProducts.BackColor = SystemColors.ButtonShadow;
                buttonCategories.BackColor = SystemColors.ButtonShadow;
                buttonOrders.BackColor = SystemColors.ButtonShadow;
                buttonCustomers.BackColor = SystemColors.ButtonShadow;
                buttonUsers.BackColor = SystemColors.ButtonShadow;
            }
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            ToggleTab(productsTab);
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            ToggleTab(categoriesTab);
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            ToggleTab(ordersTab);
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            ToggleTab(customersTab);
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            ToggleTab(usersTab);
        }

        private void buttonStat1_Click(object sender, EventArgs e)
        {
            ToggleTab(statisticsTab);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            HideTabs();
            Global.CurrentUser = null;
            Login();
        }

        private void Login()
        {
            HideButtons();
            LoginForm loginForm = new LoginForm();
            var result = loginForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                this.Close();
                return;
            }

            Role role = Global.CurrentUser.Credentials.Role;
            
            switch (role)
            {
                case Role.Employee:
                    buttonUsers.Visible = buttonUsers.Enabled = false;
                    buttonCategories.Visible = buttonCategories.Enabled = false;
                    buttonStat1.Visible = buttonStat1.Enabled = false;

                    buttonCustomers.Visible = buttonCustomers.Enabled = true;
                    buttonOrders.Visible = buttonOrders.Enabled = true;
                    buttonProducts.Visible = buttonProducts.Enabled = true;
                    break;
                case Role.Manager:

                    buttonUsers.Visible = buttonUsers.Enabled = false;
                    buttonStat1.Visible = buttonStat1.Enabled = false;

                    buttonCategories.Visible = buttonCategories.Enabled = true;
                    buttonCustomers.Visible = buttonCustomers.Enabled = true;
                    buttonOrders.Visible = buttonOrders.Enabled = true;
                    buttonProducts.Visible = buttonProducts.Enabled = true;
                    break;
                case Role.Admin:
                    buttonStat1.Visible = buttonStat1.Enabled = true;
                    buttonUsers.Visible = buttonUsers.Enabled = true;

                    buttonCategories.Visible = buttonCategories.Enabled = true;
                    buttonCustomers.Visible = buttonCustomers.Enabled = true;
                    buttonOrders.Visible = buttonOrders.Enabled = true;
                    buttonProducts.Visible = buttonProducts.Enabled = true;
                    break;
            }
            ordersTab.SetUserView();
            productsTab.SetUserView();
            labelCurrentUserInfo.Text = Global.CurrentUser.FirstName + @" " + Global.CurrentUser.LastName + @". Role: " +
                                        Global.CurrentUser.Credentials.Role;
        }

        private void HideButtons()
        {
            buttonStat1.Visible = buttonStat1.Enabled = false;
            buttonUsers.Visible = buttonUsers.Enabled = false;
            buttonCategories.Visible = buttonCategories.Enabled = false;
            buttonCustomers.Visible = buttonCustomers.Enabled = false;
            buttonOrders.Visible = buttonOrders.Enabled = false;
            buttonProducts.Visible = buttonProducts.Enabled = false;
        }
    }
}
