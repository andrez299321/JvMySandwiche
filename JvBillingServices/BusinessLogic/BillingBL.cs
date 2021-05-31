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
    public class BillingBL : BaseBL, IBillingBL
    {
        IFactoryMongo _factoryMongo;
        IMongo _DataAccessMongo;
        IMongo _DataAccessDetailMongo;
        public BillingBL(IFactoryMongo factoryMongo, IOptions<SecretSetting> options)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.BillingMongo, options.Value);
        }

        public BillingBL(IFactoryMongo factoryMongo, SecretSetting options)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.BillingMongo, options);
        }

        public ResponseBase CreateBilling(BillingRequest billing)
        {
            int id = _DataAccessMongo.Get().Count + 1;
            var result = _DataAccessMongo.Create(billing).GetAwaiter().GetResult();
            if (!result) 
            {
                return ResponseError("Error a crear la factura");
            }

            return ResponseSuccess();
        }
        public ResponseBase GetBilling(int id)
        {
            var bill = (BillingRequest)_DataAccessMongo.Get(id).GetAwaiter().GetResult();
            return ResponseSuccess("OK", bill);
        }

        public ResponseBase GetBillingAll()
        {
            List<BillingRequest> response = new List<BillingRequest>();
            List<object> bills = _DataAccessMongo.Get();
            return ResponseSuccess("OK", bills);
        }

        public ResponseBase UpdateStateBilling(int id, BillingRequest billing)
        {
            var result = _DataAccessMongo.Update(id, billing).GetAwaiter().GetResult();
            if (!result)
            {
                return ResponseError("Error a crear la factura");
            }
            return ResponseSuccess();
        }
    }
}
