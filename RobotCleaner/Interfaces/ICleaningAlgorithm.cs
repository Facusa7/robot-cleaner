using RobotCleaner.Helpers;

namespace RobotCleaner.Interfaces
{
    public interface ICleaningAlgorithm
    {
        ResponseDto Clean(IRobotCleaner robot);
    }
}
