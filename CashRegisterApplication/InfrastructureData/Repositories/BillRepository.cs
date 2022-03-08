using Domain;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.Repositories
{
    public class BillRepository:IBillRepository
    {
        private BillsDbContext _db;
        public BillRepository(BillsDbContext context)
        {
            _db=context;
        }

        public IEnumerable<Bill> GetBills()
        {
           return _db.Bills;
        }
        public void Add(Bill bill)
        {
            _db.Add(bill);
            _db.SaveChanges();
        }
    }
}
