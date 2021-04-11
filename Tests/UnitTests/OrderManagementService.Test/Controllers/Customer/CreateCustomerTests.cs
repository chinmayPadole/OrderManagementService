using System;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagementService.Application;
using OrderManagementService.Controllers;
using OrderManagementService.DataContract.V1;
using System.Web.Http;
using FluentAssertions;
using System.Net;

namespace OrderManagementService.Test
{
    [TestClass]
    public class CreateCustomerTests
    {
        private readonly Mock<IValidator<DataContract.V1.CreateCustomerRequest>> _moqValidator = new Mock<IValidator<DataContract.V1.CreateCustomerRequest>>();
        private readonly Mock<DataContract.V1.IValidatorFactory> _moqValidatorFactory = new Mock<DataContract.V1.IValidatorFactory>();
        private readonly Mock<ICustomerService> _moqCustomerService = new Mock<ICustomerService>();
        [TestMethod]
        public void CreateCustomer_Should_Be_Successful_For_Valid_Request()
        {
            var request = GetCreateCustomerRequest();
            var validationResult = new ValidationResult();
            _moqValidator.Setup(x => x.Validate(request)).Returns(validationResult);
            _moqValidatorFactory.Setup(x => x.GetValidator<DataContract.V1.CreateCustomerRequest>()).Returns(_moqValidator.Object);

            var _controller = new CustomerController(_moqCustomerService.Object, _moqValidatorFactory.Object);

            var result = _controller.CreateCustomer(request);
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void CreateCustomer_Should_Throw_Exception_Fot_InCorrect_Email()
        {
            var request = GetCreateCustomerRequest();
            request.Email = "abcd";
            var validationResult = new ValidationResult();
            _moqValidator.Setup(x => x.Validate(request)).Returns(validationResult);
            _moqValidatorFactory.Setup(x => x.GetValidator<DataContract.V1.CreateCustomerRequest>()).Returns(_moqValidator.Object);

            var _controller = new CustomerController(_moqCustomerService.Object, _moqValidatorFactory.Object);

            var exception = Assert.ThrowsException<BadRequestException>(() => _controller.CreateCustomer(request));

            exception.Should().NotBeNull();
            exception.Message.Should().Equals("The value for Email field is invalid in the request");
            exception.HttpStatusCode.Should().Equals(HttpStatusCode.BadRequest);
        }

        public DataContract.V1.CreateCustomerRequest GetCreateCustomerRequest()
        {
            return new DataContract.V1.CreateCustomerRequest()
            {
                Name = "Chinmay",
                Email = "c@p.com",
                Password = "123456",
            };
        }
    }
}
