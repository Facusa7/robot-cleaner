using System;
using System.Collections.Generic;
using RobotCleaner.Helpers;
using RobotCleaner.Implementations;
using RobotCleaner.Implementations.Directions;
using RobotCleaner.Implementations.Steps;
using RobotCleaner.Interfaces;
using FacingTo = RobotCleaner.Helpers.FacingTo;

namespace RobotCleaner.Factories
{
    /// <summary>
    /// Class that creates the robot and injects its dependencies.
    /// </summary>
    public class RobotFactory
    {
        public static Tuple<RobotConstructionStatus, IRobotCleaner> GetRobot(RobotParametersDto parameters)
        {
            Orientations.InitializeOrientations();
            //Create a validator in order to do basic verifications
            IRobotCleanerValidator validator = new RobotCleanerValidator();
            var result = Tuple.Create<RobotConstructionStatus, IRobotCleaner>(RobotConstructionStatus.Error, null);
            //if the parameters given are not valid, it will return null with the enum value in Error.
            if (!validator.IsRobotValid(parameters) || !validator.IsMapValid(parameters)) return result;

            //Here the dependencies are created and injected in the robot object. 
            var currentPosition = new CurrentPosition(GetAxis(parameters.Start["X"]), GetAxis(parameters.Start["Y"]));
            IMap map = new Map(parameters.Map, currentPosition);
            IReturnAlgorithm returnAlgorithm = new ReturnAlgorithm(new FirstStep());
            ICleaningAlgorithm cleaningAlgorithm = new CleaningAlgorithm(parameters.Commands);
            var movingStrategies = Orientations.GetMovingStrategies();

            result = Tuple.Create<RobotConstructionStatus, IRobotCleaner>(RobotConstructionStatus.Success,
                new Implementations.RobotCleaner(currentPosition.X, 
                                                 currentPosition.Y, 
                                                 Orientations.GetFacingPosition(parameters.Start["facing"]), 
                                                 parameters.Battery, map, returnAlgorithm, movingStrategies, cleaningAlgorithm));


            return result;
        }

        private static int GetAxis(string axis)
        {
            return int.Parse(axis);
        }

    }

}
