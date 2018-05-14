using System.Collections.Generic;

namespace RobotCleaner.Helpers
{
    public class RobotParametersDto
    {
        public string[][] Map { get; set; }
        public Dictionary<string, string> Start { get; set; }
        public string[] Commands { get; set;}
        public int Battery { get; set; }

    }
}
