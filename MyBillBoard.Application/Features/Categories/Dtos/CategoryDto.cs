using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Categories.Dtos
{
    public record CategoryDto(
        Guid Id,
        string Title,
        List<CategorySubCategoryDto> SubCategories);

    public record CategorySubCategoryDto(
        Guid Id,
        string Title);
}
