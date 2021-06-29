using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DatabasesCourse.Tabs
{
    public partial class StatisticsTab : UserControl
    {
        private DatabaseContext Context { get; set; }
        public StatisticsTab()
        {
            InitializeComponent();
            Context = AppGlobals.Context;
            Context.Products.Load();
        }

        private void buttonUpdateProdStat_Click(object sender, EventArgs e)
        {
            Product temp1 = null;
            Product temp2 = null;
            var products = Context.Products.ToList();
            int maxMonthSum = 0;

            var maxProd = Context.OrdersProducts.GroupBy(op => op.ProductId)
                .Select(a => new { ProductId = a.Key, SumAmount = a.Sum(b => b.Amount) })
                .OrderByDescending(x => x.SumAmount)
                .FirstOrDefault();
            temp1 = Context.Products.FirstOrDefault(p => p.Id == maxProd.ProductId);
            
            foreach (var product in products)
            {
                var sumMonth = Context.OrdersProducts.Include(op => op.Order).AsEnumerable().Where(op =>
                        op.ProductId == product.Id && (DateTime.Now - op.Order.DateTime).TotalDays < 30)
                    .Sum(op => op.Amount);

                if (sumMonth > maxMonthSum)
                {
                    maxMonthSum = sumMonth;
                    temp2 = product;
                }
            }

            if(maxProd!=null && temp1!=null)
                labelProdStat1Value.Text = maxProd.SumAmount + @" products with name " + temp1.Name;
            labelProdStat2Value.Text = maxMonthSum.ToString() + @" products with name " + (temp2 != null ? temp2.Name : "Undefined name");

        }

        private void buttonOrderStats_Click(object sender, EventArgs e)
        {
            var orders = Context.Orders.AsQueryable();
            var date1 = DateTime.Now.AddDays(-30);
            var date2 = DateTime.Now;
            labelOrdersStatTotalValue.Text = orders.Count().ToString();
            labelStatsOrdersTotalMonthValue.Text = orders.Count(o => o.DateTime >= date1 && o.DateTime <= date2).ToString();
            labelStatsOrdersTotalMoneyValue.Text = orders.Where(o => o.DateTime >= date1 && o.DateTime <= date2)
                .Sum(o => o.TotalCost).ToString(CultureInfo.InvariantCulture);
        }

        private void buttonUsersStats_Click(object sender, EventArgs e)
        {
            var users = Context.Users
                .Include(u => u.Credentials)
                .Include(u => u.ServedOrders)
                .AsQueryable();
            labelUserStat1.Text = users.Count(u => u.Credentials.Role == Role.Employee).ToString();
            labelUserStat2.Text = users.Count(u => u.Credentials.Role == Role.Manager).ToString();
            labelUserStat3.Text = users.Count(u => u.Credentials.Role == Role.Admin).ToString();

            var user = users.OrderByDescending(u => u.ServedOrders.Count).FirstOrDefault();
            if (user != null)
                labelUserStat4.Text =
                    user.ServedOrders.Count + ". User: " + user.FirstName + " " + user.LastName + ", Id = " + user.Id;
        }
    }
}
