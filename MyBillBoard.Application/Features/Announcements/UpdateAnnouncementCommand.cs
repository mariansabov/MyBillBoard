using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements
{
    public record UpdateAnnouncementCommand(
        Guid Id,
        string Title,
        string Description,
        bool Status) : IRequest<Guid>;

    public class UpdateAnnouncementHandler(IMyDbContext context) : IRequestHandler<UpdateAnnouncementCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            await context.Announcements
                .Where(a => a.Id == request.Id)
                .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.Title, request.Title)
                    .SetProperty(a => a.Description, request.Description)
                    .SetProperty(a => a.Status, request.Status)
                    .SetProperty(a => a.UpdatedAtUtc, DateTime.UtcNow),
                    cancellationToken);

            return request.Id;
        }
    }
}
