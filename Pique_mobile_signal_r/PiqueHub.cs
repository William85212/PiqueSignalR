using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Pique_mobile_signal_r
{
    public class PiqueHub : Hub
    {
        public Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task SendMessageToGroup(string groupeName, string user, string message)
        {
            return Clients.Group(groupeName).SendAsync("SendMessage", user, message);
        }
    }
}
