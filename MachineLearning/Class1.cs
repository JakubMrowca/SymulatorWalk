using System;
using Microsoft.ML;
using MongoDB.Driver;

namespace MachineLearning
{
    public class MongoDbConnection
    {
        private  IMongoDatabase _database;
        public void Open()
        {
            var client = new MongoClient();

            _database = client.GetDatabase("pokelife");
        }

        public IMongoCollection<T> GetMongoCollection<T>(string name)
        {
            var collection = _database.GetCollection<T>(name);
            return collection;
        }

        public void Close()
        {
        }
    }
}
