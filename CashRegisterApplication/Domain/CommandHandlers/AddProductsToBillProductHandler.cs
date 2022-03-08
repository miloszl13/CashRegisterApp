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

        public AddProductsToBillProductHandler(IBillProductRepository billProductRepository)
        {
            _billProductRepository = billProductRepository;
        }
        public Task<bool> Handle(AddProductsToBillProduct request, CancellationToken cancellationToken)
        {
            
            //var billProduct = new BillProduct()
            //{
                
            //    Bill_number=request.Bill_number,
            //    Product_id=request.Product_id,
            //    Product_quantity=request.Product_quantity,
            //    Products_cost
            //}
            
            
            //_billRepository.Add(bill);
            return Task.FromResult(true);
        }
    }
}
