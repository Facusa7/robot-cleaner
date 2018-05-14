using System;

namespace RobotCleaner.Helpers
{
    [Serializable]
    public abstract class Position
    {
        public int X;
        public int Y;
    }

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

    public class CurrentPosition : Position
    {
        public CurrentPosition(int x, int y) 
        {
            this.X = x;
            this.Y = y;
        }
    }
}
