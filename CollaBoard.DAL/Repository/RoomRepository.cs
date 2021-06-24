
using CollaBoard.Core.PersistenceModels;
using CollaBoard.DAL.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CollaBoard.DAL.Repository
{
    public class RoomRepository
    {
        private readonly IMongoCollection<Room> _collection;
        public RoomRepository(MongoDbConnection mongoDbRepository)
        {
            _collection = mongoDbRepository.GetCollection<Room>();
        }

        public async Task<List<Room>> Get(Expression<Func<Room, bool>> predicate)
        {
            var result =  await _collection.FindAsync<Room>(predicate);
            return await result.ToListAsync();
        }

        public async Task<Room> GetOne(Expression<Func<Room, bool>> predicate)
        {
            var result = await _collection.FindAsync<Room>(predicate);
            return await result.FirstOrDefaultAsync();
        }

        public Task Insert(Room room)
        {
            return _collection.InsertOneAsync(room);
        }

        public Task Update(Expression<Func<Room, bool>> predicate, Room room)
        {
            return _collection.ReplaceOneAsync<Room>(predicate, room);
        }
    }
}
