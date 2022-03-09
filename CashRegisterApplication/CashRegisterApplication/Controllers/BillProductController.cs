using ApplicationLayer.Interfaces;
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
        //Get all billProducts
        [HttpGet("GetAllBillProducts")]
        public ActionResult<List<BillProductViewModel>> GetAllBillProduct()
        {           
            var billProducts= _billProductService.GetAllBillProduct();
            return billProducts;
        }
        //Create new bill
        [HttpPost("AddNewProductToBillProduct")]
        public ActionResult<bool> AddNewProductToBillProduct([FromBody] BillProductViewModel billProductViewModel)
        {
            var AddingProduct = _billProductService.AddProductToBillProduct(billProductViewModel);
            return AddingProduct;
        }
        [HttpDelete("deleteBillProduct/{id:int},{id1:int}")]
        public IActionResult DeleteBillProduct([FromRoute] int id,[FromRoute] int id1)
        {
            _billProductService.Delete(id,id1);
            return Ok();
        }

    }
}
