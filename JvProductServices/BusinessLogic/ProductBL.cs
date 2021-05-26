using ContractsBusiness;
using DataAccess;
using EntitysServices;
using EntitysServices.Dto;
using EntitysServices.GlobalEntity;
using InfraestructureContracts.DataAccessContract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;

namespace LogicsBusiness
{
    public class ProductBL : BaseBL, IProductBL
    {
        IFactoryMongo _factoryMongo;
        IMongo _DataAccessMongo;
        public ProductBL(IFactoryMongo factoryMongo, IOptions<SecretSetting> options)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.ProductMongo, options);
        }

        public ResponseBase CreateProduct(ProductRequest product)
        {
            int id = _DataAccessMongo.Get().GetAwaiter().GetResult().Count + 1;
            _DataAccessMongo.Create(new Product() { 
                id = id,
                Name = product.Name,
                State = product.State,
                Description = product.Description,
                Price = product.Price,
                Image =product.Image
            });
            return ResponseSuccess();
        }

        public ResponseBase DeleteProduct(int id)
        {
            _DataAccessMongo.Delete(id);
            return ResponseSuccess();
        }
        public ResponseBase UpdateProduct(int id, ProductRequest product)
        {
            
            _DataAccessMongo.Update(id, product);
            return ResponseSuccess();
        }
        public ResponseBase GetProduct(int id)
        {
            var product = _DataAccessMongo.Get(id).GetAwaiter().GetResult();
            return ResponseSuccess("OK",product);
        }

        public ResponseBase GetAllProduct()
        {
            var result = _DataAccessMongo.Get().GetAwaiter().GetResult();
            return ResponseSuccess("OK",result);
        }
    }
}
