using System;

namespace CollaBoard.Core.Utility
{
    public class CurrentDateTimeProvider : ICurrentDateTimeProvider
    {
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
