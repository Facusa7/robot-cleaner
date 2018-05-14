namespace RobotCleaner.Interfaces
{
    public interface IStepBase
    {
        /// <summary>
        /// Change the Return Algorithm step and executes the current one
        /// </summary>
        /// <param name="returnAlgorithm"></param>
        /// <param name="robot"></param>
        void Change(IReturnAlgorithm returnAlgorithm, IRobotCleaner robot);
    }
}
