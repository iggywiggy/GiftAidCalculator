using System;
using System.Linq;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class TaxRateService : ITaxRateService
    {
        private readonly IRepository<TaxRate> _repository;

        public TaxRateService(IRepository<TaxRate> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            _repository = repository;
        }

        public void SetNewTaxRate(decimal newTaxRate)
        {
            if (newTaxRate <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(newTaxRate)} cannot be zero or less.");
            }

            SetLatestTaxRateToDeleted();

            CreateNewTaxRate(newTaxRate);
        }

        public decimal GetTaxRate()
        {
            var taxRate = _repository.Select(rate => rate.IsDeleted == false).FirstOrDefault();
            return taxRate?.Rate ?? 0;
        }

        private void SetLatestTaxRateToDeleted()
        {
            var latestTaxRate = _repository.Select(rate => rate.IsDeleted == false).FirstOrDefault();

            if (latestTaxRate == null)
                return;

            latestTaxRate.IsDeleted = true;
            latestTaxRate.DateDeleted = DateTime.Now;

            _repository.Update(latestTaxRate);
        }

        private void CreateNewTaxRate(decimal newTaxRate)
        {
            var taxRate = new TaxRate
            {
                IsDeleted = false,
                DateInserted = DateTime.Now,
                Rate = newTaxRate
            };

            _repository.Insert(taxRate);
        }
    }
}