using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCleaner.Helpers;

namespace RobotCleaner.Interfaces
{
    public interface IRobotCleaner
    {
        /// <summary>
        /// Add a value to the cleaned list. 
        /// </summary>
        void CleanCell();

        /// <summary>
        /// Change the value of a cell to clean. 
        /// </summary>
        ResponseDto Clean();
        /// <summary>
        /// Activates the return algorithm
        /// </summary>
        void Return();

        /// <summary>
        /// Return true if there's an obstacle in front/back of the robot.
        /// </summary>
        /// <returns>bool</returns>
        bool IsObstacle(int x, int y);

        /// <summary>
        /// Turn Right (TR). Instructs the robot to turn 90 degrees to the right. Consumes 1 unit of battery.
        /// </summary>
        void TurnRight();

        /// <summary>
        ///  Instructs the robot to turn 90 degrees to the left. Consumes 1 unit of battery. 
        /// </summary>
        void TurnLeft();

        /// <summary>
        /// Walk 1 cell to the front.
        /// </summary>
        void Advance();

        /// <summary>
        /// Instructs the robot to move back one cell without changing direction. Consumes 3 units of battery. 
        /// </summary>
        void Back();

        /// <summary>
        /// Total movements available. TurnRight, TurnLeft and Walk are movements. Is the amount of battery that we spent.
        /// </summary>
        int Battery { get; }

        /// <summary>
        /// X coordinate 
        /// </summary>
        int X { get; set;}

        /// <summary>
        /// Y coordinate 0 North Increase going to the south
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// 0=W,1=S,2=E,3=N
        /// </summary>
        FacingTo FaceTo { get; set;}
        IMap Map {get;}
    }
}
