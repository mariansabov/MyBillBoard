using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Categories;
using MyBillBoard.Application.Features.Categories.Dtos;
using MyBillBoard.Domain.Entities;
using System.Runtime.CompilerServices;

namespace MyBillBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(IMediator mediator, ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;

            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommand command)
        {
            var categoryId = await _mediator.Send(command);
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
