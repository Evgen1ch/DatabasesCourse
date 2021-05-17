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
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse
{
    public partial class MainForm : Form
    {
        private DatabaseContext _db;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _db = new DatabaseContext();
            _db.Products.Load();
        }
    }
}
