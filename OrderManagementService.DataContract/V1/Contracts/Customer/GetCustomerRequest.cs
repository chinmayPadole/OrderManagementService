namespace OrderManagementService.DataContract.V1
{
    public class GetCustomerRequest
    {
        //User can provide any one of these details to retrieve customer details
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
