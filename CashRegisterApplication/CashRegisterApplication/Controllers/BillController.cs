using ApplicationLayer.Interfaces;
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
        [HttpGet]
        public List<BillViewModel> GetBills()
        {
            return _billService.GetBills();
        }
        [HttpPost]
        public IActionResult CreateBill([FromBody] BillViewModel billViewModel)
        {
            _billService.Create(billViewModel);
            return Ok(billViewModel);
        }
        [HttpPut("Update")]
        public IActionResult EditBill([FromBody] BillViewModel bill)
        {
            _billService.Update(bill);
            return Ok(bill);
        }


    }
}
