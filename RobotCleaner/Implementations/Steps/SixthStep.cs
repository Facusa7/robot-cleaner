using Newtonsoft.Json;
using RobotCleaner.Exceptions;
using RobotCleaner.Helpers;
using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations.Steps
{
    public class SixthStep : IStepBase
    {
        public void Change(IReturnAlgorithm returnAlgorithm, IRobotCleaner robot)
        {
            var position = new FinalState(robot.X, robot.Y, robot.FaceTo);
            var response = new ResponseDto(robot.Map.Visited, robot.Map.Cleaned, position, robot.Battery);
            throw new OutOfMovesException("Robot ran out of moves", JsonConvert.SerializeObject(response));
        }
    }
}