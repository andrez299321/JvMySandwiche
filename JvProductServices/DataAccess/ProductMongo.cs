﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;
using InfraestructureContracts.DataAccessContract;
using DataAccess.Base;
using Utils.EnumResourse;

namespace DataAccess
{
    public class ProductMongo : MongoBase<Product>, IMongo
    {
        public ProductMongo(EnumMongo databaseName) : base(databaseName)
        {
        }

        public async Task<Object> Get(int id)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

       

        public async Task<bool> Delete(int id)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return (result.DeletedCount == 1);
        }

        public async Task<bool> Create(object entity)
        {
            try
            {
                var product = (Product) entity;
                await _collection.InsertOneAsync(product);
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
            var product  = (Product) c;
            var filter = Builders<Product>.Filter.Eq(c => c.id, id);
            var update = Builders<Product>.Update
                .Set(c => c.Name, product.Name)
                .Set(c => c.State, product.State);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        
    }
}