using System.Collections.Generic;
using System.Linq;
using RobotCleaner.Helpers;
using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations
{
    public class Map : IMap
    {
        public Map(string[][] parametersMap, CurrentPosition position)
        {
            this.CurrentMap = parametersMap;
            this.LengthXDimension = parametersMap.GetLength(0);
            this.LengthYDimension = parametersMap.Max(x => x.GetLength(0));
            this.Visited = new List<Position>() {position};
            this.Cleaned = new List<Position>();
        }

        private int LengthXDimension { get; set;}
        private int LengthYDimension { get; set;}
        public string[][] CurrentMap { get; set; }
        public List<Position> Visited { get; set; }
        public List<Position> Cleaned { get; set; }

        public bool IsNextCellValid(int x, int y)
        {
            var isXCellValid = x != LengthXDimension && x >= 0;
            var isYCellValid = y != LengthYDimension && y >= 0;

            return isXCellValid && isYCellValid && CurrentMap[y][x] != "null" && CurrentMap[y][x] != "C";
        }
    }
}
