using Microsoft.AspNetCore.SignalR;

namespace DotNetWorkspace.SignalR.WebAPI.Hubs;

public class ChatHub : Hub
{
    private static readonly Dictionary<string, string> UserConnectionMap = new();
    private static int _clientCount;

    public async Task SendMessage(string username, string message)
    {
        var connectionId = GetConnectionIdByUsername(username);

        if (connectionId is null)
        {
            UserConnectionMap.Add(username, Context.ConnectionId);
        }
        else if (connectionId != Context.ConnectionId)
        {
            await SendWarningToCaller("This username is in use.");
            return;
        }

        await Clients.All.SendAsync("ReceiveMessage", username, message);
    }

    public async Task SendClientCount(int count)
    {
        await Clients.All.SendAsync("ReceiveClientCount", count);
    }

    public async Task SendWarningToCaller(string message)
    {
        await Clients.Caller.SendAsync("ReceiveWarning", message);
    }

    public override async Task OnConnectedAsync()
    {
        await SendClientCount(++_clientCount);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        RemoveUserByConnectionId(Context.ConnectionId);
        await SendClientCount(--_clientCount);
        await base.OnDisconnectedAsync(exception);
    }

    private static void RemoveUserByConnectionId(string connectionId)
    {
        var username = UserConnectionMap.FirstOrDefault(x => x.Value == connectionId).Key;
        if (username is not null)
            UserConnectionMap.Remove(username);
    }

    private static string? GetConnectionIdByUsername(string username)
    {
        return UserConnectionMap.TryGetValue(username, out var connectionId) ? connectionId : null;
    }
}