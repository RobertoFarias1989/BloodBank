using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock;

public class CreateBloodStockCommand : IRequest<int>
{
    public string BloodType { get;  set; }
    public string RHFactor { get;  set; }
    public int QuantityML { get;  set; }
}
