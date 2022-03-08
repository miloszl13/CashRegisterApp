using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class AddProductsToBillProduct:BillProductCommand
    {
        public AddProductsToBillProduct(int bill_number, int product_id, int product_quantity)
        {
            Bill_number = bill_number;
            Product_id = product_id;
            Product_quantity = product_quantity;
        }
    }
}
