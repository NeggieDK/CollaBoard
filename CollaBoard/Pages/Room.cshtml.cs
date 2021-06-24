using System;
using System.Threading.Tasks;
using CollaBoard.Core.PersistenceModels;
using CollaBoard.Core.Utility;
using CollaBoard.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollaBoard.Pages
{
    public class RoomModel : PageModel
    {
        private readonly RoomRepository _roomRepository;
        private readonly ICurrentDateTimeProvider _currentDateTimeProvider;
        public RoomModel(RoomRepository roomRepository, ICurrentDateTimeProvider currentDateTimeProvider)
        {
            _roomRepository = roomRepository;
            _currentDateTimeProvider = currentDateTimeProvider;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int AmountParticipants { get; private set; }
        public string TimeRemaining { get; private set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var room = await _roomRepository.GetOne(i => i.Id == id);
            if (!await AllowRoomEntry(room, HttpContext.Session)) return RedirectToPage("./Index");

            Id = room.Id;
            Name = room.Name;
            AmountParticipants = room.Participants?.Count ?? 0;
            TimeRemaining = room.GetTimeRemaining(_currentDateTimeProvider);
            return Page();
        }

        public async Task<bool> AllowRoomEntry(Room room, ISession session)
        {
            if (DateTime.UtcNow.Subtract(room.CreatedAt).TotalHours >= room.HoursAlive) return false;

            var sessionId = GetSessionCookie();
            if (sessionId != null &&
                room.Participants.Contains(sessionId))
            {
                return true;
            }
            else if(room.Participants.Count < room.MaxParticipants)
            {
                var sessionGuid = Guid.NewGuid();
                HttpContext.Response.Cookies.Append("Session", sessionGuid.ToString());
                room.Participants.Add(sessionGuid.ToString());
                await _roomRepository.Update(i => i.Id == room.Id, room);
                return true;
            }

            return false;
        }

        private string GetSessionCookie()
        {
            if(HttpContext.Request.Cookies.TryGetValue("Session", out var value))
            {
                return value;
            }
            return null;
        }
    }
}
