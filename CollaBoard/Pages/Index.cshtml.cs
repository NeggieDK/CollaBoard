using CollaBoard.Core.Models;
using CollaBoard.Core.PersistenceModels;
using CollaBoard.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CollaBoard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RoomRepository _roomRepository;
        [BindProperty]
        public CreateRoom Room { get; set; }

        public IndexModel(ILogger<IndexModel> logger, RoomRepository roomRepository)
        {
            _logger = logger;
            _roomRepository = roomRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var sessionGuid = Guid.NewGuid();

            var room = new Room
            {
                Id = Guid.NewGuid(),
                Name = Room.Name,
                CreatedAt = DateTime.UtcNow,
                HoursAlive = Room.TimeAlive.ToHours(),
                MaxParticipants = Room.MaxParticipants
            };
            room.Participants.Add(sessionGuid.ToString());

            HttpContext.Response.Cookies.Append("Session", sessionGuid.ToString());

            await _roomRepository.Insert(room);
            return RedirectToPage("./Room", new { id = room.Id });
        }
    }

    
}
