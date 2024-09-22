using BloodBank.Application.Login.ViewModels;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using BloodBank.Core.Services;
using MediatR;

namespace BloodBank.Application.Login.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public LoginCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<Result<LoginViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //faço o hash da senha
        var passwordHash = _authService.ComputeSha256Hash(request.PasswordValue!);

        // busco um Donor pelo email e senha
        var donor = await _unitOfWork.DonorRepository.GetDonorByEmailAndPassword(request.EmailAddress!, passwordHash);

        // se não existir lanço um erro
        if (donor == null)
            return Result.Fail<LoginViewModel>(DonorErrors.NotFound);

        //Se existir gero o token
        var token = _authService.GenerateJwtToken(donor.Email.EmailAddress, donor.Role);


        return Result.Ok(new LoginViewModel(donor.Email.EmailAddress, token));


    }
}
