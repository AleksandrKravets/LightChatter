using Chatter.Application.DataTransferObjects.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IMessageRepository
    {
        Task<MessageModel> GetAsync(long id);
        Task<ICollection<MessageModel>> GetAllAsync();
        Task<MessageModel> CreateAsync(CreateMessageModel model);
        Task<int> UpdateAsync(long id, UpdateMessageModel model);
        Task<int> DeleteAsync(long id);
    }
}
