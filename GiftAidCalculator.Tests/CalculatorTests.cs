using System;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Enums;
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
        private Mock<IEventService> _eventService;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _taxRateService = new Mock<ITaxRateService>();
            _eventService = new Mock<IEventService>();
            _calculator = new Calculator(_taxRateService.Object, _eventService.Object);
        }

        [Test]
        public void Constructor_ParamTaxRateService_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new Calculator(null, _eventService.Object));
        }

        [Test]
        public void Constructor_ParamEventService_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new Calculator(_taxRateService.Object, null));
        }

        private void SetUpTaxServiceMock(decimal taxRate)
        {
            _taxRateService.Setup(r => r.GetTaxRate()).Returns(taxRate);
            _eventService.Setup(s => s.GetEventSupplement(It.Is<EventTypeEnum>(e => e == EventTypeEnum.Other)))
                .Returns(0);
            _eventService.Setup(s => s.GetEventSupplement(It.Is<EventTypeEnum>(e => e == EventTypeEnum.Running)))
                .Returns(5);
            _eventService.Setup(s => s.GetEventSupplement(It.Is<EventTypeEnum>(e => e == EventTypeEnum.Swimming)))
                .Returns(3);
        }

        [Test]
        [TestCase(100, 20, EventTypeEnum.Other, ExpectedResult = 20)]
        [TestCase(20, 20, EventTypeEnum.Other, ExpectedResult = 4)]
        [TestCase(50, 20, EventTypeEnum.Running, ExpectedResult = 10.5)]
        [TestCase(250, 20, EventTypeEnum.Running, ExpectedResult = 52.5)]
        [TestCase(5, 20, EventTypeEnum.Swimming, ExpectedResult = 1.03)]
        [TestCase(500, 20, EventTypeEnum.Other, ExpectedResult = 100)]
        [TestCase(55.50, 20, EventTypeEnum.Swimming, ExpectedResult = 11.43)]
        [TestCase(23.45, 20, EventTypeEnum.Running, ExpectedResult = 4.92)]
        public decimal CalculateGiftAid(decimal donationAmount, decimal taxRate, EventTypeEnum eventType)
        {
            SetUpTaxServiceMock(taxRate);

            return _calculator.CalculateGiftAid(donationAmount, eventType);
        }

        [Test]
        public void CalculateGiftAid_ParamDonationAmount_NegativeFive_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException),
                () => _calculator.CalculateGiftAid(-5, EventTypeEnum.Other));
        }

        [Test]
        public void CalculateGiftAid_ParamDonationAmount_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException),
                () => _calculator.CalculateGiftAid(0, EventTypeEnum.Other));
        }

        [Test]
        public void CalculateGiftAid_ReturnType_Decimal()
        {
            var result = _calculator.CalculateGiftAid(20m, EventTypeEnum.Other);
            Assert.IsInstanceOf(typeof (decimal), result);
        }

        [Test]
        public void Calculator_IsInstanceOf_ICalculator()
        {
            Assert.IsInstanceOf(typeof (ICalculator), _calculator);
        }
    }
}