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

    public async Task<ResultViewModel> CreateChat(ChatInputModel model)
    {
        await _repository.CreateChat(model.User1, model.User2);
        
        return ResultViewModel.Success();
    }

    public async Task<ResultViewModel<List<Chat>>> GetUserChats(string username)
    {
        var user = await _userRepository.FindUserByUserName(username);

        if (user is not null)
        {
            var chats = await _repository.FindAllUserChats(user);
            return ResultViewModel<List<Chat>>.Success(chats);
        }
        
        return ResultViewModel<List<Chat>>.Error("Nenhum chat encontrado");
    }
}