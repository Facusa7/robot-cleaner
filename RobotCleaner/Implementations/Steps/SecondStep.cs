using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Steps
{
    public class SecondStep : IStepBase
    {
        public void Change(IReturnAlgorithm returnAlgorithm, IRobotCleaner robot)
        {
            returnAlgorithm.Step = new ThirdStep();
            robot.TurnLeft();
            robot.Back();
            robot.TurnRight();
            robot.Advance();
        }
    }
}