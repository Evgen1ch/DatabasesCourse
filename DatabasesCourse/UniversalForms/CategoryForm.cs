using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Logging;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.UniversalForms
{
    public partial class CategoryForm : Form
    {
        private readonly Category _model;
        private DatabaseContext Context { get; set; }
        private FormAction Action { get; set; }
        public CategoryForm(DatabaseContext context, FormAction action, int id)
        {
            InitializeComponent();
            Context = context;
            Action = action;

            switch (action)
            {
                case FormAction.Create:
                    _model = new Category();
                    break;
                case FormAction.Update:
                    _model = Context.Categories.FirstOrDefault(c => c.Id == id);
                    if (_model is not null)
                    {
                        textBox1.Text = _model.Name;
                    }
                    break;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string modelName = textBox1.Text.Trim();
            var names = Context.Categories.Count(c => c.Name == modelName);
            if (names > 0)
            {
                MessageBox.Show("Category with this name is existing. Please check your input and try again.",
                    "DB Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _model.Name = modelName;
            try
            {
                if (Action == FormAction.Create)
                    Context.Categories.Add(_model);

                Context.SaveChanges();
                switch (Action)
                {
                    case FormAction.Create:
                        Logger.Log($"Category added with id: {_model.Id}", LogAction.Insert);
                        break;
                    case FormAction.Update:
                        Logger.Log($"Category updated with id: {_model.Id}", LogAction.Update);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Somethind went wrong...\nError is: {ex.Message}.\nInner: {ex.InnerException?.Message}.", "Error", MessageBoxButtons.OK,
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
            switch (Action)
            {
                case FormAction.Create:
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        var res = MessageBox.Show("Are you sure you want to exit without creating new entry?", "Question",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
                case FormAction.Update:
                    Close();
                    break;
            }
            Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
