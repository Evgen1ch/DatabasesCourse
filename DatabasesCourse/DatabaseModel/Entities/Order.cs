using System;
using System.Collections.Generic;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<OrderProduct> OrdersProducts { get; set; } = new List<OrderProduct>();

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; } //owner

        public int? UserId { get; set; }
        public User User { get; set; } //employee
    }
}
