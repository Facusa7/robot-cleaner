using System;

namespace RobotCleaner.Exceptions
{
    public class RobotCleanerException : Exception
    {
        public RobotCleanerException(string message, string response) : base(message)
        {
            this.Response = response;
        }

        public string Response { get; set; }
    }
}
