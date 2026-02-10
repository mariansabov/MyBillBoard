using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Announcements.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements
{
    public record GetAnnouncementsQuery : IRequest<List<AnnouncementDto>>;

    public class GetAnnouncementsHandler(IMyDbContext context) : IRequestHandler<GetAnnouncementsQuery, List<AnnouncementDto>>
    {
        public async Task<List<AnnouncementDto>> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            return await context.Announcements
                .AsNoTracking()
                .Select(a => new AnnouncementDto(
                    a.Id,
                    a.Title,
                    a.Description,
                    a.CreatedAtUtc,
                    a.UpdatedAtUtc,
                    a.Status ? "Active" : "Inactive",
                    a.Category.Title + " / " + a.SubCategory.Title))
                .ToListAsync(cancellationToken);
        }
    }
}
