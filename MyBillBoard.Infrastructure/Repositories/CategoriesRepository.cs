using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Categories.Dtos;
using MyBillBoard.Domain.Entities;
using MyBillBoard.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MyDbContext _context;

        public CategoriesRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryDto(
                    c.Id,
                    c.Title,
                    c.SubCategories
                        .Select(sc => new CategorySubCategoryDto(
                            sc.Id,
                            sc.Title
                        ))
                        .ToList()
                    ))
                .ToListAsync();
        }

        public async Task<Guid> CreateCategoryAsync(CreateCategoryRequest category)
        {
            var categoryEntity = new Category
            {
                Title = category.Title
            };
            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            return categoryEntity.Id;
        }

        public async Task<Guid> UpdateCategoryAsync(Guid id, string title)
        {
            await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(c => c.Title, title)
                );
            return id;
        }

        public async Task<Guid> DeleteCategoryAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
