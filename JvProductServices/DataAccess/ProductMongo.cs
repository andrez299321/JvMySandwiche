﻿using MongoDB.Driver;
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
    public class ProductMongo : MongoBase<Product>, IMongo
    {
        public ProductMongo(EnumMongo databaseName, IOptions<SecretSetting> options) : base(databaseName,options)
        {
            collectionMongo(nameof(Product));
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
                var Product = (Product) entity;
                await _collection.InsertOneAsync(Product);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<object>> Get()
        {
            var Product = await _collection.Find(_ => true).ToListAsync();
            return Product;
        }
        

        public async Task<bool> Update(int id, object c)
        {
            var Product  = (Product) c;
            var filter = Builders<Product>.Filter.Eq(c => c.id, id);
            var update = Builders<Product>.Update
                .Set(c => c.Name, Product.Name)
                .Set(c => c.State, Product.State);
            var result = await _collection.UpdateOneAsync(filter, update);
            return (result.ModifiedCount == 1);
        }

        
    }
}
