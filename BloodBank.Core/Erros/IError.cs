using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Erros
{
    public interface IError
    {
        //A palavra-chave init é usada para definir um tipo especial de acessador set
        //fazendo assim elas só podem ser iniciadas no construtor ou diretamente( public string Code { get; init; } = "Desta Forma")
        public string Code { get; init; }
        public string Message { get; init; }
    }
}
