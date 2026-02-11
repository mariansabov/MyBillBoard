using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Announcements.Dtos;

namespace MyBillBoard.Application.Features.Announcements
{
    public record GetAnnouncementsQuery : IRequest<List<AnnouncementDto>>;

    public class GetAnnouncementsHandler(IMyDbContext context, IMapper mapper) : IRequestHandler<GetAnnouncementsQuery, List<AnnouncementDto>>
    {
        public async Task<List<AnnouncementDto>> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            return await context.Announcements
                .AsNoTracking()
                .ProjectTo<AnnouncementDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
