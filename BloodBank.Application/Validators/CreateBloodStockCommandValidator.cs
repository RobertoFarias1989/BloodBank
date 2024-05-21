using BloodBank.Application.Commands.CreateBloodStock;
using FluentValidation;

namespace BloodBank.Application.Validators;

public class CreateBloodStockCommandValidator : AbstractValidator<CreateBloodStockCommand>
{
    public CreateBloodStockCommandValidator()
    {
        RuleFor(bs => bs.QuantityML)
           .NotEmpty()
                .WithMessage("QuantityML is required.")
           .NotNull()
                .WithMessage("QuantityML is required.");

        RuleFor(d => d.RHFactor)
          .NotEmpty()
               .WithMessage("RHFactor is required.")
          .NotNull()
               .WithMessage("RHFactor is required.")
          .IsInEnum()
               .WithMessage("RHFactor must match with one of these type:Positive, Negative.");

        RuleFor(d => d.BloodType)
            .NotEmpty()
                .WithMessage("BloodType is required.")
            .NotNull()
                .WithMessage("BloodType is required.")
            .IsInEnum()
                .WithMessage("BloodType must match with one of these type: A, B, AB, O.");
    }
}
