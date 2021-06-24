namespace CollaBoard.Core.Models
{
    public class CreateRoom
    {
        public string Name { get; set; }
        public RoomHoursAlive TimeAlive { get; set; }
        public int MaxParticipants { get; set; }
    }
}
