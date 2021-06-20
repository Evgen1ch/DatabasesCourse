using System.Collections.Generic;
using System.ComponentModel;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public int ManufacturerId { get; set; }
        [Browsable(false)]
        public Manufacturer Manufacturer { get; set; }
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
