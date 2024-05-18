using System;
using System.Text.RegularExpressions;

namespace BloodBank.Core.ValueObjects
{
    public class Name : BaseValueObject
    {
        public Name(string fullName)
        {
            //validação no fluent validation tirar da classe
            if (string.IsNullOrEmpty(fullName) || fullName.Length > 50)
                throw new ArgumentException("fullName must have a value and your max's lenght is 150 characters.", nameof(fullName));

            // Verificar se o nome contém caracteres especiais ou dígitos
            if (Regex.IsMatch(fullName, @"[^a-zA-Z\s]"))
                throw new ArgumentException("Special characters or digits found in the name.", nameof(fullName));

            FullName = fullName;
         
        }

        public string FullName { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FullName;
        }
    }
}
