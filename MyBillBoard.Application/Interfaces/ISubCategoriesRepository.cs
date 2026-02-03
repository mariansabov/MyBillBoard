using MyBillBoard.Application.Features.SubCategories.Dtos;
using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Application.Interfaces 
{ 
    public interface ISubCategoriesRepository
    {
        Task<Guid> CreateSubCategoryAsync(CreateSubCategoryRequest subCategory);
        Task<Guid> DeleteSubCategoryAsync(Guid id);
        Task<List<SubCategoryDto>> GetAllSubCategoriesAsync();
        Task<Guid> UpdateSubCategoryAsync(Guid id, string title);
    }
}