using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task<MessageModel> CreateAsync(CreateMessageModel model)
        {
            // Create message text validator (text.Length > 0)
            // check if chat exist
            // check if chat user exist
            // create message
            return _messageRepository.CreateAsync(model);
        }

        public Task DeleteAsync(long messageId)
        {
            return _messageRepository.DeleteAsync(messageId);
        }

        public Task<MessageModel> GetAsync(long messageId)
        {
            return _messageRepository.GetAsync(messageId);
        }

        public Task UpdateAsync(long id, UpdateMessageModel model)
        {
            // check if message exist
            // check if chat user exist
            // update message
            return _messageRepository.UpdateAsync(id, model);
        }

        public Task<ICollection<MessageModel>> GetAllAsync()
        {
            // надо передавать юзера чтобы проверить состоит ли он в чате 
            return _messageRepository.GetAllAsync();
        }
    }
}
