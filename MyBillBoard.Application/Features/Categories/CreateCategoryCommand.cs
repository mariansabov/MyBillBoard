using MediatR;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Categories.Dtos;
using MyBillBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Categories
{
    public record CreateCategoryCommand(string Title) : IRequest<Guid>;

    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IMyDbContext _context;

        public CreateCategoryHandler(IMyDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = new Category
            {
                Title = request.Title
            };

            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return categoryEntity.Id;
        }
    }
}
