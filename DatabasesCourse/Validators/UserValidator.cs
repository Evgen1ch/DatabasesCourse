using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabasesCourse.DatabaseModel.Entities;

namespace DatabasesCourse.Validators
{
    public class UserValidator: IValidator<User>
    {
        public string ValidateWithString(User entity)
        {
            StringBuilder sb = new StringBuilder();
            
            return sb.ToString();
        }
    }
}
