using Microsoft.AspNetCore.SignalR;

namespace DotNetWorkspace.SignalR.WebAPI.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly List<string> Names = new();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task Send(string name)
        {
            Names.Add(name);
            await Clients.All.SendAsync("ReceiveName", name);
        }

        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames", Names);
        }

    }
}
