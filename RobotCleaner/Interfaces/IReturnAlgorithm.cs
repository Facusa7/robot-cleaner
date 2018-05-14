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
        /// <summary>
        /// After every return call, the state will change in order to execute the next step. 
        /// </summary>
        /// <param name="robot"></param>
        void Return(IRobotCleaner robot);
    }
}
