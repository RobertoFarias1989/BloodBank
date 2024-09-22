
namespace BloodBank.Core.ValueObjects;

public class Password : BaseValueObject
{
    public Password(string passwordValue)
    {
        PasswordValue = passwordValue;
    }

    public string PasswordValue { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PasswordValue;
    }
}
