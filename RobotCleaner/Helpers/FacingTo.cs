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
        /// <summary>
        /// Based on the position name, it will return an Enum
        /// </summary>
        /// <param name="facing"></param>
        /// <returns></returns>
        public static FacingTo GetFacingPosition(string facing)
        {
            return FacingPositions[facing];
        }
        /// <summary>
        /// It will return a propper name in order to show it more friendly
        /// </summary>
        /// <param name="facingTo"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Creates map of strategies and FacingTo enum
        /// </summary>
        /// <returns></returns>
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
