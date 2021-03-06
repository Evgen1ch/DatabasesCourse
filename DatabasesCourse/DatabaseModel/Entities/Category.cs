using System.Collections.Generic;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Category : IEntityBase
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
