using System;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class TaxRateRepositoryTests
    {
        private IRepository<TaxRate> _repository;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _repository = new TaxRateRepository();
        }

        [Test]
        public void Insert_ParamEntity_EntityIsInserted()
        {
            var entity = new TaxRate
            {
                DateInserted = DateTime.Now,
                Rate = 20.5m
            };

            var result = _repository.Insert(entity);

            CollectionAssert.Contains(_repository.Select(rate => true), result);
        }

        [Test]
        public void Insert_ParamEntity_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _repository.Insert(null));
        }


        [Test]
        public void Select_ParamPredicate_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _repository.Select(null));
        }

        [Test]
        public void Update_ParamEntity_EntityDoesntExist_Inserted()
        {
            var entity = new TaxRate
            {
                DateInserted = DateTime.Now,
                Rate = 20.5m
            };

            var result = _repository.Update(entity);

            CollectionAssert.Contains(_repository.Select(rate => rate.Rate == entity.Rate), result);
        }

        [Test]
        public void Update_ParamEntity_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _repository.Update(null));
        }

        [Test]
        public void Update_ParamEntity_TaxRateUpdated()
        {
            var entity = new TaxRate
            {
                DateInserted = DateTime.Now,
                Rate = 20.5m
            };

            var result = _repository.Update(entity);

            Assert.AreSame(entity, result);
        }
    }
}