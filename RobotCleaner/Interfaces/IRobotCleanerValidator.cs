using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCleaner.Helpers;

namespace RobotCleaner.Interfaces
{
    public interface IRobotCleanerValidator
    {
        /// <summary>
        /// Validates the robot parameters
        /// </summary>
        /// <param name="robotParameters"></param>
        /// <returns></returns>
        bool IsRobotValid(RobotParametersDto robotParameters);
        /// <summary>
        /// Validates if the map given has a correct amount of cells
        /// </summary>
        /// <param name="robotParameters"></param>
        /// <returns></returns>
        bool IsMapValid(RobotParametersDto robotParameters);
    }
}
