using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _context.Announcements
                .Include(a => a.Category)
                .Include(a => a.SubCategory)
                .ToListAsync();
        }

        public async Task<Guid> CreateAnnouncementAsync(Announcement announcement)
        {
            var announcementEntity = new Announcement
            {
                Title = announcement.Title,
                Description = announcement.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = announcement.Status,
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
