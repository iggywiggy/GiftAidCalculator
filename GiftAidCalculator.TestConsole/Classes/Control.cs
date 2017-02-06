using System;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class Control
    {
        private static readonly ICommandFactory CommandFactory = DiContainer.Instance.ResolveCommandFactory();

        public static void DisplayMainMenu()
        {
            Console.WriteLine("Who would you like to log in as?");
            Console.WriteLine("Press 0 to exit.");

            var displayMenu = false;

            do
            {
                foreach (var aidRole in Enum.GetValues(typeof (RoleEnum)))
                {
                    Console.WriteLine($"To login as {aidRole} press {(int) aidRole}");
                    Console.WriteLine();
                }

                var role = int.Parse(Console.ReadLine());

                switch (role)
                {
                    case 1:
                        DisplayDonorMenu();
                        displayMenu = true;
                        break;
                    case 2:
                        DisplayAdministratorMenu();
                        displayMenu = true;
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            } while (!displayMenu);
        }

        private static void DisplayDonorMenu()
        {
            foreach (var evType in Enum.GetValues(typeof (EventTypeEnum)))
            {
                Console.WriteLine($"To select {evType} press {(int) evType}");
                Console.WriteLine();
            }

            var sport = (EventTypeEnum) int.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter a Donation Amount.");
            Console.WriteLine();

            var donation = int.Parse(Console.ReadLine());
            if (donation == 0)
            {
                while (!int.TryParse(Console.ReadLine(), out donation))
                {
                    Console.WriteLine("Zero is not a donation");
                }
            }

            CommandFactory.Resolve(RoleEnum.Donor, new object[] {donation, sport});

            GetMenuChoice();
        }

        private static void GetMenuChoice()
        {
            Console.WriteLine("Press 0 to return to Main Menu or X to Exit.");
            var menuChoice = Console.ReadLine();

            if (menuChoice == "0")
            {
                DisplayMainMenu();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static void DisplayAdministratorMenu()
        {
            Console.WriteLine("Please Enter a New Tax Rate:");
            Console.WriteLine();

            var taxRate = decimal.Parse(Console.ReadLine());

            if (taxRate == 0)
            {
                while (!decimal.TryParse(Console.ReadLine(), out taxRate))
                {
                    Console.WriteLine("Zero is not a taxRate");
                }
            }

            CommandFactory.Resolve(RoleEnum.Administrator, new object[] {taxRate});

            GetMenuChoice();
        }
    }
}