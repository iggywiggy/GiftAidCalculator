using System;
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
        public void CalculatorFigtAid_ParamDonationAmount_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _calculator.CalculateGiftAid(0));
        }
    }
}
