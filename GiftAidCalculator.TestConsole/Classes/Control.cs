using System;
using System.Diagnostics;
using GiftAidCalculator.TestConsole.Enums;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class Control
    {
        public static RoleEnum DisplayMainMenu()
        {
            var commandFactory = DiContainer.Instance.ResolveCommandFactory();
            Console.WriteLine("Who would you like to log in as?");

            foreach (var aidRole in Enum.GetValues(typeof(RoleEnum)))
            {
                Console.WriteLine($"To login as {aidRole} press {(int)aidRole}");
            }

            int inputNumber;

            while (!int.TryParse(Console.ReadLine(), out inputNumber) && Enum.IsDefined(typeof(RoleEnum),inputNumber))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
            }

            var role = (RoleEnum) inputNumber;

            Console.WriteLine($"You have selected to login as {role}");

            var value = GetEnteredValue(role);

            commandFactory.Resolve(role, new object[] {value});
            

            return role;
        }

        public static decimal GetEnteredValue(RoleEnum role)
        {
            decimal donationAmount = 0;
            DisplayPrompt(role);

            while (!decimal.TryParse(Console.ReadLine(), out donationAmount) && donationAmount > 0)
            {
                DisplayPrompt(role);
            }

            return donationAmount;
        }

        public static void DisplayPrompt(RoleEnum role)
        {
            switch (role)
            {
                   case RoleEnum.Donor:
                    Console.WriteLine("Please Enter donation amount:");
                    break;
                case RoleEnum.Administrator:
                    Console.WriteLine("Please Enter a New Tax Rate:");
                    break;
            }
        }
    }
}