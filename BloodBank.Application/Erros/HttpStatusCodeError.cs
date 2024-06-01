using BloodBank.Core.Erros;
using System.Net;

namespace BloodBank.Application.Erros;

public record HttpStatusCodeError(string Code, string Message, HttpStatusCode StatusCode) : IError
{
    public HttpStatusCodeError(IError error, HttpStatusCode StatusCode)
        : this(error.Code, error.Message, StatusCode) { }
}
