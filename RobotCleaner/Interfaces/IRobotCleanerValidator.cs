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
        bool IsRobotValid(RobotParametersDto robotParameters);

        bool IsMapValid(RobotParametersDto robotParameters);
    }
}
