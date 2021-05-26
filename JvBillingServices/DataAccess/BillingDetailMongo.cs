using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InfraestructureContracts.DataAccessContract;
using DataAccess.Base;
using Utils.EnumResourse;
using Microsoft.Extensions.Options;
using EntitysServices.Dto;
using EntitysServices.GlobalEntity;

namespace DataAccess
{
    public class BillingDetailMongo : MongoBase<BillingDetail>, IMongo
    {
        public BillingDetailMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName, options)
        {
            collectionMongo(nameof(BillingDetail));
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<BillingDetail>.Filter.Eq(c => c.IdBilling, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<BillingDetail>.Filter.Eq(c => c.id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var billing = (BillingDetail) entity;
                await _collection.InsertOneAsync(billing);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<object> Get()
        {
            var task = _collection.Find(_ => true).ToListAsync().GetAwaiter().GetResult();
            var result = new List<object>();
            foreach (var item in task)
            {
                result.Add(item);
            }
            return result;
        }
        

        public async Task<bool> Update(int id, object c)
        {
            var billing  = (BillingDetail) c;
            var filter = Builders<BillingDetail>.Filter.Eq(c => c.id, id);
            var update = Builders<BillingDetail>.Update
                .Set(c => c.id, billing.id)
                .Set(c => c.IdBilling, billing.IdBilling)
                .Set(c => c.IdProduct, billing.IdProduct)
                .Set(c => c.Price, billing.Price);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        public List<object> GetDetail(int id)
        {
            var filter = Builders<BillingDetail>.Filter.Eq(c => c.IdBilling, id);
            var task = _collection.Find(filter).ToListAsync().GetAwaiter().GetResult();
            var result = new List<object>();
            foreach (var item in task)
            {
                result.Add(item);
            }
            return result;
        }
    }
}
