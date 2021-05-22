using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse.Tabs
{
    public partial class StatisticsTab : UserControl
    {
        private DatabaseContext Context { get; set; } 
        public StatisticsTab()
        {
            InitializeComponent();
            Context = new DatabaseContext();
            Context.Products.Load();
        }

        private void buttonUpdateProdStat_Click(object sender, EventArgs e)
        {
            Product temp1 = null;
            Product temp2 = null;
            var products = Context.Products.ToList();
            int maxSum = 0;
            int maxMonthSum = 0;
            foreach (var product in products)
            {
                var sum = Context.OrdersProducts.Where(p => p.ProductId == product.Id).Sum(op => op.Amount);

                var sumMonth = Context.OrdersProducts.Include(op=>op.Order).AsEnumerable().Where(op =>
                        op.ProductId == product.Id && (DateTime.Now - op.Order.DateTime).TotalDays < 30)
                    .Sum(op => op.Amount);
                if (sum > maxSum)
                {
                    maxSum = sum;
                    temp1 = product;
                }
                if (sumMonth > maxMonthSum)
                {
                    maxMonthSum = sumMonth;
                    temp2 = product;
                }
            }

            labelProdStat1Value.Text = maxSum.ToString() + @"     " + (temp1 != null ? temp1.Name : "Undefined name");
            labelProdStat2Value.Text = maxMonthSum.ToString() + @"     " + (temp2 != null ? temp2.Name : "Undefined name");

        }

        private void buttonOrderStats_Click(object sender, EventArgs e)
        {
            var orders = Context.Orders.ToList();
            labelOrdersStat1Value.Text = orders.Count().ToString();
            labelStatsOrders2Value.Text = orders.Count(o => (DateTime.Now - o.DateTime).TotalDays < 30).ToString();
            labelStatsOrders3Value.Text = orders.Where(o => (DateTime.Now - o.DateTime).TotalDays < 30)
                .Sum(o => o.TotalCost).ToString(CultureInfo.InvariantCulture);
        }

        private void buttonUsersStats_Click(object sender, EventArgs e)
        {
            var users = Context.Users.Include(u=>u.Credentials).Include(u=>u.ServedOrders).ToList();
            labelUserStat1.Text = users.Count(u => u.Credentials.Role == Role.Employee).ToString();
            labelUserStat2.Text = users.Count(u => u.Credentials.Role == Role.Manager).ToString();
            labelUserStat3.Text = users.Count(u => u.Credentials.Role == Role.Admin).ToString();
            labelUserStat4.Text = users.Max(u => u.ServedOrders.Count).ToString();
        }
    }
}
