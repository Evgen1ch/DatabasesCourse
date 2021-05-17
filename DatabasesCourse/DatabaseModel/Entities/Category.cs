using System.Collections.Generic;

namespace DatabasesCourse.DatabaseModel.Entities
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
