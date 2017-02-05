using System;
using System.Collections.Generic;
using System.Linq;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class TaxRateServiceTests
    {
        private ITaxRateService _taxRateService;
        private IList<TaxRate> _taxRates;

        [TestFixtureSetUp]
        public void TestFixture()
        {
            var repositoryMock = new Mock<IRepository<TaxRate>>();
            _taxRateService = new TaxRateService(repositoryMock.Object);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _taxRates = null;
        }

        [Test]
        public void TaxRateService_Construtor_ParamRepositoryNull_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new TaxRateService(null));
        }

        [Test]
        public void TaxRateService_IsInstanceOf_ITaxRateService()
        {
            var repositoryMock = new Mock<IRepository<TaxRate>>();
            Assert.IsInstanceOf(typeof (ITaxRateService), new TaxRateService(repositoryMock.Object));
        }

        [Test]
        public void SetNewTaxRate_ParamTaxRate_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _taxRateService.SetNewTaxRate(0));
        }

        [Test]
        public void SetNewTaxRate_ParamTaxRate_NegativeTen_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _taxRateService.SetNewTaxRate(-10));
        }

        [Test]
        [TestCase(20, ExpectedResult = 20)]
        [TestCase(17.5, ExpectedResult = 17.5)]
        [TestCase(25, ExpectedResult = 25)]
        [TestCase(13.54, ExpectedResult = 13.54)]
        public decimal SetNewTaxRate_LatestTaxRate(decimal taxRate)
        {
            _taxRates = new List<TaxRate>();

            _taxRateService = new TaxRateService(SetupRepoMock(taxRate).Object);

            var rate = _taxRateService.GetTaxRate();

            return rate;
        }

        [Test]
        public void CreateNewTaxRate_ParamNewTaxRate_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _taxRateService.SetNewTaxRate(0));
        }

        [Test]
        public void CreateNewTaxRate_ParamNewTaxRate_NegativeOne_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _taxRateService.SetNewTaxRate(-1));
        }

        [Test]
        [TestCase(20, ExpectedResult = 20)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(25, ExpectedResult = 25)]
        [TestCase(57.5, ExpectedResult = 57.5)]
        [TestCase(13.3, ExpectedResult = 13.3)]
        public decimal CreateNewTaxRate_NewTaxRateSet(decimal taxRate)
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

            _taxRateService = new TaxRateService(SetupRepoMock(taxRate).Object);

            _taxRateService.SetNewTaxRate(taxRate);

            return _taxRateService.GetTaxRate();
        }

        [Test]
        public void SetLatestTaxRate_NoTaxRateSet_CountTaxRateOne()
        {
            _taxRates = new List<TaxRate>();

            _taxRateService = new TaxRateService(SetupRepoMock(20).Object);

            _taxRateService.SetNewTaxRate(20);

            Assert.IsTrue(_taxRates.Count == 1);
        }

        private IMock<IRepository<TaxRate>> SetupRepoMock(decimal taxRate)
        {
            var newTaxRate = new TaxRate
            {
                DateInserted = DateTime.Now,
                Rate = taxRate
            };

            var repositoryMock = new Mock<IRepository<TaxRate>>();
            repositoryMock.Setup(r => r.Update(_taxRates.FirstOrDefault()));
            repositoryMock.Setup(
                r => r.Insert(newTaxRate)).Returns(newTaxRate);

            repositoryMock.Setup(r => r.Select(rate => rate.IsDeleted == false))
                .Returns(() => _taxRates.Where(rate1 => rate1.IsDeleted == false))
                .Callback(() => _taxRates.Add(newTaxRate));

            return repositoryMock;
        }

    }
}
