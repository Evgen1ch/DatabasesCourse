
namespace DatabasesCourse.CreateForms
{
    partial class CreateOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.labelSelected = new System.Windows.Forms.Label();
            this.labelSelectedInfo = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.labelCustomerSelect = new System.Windows.Forms.Label();
            this.dgvSelectedItems = new System.Windows.Forms.DataGridView();
            this.labelOrderSelected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ProdName,
            this.Category,
            this.Price,
            this.Amount});
            this.dgvProducts.Location = new System.Drawing.Point(12, 81);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(776, 135);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // ProdName
            // 
            this.ProdName.DataPropertyName = "Name";
            this.ProdName.HeaderText = "Name";
            this.ProdName.Name = "ProdName";
            this.ProdName.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "CategoryId";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(587, 52);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownAmount.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(713, 52);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(676, 399);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(112, 23);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(558, 399);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(112, 23);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = true;
            this.labelSelected.Location = new System.Drawing.Point(12, 58);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(81, 15);
            this.labelSelected.TabIndex = 6;
            this.labelSelected.Text = "Selected item:";
            // 
            // labelSelectedInfo
            // 
            this.labelSelectedInfo.AutoSize = true;
            this.labelSelectedInfo.Location = new System.Drawing.Point(99, 58);
            this.labelSelectedInfo.Name = "labelSelectedInfo";
            this.labelSelectedInfo.Size = new System.Drawing.Size(62, 15);
            this.labelSelectedInfo.TabIndex = 7;
            this.labelSelectedInfo.Text = "Undefined";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(80, 12);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(373, 23);
            this.comboBoxCustomer.TabIndex = 8;
            // 
            // labelCustomerSelect
            // 
            this.labelCustomerSelect.AutoSize = true;
            this.labelCustomerSelect.Location = new System.Drawing.Point(12, 15);
            this.labelCustomerSelect.Name = "labelCustomerSelect";
            this.labelCustomerSelect.Size = new System.Drawing.Size(62, 15);
            this.labelCustomerSelect.TabIndex = 10;
            this.labelCustomerSelect.Text = "Customer:";
            // 
            // dgvSelectedItems
            // 
            this.dgvSelectedItems.AllowUserToAddRows = false;
            this.dgvSelectedItems.AllowUserToDeleteRows = false;
            this.dgvSelectedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedItems.Location = new System.Drawing.Point(12, 258);
            this.dgvSelectedItems.Name = "dgvSelectedItems";
            this.dgvSelectedItems.ReadOnly = true;
            this.dgvSelectedItems.RowTemplate.Height = 25;
            this.dgvSelectedItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedItems.Size = new System.Drawing.Size(776, 135);
            this.dgvSelectedItems.TabIndex = 11;
            // 
            // labelOrderSelected
            // 
            this.labelOrderSelected.AutoSize = true;
            this.labelOrderSelected.Location = new System.Drawing.Point(13, 237);
            this.labelOrderSelected.Name = "labelOrderSelected";
            this.labelOrderSelected.Size = new System.Drawing.Size(134, 15);
            this.labelOrderSelected.TabIndex = 12;
            this.labelOrderSelected.Text = "Order Selected Products";
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 434);
            this.Controls.Add(this.labelOrderSelected);
            this.Controls.Add(this.dgvSelectedItems);
            this.Controls.Add(this.labelCustomerSelect);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.labelSelectedInfo);
            this.Controls.Add(this.labelSelected);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.dgvProducts);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label labelSelected;
        private System.Windows.Forms.Label labelSelectedInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label labelCustomerSelect;
        private System.Windows.Forms.DataGridView dgvSelectedItems;
        private System.Windows.Forms.Label labelOrderSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount2;
    }
}