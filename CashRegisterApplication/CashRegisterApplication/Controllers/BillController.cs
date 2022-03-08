﻿using ApplicationLayer.Interfaces;
using ApplicationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService=billService;
        }
        //get all bills
        [HttpGet]
        public List<BillViewModel> GetBills()
        {
            return _billService.GetBills();
        }
        //Create new bill
        [HttpPost]
        public IActionResult CreateBill([FromBody] BillViewModel billViewModel)
        {
            _billService.Create(billViewModel);
            return Ok(billViewModel);
        }
        //update existing  bill
        [HttpPut("Update")]
        public IActionResult EditBill([FromBody] BillViewModel bill)
        {
            _billService.Update(bill);
            return Ok(bill);
        }
        //delelete bill by id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBill([FromRoute] int id)
        {
            _billService.Delete(id);
            return Ok(id);
        }
        //get bill by id
        [HttpGet("{id}")]
        public BillViewModel GetBillById([FromRoute] int id)
        {
            return _billService.GetBillById(id);
        
        }

    }
}
