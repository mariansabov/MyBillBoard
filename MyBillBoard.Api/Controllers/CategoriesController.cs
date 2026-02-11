using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBillBoard.Application.Features.Categories;
using MyBillBoard.Application.Features.Categories.Dtos;

namespace MyBillBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await mediator.Send(new GetCategoriesQuery());
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommand command)
        {
            var categoryId = await mediator.Send(command);
            return Ok(categoryId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id) 
            { 
                return BadRequest("ID mismatch"); 
            }

            var categoryId = await mediator.Send(command);
            return Ok(categoryId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deletedId = await mediator.Send(new DeleteCategoryCommand(id));
            return Ok(deletedId);
        }
    }
}
