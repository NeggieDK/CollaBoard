namespace CollaBoard.Core.Models
{
    public enum RoomHoursAlive
    {
        OneHour,
        FiveHours,
        OneDay,
        OneWeek,
        OneMonth,
        OneYear,
        Permanent
    }

    public static class RoomHoursAliveExtensions
    {
        public static int ToHours(this RoomHoursAlive roomHours)
        {
            return roomHours switch
            {
                RoomHoursAlive.OneHour => 1,
                RoomHoursAlive.FiveHours => 5,
                RoomHoursAlive.OneDay => 24,
                RoomHoursAlive.OneWeek => 168,
                RoomHoursAlive.OneMonth => 5208,
                RoomHoursAlive.OneYear => 8760,
                RoomHoursAlive.Permanent => 0,
                _ => 0
            };
        }
    }
}
