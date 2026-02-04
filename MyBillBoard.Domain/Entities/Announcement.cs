using MyBillBoard.Domain.Common;

namespace MyBillBoard.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAtUtc { get; set; }

        public DateTime UpdatedAtUtc { get; set; }

        public bool Status { get; set; } = true;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
    }
}
