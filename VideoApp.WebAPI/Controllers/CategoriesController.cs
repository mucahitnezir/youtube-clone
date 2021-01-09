using System;
using Microsoft.AspNetCore.Mvc;
using VideoApp.Business.Abstract;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.Dtos;

namespace VideoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CategoryDto categoryDto)
        {
            var result = _categoryService.Add(categoryDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CategoryDto categoryDto)
        {
            var result = _categoryService.Update(id, categoryDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}