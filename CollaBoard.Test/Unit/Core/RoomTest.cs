using CollaBoard.Core.PersistenceModels;
using CollaBoard.Test.Unit.Mocks;
using System;
using Xunit;

namespace CollaBoard.Test.Unit.Core
{
    public class RoomTest
    {
        [Fact]
        public void TimeRemaining_MinutesRemaining()
        {
            var mockCurrentDateTimeProvider = new MockCurrentDateTimeProvider();
            mockCurrentDateTimeProvider.SetCurrentDateTime(new DateTime(2021, 06, 10, 11, 23, 30));

            var room = new Room
            {
                CreatedAt = new DateTime(2021, 06, 10, 10, 43, 30),
                HoursAlive = 1
            };
            var timeRemaining = room.GetTimeRemaining(mockCurrentDateTimeProvider);
            Assert.Equal("20 minutes remaining", timeRemaining);
        }

        [Fact]
        public void TimeRemaining_HoursRemaining()
        {
            var mockCurrentDateTimeProvider = new MockCurrentDateTimeProvider();
            mockCurrentDateTimeProvider.SetCurrentDateTime(new DateTime(2021, 06, 11, 11, 23, 30));

            var room = new Room
            {
                CreatedAt = new DateTime(2021, 06, 10, 10, 43, 30),
                HoursAlive = 48
            };
            var timeRemaining = room.GetTimeRemaining(mockCurrentDateTimeProvider);
            Assert.Equal("23 hours remaining", timeRemaining);
        }

        [Fact]
        public void TimeRemaining_DaysRemaining()
        {
            var mockCurrentDateTimeProvider = new MockCurrentDateTimeProvider();
            mockCurrentDateTimeProvider.SetCurrentDateTime(new DateTime(2021, 06, 11, 10, 43, 30));

            var room = new Room
            {
                CreatedAt = new DateTime(2021, 06, 10, 10, 43, 30),
                HoursAlive = 48
            };
            var timeRemaining = room.GetTimeRemaining(mockCurrentDateTimeProvider);
            Assert.Equal("1 days remaining", timeRemaining);
        }

        [Fact]
        public void TimeRemaining_DaysRemaining_2()
        {
            var mockCurrentDateTimeProvider = new MockCurrentDateTimeProvider();
            mockCurrentDateTimeProvider.SetCurrentDateTime(new DateTime(2021, 07, 10, 10, 43, 30));

            var room = new Room
            {
                CreatedAt = new DateTime(2021, 06, 10, 10, 43, 30),
                HoursAlive = 1440
            };
            var timeRemaining = room.GetTimeRemaining(mockCurrentDateTimeProvider);
            Assert.Equal("30 days remaining", timeRemaining);
        }


        [Fact]
        public void TimeRemaining_MonthsRemaining()
        {
            var mockCurrentDateTimeProvider = new MockCurrentDateTimeProvider();
            mockCurrentDateTimeProvider.SetCurrentDateTime(new DateTime(2021, 07, 10, 10, 43, 30));

            var room = new Room
            {
                CreatedAt = new DateTime(2021, 06, 10, 10, 43, 30),
                HoursAlive = 1800
            };
            var timeRemaining = room.GetTimeRemaining(mockCurrentDateTimeProvider);
            Assert.Equal("1 months, 14 days remaining", timeRemaining);
        }
    }
}
