using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoApp.Business.Abstract;
using VideoApp.Entities.DTOs;

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

            return result.Success
                ? Ok(result.Data)
                : BadRequest(result.Message);
        }

        [HttpPost]
        // [Authorize(Roles = "Category.Add")]
        public IActionResult Add([FromBody] CategoryCreateUpdateDto categoryDto)
        {
            var result = _categoryService.Add(categoryDto);

            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Category.Update")]
        public IActionResult Update(Guid id, [FromBody] CategoryCreateUpdateDto categoryDto)
        {
            var result = _categoryService.Update(id, categoryDto);

            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }
    }
}
