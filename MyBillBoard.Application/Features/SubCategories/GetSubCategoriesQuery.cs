using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.SubCategories.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.SubCategories
{
    public record GetSubCategoriesQuery : IRequest<List<SubCategoryDto>>;

    public class GetSubCategoriesHandler : IRequestHandler<GetSubCategoriesQuery, List<SubCategoryDto>>
    {
        private readonly IMyDbContext _context;
        public GetSubCategoriesHandler(IMyDbContext context)
        {
            _context = context;
        }
        public async Task<List<SubCategoryDto>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.SubCategories
                .AsNoTracking()
                .Select(sc => new SubCategoryDto(
                    sc.Id,
                    sc.Title,
                    sc.Category.Title,
                    sc.CategoryId,
                    sc.Announcements
                        .Select(a => new AnnouncementSubCategoryDto(
                            a.Id,
                            a.Title,
                            a.Description,
                            a.Status ? "Active" : "Inactive")).ToList()))
                .ToListAsync(cancellationToken);
        }
    }
}
