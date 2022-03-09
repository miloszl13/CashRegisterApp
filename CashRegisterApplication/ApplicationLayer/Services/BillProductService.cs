using ApplicationLayer.Interfaces;
using ApplicationLayer.Model;
using ApplicationLayer.ViewModels;
using Domain.Commands;
using Domain.ErrorMessages;
using Domain.interfaces;
using DomainCore.Bus;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<BillProductViewModel>> GetAllBillProduct()
        {
            var billProducts = _billProductRepository.GetAllBillProducts();
            if (billProducts.Count() == 0)
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillProductErrorMessages.empty_billsproducts_db,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
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
        public ActionResult<bool> AddProductToBillProduct(BillProductViewModel billProductViewModel)
        {
            var addProductToBillProductCommand = new AddProductsToBillProduct(
                billProductViewModel.Bill_number,
                billProductViewModel.Product_id,
                billProductViewModel.Product_quantity);
            var Task=_bus.SendCommand(addProductToBillProductCommand);
            if (Task == Task.FromResult(false))
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillProductErrorMessages.invalid_adding_product_to_bill,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
            return true;
        }
        public ActionResult<bool> Delete(int id1, int id2)
        {
            var bill_product = _billProductRepository.GetAllBillProducts().FirstOrDefault(x => x.Bill_number == id1 && x.Product_id==id2);
            if (bill_product == null)
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillProductErrorMessages.bill_product_not_exist,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
            _billProductRepository.Delete(bill_product);
            return true;
        }

    }
}
