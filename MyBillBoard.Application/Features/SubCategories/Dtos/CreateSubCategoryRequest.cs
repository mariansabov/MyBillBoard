namespace MyBillBoard.Application.Features.SubCategories.Dtos
{ 
    public record CreateSubCategoryRequest(
        string Title,
        Guid CategoryId);
}
