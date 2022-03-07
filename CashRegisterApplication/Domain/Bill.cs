using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Bill_number { get; set; }
        public int Total_cost { get; set; }
        public int Credit_card { get; set; }
        public ICollection<Bill_Product> Bill_Products { get; set; }
    }
}
