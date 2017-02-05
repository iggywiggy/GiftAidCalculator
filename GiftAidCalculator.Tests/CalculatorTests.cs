using System;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private ICalculator _calculator;
        private Mock<ITaxRateService> _taxRateService;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _taxRateService = new Mock<ITaxRateService>();
            _calculator = new Calculator(_taxRateService.Object);
        }

        [Test]
        public void Calculator_IsInstanceOf_ICalculator()
        {
            Assert.IsInstanceOf(typeof(ICalculator), _calculator);
        }

        [Test]
        public void CalculateGiftAid_ParamDonationAmount_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _calculator.CalculateGiftAid(0));
        }

        [Test]
        public void CalculateGiftAid_ParamDonationAmount_NegativeFive_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _calculator.CalculateGiftAid(-5));
        }

        [Test]
        public void CalculateGiftAid_ReturnType_Decimal()
        {
            var result = _calculator.CalculateGiftAid(20m);
            Assert.IsInstanceOf(typeof(decimal), result);
        }

        private void SetUpTaxServiceMock(decimal taxRate)
        {
            _taxRateService.Setup(r => r.GetTaxRate()).Returns(taxRate);
        }

        [Test]
        [TestCase(100,20, ExpectedResult = 25)]
        [TestCase(20, 20, ExpectedResult = 5)]
        [TestCase(50, 20, ExpectedResult = 12.5)]
        [TestCase(250,20, ExpectedResult = 62.50)]
        [TestCase(5, 20, ExpectedResult = 1.25)]
        [TestCase(500, 20, ExpectedResult = 125.00)]
        [TestCase(55.50, 20, ExpectedResult = 13.8750)]
        [TestCase(23.45, 20, ExpectedResult = 5.8625)]
        public decimal CalculateGiftAid(decimal donationAmount, decimal taxRate)
        {
            SetUpTaxServiceMock(taxRate);

            return _calculator.CalculateGiftAid(donationAmount);
        }


    }
}
