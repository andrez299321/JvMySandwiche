using ContractsBusiness;
using DataAccess;
using DataAccess.Entity;
using EntitysServices;
using InfraestructureContracts.DataAccessContract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;
using Utils.GlobalEntity;

namespace LogicsBusiness
{
    public class BillingBL : BaseBL, IBillingBL
    {
        IFactoryMongo _factoryMongo;
        IMongo _DataAccessMongo;
        public BillingBL(IFactoryMongo factoryMongo, IOptions<SecretSetting> options)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.BillingMongo, options);
        }

        public ResponseBase CreateBilling(BillingRequest billing)
        {
            _DataAccessMongo.Create(billing);
            return ResponseSuccess();
        }

        public ResponseBase DeleteBilling(int id)
        {
            _DataAccessMongo.Delete(id);
            return ResponseSuccess();
        }
        public ResponseBase UpdateBilling(int id, BillingRequest billing)
        {
            
            _DataAccessMongo.Update(id, billing);
            return ResponseSuccess();
        }
        public ResponseBase GetBilling(int id)
        {
            _DataAccessMongo.Get(id);
            return ResponseSuccess();
        }
    }
}
