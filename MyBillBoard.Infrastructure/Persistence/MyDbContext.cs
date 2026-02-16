using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Domain.Entities;
using MyBillBoard.Infrastructure.Configurations;
using System.Runtime.CompilerServices;

namespace MyBillBoard.Infrastructure.Persistence
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options), IMyDbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurationAssembly = typeof(AnnouncementConfiguration).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(configurationAssembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            SeedAll();
        }

        private void SeedAll()
        {
            SeedCategories();
            SeedSubCategories();
        }

        private void SeedCategories()
        {
            if (Categories.Any())
            {
                return;
            }

            var categories = new List<Category>
            {
                new Category { Title = "Побутова техніка" },
                new Category { Title = "Комп'ютерна техніка" },
                new Category { Title = "Смартфони" },
                new Category { Title = "Інше" },
            };

            Categories.AddRange(categories);

            SaveChanges();
        }

        private void SeedSubCategories()
        {
            if (SubCategories.Any())
            {
                return;
            }

            var subCategoriesHouseholdAppliances = new List<SubCategory>
            {
                new SubCategory
                {
                    Title = "Холодильники",
                    CategoryId = Categories.First(c => c.Title == "Побутова техніка").Id
                },
                new SubCategory
                {
                    Title = "Пральні машини",
                    CategoryId = Categories.First(c => c.Title == "Побутова техніка").Id
                },
                new SubCategory
                {
                    Title = "Бойлери",
                    CategoryId = Categories.First(c => c.Title == "Побутова техніка").Id
                },
                new SubCategory
                {
                    Title = "Печі",
                    CategoryId = Categories.First(c => c.Title == "Побутова техніка").Id
                },
                new SubCategory
                {
                    Title = "Витяжки",
                    CategoryId = Categories.First(c => c.Title == "Побутова техніка").Id
                },
                new SubCategory
                {
                    Title = "Мікрохвильові печі",
                    CategoryId = Categories.First(c => c.Title == "Побутова техніка").Id
                },
            };

            var subCategoriesComputerEquipment = new List<SubCategory>
            {
                new SubCategory
                {
                    Title = "ПК",
                    CategoryId = Categories.First(c => c.Title == "Комп'ютерна техніка").Id
                },
                new SubCategory
                {
                    Title = "Ноутбуки",
                    CategoryId = Categories.First(c => c.Title == "Комп'ютерна техніка").Id
                },
                new SubCategory
                {
                    Title = "Монітори",
                    CategoryId = Categories.First(c => c.Title == "Комп'ютерна техніка").Id
                },
                new SubCategory
                {
                    Title = "Принтери",
                    CategoryId = Categories.First(c => c.Title == "Комп'ютерна техніка").Id
                },
                new SubCategory
                {
                    Title = "Сканери",
                    CategoryId = Categories.First(c => c.Title == "Комп'ютерна техніка").Id
                },
            };

            var subCategoriesSmartphones = new List<SubCategory>
            {
                new SubCategory
                {
                    Title = "Android",
                    CategoryId = Categories.First(c => c.Title == "Смартфони").Id
                },
                new SubCategory
                {
                    Title = "iOS/Apple",
                    CategoryId = Categories.First(c => c.Title == "Смартфони").Id
                },
            };

            var subCategoriesOther = new List<SubCategory>
            {
                new SubCategory
                {
                    Title = "Одяг",
                    CategoryId = Categories.First(c => c.Title == "Інше").Id
                },
                new SubCategory
                {
                    Title = "Взуття",
                    CategoryId = Categories.First(c => c.Title == "Інше").Id
                },
                new SubCategory
                {
                    Title = "Аксесуари",
                    CategoryId = Categories.First(c => c.Title == "Інше").Id
                },
                new SubCategory
                {
                    Title = "Спортивне обладнання",
                    CategoryId = Categories.First(c => c.Title == "Інше").Id
                },
                new SubCategory
                {
                    Title = "Іграшки",
                    CategoryId = Categories.First(c => c.Title == "Інше").Id
                },
            };

            SubCategories.AddRange(subCategoriesHouseholdAppliances);
            SubCategories.AddRange(subCategoriesComputerEquipment);
            SubCategories.AddRange(subCategoriesSmartphones);
            SubCategories.AddRange(subCategoriesOther);

            SaveChanges();
        }
    }
}
