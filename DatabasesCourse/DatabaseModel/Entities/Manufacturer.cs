using System.Collections.Generic;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Manufacturer : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
