using MediatR;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.SubCategories
{
    public record CreateSubCategoryCommand(
        string Title,
        Guid CategoryId) : IRequest<Guid>;

    public class CreateSubCategoryHandler : IRequestHandler<CreateSubCategoryCommand, Guid>
    {
        private readonly IMyDbContext _context;

        public CreateSubCategoryHandler(IMyDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var subCategoryEntity = new SubCategory
            {
                Title = request.Title,
                CategoryId = request.CategoryId
            };

            await _context.SubCategories.AddAsync(subCategoryEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return subCategoryEntity.Id;
        }
    }
}
