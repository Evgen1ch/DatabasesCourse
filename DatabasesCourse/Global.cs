using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabasesCourse.DatabaseModel.Entities;

namespace DatabasesCourse
{
    public static class Global
    {
        public static User CurrentUser { get; set; } = new User
        {
            FirstName = "Admin",
            LastName = "Adminskyi",
            Credentials = new Credentials
            {
                Email = "123aa@gmail.com", Password = "admin", Role = Role.Admin
            }
        };

        public static MainForm MainForm { get; set; } = new MainForm();

    }
}
