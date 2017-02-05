using System;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
	    private static readonly ICalculator Calculator;

	    static Program()
	    {
	        Calculator = new Calculator();
	    }

	    static void Main(string[] args)
	    {
	        // Calc Gift Aid Based on Previous
	        Console.WriteLine("Please Enter donation amount:");
	        Console.WriteLine(Calculator.CalculateGiftAid(decimal.Parse(Console.ReadLine())));
	        Console.WriteLine("Press any key to exit.");
	        Console.ReadKey(true);
	    }

	}
}
