using ApplicationLayer.Interfaces;
using ApplicationLayer.ViewModels;
using Domain.interfaces;
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
        public BillProductService(IBillProductRepository billProductRepository)
        {
            _billProductRepository=billProductRepository;
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
    }
}
