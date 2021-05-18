using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DatabasesCourse.DatabaseModel.Entities;

namespace DatabasesCourse.Validators
{
    class CustomerValidator: IValidator<Customer>
    {
        public string ValidateWithString(Customer entity)
        {
            StringBuilder sb = new StringBuilder();
            if (!Regex.IsMatch(entity.FirstName, @"^[a-zA-Z]+$"))
                sb.Append("First name must contains only letters.\n");
            if (!Regex.IsMatch(entity.LastName, @"^[a-zA-Z]+$"))
                sb.Append("Last name must contains only letters.\n");
            return sb.ToString();
        }
    }
}
