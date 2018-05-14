using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Steps
{
    public class FirstStep : IStepBase
    {
        public void Change(IReturnAlgorithm returnAlgorithm, IRobotCleaner robot)
        {
            returnAlgorithm.Step = new SecondStep();
            robot.TurnRight();
            robot.Advance();
        }
    }
}
