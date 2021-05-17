using Utils.EnumResourse;
using InfraestructureContracts.DataAccessContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class FactoryMongo : IFactoryMongo
    {
        public IMongo GetMongoObject(EnumMongo type) 
        {
            switch (type) {
                case EnumMongo.ProductMongo :
                    return new ProductMongo(type);
                break;
                default:
                    return null;
                    break;
            }
        }
    }
}
