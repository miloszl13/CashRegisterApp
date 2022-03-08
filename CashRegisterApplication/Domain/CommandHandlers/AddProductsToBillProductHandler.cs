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
        public AddProductsToBillProductHandler(IBillProductRepository billProductRepository, IProductRepository productRepository)
        {
            _billProductRepository = billProductRepository;
            _productRepository=productRepository;
        }
        public Task<bool> Handle(AddProductsToBillProduct request, CancellationToken cancellationToken)
        {
            Product product = _productRepository.GetProducts().FirstOrDefault(x => x.Product_id == request.Product_id);
            var billProduct = new BillProduct()
            {
                Bill_number = request.Bill_number,
                Product_id = request.Product_id,
                Product_quantity = request.Product_quantity,
                Products_cost = (product.Cost * request.Product_quantity)
            };

            _billProductRepository.Add(billProduct);
            return Task.FromResult(true);
        }
    }
}
