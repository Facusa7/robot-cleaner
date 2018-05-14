using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Steps
{
    public class FifthStep : IStepBase
    {
        public void Change(IReturnAlgorithm returnAlgorithm, IRobotCleaner robot)
        {
            returnAlgorithm.Step = new SixthStep();
            robot.TurnLeft();
            robot.TurnLeft();
            robot.Advance();
        }
    }
}