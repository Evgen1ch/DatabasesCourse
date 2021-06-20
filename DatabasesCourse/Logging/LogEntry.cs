using DatabasesCourse.DatabaseModel.Entities;
using System;

namespace DatabasesCourse.Logging
{
    public enum LogAction
    {
        Insert,
        Update,
        Remove,
        LogIn
    }

    public class LogEntry
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }

        public LogEntry() { }

        public LogEntry(LogAction action, User user, string details = "")
        {
            Action = action.ToString();
            User = user;
            Details = details;
            DateTime = DateTime.Now;
        }
    }
}
