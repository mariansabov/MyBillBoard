using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.Categories
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Minimum 2 characters")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }
    }
}
