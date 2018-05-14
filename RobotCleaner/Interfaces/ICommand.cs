namespace RobotCleaner.Interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// Execute the command given. Each command will call an especific action in the robot.
        /// </summary>
        /// <param name="robotCleaner"></param>
        void Execute(IRobotCleaner robotCleaner);
    }
}
