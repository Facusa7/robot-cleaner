using System.Collections.Generic;
using RobotCleaner.Helpers;
using RobotCleaner.Implementations.Commands;
using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations
{
    public class CleaningAlgorithm : ICleaningAlgorithm
    {
        private readonly string[] _commands;
        private readonly Dictionary<string, ICommand> _com = new Dictionary<string, ICommand>();
        public CleaningAlgorithm(string[] commands)
        {
            this._commands = commands;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            _com.Add("TL", new TurnLeftCommand());
            _com.Add("TR", new TurnRightCommand());
            _com.Add("A", new AdvanceCommand());
            _com.Add("C", new CleanCommand());
            _com.Add("B", new BackCommand());
        }
        /// <summary>
        /// Calls the respective command based on the parameter given in the constructor. 
        /// When it's done, an final status will be returned as result of the operation.
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        public ResponseDto Clean(IRobotCleaner robot)
        {
            foreach (var command in _commands)
            {
                _com[command].Execute(robot);
            }

            var position = new FinalState(robot.X, robot.Y, robot.FaceTo);
            var response = new ResponseDto(robot.Map.Visited, robot.Map.Cleaned, position, robot.Battery);
            
            return response;
        }
    }
}
