using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.SubCategories
{
    public record DeleteSubCategoryCommand(Guid Id) : IRequest<Guid>;

    public class DeleteSubCategoryHandler : IRequestHandler<DeleteSubCategoryCommand, Guid>
    {
        private readonly IMyDbContext _context;

        public DeleteSubCategoryHandler(IMyDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(sc => sc.Id == request.Id, cancellationToken);

            if (subCategory != null)
            {
                _context.SubCategories.Remove(subCategory);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return request.Id;
        }
    }
}
