using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyBillBoard.Application.Features.SubCategories
{
    public record UpdateSubCategoryCommand(
        Guid Id,
        string Title
    ) : IRequest<Guid>;

    public class UpdateSubCategoryHandler : IRequestHandler<UpdateSubCategoryCommand, Guid>
    {
        private readonly IMyDbContext _context;
        public UpdateSubCategoryHandler(IMyDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            await _context.SubCategories
                .Where(x => x.Id == request.Id)
                .ExecuteUpdateAsync(x => 
                    x.SetProperty(p => p.Title, request.Title), cancellationToken);

            return request.Id;
        }
    }
}
