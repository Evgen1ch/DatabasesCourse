using System.Collections.Generic;
using System.ComponentModel;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
