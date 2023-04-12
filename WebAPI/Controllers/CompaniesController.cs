using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var result = _companyService.GetAll();

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{name}")]
        public IActionResult GetAllCompaniesByName([FromRoute(Name = "name")] string name)
        {
            var result = _companyService.GetAllByName(name: name);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneCompanyById([FromRoute(Name = "id")] int id)
        {
            var result = _companyService.GetById(id: id);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateOneCompany([FromBody] Company company)
        {
            var result = _companyService.Add(company: company);

            if (result.IsSuccess)
                return StatusCode(201, result.Message);

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteOneCompany([FromBody] Company company)
        {
            var result = _companyService.Delete(company: company);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateOneCompany([FromBody] Company company)
        {
            var result = _companyService.Update(company: company);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }
    }
}
