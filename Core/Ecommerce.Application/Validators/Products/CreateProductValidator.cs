using Ecommerce.Application.ViewModels.Products;
using FluentValidation;


namespace Ecommerce.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<CreateProductVM>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Please enter product name.")
                .MaximumLength(100)
                .MinimumLength(3)
                .WithMessage("Please enter the product name between 3 and 100 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().NotNull().WithMessage("Please enter product description.")
                .MaximumLength(250)
                .MinimumLength(15)
                .WithMessage("Please enter the product description between 15 and 250 characters.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please do not leave stock information blank.")
                .Must(s => s >= 0)
                .WithMessage("Stock number cannot be a negative number.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please do not leave price information blank.")
                .Must(s => s >= 0)
                .WithMessage("Price cannot be a negative number.");

        }
    }
}
