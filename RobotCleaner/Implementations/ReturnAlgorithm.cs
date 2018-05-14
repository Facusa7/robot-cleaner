using RobotCleaner.Interfaces;

namespace RobotCleaner.Implementations
{
    public class ReturnAlgorithm : IReturnAlgorithm
    {
        public IStepBase Step { get; set;}
        
        public ReturnAlgorithm(IStepBase stateBase) 
        {
            this.Step = stateBase;
        }
        
        public void Return(IRobotCleaner robot)
        {
            Step.Change(this, robot);
        }
    }
}
