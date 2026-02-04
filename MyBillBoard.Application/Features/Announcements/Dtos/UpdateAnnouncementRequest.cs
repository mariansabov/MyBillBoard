using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements.Dtos
{
    public record UpdateAnnouncementRequest(
        string Title,
        string Description,
        bool Status);
}
