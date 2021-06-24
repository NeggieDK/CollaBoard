using CollaBoard.Core.PersistenceModels;
using CollaBoard.DAL.Mongo;
using MongoDB.Driver;
using System;
using Xunit;

namespace CollaBoard.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var mongoConnection = new MongoDbConnection();
            var collection = mongoConnection.GetCollection<Room>();

            var room = new Room
            {
                Id = Guid.NewGuid(),
                Name = "TestRoom",
                HoursAlive = 32,
                CreatedAt = DateTime.Now
            };

            collection.InsertOne(room);

            var result = await collection.FindAsync<Room>(i => i.Name == "TestRoom");
            var roomDb = await result.FirstOrDefaultAsync();
            Assert.NotNull(roomDb);
        }
    }
}
