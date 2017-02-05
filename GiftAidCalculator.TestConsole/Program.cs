using System;
using System.Collections.Generic;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Commands;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }


	    static void Main(string[] args)
	    {
	        try
	        {
                AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

                Control.DisplayMainMenu();

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
	        catch (IndexOutOfRangeException)
	        {

                Console.WriteLine("Opps looks like you forgot to enter the source file and/or loan amount.");
                ExitApplication();
            }
	       
	    }

        private static void ExitApplication()
        {
            Console.WriteLine("Press Any Key to Exit");
            Console.ReadKey(true);
        }

	





    }
}
