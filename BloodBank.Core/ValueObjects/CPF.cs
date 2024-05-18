using System.Net.Mail;

namespace BloodBank.Core.ValueObjects
{
    public class CPF : BaseValueObject
    {
        public CPF(string number)
        {
            if(!IsCPFValidate(number))
                throw new ArgumentException("CPF is a invalid number");


            CPFNumber = number;
        }

        public string CPFNumber { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CPFNumber;
        }

        public bool IsCPFValidate(string number)
        {
            if (number.Length > 11)
                return false;

            while (number.Length != 11)
                number = '0' + number;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (number[i] != number[0])
                    igual = false;

            if (igual || number == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(number[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

    }
}
