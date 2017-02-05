using System;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class Calculator : ICalculator
    {
        public decimal CalculateGiftAid(decimal donationAmount)
        {
            if (donationAmount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(donationAmount)} cannot be zero or less");
            }

            var gaRatio = 17.5m / (100 - 17.5m);
            return donationAmount * gaRatio;
        }
    }
}