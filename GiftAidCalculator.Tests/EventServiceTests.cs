using System;
using GiftAidCalculator.TestConsole.Classes;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class EventServiceTests
    {
        [Test]
        public void Constructor_ParamRepository_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new EventService(null));
        }
    }
}