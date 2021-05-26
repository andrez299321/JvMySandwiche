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
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.BillingMongo, options);
            _DataAccessDetailMongo = _factoryMongo.GetMongoObject(EnumMongo.BillingDetailMongo, options);
        }

        public ResponseBase CreateBilling(BillingRequest billing)
        {
            int id = _DataAccessMongo.Get().Count + 1;
            var billingDto = new Billing()
            {
                id = id,
                Idclient = billing.Idclient,
                IdPayment = billing.IdPayment,
                State = billing.State,
                TypeToDelivery = billing.TypeToDelivery,
                TypeToPayment = billing.TypeToPayment
            };
            var result = _DataAccessMongo.Create(billingDto).GetAwaiter().GetResult();
            if (!result) 
            {
                return ResponseError("Error a crear la factura");
            }

            foreach (var item in billing.products)
            {
                var billingDetailDto = new BillingDetail()
                {
                    IdProduct = item.IdProduct,
                    Price = item.Price,
                    IdBilling = id
                };
                var resultDetail = _DataAccessDetailMongo.Create(billingDetailDto).GetAwaiter().GetResult();
                if (!result)
                {
                    return ResponseError("Error a crear la factura");
                }
            }

            return ResponseSuccess();
        }
        public ResponseBase GetBilling(int id)
        {
            var bill = (Billing)_DataAccessMongo.Get(id).GetAwaiter().GetResult();
            var result = new BillingRequest()
            {
                Id = bill.id,
                Idclient = bill.Idclient,
                IdPayment = bill.IdPayment,
                State = bill.State,
                TypeToDelivery = bill.TypeToDelivery,
                TypeToPayment = bill.TypeToPayment
            };
            var billDetail = _DataAccessDetailMongo.GetDetail(id);

            List<BillingProductRequest> obj = new List<BillingProductRequest>();

            foreach (BillingDetail item  in billDetail)
            {
                var aux = new BillingProductRequest()
                {
                    IdProduct = item.IdProduct,
                    Price = item.Price
                };
                obj.Add(aux);
                result.products = obj;
            }

            return ResponseSuccess("OK",result);
        }

        public ResponseBase GetBillingAll()
        {
            List<BillingRequest> response = new List<BillingRequest>();
            List<object> bills = _DataAccessMongo.Get();
            foreach (Billing bill in bills)
            {
                var result = new BillingRequest()
                {
                    Id = bill.id,
                    Idclient = bill.Idclient,
                    IdPayment = bill.IdPayment,
                    State = bill.State,
                    TypeToDelivery = bill.TypeToDelivery,
                    TypeToPayment = bill.TypeToPayment
                };
                List<object> billsDetail = _DataAccessDetailMongo.Get();

                List<BillingProductRequest> obj = new List<BillingProductRequest>();

                foreach (BillingDetail item in billsDetail)
                {
                    var aux = new BillingProductRequest()
                    {
                        IdProduct = item.IdProduct,
                        Price = item.Price
                    };
                    obj.Add(aux);
                    result.products = obj;
                }
                response.Add(result);
            }
            return ResponseSuccess("OK", response);
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
