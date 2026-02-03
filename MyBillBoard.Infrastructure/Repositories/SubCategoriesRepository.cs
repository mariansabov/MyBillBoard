using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Features.SubCategories.Dtos;
using MyBillBoard.Application.Interfaces;
using MyBillBoard.Domain.Entities;
using MyBillBoard.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Infrastructure.Repositories
{
    public class SubCategoriesRepository : ISubCategoriesRepository
    {
        private readonly MyDbContext _context;

        public SubCategoriesRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategoryDto>> GetAllSubCategoriesAsync()
        {
            return await _context.SubCategories
                .AsNoTracking()
                .Select(sc => new SubCategoryDto(sc.Id, sc.Title, sc.Category.Title, sc.CategoryId))
                .ToListAsync();
        }

        public async Task<Guid> CreateSubCategoryAsync(CreateSubCategoryRequest subCategory)
        {
            var subCategoryEntity = new SubCategory
            {
                Title = subCategory.Title,
                CategoryId = subCategory.CategoryId
            };

            await _context.SubCategories.AddAsync(subCategoryEntity);
            await _context.SaveChangesAsync();
            return subCategoryEntity.Id;
        }

        public async Task<Guid> UpdateSubCategoryAsync(Guid id, string title)
        {
            await _context.SubCategories
                .Where(sc => sc.Id == id)
                .ExecuteUpdateAsync(sc => sc
                    .SetProperty(sc => sc.Title, title)
                );
            return id;
        }

        public async Task<Guid> DeleteSubCategoryAsync(Guid id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory != null)
            {
                _context.SubCategories.Remove(subCategory);
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
