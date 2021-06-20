using System.Collections.Generic;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Credentials Credentials { get; set; }

        public ICollection<Order> ServedOrders { get; set; }
    }
}
