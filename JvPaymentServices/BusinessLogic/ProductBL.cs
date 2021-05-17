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
    public class PaymentBL : BaseBL, IPaymentBL
    {
        IFactoryMongo _factoryMongo;
        IMongo _DataAccessMongo;
        public PaymentBL(IFactoryMongo factoryMongo, IOptions<SecretSetting> options)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.PaymentMongo, options);
        }

        public ResponseBase CreatePayment(PaymentRequest payment)
        {

            _DataAccessMongo.Create(new Payment() { 
                id = payment.Id,
                Name = payment.Name,
                State = payment.State
            });
            return ResponseSuccess();
        }

        public ResponseBase DeletePayment(int id)
        {
            _DataAccessMongo.Delete(id);
            return ResponseSuccess();
        }
        public ResponseBase UpdatePayment(int id, PaymentRequest payment)
        {
            
            _DataAccessMongo.Update(id, payment);
            return ResponseSuccess();
        }
        public ResponseBase GetPayment(int id)
        {
            _DataAccessMongo.Get(id);
            return ResponseSuccess();
        }
    }
}
