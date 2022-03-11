﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BillErrorMessages
    {
        public const string bill_not_exist = "Bill with that Bill_number does not exist!";
        public const string bill_already_exist = "Bill with that Bill_number already exist!";
        public const string empty_bills_db = "There are no bills in database!";
        public const string not_valid_id = "You tried to create bill with invalid bill number!!";
    }
}
