using MediatR;
using MyBillBoard.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Categories
{
    public record CreateCategoryCommand(string Title) : IRequest<Guid>;
}
