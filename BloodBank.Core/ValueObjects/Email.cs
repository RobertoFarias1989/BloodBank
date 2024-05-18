using System.Net;

namespace BloodBank.Core.ValueObjects
{
    public class Email : BaseValueObject
    {
        public Email(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException("EmailAddress must have a value", nameof(emailAddress));

            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
        }
    }
}
