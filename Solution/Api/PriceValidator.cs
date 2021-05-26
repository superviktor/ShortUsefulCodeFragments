using FluentValidation;

namespace Api
{
    public class PriceValidator : AbstractValidator<PriceDto>
    {
        public PriceValidator()
        {
            RuleFor(x => x.ValidFrom).IsInUtc();
            When(x => x.ValidTo.HasValue, () =>
            {
                RuleFor(x => x.ValidTo).IsInUtc();
            });
            RuleFor(x => x.Value).GreaterThan(0);
        }
    }
}
