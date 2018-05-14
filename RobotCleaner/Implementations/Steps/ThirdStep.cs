using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Steps
{
    public class ThirdStep : IStepBase
    {
        public void Change(IReturnAlgorithm returnAlgorithm, IRobotCleaner robot)
        {
            returnAlgorithm.Step = new FourthStep();
            robot.TurnLeft();
            robot.TurnLeft();
            robot.Advance();
        }
    }
}