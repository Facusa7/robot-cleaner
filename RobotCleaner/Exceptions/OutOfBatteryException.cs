namespace RobotCleaner.Exceptions
{
    public class OutOfBatteryException : RobotCleanerException
    {
        public OutOfBatteryException(string message, string response) : base(message, response)
        {
        }
    }
}
