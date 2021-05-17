using Utils.EnumResourse;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public class MongoBase<T>
    {
        public readonly IMongoCollection<T> _collection; 
        public MongoBase(EnumMongo name)
        {
            string databaseName = Enum.GetName(typeof(EnumMongo), name).ToString().ToLower();
            var client = new MongoClient("mongodb+srv://javeriana:jave123@cluster0.h69mx.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<T>(nameof(T));
            _collection = collection;
        }
        
        
    }
}
