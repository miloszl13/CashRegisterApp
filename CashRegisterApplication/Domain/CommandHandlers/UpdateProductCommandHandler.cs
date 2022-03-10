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
    public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _productRepository.GetProducts().FirstOrDefault(x => x.Product_id == request.Product_id);
                if (product != null)
                {
                    product.Product_id = request.Product_id;
                    product.Name = request.Name;
                    product.Cost = request.Cost;
                    _productRepository.Update(product,product.Product_id);
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }


        }
    }
}
