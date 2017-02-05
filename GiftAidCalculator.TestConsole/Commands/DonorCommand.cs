using System;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.Commands
{
    public class DonorCommand : ICommand
    {
        private readonly ICalculator _calculator;

        public DonorCommand(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public void Execute(object[] args)
        {
            var donation = decimal.Parse(args[0].ToString());
            if (donation <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(donation)} cannot be zero or less.");
            }

            Console.WriteLine(_calculator.CalculateGiftAid(donation));
        }
    }
}