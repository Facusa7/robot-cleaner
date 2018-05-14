using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Commands
{
    public class CleanCommand : ICommand
    {
        public void Execute(IRobotCleaner robotCleaner)
        {
            robotCleaner.CleanCell();
        }
    }
}
