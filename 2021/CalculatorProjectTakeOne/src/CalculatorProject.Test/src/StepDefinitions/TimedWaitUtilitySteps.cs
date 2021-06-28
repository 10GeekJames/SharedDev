using System.Threading;
using TechTalk.SpecFlow;

namespace CalculatorProject.Test.StepDefinitions
{
    [Binding]
    public class TimedWaitUtilitySteps : Steps
    {

        [Given, When, Then(@"I wait a moment")]
        public void IWaitAMoment()
        {
            Thread.Sleep(1000);
        }

        [Given, When, Then(@"I wait half a moment")]
        public void IWaitHalfAMoment()
        {
            Thread.Sleep(500);
        }
        
        [Given, When, Then(@"I wait forever")]
        public void IWaitForever()
        {
            Thread.Sleep(15000);
        }
        
    }
}

