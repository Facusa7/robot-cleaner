namespace RobotCleaner.Interfaces
{
    /// <summary>
    /// Indicates how the robot should move considering the orientation and the command: Advance or Back.
    /// </summary>
    public interface IMovingStrategy
    {
        /// <summary>
        /// Advance 
        /// </summary>
        /// <param name="robot"></param>
        void MoveForward(IRobotCleaner robot);
        /// <summary>
        /// Back
        /// </summary>
        /// <param name="robot"></param>
        void MoveBackwards(IRobotCleaner robot);
    }
}
