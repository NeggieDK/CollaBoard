using CollaBoard.Core.Utility;
using System;

namespace CollaBoard.Test.Unit.Mocks
{
    public class MockCurrentDateTimeProvider : ICurrentDateTimeProvider
    {
        private DateTime currentDateTime;
        public void SetCurrentDateTime(DateTime datetime)
        {
            currentDateTime = datetime;
        }
        public DateTime GetUtcNow()
        {
            return currentDateTime;
        }
    }
}
