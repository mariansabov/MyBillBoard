using Microsoft.EntityFrameworkCore;
using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Application.Interfaces
{
    public interface IMyDbContext
    {
        DbSet<Announcement> Announcements { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
    }
}