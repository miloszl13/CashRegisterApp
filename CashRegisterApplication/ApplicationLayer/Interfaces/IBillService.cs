﻿using ApplicationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface IBillService
    {
        List<BillViewModel> GetBills();
        void Create(BillViewModel billViewModel);
        void Update(BillViewModel billViewModel);
        void Delete(int id);
        BillViewModel GetBillById(int id);
    }
}
