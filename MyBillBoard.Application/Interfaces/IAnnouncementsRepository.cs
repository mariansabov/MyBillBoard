using MyBillBoard.Application.Features.Announcements.Dtos;
using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Application.Interfaces
{
    public interface IAnnouncementsRepository
    {
        Task<Guid> ChangeStatusAsync(Guid id, bool status);
        Task<Guid> CreateAnnouncementAsync(CreateAnnouncementRequest announcement);
        Task<Guid> DeleteAnnouncementAsync(Guid id);
        Task<List<AnnouncementDto>> GetAllAnnouncementsAsync();
        Task<AnnouncementDto> GetAnnouncementByIdAsync(Guid id);
        Task<Guid> UpdateAnnouncementAsync(Guid id, UpdateAnnouncementRequest request);
    }
}