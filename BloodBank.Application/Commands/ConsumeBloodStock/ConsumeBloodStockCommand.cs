using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.ConsumeBloodStock;

public class ConsumeBloodStockCommand : IRequest<Result>
{
    public int Id { get;  set; }
    public int IdDonation { get;  set; }
    public int QuantityML { get;  set; }

}
