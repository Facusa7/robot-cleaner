using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public void Execute(IRobotCleaner robotCleaner)
        {
            robotCleaner.TurnLeft();
        }
    }
}
