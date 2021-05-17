using ContractsBusiness;
using DataAccess;
using DataAccess.Entity;
using EntitysServices;
using InfraestructureContracts.DataAccessContract;
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
        public ProductBL(IFactoryMongo factoryMongo)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.ProductMongo);
        }

        public ResponseBase CreateProduct(ProductRequest product)
        {
            _DataAccessMongo.Create(product);
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
            _DataAccessMongo.Get(id);
            return ResponseSuccess();
        }
    }
}
