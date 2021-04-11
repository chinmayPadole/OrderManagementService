using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public class Filters
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderBy { get; set; } = "ASC";
    }

    public enum OrderBy
    {
        ASC,
        DESC
    }
}
