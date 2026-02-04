using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements.Dtos
{
    public record UpdateAnnouncementRequest(
        Guid Id,
        string Title,
        string Description,
        bool Status);
}
