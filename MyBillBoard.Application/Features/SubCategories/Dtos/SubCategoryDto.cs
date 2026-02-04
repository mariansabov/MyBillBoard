namespace MyBillBoard.Application.Features.SubCategories.Dtos
{ 
    public record SubCategoryDto(
        Guid Id,
        string Title,
        string CategoryTitle,
        Guid CategoryId,
        List<AnnouncementSubCategoryDto> Announcements);

    public record AnnouncementSubCategoryDto(
        Guid Id,
        string Title,
        string Description,
        string Status);
}
