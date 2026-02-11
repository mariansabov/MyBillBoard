using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBillBoard.Application.Features.SubCategories;
using MyBillBoard.Application.Features.SubCategories.Dtos;

namespace MyBillBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDto>>> GetAll()
        {
            var subCategories = await mediator.Send(new GetSubCategoriesQuery());
            return Ok(subCategories);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSubCategoryCommand command)
        {
            var subCategoryId = await mediator.Send(command);
            return Ok(subCategoryId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UpdateSubCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            var subCategoryId = await mediator.Send(command);
            return Ok(subCategoryId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deletedId = await mediator.Send(new DeleteSubCategoryCommand(id));
            return Ok(deletedId);
        }
    }
}
