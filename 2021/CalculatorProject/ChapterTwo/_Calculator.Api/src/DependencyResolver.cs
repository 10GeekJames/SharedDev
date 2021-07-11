using System;
using StructureMap;
using StructureMap.Graph;
using Calculator.Service.Interfaces;
using Calculator.Service;

namespace Calculator.Api
{
    public class DependencyResolver : Registry
    {
        public DependencyResolver()
        {
            Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            Scan(x =>
                {
                    x.Description = "Grab Calculator Service";
                    x.Assembly("Calculator.Service");
                    x.AssemblyContainingType<ICalculatorService>();
                    x.AddAllTypesOf<ICalculatorService>();
                });
            Scan(x =>
                {
                    x.Description = "Find Active Calculator Strategy/Provider";
                    x.AssembliesFromApplicationBaseDirectory();
                    x.AddAllTypesOf<ICalculatorServiceProvider>();
                });
        }
    }
}
