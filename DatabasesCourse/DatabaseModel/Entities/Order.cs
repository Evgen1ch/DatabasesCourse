using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesCourse.DatabaseModel.Entities
{
    class Order
    {
        public int Id { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; } //owner

        public int? UserId { get; set; }
        public User User { get; set; } //employee
    }
}
