using MediatR;

namespace BloodBank.Application.Commands.UpdateBloodStock;

public class UpdateBloodStockCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string BloodType { get; set; }
    public string RHFactor { get; set; }
    public int QuantityML { get; set; }
}
