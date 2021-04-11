using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public class QuotedPriceValidator : AbstractValidator<QuotedPrice>
    {
        public QuotedPriceValidator()
        {
            RuleFor(x => x.Amount)
               .Cascade(CascadeMode.StopOnFirstFailure)
                  .NotNull()
                  .WithErrorCode("400")
                  .WithMessage($"The value for amount field is missing in the request")
                  .GreaterThan(0)
                  .WithErrorCode("400")
                  .WithMessage($"The value for amount field is incorrect in the request");

            RuleFor(x => x.AmountWithoutTax)
                .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull()
                   .WithErrorCode("400")
                   .WithMessage($"The value for amountWithoutTax field is missing in the request")
                   .GreaterThan(0)
                   .WithErrorCode("400")
                   .WithMessage($"The value for amountWithoutTax field is incorrect in the request");
        }
    }
}
