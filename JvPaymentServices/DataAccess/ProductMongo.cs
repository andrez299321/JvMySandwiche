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
    public class PaymentMongo : MongoBase<Payment>, IMongo
    {
        public PaymentMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName,options)
        {
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

        public async Task<IEnumerable<object>> Get()
        {
            var payment = await _collection.Find(_ => true).ToListAsync();
            return payment;
        }
        

        public async Task<bool> Update(int id, object c)
        {
            var payment  = (Payment) c;
            var filter = Builders<Payment>.Filter.Eq(c => c.id, id);
            var update = Builders<Payment>.Update
                .Set(c => c.Name, payment.Name)
                .Set(c => c.State, payment.State);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        
    }
}
