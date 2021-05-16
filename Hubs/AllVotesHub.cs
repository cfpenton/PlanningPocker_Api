using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace APIREST_PlanningPocker.Hubs
{

    public class AllVotesHub : Hub
    {

        public async Task SendVotes(object votes)
        {
            await Clients.All.SendAsync("ReceiveVotes", votes);
        }
    }
}