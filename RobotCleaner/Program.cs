using Newtonsoft.Json;
using RobotCleaner.Exceptions;
using RobotCleaner.Helpers;
using RobotCleaner.Implementations;
using RobotCleaner.Interfaces;
using System;
using System.Configuration;
using System.IO;
using RobotCleaner.Factories;

namespace RobotCleaner
{
    class Program
    {
        private static readonly string ResultFileName = ConfigurationManager.AppSettings["ResultFileName"];

        public static void Main(string[] args)
        {
            string response;
            var jsonParameters = LoadRobotParameters(args[0]);
            var robotCreationResult = RobotFactory.GetRobot(jsonParameters);
            
            if (robotCreationResult.Item1.Equals(RobotConstructionStatus.Error))
            {
                response = "Parameters are not valid";
            }
            else
            {

                try
                {
                    response = JsonConvert.SerializeObject(robotCreationResult.Item2.Clean());
                }
                catch (RobotCleanerException e)
                {
                    Console.WriteLine(e.Message);
                    response = e.Response;
                }
            }
            
            WriteResponse(response);
        }
        /// <summary>
        /// It writes the response in the console line and the result file
        /// </summary>
        /// <param name="response"></param>
        private static void WriteResponse(string response)
        {
            Console.WriteLine(response);
            File.WriteAllText(ResultFileName, response);
        }
        /// <summary>
        /// Deserializes the json string parameters into an object.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static RobotParametersDto LoadRobotParameters(string fileName)
        {
            using (var r = new StreamReader(fileName))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<RobotParametersDto>(json);
            }
        }
    }
}
