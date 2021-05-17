using Utils.EnumResourse;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Utils.GlobalEntity;

namespace DataAccess.Base
{
    public class MongoBase<T>
    {
        public readonly IMongoCollection<T> _collection; 
        public MongoBase(EnumMongo name, IOptions<SecretSetting> options)
        {
            string databaseName = Enum.GetName(typeof(EnumMongo), name).ToString().ToLower();
            var product = new MongoClient(options.Value.MongoDB);
            var database = product.GetDatabase(databaseName);
            var collection = database.GetCollection<T>(nameof(T));
            _collection = collection;
        }
        
        
    }
}
