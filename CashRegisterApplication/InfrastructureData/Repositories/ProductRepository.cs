using Domain;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private BillsDbContext _db;
        public ProductRepository(BillsDbContext context)
        {
            _db = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products;
        }
        public void Add(Product product)
        {
            _db.Add(product);
            _db.SaveChanges();
        }
        public void Delete(Product product)
        {
            _db.Remove(product);
            _db.SaveChanges();
        }
        public void Update(Product product,int id)
        {
            var productFromDb = GetProducts().FirstOrDefault(x => x.Product_id == id);
            if (productFromDb != null)
            {
                productFromDb.Product_id = product.Product_id;
                productFromDb.Name = product.Name;
                productFromDb.Cost = product.Cost;
            }
            _db.Update(product);
            _db.SaveChanges();
        }
    }
}
