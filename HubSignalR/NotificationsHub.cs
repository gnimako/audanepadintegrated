using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace AUDANEPAD_Integrated.HubSignalR
{
    public class NotificationsHub: Hub
    {
        public async Task SendNotification(string msgcount)
        {
            await Clients.All.SendAsync("ReceiveNotification", msgcount);
        }
        
    }
}