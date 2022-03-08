﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IBillRepository
    {
        IEnumerable<Bill> GetBills();
        void Add(Bill bill);
        void Update(Bill bill,int id);
        void Delete(Bill bill);
        public Bill GetBillById(int id);
    }
}
