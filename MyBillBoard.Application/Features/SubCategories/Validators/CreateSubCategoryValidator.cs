using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Features.SubCategories.Validators
{
    public class CreateSubCategoryValidator : AbstractValidator<CreateSubCategoryCommand>
    {
        public CreateSubCategoryValidator()
        {
            RuleFor(sc => sc.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Minimum 2 characters")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }
    }
}
