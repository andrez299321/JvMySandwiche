using Utils.EnumResourse;
using InfraestructureContracts.DataAccessContract;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Utils.GlobalEntity;

namespace DataAccess
{
    public class FactoryMongo : IFactoryMongo
    {
        public IMongo GetMongoObject(EnumMongo type, IOptions<SecretSetting> options) 
        {
            switch (type) {
                case EnumMongo.BillingMongo :
                    return new BillingMongo(type, options);
                break;
                default:
                    return null;
                    break;
            }
        }
    }
}
