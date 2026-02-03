using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Domain.Common
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
