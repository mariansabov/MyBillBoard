using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBillBoard.Application.Features.Announcements;
using MyBillBoard.Application.Features.Announcements.Dtos;

namespace MyBillBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AnnouncementDto>>> GetAll()
        {
            var announcements = await mediator.Send(new GetAnnouncementsQuery());
            return Ok(announcements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementDto>> GetById(Guid id)
        {
            var announcement = await mediator.Send(new GetAnnouncementByIdQuery(id));
            return Ok(announcement);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAnnouncementCommand command)
        {
            var announcementId = await mediator.Send(command);
            return Ok(announcementId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UpdateAnnouncementCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            var announcementId = await mediator.Send(command);
            return Ok(announcementId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var announcementId = await mediator.Send(new DeleteAnnouncementCommand(id));
            return Ok(announcementId);
        }
    }
}