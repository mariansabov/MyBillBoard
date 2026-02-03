using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticAssets.Infrastructure;

using MyBillBoard.Application.Interfaces;
using MyBillBoard.Application.Services;
using MyBillBoard.Domain.Entities;
using MyBillBoard.Infrastructure.Repositories;

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
        public async Task<ActionResult<List<Announcement>>> GetAll()
        {
            var announcements = await _announcementsService.GetAllAnnouncementsAsync();

            return Ok(announcements);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] Announcement request)
        {
            var announcement = new Announcement
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                CategoryId = request.CategoryId,
                SubCategoryId = request.SubCategoryId
            };

            var announcementId = await _announcementsService.CreateAnnouncementAsync(announcement);

            return Ok(announcementId);
        }
    }
}