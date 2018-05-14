using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Directions
{
    public class FacingToWest : IMovingStrategy
    {
        public void MoveBackwards(IRobotCleaner robot)
        {
            var nextCell = robot.X + 1;
            if (!robot.IsObstacle(nextCell, robot.Y))
            {
                robot.X += 1;
            }
            else
            {
                robot.Return();
            }
        }

        public void MoveForward(IRobotCleaner robot)
        {
            var nextCell = robot.X - 1;
            if (!robot.IsObstacle(nextCell,robot.Y))
            {
                robot.X -= 1;
            }
            else
            {
                robot.Return();
            }
        }
    }
}
