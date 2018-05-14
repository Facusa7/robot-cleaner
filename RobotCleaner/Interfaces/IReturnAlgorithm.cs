using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Interfaces
{
    public interface IReturnAlgorithm
    {
        /// <summary>
        /// Indicates which step of the algorithm is beign executed.
        /// </summary>
        IStepBase Step {get; set;}
        void Return(IRobotCleaner robot);
    }
}
