using System;
using DataAccess;
using EntitysServices;
using InfraestructureContracts.DataAccessContract;
using LogicsBusiness;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Utils.EnumResourse;
using Utils.GlobalEntity;

namespace FunctionSalesOrder
{
    public static class FunctionSalesOrder
    {
        [FunctionName("FunctionSalesOrder")]
        public static void Run([ServiceBusTrigger("jvsalesorderservices", Connection = "AzureWebJobsMyServiceBus")]string myQueueItem, ILogger log)
        {
            if (string.IsNullOrEmpty(myQueueItem))
            {
                return;
            }

            try
            {
                int idSalesOrder = Convert.ToInt32(myQueueItem);
                IFactoryMongo factoryMongo = new FactoryMongo();
                var settings = new SecretSetting()
                {
                    MongoDB = "mongodb+srv://javeriana:jave123@cluster0.h69mx.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
                };

                SalesOrderBL obj = new SalesOrderBL(factoryMongo, settings);
                var sales = obj.GetSalesOrder(idSalesOrder);
                if (sales != null ) {
                    var result =(SalesOrderRequest) sales.Data;
                    result.State = EnumState.close;
                    obj.UpdateSalesOrder(idSalesOrder, result);
                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}
