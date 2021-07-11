using StructureMap;
using StructureMap.Graph;

using System.Globalization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Calculator.Service.Interfaces;
using Calculator.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Calculator.UI.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var container = Container.For<DependencyResolver>();
                var provider = container.GetInstance<ICalculatorServiceProvider>();
                var app = container.GetInstance<ICalculatorService>();
                while (1 == 1)
                {
                    System.Console.WriteLine("Please give me your first value :");
                    var input1 = System.Console.ReadLine();

                    System.Console.WriteLine("Thank you, now your second :");
                    var input2 = System.Console.ReadLine();

                    int input1AsNumber = 0;
                    int input2AsNumber = 0;

                    var areNumbers = (int.TryParse(input1, out input1AsNumber) && int.TryParse(input2, out input2AsNumber));

                    if (areNumbers)
                    {
                        System.Console.WriteLine("Thank you, I see two numbers, going to add them up for you, please hold :");
                        System.Console.WriteLine(app.AddIntegers(input1AsNumber, input2AsNumber));
                    }
                    else
                    {
                        System.Console.WriteLine("Thank you, I see one of these is not a number, I am going to concatenate them for you, please hold :");
                        System.Console.WriteLine(app.AddAsStrings(input1, input2));
                    }

                    System.Console.WriteLine("If you were happy we can go again, or you can ctrl-c to exit");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }
            }
            catch (Exception ex)
            {
                // NLog: catch any exception and log it.
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }
        public static T GetFirst<T>()
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblies = assembly.GetReferencedAssemblies();
            var found = false;

            foreach (var assemblyName in assemblies)
            {
                assembly = Assembly.Load(assemblyName);

                foreach (var ti in assembly.DefinedTypes)
                {
                    if (ti.ImplementedInterfaces.Contains(typeof(T)))
                    {
                        return (T)assembly.CreateInstance(ti.FullName);
                    }
                }
            }
            return default(T);
        }
    }
}