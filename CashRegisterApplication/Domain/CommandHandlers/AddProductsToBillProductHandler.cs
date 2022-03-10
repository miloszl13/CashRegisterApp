using Domain.Commands;
using Domain.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class AddProductsToBillProductHandler : IRequestHandler<AddProductsToBillProduct, bool>
    {
        private readonly IBillProductRepository _billProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBillRepository _billRepository;
        public AddProductsToBillProductHandler(IBillProductRepository billProductRepository, IProductRepository productRepository, IBillRepository billRepository)
        {
            _billProductRepository = billProductRepository;
            _productRepository=productRepository;
            _billRepository=billRepository;
        }
        public Task<bool> Handle(AddProductsToBillProduct request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _productRepository.GetProducts().FirstOrDefault(x => x.Product_id == request.Product_id);
                if(product == null)
                {
                    return Task.FromResult(false);
                }
                
                var billProduct = new BillProduct()
                {
                    Bill_number = request.Bill_number,
                    Product_id = request.Product_id,
                    Product_quantity = request.Product_quantity,
                    Products_cost = (product.Cost * request.Product_quantity)
                };

                _billRepository.IncreaseTotalCost(billProduct.Products_cost, billProduct.Bill_number);
                _billProductRepository.Add(billProduct);

                return Task.FromResult(true);
            }
            catch(NullReferenceException ex)
            {
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
