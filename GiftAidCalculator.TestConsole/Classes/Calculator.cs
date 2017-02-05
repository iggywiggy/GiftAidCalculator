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
            
            return donationAmount * GiftAidRation();
        }

        private decimal GiftAidRation()
        {
            return 20m/(100 - 20m);
        }
    }
}