﻿using System;
using System.Collections.Generic;

namespace webApi.Models
{
    public partial class CustOrder
    {
        public int? Custid { get; set; }
        public DateTime? Ordermonth { get; set; }
        public int? Qty { get; set; }
    }
}
