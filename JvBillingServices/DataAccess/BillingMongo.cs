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
using EntitysServices;

namespace DataAccess
{
    public class BillingMongo : MongoBase<BillingRequest>, IMongo
    {
        public BillingMongo(EnumMongo databaseName, SecretSetting options) : base(databaseName, options)
        {
            collectionMongo(nameof(Billing));
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<BillingRequest>.Filter.Eq(c => c.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<BillingRequest>.Filter.Eq(c => c.Id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var billing = (BillingRequest) entity;
                billing.Id = Get().Count + 1;

                await _collection.InsertOneAsync(billing);
                return true;
            }
            catch(Exception ex)
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
            var billing  = (BillingRequest) c;
            var filter = Builders<BillingRequest>.Filter.Eq(c => c.Id, id);
            var update = Builders<BillingRequest>.Update
                .Set(c => c.Id, billing.Id)
                .Set(c => c.Idclient, billing.Idclient)
                .Set(c => c.IdPayment, billing.IdPayment)
                .Set(c => c.IdOrder, billing.IdOrder);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        public List<object> GetDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
