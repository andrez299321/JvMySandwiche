using ContractsBusiness;
using DataAccess;
using EntitysServices;
using InfraestructureContracts.DataAccessContract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;
using EntitysServices.GlobalEntity;
using EntitysServices.Dto;
using InfraestructureContracts.ExternalServices;
using EntitysServices.ExternalServices;
using Newtonsoft.Json;
using Utils;

namespace LogicsBusiness
{
    public class PaymentBL : BaseBL, IPaymentBL
    {
        IFactoryMongo _factoryMongo;
        IMongo _DataAccessMongo;
        IPaymentExternalServices _paymentExternal;
        IOptions<SecretSetting> _options;
        public PaymentBL(IFactoryMongo factoryMongo, IOptions<SecretSetting> options, IPaymentExternalServices paymentExternal)
        {
            _paymentExternal = paymentExternal;
            _factoryMongo = factoryMongo;
            _options = options;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.PaymentMongo, options);
        }

        public ResponseBase CreatePayment(CaptureAndAuthorize payment)
        {
            string language = "es";
            string output = JsonConvert.SerializeObject(payment);
            var deserializedCapture = JsonConvert.DeserializeObject<CaptureAndAuthorizeExternalServices>(output);
            deserializedCapture.command = "SUBMIT_TRANSACTION";
            deserializedCapture.language = language;
            deserializedCapture.merchant = new Merchant() { apiKey = _options.Value.ApiKey, apiLogin = _options.Value.apiLogin };
            deserializedCapture.transaction.order.accountId = _options.Value.accountId;
            deserializedCapture.transaction.order.language = language;
            deserializedCapture.transaction.order.notifyUrl = "http://www.tes.com/confirmation";

            string signature = string.Format("{0}~{1}~{2}~{3}~{4}",
                _options.Value.ApiKey,
                _options.Value.merchantId,
                deserializedCapture.transaction.order.referenceCode,
                deserializedCapture.transaction.order.additionalValues.TX_VALUE.value,
                deserializedCapture.transaction.order.additionalValues.TX_VALUE.currency);
            signature = Security.GetMD5Hash(signature);
            deserializedCapture.transaction.order.signature = signature;
            deserializedCapture.transaction.extraParameters = new EntitysServices.ExternalServices.ExtraParameters() { INSTALLMENTS_NUMBER = 1 };
            deserializedCapture.transaction.type= "AUTHORIZATION_AND_CAPTURE";
            deserializedCapture.transaction.cookie = "pt1t38347bs6jc9ruv2ecpv7o2";
            deserializedCapture.transaction.threeDomainSecure = new EntitysServices.ExternalServices.ThreeDomainSecure()
            {
                embedded = false,
                eci = "02",
                cavv = "BwABBylVaQAAAAFwllVpAAAAAAA",
                xid = "Nmp3VFdWMlEwZ05pWGN3SGo4TDA",
                directoryServerTransactionId = "f38e6948-5388-41a6-bca4-b49723c19437"
            };

            string responsString =_paymentExternal.AuthorizationAndCapture(deserializedCapture);

            CaptureAndAuthorizationResponse response = JsonConvert.DeserializeObject<CaptureAndAuthorizationResponse>(responsString);

            _DataAccessMongo.Create(new Payment() { 
                idclient = payment.billing.Idclient,
                state = response.transactionResponse.state,
                transactionId = response.transactionResponse.transactionId,
                transactionTime = response.transactionResponse.transactionTime,
                observation = response.code
            });
            int idpayment = _DataAccessMongo.Get().Count;
            SendBus(idpayment, payment);


            return ResponseSuccess("OK", response);
        }
        private void SendBus(int idpayment, CaptureAndAuthorize paymen) 
        {
            paymen.billing.IdPayment = idpayment;

            string output = JsonConvert.SerializeObject(paymen.billing);
            BusAzure bill = new BusAzure(_options.Value.Bus,EnumBusQueu.jvbillingservices);
            bill.setBusAsync(output);

            BusAzure order = new BusAzure(_options.Value.Bus, EnumBusQueu.JvSalesOrderServices);
            order.setBusAsync(output);
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
