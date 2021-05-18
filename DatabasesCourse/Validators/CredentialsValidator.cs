using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DatabasesCourse.DatabaseModel.Entities;

namespace DatabasesCourse.Validators
{
    class CredentialsValidator:IValidator<Credentials>
    {
        public string ValidateWithString(Credentials entity)
        {
            StringBuilder sb = new StringBuilder();
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.CultureInvariant | RegexOptions.Singleline);
            if (!regex.IsMatch(entity.Email))
                sb.Append("Invalid email. Please enter an email.\n");
            if(entity.Password.Length is > 50 or < 6)
                sb.Append("Invalid password. Password must has al least 6 symbols.\n");
            return sb.ToString();
        }
    }
}
