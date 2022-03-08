using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ViewModels
{
    public class BillViewModel
    {
        public int Bill_number { get; set; }
        public int? Total_cost { get; set; }
        public int? Credit_card { get; set; }
        public ICollection<Bill_Product> Bill_Products { get; set; }
        //public IEnumerable<Bill> Bills { get; set; }
    }
}
