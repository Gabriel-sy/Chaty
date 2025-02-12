using backend.Models;

namespace backend.Services;

public interface IAuthService
{
    Task<ResultViewModel> Register(RegisterInputModel model);
    Task<ResultViewModel<string?>> Login(LoginInputModel model);
}