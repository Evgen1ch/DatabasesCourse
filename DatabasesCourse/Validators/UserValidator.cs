using DatabasesCourse.DatabaseModel.Entities;
using System.Text;

namespace DatabasesCourse.Validators
{
    class UserValidator : IValidator<User>
    {
        public string ValidateWithString(User entity)
        {
            StringBuilder sb = new StringBuilder();
            if (entity.FirstName.Length == 0)
                sb.Append("Invalid First name. Please enter the First name.\n");
            if (entity.LastName.Length == 0)
                sb.Append("Invalid Last name. Please enter the Last name.\n");
            return sb.ToString();
        }
    }
}
