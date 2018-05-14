using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Directions
{
    public class FacingToSouth : IMovingStrategy
    {
        public void MoveBackwards(IRobotCleaner robot)
        {
            var nextCell = robot.Y - 1;
            if (!robot.IsObstacle(robot.X, nextCell))
            {
                robot.Y -= 1;
            }
            else
            {
                robot.Return();
            }
        }

        public void MoveForward(IRobotCleaner robot)
        {
            var nextCell = robot.Y + 1;
            if (!robot.IsObstacle(robot.X, nextCell))
            {
                robot.Y += 1;
            }
            else
            {
                robot.Return();
            }
        }
    }
}
