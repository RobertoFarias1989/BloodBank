using BloodBank.Application.Commands.UpdateDonation;
using FluentValidation;

namespace BloodBank.Application.Validators;

public class UpdateDonationCommandValidator : AbstractValidator<UpdateDonationCommand>
{
    public UpdateDonationCommandValidator()
    {
        RuleFor(dt => dt.QuantityML)
           .NotEmpty()
                .WithMessage("QuantityML is required.")
           .NotNull()
                .WithMessage("QuantityML is required.");
    }
}
