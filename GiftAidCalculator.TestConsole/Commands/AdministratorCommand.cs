using System;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.Commands
{
    public class AdministratorCommand : ICommand
    {
        private readonly ITaxRateService _taxRateService;

        public AdministratorCommand(ITaxRateService taxRateService)
        {
            if (taxRateService == null)
            {
                throw new ArgumentNullException(nameof(taxRateService));
            }
            _taxRateService = taxRateService;
        }

        public void Execute(object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var taxRate = decimal.Parse(args[0].ToString());
            if (taxRate <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(taxRate)} cannot be zero or less.");
            }

            _taxRateService.SetNewTaxRate(taxRate);
        }
    }
}