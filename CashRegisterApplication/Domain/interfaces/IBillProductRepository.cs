using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IBillProductRepository
    {
        void Add(BillProduct billproduct);

        IEnumerable<BillProduct> GetAllBillProducts();
        void Delete(BillProduct billproduct);

    }
}
