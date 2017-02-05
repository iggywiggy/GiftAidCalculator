using System;
using System.Net;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Interfaces;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private ICalculator _calculator;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Calculator_IsInstanceOf_ICalculator()
        {
            var calculator = new Calculator();
            Assert.IsInstanceOf(typeof(ICalculator), calculator);
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

        [Test]
        [TestCase(100, ExpectedResult = 25)]
        [TestCase(20, ExpectedResult = 5)]
        [TestCase(50, ExpectedResult = 12.5)]
        [TestCase(250, ExpectedResult = 62.50)]
        [TestCase(5, ExpectedResult = 1.25)]
        [TestCase(500, ExpectedResult = 125.00)]
        [TestCase(55.50, ExpectedResult = 13.8750)]
        [TestCase(23.45, ExpectedResult = 5.8625)]
        public decimal CalculateGiftAid(decimal donationAmount)
        {
            return _calculator.CalculateGiftAid(donationAmount);
        }


    }
}
