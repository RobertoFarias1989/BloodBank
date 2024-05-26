using System.Net.Mail;

namespace BloodBank.Core.ValueObjects;

public class CPF : BaseValueObject
{
    public CPF()
    {

    }
    public CPF(string number)
    {
        CPFNumber = number;
    }

    public string CPFNumber { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CPFNumber;
    }

}
