using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace UdemyClone.Hubs
{
    public class ChatHub : Hub
    {
        public  Task SendMessage(string message)
        {
            return  Clients.All.SendAsync(message);
        }
    }
}
