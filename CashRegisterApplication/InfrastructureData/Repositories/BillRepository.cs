using Domain;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;
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
        //get all bills
        public IEnumerable<Bill> GetBills()
        {
           return _db.Bills;
        }
        //add new bill
        public void Add(Bill bill)
        {
            _db.Add(bill);
            _db.SaveChanges();
        }
        //update bill
        public void Update(Bill bill,int id)
        {
            var billfromdb = GetBills().FirstOrDefault(x => x.Bill_number == id );
            if (billfromdb != null)
            {
                billfromdb.Total_cost = bill.Total_cost;
                billfromdb.Credit_card = bill.Credit_card;
            }
            _db.SaveChanges();
        }
        //Delete bill
        public void Delete(Bill bill)
        {
            _db.Remove(bill);
            _db.SaveChanges();
        }
        //Get bill by id
        public Bill GetBillById(int id)
        {

            var bill = _db.Bills.Include(x=>x.Bill_Products).FirstOrDefault(x => x.Bill_number == id);
            return bill;
        }
    }
}
