using System;

namespace Chatter.Application.DataTransferObjects.Messages
{
    public class MessageModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long SenderId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
