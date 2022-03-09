using ApplicationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        ActionResult<int> Delete(int id);
        ActionResult<BillViewModel> GetBillById(int id);
    }
}
