using Microsoft.AspNetCore.SignalR;

namespace Chatter.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
