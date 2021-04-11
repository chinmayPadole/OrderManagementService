using FluentValidation;

namespace OrderManagementService.DataContract.V1
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.Name)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull()
                   .WithErrorCode("400")
                   .WithMessage($"The value for Name field is missing in the request")
                   .NotEmpty()
                   .WithErrorCode("400")
                   .WithMessage($"The value for Name field is incorrect in the request");

            RuleFor(x => x.Password)
                  .Cascade(CascadeMode.StopOnFirstFailure)
                  .NotNull()
                  .WithErrorCode("400")
                  .WithMessage($"The value for Password field is missing in the request")
                  .NotEmpty()
                  .WithErrorCode("400")
                  .WithMessage($"The value for Password field is incorrect in the request")
                  .MinimumLength(6)
                  .WithErrorCode("400")
                  .WithMessage($"The value for Password field is does not match the minimum password length of {6}");

            RuleFor(x => x.Email)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull()
                   .WithErrorCode("400")
                   .WithMessage($"The value for Email field is missing in the request")
                   .NotEmpty()
                   .WithErrorCode("400")
                   .WithMessage($"The value for Email field is incorrect in the request")
                   .EmailAddress()
                   .WithErrorCode("400")
                   .WithMessage($"The value for Email field is invalid in the request");

        }
    }
}
