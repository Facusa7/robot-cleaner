using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCleaner.Helpers;

namespace RobotCleaner.Interfaces
{
    public interface IMap
    {
        string[][] CurrentMap { get; set; }
        List<Position> Visited {get; set;}
        List<Position> Cleaned { get; set;}
        bool IsNextCellValid(int x, int y);
    }
}
