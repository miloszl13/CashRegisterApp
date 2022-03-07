using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public ICollection<Bill_Product> Bill_Products { get; set; }

    }
}
