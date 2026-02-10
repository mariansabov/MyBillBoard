using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements
{
    public record CreateAnnouncementCommand(
        string Title,
        string Description,
        Guid CategoryId,
        Guid SubCategoryId) : IRequest<Guid>;

    public class CreateAnnouncementHandler(IMyDbContext context) : IRequestHandler<CreateAnnouncementCommand, Guid>
    {
        public async Task<Guid> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcementEntity = new Announcement
            {
                Title = request.Title,
                Description = request.Description,
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow,
                CategoryId = request.CategoryId,
                SubCategoryId = request.SubCategoryId
            };

            await context.Announcements.AddAsync(announcementEntity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return announcementEntity.Id;
        }
    }
}
