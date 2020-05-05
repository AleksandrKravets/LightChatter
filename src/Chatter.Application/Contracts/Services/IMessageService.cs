using Chatter.Application.DataTransferObjects.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IMessageService
    {
        Task<MessageModel> CreateAsync(CreateMessageModel message);
        Task UpdateAsync(long id, UpdateMessageModel message);
        Task DeleteAsync(long id);
        Task<MessageModel> GetAsync(long id);
        Task<ICollection<MessageModel>> GetAllAsync();
    }
}
