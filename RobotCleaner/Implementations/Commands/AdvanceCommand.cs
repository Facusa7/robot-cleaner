using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Commands
{
    public class AdvanceCommand : ICommand
    {
        public void Execute(IRobotCleaner robotCleaner)
        {
            robotCleaner.Advance();
        }
    }
}
