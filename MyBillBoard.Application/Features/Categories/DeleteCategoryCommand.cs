using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Categories
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<Guid>;

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Guid>
    {
        private readonly IMyDbContext _context;

        public DeleteCategoryHandler(IMyDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return request.Id;
        }
    }
}
