using System;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.Commands
{
    public class DonorCommand : ICommand
    {
        private readonly ICalculator _calculator;
        private readonly IEventService _eventService;

        public DonorCommand(ICalculator calculator)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            _calculator = calculator;
        }

        public void Execute(object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var donation = decimal.Parse(args[0].ToString());
            if (donation <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(donation)} cannot be zero or less.");
            }

            var evenType = (EventTypeEnum) Enum.Parse(typeof (EventTypeEnum), args[1].ToString());
            _calculator.CalculateGiftAid(donation, evenType);
        }
    }
}