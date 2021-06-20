namespace DatabasesCourse.DatabaseModel.Entities
{
    public enum Role
    {
        Employee,
        Manager,
        Admin
    }
    public class Credentials : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
