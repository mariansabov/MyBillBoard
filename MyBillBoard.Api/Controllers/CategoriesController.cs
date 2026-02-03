using Microsoft.AspNetCore.Mvc;
using MyBillBoard.Application.Features.Categories.Dtos;
using MyBillBoard.Application.Interfaces;
using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryRequest category)
        {
            var categoryId = await _categoriesRepository.CreateCategoryAsync(category);
            return Ok(categoryId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] Category category)
        {
            var categoryId = await _categoriesRepository.UpdateCategoryAsync(id, category.Title);
            return Ok(categoryId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var categoryId = await _categoriesRepository.DeleteCategoryAsync(id);
            return Ok(categoryId);
        }
    }
}
