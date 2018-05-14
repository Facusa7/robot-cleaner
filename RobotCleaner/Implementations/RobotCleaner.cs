using RobotCleaner.Helpers;
using RobotCleaner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using RobotCleaner.Exceptions;
using Newtonsoft.Json;
using RobotCleaner.Implementations.Directions;
using RobotCleaner.Implementations.Steps;

namespace RobotCleaner.Implementations
{
    public class RobotCleaner : IRobotCleaner
    {
        public RobotCleaner(int x, int y, FacingTo faceTo, int battery, IMap map, IReturnAlgorithm returnAlgorithm, Dictionary<FacingTo, IMovingStrategy> movingStrategies, ICleaningAlgorithm cleaningAlgorithm)
        {
            X = x;
            Y = y;
            FaceTo = faceTo;
            Battery = battery;
            Map = map;
            ReturnAlgorithm = returnAlgorithm;
            CleaningAlgorithm = cleaningAlgorithm;
            _movingStrategies = movingStrategies;
        }

        private readonly Dictionary<FacingTo, IMovingStrategy> _movingStrategies;
        private IReturnAlgorithm ReturnAlgorithm { get; set; }
        private ICleaningAlgorithm CleaningAlgorithm { get; set; }
        private void ValidateMove(int cost)
        {
            var batteryState = Battery - cost;
            
            if (batteryState < 0)
            {
                var finalState = new FinalState(X, Y, FaceTo);
                var response = new ResponseDto(Map.Visited, Map.Cleaned, finalState, Battery);
                throw new OutOfBatteryException("Battery died", JsonConvert.SerializeObject(response));
            }
        }
       
        public IMap Map { get; set; }
        public int Battery { get; set;} 

        public int X { get; set;} 

        public int Y { get; set;} 

        public FacingTo FaceTo { get; set;}

        public bool IsObstacle(int x, int y)
        {
            return !Map.IsNextCellValid(x, y);
        }
        public void Back()
        {
            ValidateMove(3);
            var facingTo = (FacingTo) Enum.Parse(typeof(FacingTo), FaceTo.ToString());
            _movingStrategies[facingTo].MoveBackwards(this);
            Battery -= 3;
        }

        public void TurnLeft()
        {
            ValidateMove(1);
            FaceTo = FaceTo  == FacingTo.North ? FacingTo.West : FaceTo + 1;
            Battery -= 1;
        }

        public void TurnRight()
        {
            ValidateMove(1);
            FaceTo = FaceTo == FacingTo.West ? FacingTo.North : FaceTo - 1;
            Battery -= 1;
        }

        public void Advance()
        {
            ValidateMove(2);
            var facingTo = (FacingTo) Enum.Parse(typeof(FacingTo), FaceTo.ToString());
            _movingStrategies[facingTo].MoveForward(this);

            var position = new CurrentPosition(X, Y);
            if (!Map.Visited.Any(item=> item.X == position.X && item.Y == position.Y))
            {
                Map.Visited.Add(position);
            }
                
            Battery -= 2;

        }

        public void CleanCell()
        {
            ValidateMove(5);
            var position = new CurrentPosition(X, Y);
            if (!Map.Cleaned.Any(item=> item.X == position.X && item.Y == position.Y))
            {
                Map.Cleaned.Add(position);
            }
                 
            Battery -= 5;
        }

        public ResponseDto Clean()
        {
            return CleaningAlgorithm.Clean(this);
        }

        public void Return()
        {
            ReturnAlgorithm.Return(this);
        }

    }

}
