using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Steps
{
    public class FourthStep : IStepBase
    {
        public void Change(IReturnAlgorithm returnAlgorithm, IRobotCleaner robot)
        {
            returnAlgorithm.Step = new FifthStep();
            robot.TurnRight();
            robot.Back();
            robot.TurnRight();
            robot.Advance();
        }
    }
}