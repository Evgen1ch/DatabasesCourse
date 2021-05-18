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

namespace DatabasesCourse.DetailsForms
{
    public partial class DetailsOrderForm : Form
    {
        private DatabaseContext Context { get; set; }
        private int _id;
        public DetailsOrderForm(DatabaseContext context, int id)
        {
            InitializeComponent();
            Context = context;
            _id = id;
        }
    }
}
