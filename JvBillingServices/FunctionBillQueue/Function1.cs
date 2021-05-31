using System;
using DataAccess;
using EntitysServices;
using EntitysServices.GlobalEntity;
using InfraestructureContracts.DataAccessContract;
using LogicsBusiness;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FunctionBillQueue
{
    public static class FunctionBillBus
    {
        [FunctionName("FunctionBillBus")]
        public static void Run([ServiceBusTrigger("jvbillingservices", Connection = "AzureWebJobsMyServiceBus")]string myQueueItem, ILogger log)
        {
            if (string.IsNullOrEmpty(myQueueItem))
            {
                return;
            }

            try
            {
                IFactoryMongo factoryMongo = new FactoryMongo();
                var deserializedCapture = JsonConvert.DeserializeObject<BillingRequest>(myQueueItem);
                var settings = new SecretSetting()
                {
                    MongoDB = "mongodb+srv://javeriana:jave123@cluster0.h69mx.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
                };
                
                BillingBL obj = new BillingBL(factoryMongo, settings);
                obj.CreateBilling(deserializedCapture);

            }
            catch { 
            }
            

        }
    }
}
