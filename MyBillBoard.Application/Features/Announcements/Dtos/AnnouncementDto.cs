using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements.Dtos
{
    public record AnnouncementDto(
        Guid Id,
        string Title,
        string Description,
        DateTime CreatedAtUtc,
        DateTime UpdatedAtUtc,
        string Status,
        string CategorySubCategoryTitle);
}
