using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Donor.Commands.CreateDonor;

public class CreateDonorCommand : IRequest<Result<int>>
{
    public string? FullName { get; set; }
    public string? CPFNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? PasswordValue { get; set; }
    public string? Role { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Gender { get; set; }
    public double Weight { get; set; }
    public string? BloodType { get; set; }
    public string? RHFactor { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}
