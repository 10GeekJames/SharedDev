namespace CalculatorProject.Test.Factories.Environments
{
    public class LocalDevEnvironmentUrls : IEnvironmentUrls
    {
        private string _appUrl = "http://google.com";
        public string AppUrl { get { return _appUrl; } private set { } }        
    }
}