using backend.Entities;
using backend.Models;
using backend.Repositories;

namespace backend.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;

    public ChatService(IChatRepository repository, IUserRepository userRepository, IMessageRepository messageRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
    }

    public async Task<ResultViewModel> CreateChat(string username1, string username2)
    {
        var user1 = await _userRepository.FindUserByUserName(username1);
        var user2 = await _userRepository.FindUserByUserName(username2);
        
        await _repository.CreateChat(user1, user2);
        
        return ResultViewModel.Success();
    }

    public async Task<ResultViewModel<List<ChatViewModel>>> GetUserChats(string email)
    {
        var user = await _userRepository.FindUserByEmail(email);

        if (user is not null)
        {
            var userNames = await _repository.FindAllUserChats(user);
            return ResultViewModel<List<ChatViewModel>>.Success(userNames.Select(u => new ChatViewModel(u)).ToList());
        }
        
        return ResultViewModel<List<ChatViewModel>>.Error("Nenhum chat encontrado");
    }

    
}