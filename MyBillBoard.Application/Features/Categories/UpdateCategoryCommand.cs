using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Application.Common.Interfaces;

namespace MyBillBoard.Application.Features.Categories
{
    public record UpdateCategoryCommand (
        Guid Id,
        string Title
    ) : IRequest<Guid>;

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Guid>
    {
        private readonly IMyDbContext _context;
        public UpdateCategoryHandler(IMyDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _context.Categories
                .Where(x => x.Id == request.Id)
                .ExecuteUpdateAsync(x => 
                    x.SetProperty(p => p.Title, request.Title), cancellationToken);

            return request.Id;
        }
    }
}
