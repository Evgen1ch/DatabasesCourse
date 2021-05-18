using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.Tabs;

namespace DatabasesCourse
{
    public partial class MainForm : Form
    {
        private List<Control> _tabs;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            

            _tabs = new List<Control>
            {
                productsTab,
                categoriesTab,
                ordersTab,
                customersTab,
                usersTab,
            };

            //_db = new DatabaseContext();
            //_db.Products.Load();
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

        }

        private void buttonStat2_Click(object sender, EventArgs e)
        {

        }
    }
}
