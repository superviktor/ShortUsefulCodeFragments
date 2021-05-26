using System;
using FluentValidation;

namespace Api
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, DateTime?> IsInUtc<T>(this IRuleBuilder<T, DateTime?> initial)
        {
            return initial.Must(x => !x.HasValue || x.Value.Kind == DateTimeKind.Utc)
                .WithMessage("The {PropertyName} should be in ISO 8601 format and in UTC (suffixed with 'Z')");
        }

        public static IRuleBuilderOptions<T, DateTime> IsInUtc<T>(this IRuleBuilder<T, DateTime> initial)
        {
            return initial.Must(x => x.Kind == DateTimeKind.Utc)
                .WithMessage("The {PropertyName} should be in ISO 8601 format and in UTC (suffixed with 'Z')");
        }
    }
}