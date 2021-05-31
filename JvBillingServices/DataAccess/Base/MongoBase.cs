using Utils.EnumResourse;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using EntitysServices.GlobalEntity;

namespace DataAccess.Base
{
    public class MongoBase<T>
    {
        public IMongoCollection<T> _collection;

        private readonly IMongoDatabase _database;

        public MongoBase(EnumMongo name, SecretSetting options)
        {
            string databaseName = Enum.GetName(typeof(EnumMongo), name).ToString().ToLower();
            var payment = new MongoClient(options.MongoDB);
            _database = payment.GetDatabase(databaseName);
        }

        public void collectionMongo(string name)
        {
            var collection = _database.GetCollection<T>(name);
            _collection = collection;
        }


    }
}
