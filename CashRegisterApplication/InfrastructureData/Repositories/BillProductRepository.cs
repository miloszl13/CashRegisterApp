using Domain;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.Repositories
{
    public class BillProductRepository:IBillProductRepository
    {
        private BillsDbContext _db;
        public BillProductRepository(BillsDbContext db)
        {
            _db=db;
        }

        public void Add(BillProduct billproduct)
        {
            _db.Add(billproduct);
            _db.SaveChanges();
        }

        //get all bill products
        public IEnumerable<BillProduct> GetAllBillProducts()
        {
                return _db.Bill_Products;
        }
        //Delete bill_product
        public void Delete(BillProduct billproduct)
        {

            _db.Remove(billproduct);
            _db.SaveChanges();
        }

    }
}
