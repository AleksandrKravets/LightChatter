using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<MessageModel> CreateAsync(CreateMessageModel model)
        {
            if(model.Text.Length == 0) // Create message text validator (text.Length > 0)
                return null;

            var user = await _userRepository.GetAsync(model.SenderId);

            if(user == null)
                return null;

            return await _messageRepository.CreateAsync(model);
        }

        public Task DeleteAsync(long messageId)
        {
            return _messageRepository.DeleteAsync(messageId);
        }

        public Task<MessageModel> GetAsync(long messageId)
        {
            return _messageRepository.GetAsync(messageId);
        }

        public Task UpdateAsync(long id, UpdateMessageModel model) // update this action 
        {
            // where senderId = userId(from front) and messageId = messageId(from front)
            return _messageRepository.UpdateAsync(id, model);
        }

        public Task<ICollection<MessageModel>> GetAllAsync()
        {
            return _messageRepository.GetAllAsync();
        }
    }
}
