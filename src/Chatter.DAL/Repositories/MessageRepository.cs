using Chatter.Application.Contracts.Repositories;
using Chatter.Application.DataTransferObjects.Messages;
using Chatter.DAL.StoredProcedures.Messages;
using Quantum.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    internal class MessageRepository : IMessageRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public MessageRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<MessageModel> CreateAsync(CreateMessageModel model)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<MessageModel>(new SPCreateMessage
            {
                CreationTime = DateTime.Now, 
                SenderId = model.SenderId, 
                Text = model.Text
            });
        }

        public Task<int> DeleteAsync(long id)
        {
            return _procedureExecutor.ExecuteAsync(new SPDeleteMessage
            {
                Id = id
            });
        }

        public Task<ICollection<MessageModel>> GetAllAsync()
        {
            return _procedureExecutor.ExecuteWithListResponseAsync<MessageModel>(new SPGetMessages());
        }

        public Task<MessageModel> GetAsync(long id)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<MessageModel>(new SPGetMessage
            {
                Id = id
            });
        }

        public Task<int> UpdateAsync(long id, UpdateMessageModel model)
        {
            return _procedureExecutor.ExecuteAsync(new SPUpdateMessage
            {
                Id = id, 
                CreationTime = DateTime.Now, 
                Text = model.Text
            });
        }
    }
}
