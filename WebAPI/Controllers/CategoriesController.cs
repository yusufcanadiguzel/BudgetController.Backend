using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAll();

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{name}")]
        public IActionResult GetAllCategories([FromRoute(Name = "name")] string name)
        {
            var result = _categoryService.GetAllByName(name: name);

            if(result.IsSuccess) 
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneCategoryById([FromRoute(Name = "id")] int id)
        {
            var result = _categoryService.GetById(id: id);

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateOneCategory([FromBody] Category category)
        {
            var result = _categoryService.Add(category: category);

            if (result.IsSuccess)
                return StatusCode(201, result.Message);

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteOneCategory([FromBody] Category category)
        {
            var result = _categoryService.Delete(category: category);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateOneCategory([FromBody] Category category)
        {
            var result = _categoryService.Update(category: category);

            if (result.IsSuccess)
                return StatusCode(204, result.Message);

            return BadRequest();
        }
    }
}
