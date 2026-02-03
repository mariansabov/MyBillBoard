using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Application.Interfaces
{
    public interface IAnnouncementsRepository
    {
        Task<Guid> CreateAnnouncementAsync(Announcement announcement);
        Task<Guid> DeleteAnnouncementAsync(Guid id);
        Task<List<Announcement>> GetAllAnnouncementsAsync();
        Task<Guid> UpdateAnnouncementAsync(Guid id, string title, string description, bool status);
    }
}