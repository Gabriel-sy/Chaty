using backend.Entities;
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

    public async Task<ResultViewModel<List<SearchUserViewModel>>> SearchUsersByUserName(string query)
    {
        var names = await _repository.FindUsersByUserName(query);

        return ResultViewModel<List<SearchUserViewModel>>
            .Success(names.Select(n => new SearchUserViewModel(n)).ToList());
    }
    
    public async Task<ResultViewModel> SendChatRequest(User sender, string receiver)
    {
        var receiverUser = await _repository.FindUserByUserName(receiver);

        if (receiverUser is null) return ResultViewModel.Error("Não foi possivel enviar a solicitação");
        
        await _repository.SendChatRequest(receiverUser, sender.UserName);
        return ResultViewModel.Success();

    }

    public async Task<ResultViewModel<User?>> FindUserByEmail(string email)
    {
        var user = await _repository.FindUserByEmail(email);

        return ResultViewModel<User?>.Success(user);
    }

    public async Task<ResultViewModel> RefuseChatRequest(User refuser, string nameToRemove)
    {
        await _repository.RefuseChatRequest(refuser, nameToRemove);
        
        return ResultViewModel.Success();
    }
}