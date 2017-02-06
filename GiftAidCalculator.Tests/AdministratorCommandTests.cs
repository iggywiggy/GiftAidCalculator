using System;
using GiftAidCalculator.TestConsole.Commands;
using GiftAidCalculator.TestConsole.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class AdministratorCommandTests
    {
        private AdministratorCommand _administratorCommand;
        private Mock<ITaxRateService> _taxRateService;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _taxRateService = new Mock<ITaxRateService>();
            _administratorCommand = new AdministratorCommand(_taxRateService.Object);
        }

        [Test]
        public void Constructor_ParamTaxRateService_Null_ThrowsArgumentNullExcception()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new AdministratorCommand(null));
        }

        [Test]
        public void Execute_ParamArgs_Null_ThrowsArgumentNullExcception()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _administratorCommand.Execute(null));
        }

        [Test]
        public void Execute_ParamArgs_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => _administratorCommand.Execute(new object[] {0}));
        }

        [Test]
        public void Execute_VerifyTaxService_Called()
        {
            _taxRateService.Setup(t => t.SetNewTaxRate(10));
            _administratorCommand.Execute(new object[] {10});
            _taxRateService.Verify(mock => mock.SetNewTaxRate(10));
        }
    }
}