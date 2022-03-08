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
        public List<BillViewModel> GetBill()
        {
            return _billService.GetBills();
        }
        [HttpPost]
        public IActionResult CreateBill([FromBody] BillViewModel billViewModel)
        {
            _billService.Create(billViewModel);
            return Ok(billViewModel);
        }
       
    }
}
