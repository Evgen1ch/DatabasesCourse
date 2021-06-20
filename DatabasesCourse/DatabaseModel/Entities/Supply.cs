using System;

namespace DatabasesCourse.DatabaseModel.Entities
{
    public class Supply : IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
