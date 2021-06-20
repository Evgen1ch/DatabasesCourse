
using DatabasesCourse.DatabaseModel;
using System;

namespace DatabasesCourse.Logging
{

    public static class Logger
    {
        private static DatabaseContext Context { get; set; }

        static Logger()
        {
            Context = AppGlobals.Context;
        }

        public static void Log(string details, LogAction action)
        {
            try
            {
                Context.Add(new LogEntry(action, AppGlobals.CurrentUser, details));
                Context.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
