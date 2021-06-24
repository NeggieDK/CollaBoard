using CollaBoard.Core.Utility;
using CollaBoard.DAL.Repository;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CollaBoard.RealTime.Hubs
{
    public class RoomHub : Hub
    {
        private readonly RoomRepository _roomRepository;
        public RoomHub(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task JoinGroup(string groupId)
        {
            var room = await _roomRepository.GetOne(i => i.Id == Guid.Parse(groupId));
            var session = Context.GetHttpContext().GetSessionCookie();

            if (string.IsNullOrEmpty(session) || !room.Participants.Contains(session)) return;

            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            await Clients.Group(groupId).SendAsync("UpdateParticipants", room.Participants.Count);
        }

        public async Task AddCard(string columnId, string text)
        {

        }
    }
}
