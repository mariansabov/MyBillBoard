using MediatR;
using MyBillBoard.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements
{
    public record DeleteAnnouncementCommand(Guid Id) : IRequest<Guid>;

    public class DeleteAnnouncementHandler(IMyDbContext context) : IRequestHandler<DeleteAnnouncementCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await context.Announcements.FindAsync([request.Id], cancellationToken);

            if (announcement == null)
            {
                throw new KeyNotFoundException($"Announcement with Id {request.Id} not found.");
            } 

            context.Announcements.Remove(announcement);
            await context.SaveChangesAsync(cancellationToken);
            
            return request.Id;
        }
    }
}
