using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.BloodStock.Commands.UpdateBloodStock;

public class UpdateBloodStockCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string BloodType { get; set; }
    public string RHFactor { get; set; }
    public int QuantityML { get; set; }
}
