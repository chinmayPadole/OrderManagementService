using FluentValidation;
using OrderManagementService.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public static class Validations
    {
        public static void Validate<TRequest>(this TRequest request, IValidator<TRequest> validator)
        {
            var validationError = Errors.ClientSide.InvalidRequest();

            if (request == null)
                throw validationError;

            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
                return;

            validationError.BaseException.Info.AddRange(
                validationResult.Errors.Select(
                    validationFailure => new Info(validationFailure.ErrorCode, validationFailure.ErrorMessage)
                    ));


            throw validationError;
        }
    }
}
