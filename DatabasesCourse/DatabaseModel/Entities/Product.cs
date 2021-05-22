using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        
        public int CategoryId { get; set; }
        [Browsable(false)]
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        [Browsable(false)]
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        [Browsable(false)]
        public ICollection<OrderProduct> OrdersProducts { get; set; } = new List<OrderProduct>();
    }
}
