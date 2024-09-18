using BloodBank.Application.Donation.Commands.CreateDonation;
using FluentValidation;

namespace BloodBank.Application.Donation.Validators;

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
