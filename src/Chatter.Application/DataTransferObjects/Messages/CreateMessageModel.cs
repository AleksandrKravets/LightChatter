namespace Chatter.Application.DataTransferObjects.Messages
{
    public class CreateMessageModel
    {
        public string Text { get; set; }
        public long SenderId { get; set; }
    }
}
