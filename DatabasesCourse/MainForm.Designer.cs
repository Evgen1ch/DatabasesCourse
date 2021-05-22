
namespace DatabasesCourse
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonStat1 = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonOrders = new System.Windows.Forms.Button();
            this.buttonCategories = new System.Windows.Forms.Button();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelCurrentUserInfo = new System.Windows.Forms.Label();
            this.labelCurrentUser = new System.Windows.Forms.Label();
            this.productsTab = new DatabasesCourse.Tabs.ProductsTab();
            this.categoriesTab = new DatabasesCourse.Tabs.CategoriesTab();
            this.ordersTab = new DatabasesCourse.Tabs.OrdersTab();
            this.customersTab = new DatabasesCourse.Tabs.CustomersTab();
            this.usersTab = new DatabasesCourse.Tabs.UsersTab();
            this.statisticsTab = new DatabasesCourse.Tabs.StatisticsTab();
            this.panelMenu.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Controls.Add(this.buttonStat1);
            this.panelMenu.Controls.Add(this.buttonUsers);
            this.panelMenu.Controls.Add(this.buttonCustomers);
            this.panelMenu.Controls.Add(this.buttonOrders);
            this.panelMenu.Controls.Add(this.buttonCategories);
            this.panelMenu.Controls.Add(this.buttonProducts);
            this.panelMenu.Location = new System.Drawing.Point(0, 40);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.MaximumSize = new System.Drawing.Size(300, 0);
            this.panelMenu.MinimumSize = new System.Drawing.Size(200, 421);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 421);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonStat1
            // 
            this.buttonStat1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonStat1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStat1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStat1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStat1.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStat1.Location = new System.Drawing.Point(0, 255);
            this.buttonStat1.Name = "buttonStat1";
            this.buttonStat1.Size = new System.Drawing.Size(200, 51);
            this.buttonStat1.TabIndex = 5;
            this.buttonStat1.Text = "Some statistics 1";
            this.buttonStat1.UseVisualStyleBackColor = false;
            this.buttonStat1.Click += new System.EventHandler(this.buttonStat1_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUsers.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonUsers.Location = new System.Drawing.Point(0, 204);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(200, 51);
            this.buttonUsers.TabIndex = 4;
            this.buttonUsers.Text = "Users";
            this.buttonUsers.UseVisualStyleBackColor = false;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCustomers.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCustomers.Location = new System.Drawing.Point(0, 153);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(200, 51);
            this.buttonCustomers.TabIndex = 3;
            this.buttonCustomers.Text = "Customers";
            this.buttonCustomers.UseVisualStyleBackColor = false;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonOrders
            // 
            this.buttonOrders.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrders.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOrders.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonOrders.Location = new System.Drawing.Point(0, 102);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(200, 51);
            this.buttonOrders.TabIndex = 2;
            this.buttonOrders.Text = "Orders";
            this.buttonOrders.UseVisualStyleBackColor = false;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonCategories
            // 
            this.buttonCategories.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategories.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCategories.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCategories.Location = new System.Drawing.Point(0, 51);
            this.buttonCategories.Name = "buttonCategories";
            this.buttonCategories.Size = new System.Drawing.Size(200, 51);
            this.buttonCategories.TabIndex = 1;
            this.buttonCategories.Text = "Categories";
            this.buttonCategories.UseVisualStyleBackColor = false;
            this.buttonCategories.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonProducts
            // 
            this.buttonProducts.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProducts.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonProducts.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonProducts.Location = new System.Drawing.Point(0, 0);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(200, 51);
            this.buttonProducts.TabIndex = 0;
            this.buttonProducts.Text = "Products";
            this.buttonProducts.UseVisualStyleBackColor = false;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelTop.Controls.Add(this.buttonLogout);
            this.panelTop.Controls.Add(this.labelCurrentUserInfo);
            this.panelTop.Controls.Add(this.labelCurrentUser);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.MaximumSize = new System.Drawing.Size(0, 40);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 40);
            this.panelTop.TabIndex = 1;
            // 
            // buttonLogout
            // 
            this.buttonLogout.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLogout.Location = new System.Drawing.Point(0, 3);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(103, 32);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelCurrentUserInfo
            // 
            this.labelCurrentUserInfo.AutoSize = true;
            this.labelCurrentUserInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentUserInfo.Location = new System.Drawing.Point(109, 9);
            this.labelCurrentUserInfo.Name = "labelCurrentUserInfo";
            this.labelCurrentUserInfo.Size = new System.Drawing.Size(91, 20);
            this.labelCurrentUserInfo.TabIndex = 1;
            this.labelCurrentUserInfo.Text = "Current user:";
            // 
            // labelCurrentUser
            // 
            this.labelCurrentUser.AutoSize = true;
            this.labelCurrentUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentUser.Location = new System.Drawing.Point(206, 9);
            this.labelCurrentUser.Name = "labelCurrentUser";
            this.labelCurrentUser.Size = new System.Drawing.Size(78, 20);
            this.labelCurrentUser.TabIndex = 0;
            this.labelCurrentUser.Text = "Undefined";
            // 
            // productsTab
            // 
            this.productsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsTab.BackColor = System.Drawing.SystemColors.Control;
            this.productsTab.Context = null;
            this.productsTab.Location = new System.Drawing.Point(200, 40);
            this.productsTab.Name = "productsTab";
            this.productsTab.Size = new System.Drawing.Size(584, 421);
            this.productsTab.TabIndex = 2;
            this.productsTab.Visible = false;
            // 
            // categoriesTab
            // 
            this.categoriesTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoriesTab.Context = null;
            this.categoriesTab.Location = new System.Drawing.Point(200, 40);
            this.categoriesTab.Name = "categoriesTab";
            this.categoriesTab.Size = new System.Drawing.Size(584, 421);
            this.categoriesTab.TabIndex = 3;
            this.categoriesTab.Visible = false;
            // 
            // ordersTab
            // 
            this.ordersTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersTab.Context = null;
            this.ordersTab.Location = new System.Drawing.Point(200, 40);
            this.ordersTab.Name = "ordersTab";
            this.ordersTab.Size = new System.Drawing.Size(584, 421);
            this.ordersTab.TabIndex = 4;
            this.ordersTab.Visible = false;
            // 
            // customersTab
            // 
            this.customersTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customersTab.Context = null;
            this.customersTab.Location = new System.Drawing.Point(200, 40);
            this.customersTab.Name = "customersTab";
            this.customersTab.Size = new System.Drawing.Size(584, 421);
            this.customersTab.TabIndex = 5;
            this.customersTab.Visible = false;
            // 
            // usersTab
            // 
            this.usersTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersTab.Context = null;
            this.usersTab.Location = new System.Drawing.Point(200, 40);
            this.usersTab.Name = "usersTab";
            this.usersTab.Size = new System.Drawing.Size(584, 421);
            this.usersTab.TabIndex = 6;
            this.usersTab.Visible = false;
            // 
            // statisticsTab
            // 
            this.statisticsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statisticsTab.Location = new System.Drawing.Point(200, 40);
            this.statisticsTab.Name = "statisticsTab";
            this.statisticsTab.Size = new System.Drawing.Size(584, 421);
            this.statisticsTab.TabIndex = 7;
            this.statisticsTab.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.statisticsTab);
            this.Controls.Add(this.usersTab);
            this.Controls.Add(this.customersTab);
            this.Controls.Add(this.ordersTab);
            this.Controls.Add(this.categoriesTab);
            this.Controls.Add(this.productsTab);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonStat1;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.Button buttonCategories;
        private System.Windows.Forms.Button buttonProducts;
        private Tabs.ProductsTab productsTab;
        private Tabs.CategoriesTab categoriesTab;
        private Tabs.OrdersTab ordersTab;
        private Tabs.CustomersTab customersTab;
        private Tabs.UsersTab usersTab;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelCurrentUserInfo;
        private System.Windows.Forms.Label labelCurrentUser;
        private Tabs.StatisticsTab statisticsTab;
    }
}

