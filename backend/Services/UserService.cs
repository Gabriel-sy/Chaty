using backend.Models;
using backend.Repositories;

namespace backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<string>>> SearchUsersByUserName(string query)
    {
        var names = await _repository.FindUsersByUserName(query);

        return ResultViewModel<List<string>>.Success(names);
    }
}