using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Categories
{
    public record GetCategoriesQuery : IRequest<List<CategoryDto>>;

    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMyDbContext _context;
        public GetCategoriesHandler(IMyDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
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
                .ToListAsync(cancellationToken);
        }
    }
}
