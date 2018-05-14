namespace RobotCleaner.Exceptions
{
    public class OutOfMovesException : RobotCleanerException
    {
        public OutOfMovesException(string message, string response) : base(message, response)
        {
        }
    }
}
