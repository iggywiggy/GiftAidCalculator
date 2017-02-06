using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class TaxRateRepository : IRepository<TaxRate>
    {
        private readonly IList<TaxRate> _taxRates;

        public TaxRateRepository()
        {
            _taxRates = new List<TaxRate>
            {
                new TaxRate
                {
                    IsDeleted = false,
                    DateInserted = DateTime.Now,
                    Rate = 17.5m
                }
            };
        }

        public TaxRate Update(TaxRate entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var findRate = _taxRates.FirstOrDefault(r => r.Rate == entity.Rate);

            if (findRate == null)
            {
                _taxRates.Add(entity);
                return entity;
            }

            _taxRates.Remove(findRate);
            _taxRates.Add(entity);

            return entity;
        }

        public IEnumerable<TaxRate> Select(Expression<Func<TaxRate, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return _taxRates.Where(predicate.Compile());
        }

        public TaxRate Insert(TaxRate entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _taxRates.Add(entity);

            return entity;
        }
    }
}