using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Commands
{
    public class TurnRightCommand : ICommand
    {
        public void Execute(IRobotCleaner robotCleaner)
        {
            robotCleaner.TurnRight();
        }
    }
}
