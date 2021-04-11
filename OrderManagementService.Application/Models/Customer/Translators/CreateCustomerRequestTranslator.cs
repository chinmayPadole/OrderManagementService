namespace OrderManagementService.Application
{
    public static class CreateCustomerRequestTranslator
    {
        public static Gateways.CreateCustomerRequest ToModel(this CreateCustomerRequest request)
        {
            return new Gateways.CreateCustomerRequest()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}
