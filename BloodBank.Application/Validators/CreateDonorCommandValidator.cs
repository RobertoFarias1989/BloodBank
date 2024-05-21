using BloodBank.Application.Commands.CreateDonor;
using FluentValidation;

namespace BloodBank.Application.Validators;

public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
{
	public CreateDonorCommandValidator()
	{

        RuleFor(d => d.FullName)
            .NotEmpty()
                .WithMessage("FullName is required.")
            .NotNull()
                .WithMessage("FullName is required.")
            .MaximumLength(150)
                .WithMessage("FullName's maximum length is around 150 characters.");

        RuleFor(d => d.CPFNumber)
            .NotEmpty()
                .WithMessage("CPFNumber is required.")
            .NotNull()
                .WithMessage("CPFNumber is required.")
            .MaximumLength(11)
                .WithMessage("CPFNumber's maximum length is around 11 characters.")
             .Must(IsCPFValidate)
                .WithMessage("A valid CPFNumber is required.");

        RuleFor(d => d.EmailAddress)
             .NotEmpty()
                .WithMessage("EmailAddress is required.")
            .NotNull()
                .WithMessage("EmailAddress is required.")
            .EmailAddress()
                .WithMessage("A valid email address is required.")
            .MaximumLength(100)
                .WithMessage("EmailAddress's maximum length is around 100 characters.");

        RuleFor(d => d.Gender)
          .NotEmpty()
               .WithMessage("Gender is required.")
          .NotNull()
               .WithMessage("Gender is required.")
          .IsInEnum()
               .WithMessage("Gender must match with one of these type: Male, Female, Other.");

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

        RuleFor(d => d.Street)
            .NotEmpty()
               .WithMessage("Street is required.")
           .NotNull()
               .WithMessage("Street is required.")
           .MaximumLength(100)
               .WithMessage("Street's maximum length is around 100 characters.");

        RuleFor(d => d.City)
           .NotEmpty()
              .WithMessage("City is required.")
          .NotNull()
              .WithMessage("City is required.")
          .MaximumLength(100)
              .WithMessage("City's maximum length is around 100 characters.");

        RuleFor(d => d.State)
           .NotEmpty()
              .WithMessage("State is required.")
  .        NotNull()
              .WithMessage("State is required.")
  .        MaximumLength(100)
              .WithMessage("State's maximum length is around 100 characters.");

        RuleFor(d => d.PostalCode)
            .NotEmpty()
               .WithMessage("PostalCode is required.")
            .NotNull()
               .WithMessage("PostalCode is required.")
            .MaximumLength(100)
               .WithMessage("PostalCode's maximum length is around 100 characters.");

        RuleFor(d => d.Country)
            .NotEmpty()
               .WithMessage("Country is required.")
            .NotNull()
               .WithMessage("Country is required.")
            .MaximumLength(50)
               .WithMessage("Country's maximum length is around 50 characters.");

    }

    public bool IsCPFValidate(string number)
    {
        if (number.Length > 11)
            return false;

        while (number.Length != 11)
            number = '0' + number;

        var igual = true;
        for (var i = 1; i < 11 && igual; i++)
            if (number[i] != number[0])
                igual = false;

        if (igual || number == "12345678909")
            return false;

        var numeros = new int[11];

        for (var i = 0; i < 11; i++)
            numeros[i] = int.Parse(number[i].ToString());

        var soma = 0;
        for (var i = 0; i < 9; i++)
            soma += (10 - i) * numeros[i];

        var resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0)
                return false;
        }
        else if (numeros[9] != 11 - resultado)
            return false;

        soma = 0;
        for (var i = 0; i < 10; i++)
            soma += (11 - i) * numeros[i];

        resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0)
                return false;
        }
        else if (numeros[10] != 11 - resultado)
            return false;

        return true;
    }
}
