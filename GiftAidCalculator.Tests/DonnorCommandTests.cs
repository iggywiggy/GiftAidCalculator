using System;
using GiftAidCalculator.TestConsole.Commands;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class DonnorCommandTests
    {
        private DonorCommand _donorCommand;
        private Mock<ICalculator> _calculator;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _calculator = new Mock<ICalculator>();
            _donorCommand = new DonorCommand(_calculator.Object);
        }

        [Test]
        public void Constructor_ParamCalculator_Null_ThrowsArgumentNullExcception()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new DonorCommand(null));
        }

        [Test]
        public void Execute_ParamArgs_Null_ThrowsArgumentNullExcception()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _donorCommand.Execute(null));
        }

        [Test]
        public void Execute_ParamArgs_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _donorCommand.Execute(new object[] {0}));
        }

        [Test]
        public void Execute_VerifyTaxService_Called()
        {
            _calculator.Setup(c => c.CalculateGiftAid(100, EventTypeEnum.Other));
            _donorCommand.Execute(new object[] {100, EventTypeEnum.Other});
            _calculator.Verify(mock => mock.CalculateGiftAid(100, EventTypeEnum.Other));
        }
    }
}