using ApplicationLayer.Interfaces;
using ApplicationLayer.ViewModels;
using Domain.Commands;
using Domain.interfaces;
using DomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMediatorHandler _bus;

        public BillService(IBillRepository billRepository, IMediatorHandler bus)
        {
            _billRepository = billRepository;
            _bus = bus;
        }

        public List<BillViewModel> GetBills()
        {
            var bills = _billRepository.GetBills();
            var result = new List<BillViewModel>();
            foreach(var bill in bills)
            {
                result.Add(new BillViewModel
                {
                    Bill_number = bill.Bill_number,
                    Total_cost = bill.Total_cost,
                    Credit_card = bill.Credit_card
                });
            }
            return result;

        }
        public void Create(BillViewModel billViewModel)
        {
            var createBillCommand = new CreateBillCommand(
                billViewModel.Bill_number,
                billViewModel.Total_cost,
                billViewModel.Credit_card);
            _bus.SendCommand(createBillCommand);
        }
        public void Update(BillViewModel billViewModel)
        {
            var updateBillCommand = new UpdateBillCommand(
                billViewModel.Bill_number,
                billViewModel.Total_cost,
                billViewModel.Credit_card);
            _bus.SendCommand(updateBillCommand); 
            
        }
        public void Delete(int id)
        {
            var billfromdb = _billRepository.GetBills().FirstOrDefault(x => x.Bill_number == id);
            _billRepository.Delete(billfromdb);
        }

    }
}
