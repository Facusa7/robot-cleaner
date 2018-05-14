using System;
using System.Collections.Generic;

namespace RobotCleaner.Helpers
{
    [Serializable]
    public class ResponseDto
    {
        public ResponseDto(List<Position> visited, List<Position> cleaned, Position finalState, int battery)
        {
            Visited = visited;
            Cleaned = cleaned;
            Final = finalState;
            Battery = battery;
        }
        public List<Position> Visited {get; set;}
        public List<Position> Cleaned {get; set;}
        public Position Final {get; set;}
        public int Battery {get; set;}
    }
}
