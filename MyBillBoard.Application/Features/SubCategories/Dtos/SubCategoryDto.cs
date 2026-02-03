namespace MyBillBoard.Application.Features.SubCategories.Dtos
{ 
    public record SubCategoryDto(
        Guid Id,
        string Title,
        string CategoryTitle,
        Guid CategoryId);
}
