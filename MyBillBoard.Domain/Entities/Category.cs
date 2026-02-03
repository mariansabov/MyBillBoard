using MyBillBoard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    }
}
