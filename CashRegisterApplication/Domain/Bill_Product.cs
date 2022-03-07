using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bill_Product
    {
        [ForeignKey("Bill")]
        public int Bill_number { get; set; }
        public Bill Bill { get; set; }
        [ForeignKey("Product")]
        public int Product_id { get; set; }
        public Product Product { get; set; }

        public int Product_quantity { get; set; }
        public int Products_cost { get; set; }

    }
}
