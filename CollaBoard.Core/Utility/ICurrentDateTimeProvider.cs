using System;

namespace CollaBoard.Core.Utility
{
    public interface ICurrentDateTimeProvider
    {
        DateTime GetUtcNow();
    }
}