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
    public class BillProductService : IBillProductService
    {
        private readonly IBillProductRepository _billProductRepository;
        private readonly IMediatorHandler _bus;

        public BillProductService(IBillProductRepository billProductRepository, IMediatorHandler bus)
        {
            _billProductRepository=billProductRepository;
            _bus = bus;

        }
        public List<BillProductViewModel> GetAllBillProduct()
        {
            var billProducts = _billProductRepository.GetAllBillProducts();
            var result = new List<BillProductViewModel>();
            if (billProducts != null)
            {
                foreach (var billproduct in billProducts)
                {
                    result.Add(new BillProductViewModel
                    {
                        Bill_number = billproduct.Bill_number,
                        Product_id = billproduct.Product_id,
                        Product_quantity = billproduct.Product_quantity,
                        Products_cost = billproduct.Products_cost
                    });
                }
            }
            return result;
        }
        public void Create(BillProductViewModel billProductViewModel)
        {
            var addProductToBillProductCommand = new AddProductsToBillProduct(
                billProductViewModel.Bill_number,
                billProductViewModel.Product_id,
                billProductViewModel.Product_quantity);
            _bus.SendCommand(addProductToBillProductCommand);
        }
    }
}
