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
    public class SalesOrderBL : BaseBL, ISalesOrderBL
    {
        IFactoryMongo _factoryMongo;
        IMongo _DataAccessMongo;
        IMongo _DataAccessDetailMongo;
        public SalesOrderBL(IFactoryMongo factoryMongo, IOptions<SecretSetting> options)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.SalesOrderMongo, options);
            _DataAccessDetailMongo = _factoryMongo.GetMongoObject(EnumMongo.SalesOrderDetailMongo, options);
        }

        public ResponseBase CreateSalesOrder(SalesOrderRequest salesOrder)
        {
            _DataAccessMongo.Create(salesOrder);
            return ResponseSuccess();
        }

        public ResponseBase DeleteSalesOrder(int id)
        {
            _DataAccessMongo.Delete(id);
            return ResponseSuccess();
        }
        public ResponseBase UpdateSalesOrder(int id, SalesOrderRequest salesOrder)
        {
            
            _DataAccessMongo.Update(id, salesOrder);
            return ResponseSuccess();
        }
        public ResponseBase GetSalesOrder(int id)
        {
            var response = _DataAccessMongo.Get(id).GetAwaiter().GetResult();

            
            return ResponseSuccess("OK",response);
        }

        public ResponseBase GetAllSalesOrder()
        {
            var response = _DataAccessMongo.Get().GetAwaiter().GetResult();

            return ResponseSuccess("OK", response);
        }
    }
}
