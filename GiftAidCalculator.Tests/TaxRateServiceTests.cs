using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class TaxRateServiceTests
    {
        [Test]
        public void TaxRateService_IsInstanceOf_ITaxRateService()
        {
            Assert.Fail();
        }

        [Test]
        public void SetNewTaxRate_ParamTaxRate_Zero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Fail();
        }

        [Test]
        public void SetNewTaxRate_ParamTaxRate_NegativeTen_ThrowsArgumentOutOfRangeException()
        {
            Assert.Fail();
        }


    }
}
