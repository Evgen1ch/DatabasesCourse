using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;

namespace DatabasesCourse
{
    public static class AppGlobals
    {
        public static User CurrentUser { get; set; }
        public static DatabaseContext Context { get; set; }

        public static MainForm MainForm { get; set; }
        public static LoginForm LoginForm { get; set; }

        static AppGlobals()
        {
            Context = DatabaseContext.Create();
            MainForm = new MainForm();
            LoginForm = new LoginForm();
        }
    }
}
