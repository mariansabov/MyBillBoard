using MyBillBoard.Application.Features.Announcements.Dtos;
using MyBillBoard.Application.Interfaces;
using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Application.Services
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly IAnnouncementsRepository _announcementsRepository;

        public AnnouncementsService(IAnnouncementsRepository announcementsRepository)
        {
            _announcementsRepository = announcementsRepository;
        }

        public async Task<List<AnnouncementDto>> GetAllAnnouncementsAsync()
        {
            return await _announcementsRepository.GetAllAnnouncementsAsync();
        }

        public async Task<Guid> CreateAnnouncementAsync(CreateAnnouncementRequest announcement)
        {
            return await _announcementsRepository.CreateAnnouncementAsync(announcement);
        }

        public async Task<Guid> UpdateAnnouncementAsync(Guid id, UpdateAnnouncementRequest request)
        {
            return await _announcementsRepository.UpdateAnnouncementAsync(id, request);
        }

        public async Task<Guid> DeleteAnnouncementAsync(Guid id)
        {
            return await _announcementsRepository.DeleteAnnouncementAsync(id);
        }
    }
}
