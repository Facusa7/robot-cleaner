using System.Collections.Generic;
using System.Linq;
using RobotCleaner.Implementations.Directions;
using RobotCleaner.Interfaces;

namespace RobotCleaner.Helpers
{
    public static class Orientations
    {
        public static readonly Dictionary<string, FacingTo> FacingPositions;

        static Orientations()
        {
            FacingPositions = new Dictionary<string, FacingTo>();
        }

        public static FacingTo GetFacingPosition(string facing)
        {
            return FacingPositions[facing];
        }

        public static string GetFacingName(FacingTo facingTo)
        {
            return FacingPositions.FirstOrDefault(x => x.Value == facingTo).Key;
        }

        public static void InitializeOrientations()
        {
            FacingPositions.Add("E", FacingTo.East);
            FacingPositions.Add("S", FacingTo.South);
            FacingPositions.Add("W", FacingTo.West);
            FacingPositions.Add("N", FacingTo.North);
        }

        public static Dictionary<FacingTo, IMovingStrategy> GetMovingStrategies()
        {
            return new Dictionary<FacingTo, IMovingStrategy>
            {
                { FacingTo.East, new FacingToEast() },
                { FacingTo.West, new FacingToWest() },
                { FacingTo.North, new FacingToNorth() },
                { FacingTo.South, new FacingToSouth() }
            };
        }
    }
    public enum FacingTo
    {
        West = 0,
        South = 1,
        East = 2,
        North = 3
    }
}
