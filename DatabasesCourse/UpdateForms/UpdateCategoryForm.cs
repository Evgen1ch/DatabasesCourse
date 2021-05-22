using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.UpdateForms
{
    public partial class UpdateCategoryForm : Form
    {
        private Category _model = new();
        private DatabaseContext _context;
        private int _id;
        public UpdateCategoryForm(DatabaseContext context, int id)
        {
            InitializeComponent();
            _context = context;
            _id = id;
            _model = _context.Categories.FirstOrDefault(c => c.Id == _id);
            if (_model is not null)
            {
                textBox1.Text = _model.Name;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string modelName = textBox1.Text.Trim();
            var names = _context.Categories.Count(c => c.Name == modelName);
            if (names > 0)
            {
                MessageBox.Show("Category with this name is existing. Please check your input and try again.",
                    "DB Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _model.Name = modelName;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Somethind went wrong...\nError is: {ex.Message}.\nInner: {ex.InnerException?.Message}.",
                    @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void UpdateCategoryForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
