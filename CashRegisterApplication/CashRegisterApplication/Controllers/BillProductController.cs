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
        //Create new bill
        [HttpPost("Add product to billproduct")]
        public IActionResult CreateBill([FromBody] BillProductViewModel billProductViewModel)
        {
            _billProductService.Create(billProductViewModel);
            return Ok();
        }
        [HttpDelete("delete/{id:int},{id1:int}")]
        public IActionResult DeleteBillProduct([FromRoute] int id,[FromRoute] int id1)
        {
            _billProductService.Delete(id,id1);
            return Ok();
        }

    }
}
