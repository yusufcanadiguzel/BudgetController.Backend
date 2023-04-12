using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpGet]
        public IActionResult GetAllReceipts()
        {
            var result = _receiptService.GetAll();

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{companyId:int}")]
        public IActionResult GetAllReceiptsByCompanyId([FromRoute(Name = "companyId")] int companyId)
        {
            var result = _receiptService.GetAllByCompanyId(companyId: companyId);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{categoryId:int}")]
        public IActionResult GetAllReceiptsByCategoryId([FromRoute(Name = "categoryId")] int categoryId)
        {
            var result = _receiptService.GetAllByCategoryId(categoryId: categoryId);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneReceiptById([FromRoute(Name = "id")] int id)
        {
            var result = _receiptService.GetById(id: id);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateOneReceipt([FromBody] Receipt receipt)
        {
            var result = _receiptService.Add(receipt: receipt);

            if (result.IsSuccess)
                return StatusCode(201, result.Message);

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteOneReceipt([FromBody] Receipt receipt)
        {
            var result = _receiptService.Delete(receipt: receipt);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateOneReceipt([FromBody] Receipt receipt)
        {
            var result = _receiptService.Update(receipt: receipt);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }
    }
}
