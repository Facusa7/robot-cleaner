using System;

namespace RobotCleaner.Helpers
{
    [Serializable]
    public abstract class Position
    {
        public int X;
        public int Y;
    }
    /// <summary>
    /// A final position that is used to show the data in the result set. 
    /// </summary>
    public class FinalState : Position
    {
        public string FacingTo;
        public FinalState(int x, int y, FacingTo facingTo) 
        {
            this.X = x;
            this.Y = y;
            this.FacingTo = Orientations.GetFacingName(facingTo);
        }
    }
    /// <summary>
    /// Object that represents the current position of the robot in a specific moment.
    /// </summary>
    public class CurrentPosition : Position
    {
        public CurrentPosition(int x, int y) 
        {
            this.X = x;
            this.Y = y;
        }
    }
}
