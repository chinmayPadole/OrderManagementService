using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull()
                   .WithErrorCode("400")
                   .WithMessage($"The value for id field is missing in the request")
                   .NotEmpty()
                   .WithErrorCode("400")
                   .WithMessage($"The value for id field is incorrect in the request");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull()
                   .WithErrorCode("400")
                   .WithMessage($"The value for name field is missing in the request")
                   .NotEmpty()
                   .WithErrorCode("400")
                   .WithMessage($"The value for name field is incorrect in the request");

            RuleFor(x => x.QuotedPrice)
                .SetValidator(new QuotedPriceValidator());
        }
    }
}
