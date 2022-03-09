using ApplicationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface IBillProductService
    {
        List<BillProductViewModel> GetAllBillProduct();
        void Create(BillProductViewModel billProductViewModel);
        void Delete(int id1,int id2);

    }
}
