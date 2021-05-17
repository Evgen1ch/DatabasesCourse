using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesCourse.DatabaseModel.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
