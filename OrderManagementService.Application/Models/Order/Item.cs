﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public QuotedPrice QuotedPrice { get; set; }
    }
}
