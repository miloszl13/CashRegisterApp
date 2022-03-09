using ApplicationLayer.Interfaces;
using ApplicationLayer.ViewModels;
using Domain;
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
        [HttpGet("GetAllBills")]
        public List<BillViewModel> GetBills()
        {
            return _billService.GetBills();
        }
        //Create new bill
        [HttpPost("CreateNewBill")]
        public IActionResult CreateBill([FromBody] BillViewModel billViewModel)
        {
            _billService.Create(billViewModel);
            return Ok(billViewModel);
        }
        //update existing  bill
        [HttpPut("UpdateBill")]
        public IActionResult EditBill([FromBody] BillViewModel bill)
        {
            _billService.Update(bill);
            return Ok(bill);
        }
        //delelete bill by id
        [HttpDelete("delete/{id}")]
        public ActionResult<int> DeleteBill([FromRoute] int id)
        {
            var deletedBill = _billService.Delete(id);
            return deletedBill;
        }
        //get bill by id
        [HttpGet("GetBillById{id}")]
        public ActionResult<BillViewModel> GetBillById([FromRoute] int id)
        {
           var billFromDb = _billService.GetBillById(id);
           return billFromDb;
        }

    }
}
