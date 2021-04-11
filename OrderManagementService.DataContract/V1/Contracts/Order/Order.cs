using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public class Order
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public List<Item> Items { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
    }
}
