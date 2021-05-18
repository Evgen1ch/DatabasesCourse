using System;
using System.Linq;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;

namespace DatabasesCourse.CreateForms
{
    public partial class CreateCategoryForm : Form
    {
        private Category _model = new();
        private DatabaseContext _context;
        public CreateCategoryForm(DatabaseContext context)
        {
            InitializeComponent();
            _context = context;
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
                _context.Categories.Add(_model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Somethind went wrong...\nError is: {ex.Message}.\nInner: {ex.InnerException.Message}.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                var res = MessageBox.Show("Are you sure you want to exit without creating new entry?", "Question",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}
