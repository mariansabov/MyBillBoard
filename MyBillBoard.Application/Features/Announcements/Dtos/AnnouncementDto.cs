using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Announcements.Dtos
{
    public record AnnouncementDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public string Status { get; set; } = string.Empty;
        public string CategorySubCategoryTitle { get; set; } = string.Empty;
    }
}
