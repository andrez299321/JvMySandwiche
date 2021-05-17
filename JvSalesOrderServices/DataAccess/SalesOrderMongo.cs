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

namespace DataAccess
{
    public class SalesOrderMongo : MongoBase<SalesOrder>, IMongo
    {
        public SalesOrderMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName, options)
        {
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<SalesOrder>.Filter.Eq(c => c.id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<SalesOrder>.Filter.Eq(c => c.id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var salesOrder = (SalesOrder) entity;
                await _collection.InsertOneAsync(salesOrder);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<object>> Get()
        {
            var client = await _collection.Find(_ => true).ToListAsync();
            return client;
        }
        

        public async Task<bool> Update(int id, object c)
        {
            var salesOrder  = (SalesOrder) c;
            var filter = Builders<SalesOrder>.Filter.Eq(c => c.id, id);
            var update = Builders<SalesOrder>.Update
                .Set(c => c.Name, salesOrder.Name)
                .Set(c => c.State, salesOrder.State);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        
    }
}
