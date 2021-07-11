using System;
using System.Collections.Generic;

namespace CalculatorProject.UnitTest.Factories.Environments
{
    public class EnvironmentUrlFactory : IEnvironmentUrlFactory
    {
        private string _currentEnvironment = "localdev";
        private IEnvironmentUrls _environmentUrls;
        public EnvironmentUrlFactory() : base()
        {

        }
        public EnvironmentUrlFactory(string defaultBrowser)
        {
            this.SetDriver(defaultBrowser);
        }
        public void SetDriver(string driverName)
        {
            driverName = driverName.ToLower();
            if (!(new List<string> { "localdev", "dev", "uat", "prod" }.Contains(driverName)))
            {
                throw new Exception("Invalid attempt to set to unapproved driver");
            }
            this._currentEnvironment = driverName;
        }
        public IEnvironmentUrls EnvironmentUrls
        {
            get
            {
                switch (this._currentEnvironment)
                {
                    case "localdev":
                        if (this._environmentUrls == null || !(this._environmentUrls is LocalDevEnvironmentUrls))
                        {
                            this._environmentUrls = new LocalDevEnvironmentUrls();
                        }
                        break;
                    default:
                        break;
                }
                return _environmentUrls;
            }
            private set { }
        }

    }
}