using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices;
namespace ContractsBusiness
{
    public interface IBillingBL
    {
        ResponseBase CreateBilling(BillingRequest client);

        ResponseBase DeleteBilling(int id);

        ResponseBase UpdateBilling(int id, BillingRequest billing);

        ResponseBase GetBilling(int id);
        
    }
}
