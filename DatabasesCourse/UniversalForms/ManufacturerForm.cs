using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.UniversalForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.CreateForms
{
    public partial class ManufacturerForm : Form
    {
        private DatabaseContext Context { get; set; }
        private readonly Manufacturer _model;
        private FormAction Action { get; set; }
        public ManufacturerForm(DatabaseContext context, FormAction action, int id)
        {
            InitializeComponent();
            Action = action;
            Context = context;
            switch (action)
            {
                case FormAction.Create:
                    _model = new Manufacturer();
                    break;
                case FormAction.Update:
                    _model = Context.Manufacturers.FirstOrDefault(m => m.Id == id);
                    if (_model != null)
                    {
                        textBox1.Text = _model.Name;
                        textBox2.Text = _model.Country;
                    }
                    break;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string modelName = textBox1.Text.Trim();
            string modelCountry = textBox2.Text.Trim();

            _model.Name = modelName;
            _model.Country = modelCountry;
            try
            {
                if (Action == FormAction.Create)
                    Context.Manufacturers.Add(_model);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    @$"Somethind went wrong...\nError is: {ex.Message}.\nInner: {ex.InnerException?.Message}.", @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            switch (Action)
            {
                case FormAction.Create:
                    if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text))
                    {
                        var res = MessageBox.Show(@"Are you sure you want to exit without creating new entry?", @"Question",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                            this.Close();
                    }
                    break;
                case FormAction.Update:
                    this.Close();
                    break;
            }
        }
    }
}
