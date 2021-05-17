using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices;
namespace ContractsBusiness
{
    public interface ISalesOrderBL
    {
        ResponseBase CreateSalesOrder(SalesOrderRequest client);

        ResponseBase DeleteSalesOrder(int id);

        ResponseBase UpdateSalesOrder(int id, SalesOrderRequest salesOrder);

        ResponseBase GetSalesOrder(int id);
        
    }
}
