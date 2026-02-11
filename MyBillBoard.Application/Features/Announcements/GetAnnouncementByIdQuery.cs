using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Announcements.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements
{
    public record GetAnnouncementByIdQuery(
        Guid Id) : IRequest<AnnouncementDto>;

    public class GetAnnouncementByIdHandler(IMyDbContext context, IMapper mapper) : IRequestHandler<GetAnnouncementByIdQuery, AnnouncementDto>
    {
        public async Task<AnnouncementDto> Handle(GetAnnouncementByIdQuery request, CancellationToken cancellationToken)
        {
            var announcement = await context.Announcements
                 .AsNoTracking()
                 .Where(a => a.Id == request.Id)
                 .ProjectTo<AnnouncementDto>(mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync(cancellationToken);

            return announcement ?? throw new KeyNotFoundException($"Announcement with ID {request.Id} not found.");
        }
    }
}