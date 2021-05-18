
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
            this.buttonStat2 = new System.Windows.Forms.Button();
            this.buttonStat1 = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonOrders = new System.Windows.Forms.Button();
            this.buttonCategories = new System.Windows.Forms.Button();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.productsTab = new DatabasesCourse.Tabs.ProductsTab();
            this.categoriesTab = new DatabasesCourse.Tabs.CategoriesTab();
            this.ordersTab = new DatabasesCourse.Tabs.OrdersTab();
            this.customersTab = new DatabasesCourse.Tabs.CustomersTab();
            this.usersTab = new DatabasesCourse.Tabs.UsersTab();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Controls.Add(this.buttonStat2);
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
            // buttonStat2
            // 
            this.buttonStat2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStat2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStat2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStat2.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStat2.Location = new System.Drawing.Point(0, 306);
            this.buttonStat2.Name = "buttonStat2";
            this.buttonStat2.Size = new System.Drawing.Size(200, 51);
            this.buttonStat2.TabIndex = 6;
            this.buttonStat2.Text = "Some statistics 2";
            this.buttonStat2.UseVisualStyleBackColor = true;
            this.buttonStat2.Click += new System.EventHandler(this.buttonStat2_Click);
            // 
            // buttonStat1
            // 
            this.buttonStat1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStat1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStat1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStat1.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStat1.Location = new System.Drawing.Point(0, 255);
            this.buttonStat1.Name = "buttonStat1";
            this.buttonStat1.Size = new System.Drawing.Size(200, 51);
            this.buttonStat1.TabIndex = 5;
            this.buttonStat1.Text = "Some statistics 1";
            this.buttonStat1.UseVisualStyleBackColor = true;
            this.buttonStat1.Click += new System.EventHandler(this.buttonStat1_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUsers.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonUsers.Location = new System.Drawing.Point(0, 204);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(200, 51);
            this.buttonUsers.TabIndex = 4;
            this.buttonUsers.Text = "Users";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCustomers.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCustomers.Location = new System.Drawing.Point(0, 153);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(200, 51);
            this.buttonCustomers.TabIndex = 3;
            this.buttonCustomers.Text = "Customers";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonOrders
            // 
            this.buttonOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrders.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOrders.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonOrders.Location = new System.Drawing.Point(0, 102);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(200, 51);
            this.buttonOrders.TabIndex = 2;
            this.buttonOrders.Text = "Orders";
            this.buttonOrders.UseVisualStyleBackColor = true;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonCategories
            // 
            this.buttonCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategories.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCategories.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCategories.Location = new System.Drawing.Point(0, 51);
            this.buttonCategories.Name = "buttonCategories";
            this.buttonCategories.Size = new System.Drawing.Size(200, 51);
            this.buttonCategories.TabIndex = 1;
            this.buttonCategories.Text = "Categories";
            this.buttonCategories.UseVisualStyleBackColor = true;
            this.buttonCategories.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonProducts
            // 
            this.buttonProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProducts.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonProducts.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonProducts.Location = new System.Drawing.Point(0, 0);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(200, 51);
            this.buttonProducts.TabIndex = 0;
            this.buttonProducts.Text = "Products";
            this.buttonProducts.UseVisualStyleBackColor = true;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.MaximumSize = new System.Drawing.Size(0, 40);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 40);
            this.panelTop.TabIndex = 1;
            // 
            // productsTab
            // 
            this.productsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsTab.BackColor = System.Drawing.SystemColors.Control;
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
            this.usersTab.Location = new System.Drawing.Point(200, 40);
            this.usersTab.Name = "usersTab";
            this.usersTab.Size = new System.Drawing.Size(584, 421);
            this.usersTab.TabIndex = 6;
            this.usersTab.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonStat2;
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
    }
}

