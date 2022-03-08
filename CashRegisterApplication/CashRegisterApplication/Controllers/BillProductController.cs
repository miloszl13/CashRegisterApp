﻿using ApplicationLayer.Interfaces;
using ApplicationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillProductController : ControllerBase
    {
        private readonly IBillProductService _billProductService;
        public BillProductController(IBillProductService billProductService)
        {
            _billProductService = billProductService;
        }
        [HttpGet]
        public List<BillProductViewModel> GetAllBillProduct()
        {           
            return _billProductService.GetAllBillProduct();
        }
    }
}
