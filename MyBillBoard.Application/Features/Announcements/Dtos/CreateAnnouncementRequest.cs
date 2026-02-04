using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements.Dtos
{
    public record CreateAnnouncementRequest(
        string Title,
        string Description,
        Guid CategoryId,
        Guid SubCategoryId);
}
