using System;
using System.Collections.Generic;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Customer : IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateTimeRegistered { get; set; }

        public ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + PhoneNumber;
        }
    }
}
