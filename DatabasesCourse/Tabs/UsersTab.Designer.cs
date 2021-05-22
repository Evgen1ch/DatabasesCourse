
namespace DatabasesCourse.Tabs
{
    partial class UsersTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.buttonApplyFilters = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSearchPhone = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelSearchLastname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(277, 0);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(104, 37);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(57, 0);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(104, 37);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Location = new System.Drawing.Point(167, 0);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(104, 37);
            this.buttonUpdate.TabIndex = 13;
            this.buttonUpdate.Text = "Change";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.buttonReset);
            this.panelSearch.Controls.Add(this.groupBoxFilter);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSearch.Location = new System.Drawing.Point(384, 0);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(200, 421);
            this.panelSearch.TabIndex = 11;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.AllowUserToResizeRows = false;
            this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Location = new System.Drawing.Point(0, 37);
            this.dgvTable.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.RowTemplate.Height = 25;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(384, 384);
            this.dgvTable.TabIndex = 16;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(110, 294);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBoxFilter.Controls.Add(this.comboBoxRole);
            this.groupBoxFilter.Controls.Add(this.label2);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.buttonApplyFilters);
            this.groupBoxFilter.Controls.Add(this.textBoxName);
            this.groupBoxFilter.Controls.Add(this.labelSearchPhone);
            this.groupBoxFilter.Controls.Add(this.textBoxEmail);
            this.groupBoxFilter.Controls.Add(this.labelSearchLastname);
            this.groupBoxFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxFilter.Location = new System.Drawing.Point(6, 16);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(185, 272);
            this.groupBoxFilter.TabIndex = 8;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filters";
            // 
            // buttonApplyFilters
            // 
            this.buttonApplyFilters.Location = new System.Drawing.Point(104, 243);
            this.buttonApplyFilters.Name = "buttonApplyFilters";
            this.buttonApplyFilters.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyFilters.TabIndex = 6;
            this.buttonApplyFilters.Text = "Apply";
            this.buttonApplyFilters.UseVisualStyleBackColor = true;
            this.buttonApplyFilters.Click += new System.EventHandler(this.buttonApplyFilters_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(11, 44);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(168, 23);
            this.textBoxName.TabIndex = 0;
            // 
            // labelSearchPhone
            // 
            this.labelSearchPhone.AutoSize = true;
            this.labelSearchPhone.Location = new System.Drawing.Point(11, 26);
            this.labelSearchPhone.Name = "labelSearchPhone";
            this.labelSearchPhone.Size = new System.Drawing.Size(42, 15);
            this.labelSearchPhone.TabIndex = 1;
            this.labelSearchPhone.Text = "Name:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(11, 97);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(168, 23);
            this.textBoxEmail.TabIndex = 2;
            // 
            // labelSearchLastname
            // 
            this.labelSearchLastname.AutoSize = true;
            this.labelSearchLastname.Location = new System.Drawing.Point(11, 79);
            this.labelSearchLastname.Name = "labelSearchLastname";
            this.labelSearchLastname.Size = new System.Drawing.Size(39, 15);
            this.labelSearchLastname.TabIndex = 3;
            this.labelSearchLastname.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Role:";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(11, 157);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(168, 23);
            this.comboBoxRole.TabIndex = 9;
            // 
            // UsersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.panelSearch);
            this.Name = "UsersTab";
            this.Size = new System.Drawing.Size(584, 421);
            this.panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Button buttonApplyFilters;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelSearchPhone;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelSearchLastname;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
