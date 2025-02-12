using backend.AuthServices;
using backend.Models;
using backend.Repositories;
using Microsoft.VisualBasic;

namespace backend.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly IJwtConfiguration _jwtConfiguration;

    public AuthService(IAuthRepository repository, IJwtConfiguration jwtConfiguration)
    {
        _jwtConfiguration = jwtConfiguration;
        _repository = repository;
    }
    
    public async Task<ResultViewModel> Register(RegisterInputModel model)
    {
        model.Password = _jwtConfiguration.EncryptPassword(model.Password);

        var user = model.FromEntity();

        var result = await _repository.Register(user);

        if (result is null)
        {
            return ResultViewModel.Error("Usuário já existe");
        }
        
        return ResultViewModel.Success();
    }

    public async Task<ResultViewModel<string?>> Login(LoginInputModel model)
    {
        var encryptedPassword = _jwtConfiguration.EncryptPassword(model.Password);

        var result = await _repository.Login(model.Email, encryptedPassword);

        if (result is null)
        {
            return ResultViewModel<string?>.Error("Credenciais inválidas");
        }

        var token = _jwtConfiguration.GenerateJwtToken(model.Email, "user");
        
        return ResultViewModel<string?>.Success(token);
    }
}