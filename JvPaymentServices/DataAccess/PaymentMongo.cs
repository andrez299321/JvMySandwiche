using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfraestructureContracts.DataAccessContract;
using DataAccess.Base;
using Utils.EnumResourse;
using Microsoft.Extensions.Options;
using EntitysServices.Dto;
using EntitysServices.GlobalEntity;

namespace DataAccess
{
    public class PaymentMongo : MongoBase<Payment>, IMongo
    {
        public PaymentMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName,options)
        {
            collectionMongo(nameof(Payment));
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<Payment>.Filter.Eq(c => c.id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<Payment>.Filter.Eq(c => c.id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var payment = (Payment) entity;
                await _collection.InsertOneAsync(payment);
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
            var payment  = (Payment) c;
            var filter = Builders<Payment>.Filter.Eq(c => c.id, id);
            var update = Builders<Payment>.Update
                .Set(c => c.idclient, payment.idclient)
                .Set(c => c.transactionId, payment.transactionId)
                .Set(c => c.transactionTime, payment.transactionTime)
                .Set(c => c.observation, payment.observation)
                .Set(c => c.state, payment.state);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        
    }
}
