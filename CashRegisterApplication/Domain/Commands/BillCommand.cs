using DomainCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class BillCommand:Command
    {
        public string Bill_number { get; set; }
        public int? Total_cost { get; set; }
        public int? Credit_card { get; set; }
    }
}
