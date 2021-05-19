using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;
using InfraestructureContracts.DataAccessContract;
using DataAccess.Base;
using Utils.EnumResourse;
using Utils.GlobalEntity;
using Microsoft.Extensions.Options;

namespace DataAccess
{
    public class ClientMongo : MongoBase<Client>, IMongo
    {
        public ClientMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName,options)
        {
            collectionMongo(nameof(Client));
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<Client>.Filter.Eq(c => c.id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<Client>.Filter.Eq(c => c.id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var client = (Client) entity;
                await _collection.InsertOneAsync(client);
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
            var client  = (Client) c;
            var filter = Builders<Client>.Filter.Eq(c => c.id, id);
            var update = Builders<Client>.Update
                .Set(c => c.Identification, client.Identification)
                .Set(c => c.Name, client.Name)
                .Set(c => c.LastName, client.LastName)
                .Set(c => c.Password, client.Password);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        
    }
}
