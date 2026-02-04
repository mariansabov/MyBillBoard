using Microsoft.AspNetCore.Mvc;
using MyBillBoard.Application.Features.Announcements.Dtos;
using MyBillBoard.Application.Interfaces;

namespace MyBillBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnnouncementDto>>> GetAll()
        {
            var announcements = await _announcementsService.GetAllAnnouncementsAsync();

            return Ok(announcements);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAnnouncementRequest request)
        {
            var announcementId = await _announcementsService.CreateAnnouncementAsync(request);

            return Ok(announcementId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UpdateAnnouncementRequest request)
        {
            var announcementId = await _announcementsService.UpdateAnnouncementAsync(id, request);
            return Ok(announcementId);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Guid>> ChangeStatus(Guid id, [FromQuery] bool status)
        {
            var announcementId = await _announcementsService.ChangeStatusAsync(id, status);
            return Ok(announcementId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var announcementId = await _announcementsService.DeleteAnnouncementAsync(id);
            return Ok(announcementId);
        }
    }
}