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

    public class GetAnnouncementByIdHandler(IMyDbContext context) : IRequestHandler<GetAnnouncementByIdQuery, AnnouncementDto>
    {
        public async Task<AnnouncementDto> Handle(GetAnnouncementByIdQuery request, CancellationToken cancellationToken)
        {
            var announcement = await context.Announcements
                 .AsNoTracking()
                 .Where(a => a.Id == request.Id)
                 .Select(a => new AnnouncementDto(
                     a.Id,
                     a.Title,
                     a.Description,
                     a.CreatedAtUtc,
                     a.UpdatedAtUtc,
                     a.Status ? "Active" : "Inactive",
                     a.Category.Title + " / " + a.SubCategory.Title))
                 .FirstOrDefaultAsync(cancellationToken);

            return announcement ?? throw new KeyNotFoundException($"Announcement with ID {request.Id} not found.");
        }
    }
}