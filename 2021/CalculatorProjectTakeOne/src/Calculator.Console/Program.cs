using System;
using System.Diagnostics;

namespace Calculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Gimme 2 numbers");
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Lemme think about that, one moment, press enter");
            Console.ReadLine();

            var calc = new CalculatorProject.Calculator();
            calc.FirstNumber = num1;
            calc.SecondNumber = num2;
            var answer = calc.Add();
            var answer2 = calc.Sub();

            Console.WriteLine($"{num1} + {num2} {answer}");
            Console.WriteLine($"{num1} - {num2} {answer2}");
        }
    }
}
