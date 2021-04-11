using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        //todo : HardCoding error codes and messages for now, will later update it
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.Currency)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull()
                   .WithErrorCode("400")
                   .WithMessage($"The value for currency field is missing in the request")
                   .NotEmpty()
                   .WithErrorCode("400")
                   .WithMessage($"The value for currency field is incorrect in the request");

            //todo: implement currency validation later to check if currency in req is correct or supported by our system
            //which can be compared from either db or some other config storage.

            RuleFor(x => x.Amount)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull()
                   .WithErrorCode("400")
                   .WithMessage($"The value for amount field is missing in the request")
                   .GreaterThan(0)
                   .WithErrorCode("400")
                   .WithMessage($"The value for amount field is incorrect in the request");

            RuleForEach(x => x.Items)
                .SetValidator(new ItemValidator())
                .When(x => x.Items != null);
        }
    }
}
