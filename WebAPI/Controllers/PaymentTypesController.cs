using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypesController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet]
        public IActionResult GetAllPaymentTypes() 
        {
            var result = _paymentTypeService.GetAll();

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{name}")]
        public IActionResult GetAllPaymentTypesByName([FromRoute(Name = "name")] string name) 
        {
            var result = _paymentTypeService.GetAllByName(name: name);

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPaymentTypesById([FromRoute(Name = "id")] int id)
        {
            var result = _paymentTypeService.GetById(id: id);

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateOnePaymentType([FromBody] PaymentType paymentType)
        {
            var result = _paymentTypeService.Add(paymentType: paymentType);

            if (result.IsSuccess)
                return StatusCode(201, result.Message);

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteOnePaymentType([FromBody] PaymentType paymentType) 
        {
            var result = _paymentTypeService.Delete(paymentType: paymentType);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateOnePaymentType([FromBody] PaymentType paymentType)
        {
            var result = _paymentTypeService.Update(paymentType: paymentType);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }
    }
}
