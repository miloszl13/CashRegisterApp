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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }

        public List<ProductViewModel> GetProducts()
        {
            var products = _productRepository.GetProducts();
            var result = new List<ProductViewModel>();
            foreach (var product in products)
            {
                result.Add(new ProductViewModel
                {
                    Product_id=product.Product_id,
                    Name=product.Name,
                    Cost=product.Cost
                });
            }
            return result;
        }
    }
}
