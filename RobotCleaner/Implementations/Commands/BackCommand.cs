using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Commands
{
    public class BackCommand : ICommand
    {
        public void Execute(IRobotCleaner robotCleaner)
        {
            robotCleaner.Back();
        }
    }
}
