using System;
using GiftAidCalculator.TestConsole.Classes;

namespace GiftAidCalculator.TestConsole
{
    internal class Program
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

        private static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

                Control.DisplayMainMenu();

                ExitApplication();
            }
            catch (IndexOutOfRangeException)
            {
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