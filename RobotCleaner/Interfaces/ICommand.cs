namespace RobotCleaner.Interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// Execute the command given
        /// </summary>
        /// <param name="robotCleaner"></param>
        void Execute(IRobotCleaner robotCleaner);
    }
}
