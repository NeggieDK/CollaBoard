using CollaBoard.Core.Utility;
using System;
using System.Collections.Generic;

namespace CollaBoard.Core.PersistenceModels
{
    public class Room
    {
        public Room()
        {
            Participants = new List<string>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int HoursAlive { get; set; }
        public int MaxParticipants { get; set; }
        public List<string> Participants { get; set; }

        public string GetTimeRemaining(ICurrentDateTimeProvider currentDateTimeProvider)
        {
            var minutesLeft = (int)currentDateTimeProvider.GetUtcNow().Subtract(CreatedAt).TotalMinutes;
            var remaining = (HoursAlive * 60) - minutesLeft;
            if(remaining == 0)
            {
                return "Permanent";
            }
            else if (remaining < 60)
            {
                return $"{remaining} minutes remaining";
            }
            else if(remaining < 24 * 60)
            {
                return $"{remaining / 60} hours remaining";
            }
            else if (remaining < 31 * 24 * 60)
            {
                return $"{remaining / 24 / 60} days remaining";
            }
            else
            {
                return $"{(remaining / 24 / 31 / 60)} months, {(remaining / 24 / 60)% 31} days remaining";
            }
        }
    }
}
