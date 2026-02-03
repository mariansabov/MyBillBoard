using MyBillBoard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public Category Category { get; set; } = null!;

        public Guid CategoryId { get; set; }

        public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
    }
}
