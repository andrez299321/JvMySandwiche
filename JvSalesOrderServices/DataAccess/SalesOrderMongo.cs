using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;
using InfraestructureContracts.DataAccessContract;
using DataAccess.Base;
using Utils.EnumResourse;
using Microsoft.Extensions.Options;
using Utils.GlobalEntity;
using EntitysServices;

namespace DataAccess
{
    public class SalesOrderMongo : MongoBase<SalesOrderRequest>, IMongo
    {
        public SalesOrderMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName, options)
        {
            collectionMongo(nameof(SalesOrder));
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<SalesOrderRequest>.Filter.Eq(c => c.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<SalesOrderRequest>.Filter.Eq(c => c.Id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var salesOrder = (SalesOrderRequest) entity;
                salesOrder.Id = Get().GetAwaiter().GetResult().Count+1;
                var result = _collection.InsertOneAsync(salesOrder);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<object>> Get()
        {
            var sales = await _collection.Find(_ => true).ToListAsync();
            var result = new List<object>();
            foreach (var item in sales)
            {
                result.Add(item);
            }
            return result;
        }
        

        public async Task<bool> Update(int id, object c)
        {
            var salesOrder  = (SalesOrderRequest) c;
            var filter = Builders<SalesOrderRequest>.Filter.Eq(c => c.Id, id);
            var update = Builders<SalesOrderRequest>.Update
                .Set(c => c.Name, salesOrder.Name)
                .Set(c => c.State, salesOrder.State);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        
    }
}
