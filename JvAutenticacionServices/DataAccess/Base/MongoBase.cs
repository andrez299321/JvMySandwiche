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
        public readonly IMongoCollection<T> _collection; 
        public MongoBase(EnumMongo name, IOptions<SecretSetting> options)
        {
            string databaseName = Enum.GetName(typeof(EnumMongo), name).ToString().ToLower();
            var client = new MongoClient(options.Value.MongoDB);
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<T>(nameof(T));
            _collection = collection;
        }
        
        
    }
}
