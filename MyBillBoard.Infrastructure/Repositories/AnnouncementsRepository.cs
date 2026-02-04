using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Features.Announcements.Dtos;
using MyBillBoard.Application.Interfaces;
using MyBillBoard.Domain.Entities;
using MyBillBoard.Infrastructure.Persistence;

namespace MyBillBoard.Infrastructure.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly MyDbContext _context;

        public AnnouncementsRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnnouncementDto>> GetAllAnnouncementsAsync()
        {

            return await _context.Announcements
                .AsNoTracking()
                .Select(a => new AnnouncementDto(
                    a.Id,
                    a.Title,
                    a.Description,
                    a.CreatedAt,
                    a.UpdatedAt,
                    a.Status ? "Active" : "Inactive",
                    a.Category.Title + " / " + a.SubCategory.Title))
                .ToListAsync();
        }

        public async Task<Guid> CreateAnnouncementAsync(CreateAnnouncementRequest announcement)
        {
            var announcementEntity = new Announcement
            {
                Title = announcement.Title,
                Description = announcement.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CategoryId = announcement.CategoryId,
                SubCategoryId = announcement.SubCategoryId

            };

            await _context.Announcements.AddAsync(announcementEntity);
            await _context.SaveChangesAsync();

            return announcementEntity.Id;
        }

        public async Task<Guid> UpdateAnnouncementAsync(Guid id, string title, string description, bool status)
        {
            await _context.Announcements
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.Title, title)
                    .SetProperty(a => a.Description, description)
                    .SetProperty(a => a.Status, status)
                    .SetProperty(a => a.UpdatedAt, DateTime.UtcNow)
                );

            return id;
        }

        public async Task<Guid> DeleteAnnouncementAsync(Guid id)
        {
            await _context.Announcements
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
