using System.Threading;
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



namespace Calculator.UI.Console
{
    public class HostedCalculatorService : IHostedService
    {
        private ICalculatorService _calculatorService;
        public HostedCalculatorService(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Hello there");
            System.Console.WriteLine($"Answer 5 + 4 = {_calculatorService.AddIntegers(5, 4)} ");
            var b = System.Console.ReadLine();
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Help me, I am being shut down, noooo......");
            return Task.CompletedTask;
        }
    }
}