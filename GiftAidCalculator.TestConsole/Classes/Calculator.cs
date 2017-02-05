using System;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class Calculator : ICalculator
    {
        private readonly ITaxRateService _taxRateService;

        public Calculator(ITaxRateService taxRateService)
        {
            _taxRateService = taxRateService;
        }

        public decimal CalculateGiftAid(decimal donationAmount)
        {
            if (donationAmount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(donationAmount)} cannot be zero or less");
            }
            
            return donationAmount * GiftAidRatio();
        }

        private decimal GiftAidRatio()
        {
            var taxRate = _taxRateService.GetTaxRate();
            return taxRate / (100 - taxRate);
        }
        
    }
}