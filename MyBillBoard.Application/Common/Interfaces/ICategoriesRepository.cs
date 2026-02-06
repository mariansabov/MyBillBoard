using MyBillBoard.Application.Features.Categories.Dtos;
using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Application.Common.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Guid> CreateCategoryAsync(CreateCategoryRequest category);
        Task<Guid> DeleteCategoryAsync(Guid id);
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<Guid> UpdateCategoryAsync(Guid id, string title);
    }
}