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
    public class BillingMongo : MongoBase<Billing>, IMongo
    {
        public BillingMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName, options)
        {
            collectionMongo(nameof(Billing));
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<Billing>.Filter.Eq(c => c.id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<Billing>.Filter.Eq(c => c.id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var billing = (Billing) entity;
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
            var billing  = (Billing) c;
            var filter = Builders<Billing>.Filter.Eq(c => c.id, id);
            var update = Builders<Billing>.Update
                .Set(c => c.id, billing.id)
                .Set(c => c.Idclient, billing.Idclient)
                .Set(c => c.IdPayment, billing.IdPayment)
                .Set(c => c.State, billing.State)
                .Set(c => c.TypeToPayment, billing.TypeToPayment)
                .Set(c => c.TypeToDelivery, billing.TypeToDelivery);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        public List<object> GetDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
