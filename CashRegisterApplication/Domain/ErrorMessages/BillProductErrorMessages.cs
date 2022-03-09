using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ErrorMessages
{
    public class BillProductErrorMessages
    {
        public const string empty_billsproducts_db = "There are no products on any bill yet!";
        public const string invalid_adding_product_to_bill = "Unable to add that products to bill.Check if you entered bill and product informations correct!";
        public const string bill_product_not_exist = "The products you have chosen to delete do not exist in that bill!";

    }
}
