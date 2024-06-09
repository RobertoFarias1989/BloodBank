using BloodBank.Application.Commands.CreateDonation;
using FluentValidation;

namespace BloodBank.Application.Validators;

public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
{
    public CreateDonationCommandValidator()
    {
        RuleFor(dt => dt.QuantityML)
            .NotEmpty()
                 .WithMessage("QuantityML is required.")
            .NotNull()
                 .WithMessage("QuantityML is required.");

        RuleFor(dt => dt.IdDonor)
           .NotEmpty()
                .WithMessage("QuantityML is required.")
           .NotNull()
                .WithMessage("QuantityML is required.");
    }
}
