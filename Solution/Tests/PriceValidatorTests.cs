using System;
using Api;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PriceValidatorTests
    {
        private readonly PriceValidator _validator;

        public PriceValidatorTests()
        {
            _validator = new PriceValidator();
        }

        [Test]
        public void DateFromIsNotUtc_Invalid()
        {
            var price = new PriceDto
            {
                ValidFrom = DateTime.Now,
                Value = 1
            };

            var result = _validator.TestValidate(price);

            result.ShouldHaveValidationErrorFor(x => x.ValidFrom);
        }

        [Test]
        public void DateFromIsUtc_Valid()
        {
            var price = new PriceDto
            {
                ValidFrom = DateTime.UtcNow,
                Value = 1
            };

            var result = _validator.TestValidate(price);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}