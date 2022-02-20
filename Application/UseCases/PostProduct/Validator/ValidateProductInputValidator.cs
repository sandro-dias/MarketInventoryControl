using Application.UseCases.ValidateProduct.Input;
using FluentValidation;

namespace Application.UseCases.ValidateProduct.Validator
{
    public class ValidateProductInputValidator : AbstractValidator<ValidateProductInput>
    {
        public ValidateProductInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Brand)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.Quantity)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
