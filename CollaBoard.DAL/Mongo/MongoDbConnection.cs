﻿using MongoDB.Driver;

namespace CollaBoard.DAL.Mongo
{
    public class MongoDbConnection
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        public MongoDbConnection()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            _mongoDatabase = _mongoClient.GetDatabase("CollaBoard");
        }

        public IMongoClient GetClient()
        {
            return _mongoClient;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _mongoDatabase.GetCollection<T>(name);
        }
    }
}
