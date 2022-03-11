using DomainCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class BillProductCommand:Command
    {

        public string Bill_number { get; set; }

        public int Product_id { get; set; }

        public int Product_quantity { get; set; }
        public int? Products_cost { get; set; }
    }
}
