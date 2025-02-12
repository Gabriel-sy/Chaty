using backend.Entities;
using backend.Models;
using backend.Repositories;

namespace backend.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _repository;
    private readonly IChatRepository _chatRepository;
    
    public MessageService(IMessageRepository repository, IChatRepository chatRepository)
    {
        _repository = repository;
        _chatRepository = chatRepository;
    }

    public async Task<ResultViewModel<List<MessageViewModel>>> GetAllMessagesFromAChat(ChatInputModel model)
    {
        var chat = await _chatRepository.FindChatByUsers(model.User1, model.User2);

        if (chat is not null)
        {
            var messages = await _repository.GetAllMessagesFromAChat(chat); 
            
            return ResultViewModel<List<MessageViewModel>>
                .Success(messages.Select(m => m.FromEntity()).ToList());
        }

        return ResultViewModel<List<MessageViewModel>>.Error("Chat não existe");

    }

    public Task<ResultViewModel> DeleteMessage(MessageInputModel model)
    {
        throw new NotImplementedException();
    }
}