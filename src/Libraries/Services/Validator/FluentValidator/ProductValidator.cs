using FluentValidation;
using Models.DbEntities;

namespace Services.Validator.FluentValidator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("must be populated in for Product  of type 'ProductName'");
        }
    }
}
