using FluentValidation;

namespace Sample.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(p => p.Street).NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
        }
    }
}
