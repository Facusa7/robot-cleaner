using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCleaner.Helpers;
using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations
{
    /// <summary>
    /// Validates basic parameters given in order to pass correct data to the constructor. 
    /// </summary>
    public class RobotCleanerValidator : IRobotCleanerValidator
    {
        public bool IsRobotValid(RobotParametersDto robotParameters)
        {
            var axisValid = false;
            var orientationValid = false;
            var batteryValid = false;
            try
            {
               axisValid = ValidateAxis(robotParameters.Start);
               orientationValid = ValidateOrientation(robotParameters.Start);
               batteryValid = ValidateBatteryValue(robotParameters);
            }
            catch (Exception)
            {
                return false;
            }

            return axisValid && orientationValid && batteryValid;
        }

        private bool ValidateBatteryValue(RobotParametersDto robotParameters)
        {
            return robotParameters.Battery > 0;
        }

        public bool IsMapValid(RobotParametersDto robotParameters)
        {
            return robotParameters.Map.Length > 0;
        }

        private bool ValidateOrientation(Dictionary<string, string> start)
        {
            return start["facing"] == "E" || start["facing"] == "S" ||
                   start["facing"] == "W" || start["facing"] == "N";
        }

        private static bool ValidateAxis(Dictionary<string, string> robotParametersStart)
        {
            var x = int.Parse(robotParametersStart["X"]);
            var y = int.Parse(robotParametersStart["Y"]);

            return x >= 0 && y >= 0;
        }

        
    }
}
