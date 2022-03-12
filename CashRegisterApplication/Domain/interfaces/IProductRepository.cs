using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void Delete(Product product);
        void Add(Product product);
        void Update(Product product,int id);
    }
}
