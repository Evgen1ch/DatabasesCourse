
namespace DatabasesCourse.DetailsForms
{
    partial class DetailsOrderForm
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
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelCustomerText = new System.Windows.Forms.Label();
            this.labelUserText = new System.Windows.Forms.Label();
            this.labelCustomerValue = new System.Windows.Forms.Label();
            this.labelUserValue = new System.Windows.Forms.Label();
            this.labelTotalCostText = new System.Windows.Forms.Label();
            this.labelTotalCostValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Price,
            this.PName,
            this.Amount});
            this.dgvProducts.Location = new System.Drawing.Point(13, 66);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(775, 302);
            this.dgvProducts.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // PName
            // 
            this.PName.DataPropertyName = "Name";
            this.PName.HeaderText = "Name";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(694, 415);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(94, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // labelCustomerText
            // 
            this.labelCustomerText.AutoSize = true;
            this.labelCustomerText.Location = new System.Drawing.Point(13, 13);
            this.labelCustomerText.Name = "labelCustomerText";
            this.labelCustomerText.Size = new System.Drawing.Size(62, 15);
            this.labelCustomerText.TabIndex = 2;
            this.labelCustomerText.Text = "Customer:";
            // 
            // labelUserText
            // 
            this.labelUserText.AutoSize = true;
            this.labelUserText.Location = new System.Drawing.Point(13, 37);
            this.labelUserText.Name = "labelUserText";
            this.labelUserText.Size = new System.Drawing.Size(33, 15);
            this.labelUserText.TabIndex = 3;
            this.labelUserText.Text = "User:";
            // 
            // labelCustomerValue
            // 
            this.labelCustomerValue.AutoSize = true;
            this.labelCustomerValue.Location = new System.Drawing.Point(99, 13);
            this.labelCustomerValue.Name = "labelCustomerValue";
            this.labelCustomerValue.Size = new System.Drawing.Size(61, 15);
            this.labelCustomerValue.TabIndex = 4;
            this.labelCustomerValue.Text = "undefined";
            // 
            // labelUserValue
            // 
            this.labelUserValue.AutoSize = true;
            this.labelUserValue.Location = new System.Drawing.Point(99, 37);
            this.labelUserValue.Name = "labelUserValue";
            this.labelUserValue.Size = new System.Drawing.Size(61, 15);
            this.labelUserValue.TabIndex = 5;
            this.labelUserValue.Text = "undefined";
            // 
            // labelTotalCostText
            // 
            this.labelTotalCostText.AutoSize = true;
            this.labelTotalCostText.Location = new System.Drawing.Point(558, 375);
            this.labelTotalCostText.Name = "labelTotalCostText";
            this.labelTotalCostText.Size = new System.Drawing.Size(60, 15);
            this.labelTotalCostText.TabIndex = 7;
            this.labelTotalCostText.Text = "Total cost:";
            // 
            // labelTotalCostValue
            // 
            this.labelTotalCostValue.AutoSize = true;
            this.labelTotalCostValue.Location = new System.Drawing.Point(624, 375);
            this.labelTotalCostValue.Name = "labelTotalCostValue";
            this.labelTotalCostValue.Size = new System.Drawing.Size(36, 15);
            this.labelTotalCostValue.TabIndex = 8;
            this.labelTotalCostValue.Text = "None";
            // 
            // DetailsOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTotalCostValue);
            this.Controls.Add(this.labelTotalCostText);
            this.Controls.Add(this.labelUserValue);
            this.Controls.Add(this.labelCustomerValue);
            this.Controls.Add(this.labelUserText);
            this.Controls.Add(this.labelCustomerText);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dgvProducts);
            this.Name = "DetailsOrderForm";
            this.Text = "DetailsOrderForm";
            this.Load += new System.EventHandler(this.DetailsOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelCustomerText;
        private System.Windows.Forms.Label labelUserText;
        private System.Windows.Forms.Label labelCustomerValue;
        private System.Windows.Forms.Label labelUserValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Label labelTotalCostText;
        private System.Windows.Forms.Label labelTotalCostValue;
    }
}