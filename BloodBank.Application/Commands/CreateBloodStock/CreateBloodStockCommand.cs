using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock;

public class CreateBloodStockCommand : IRequest<Result<int>>
{
    public string BloodType { get;  set; }
    public string RHFactor { get;  set; }
    public int QuantityML { get;  set; }
    public int IdDonation { get;  set; }
}
