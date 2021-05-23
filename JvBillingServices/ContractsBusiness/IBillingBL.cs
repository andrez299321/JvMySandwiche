using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices;
namespace ContractsBusiness
{
    public interface IBillingBL
    {
        ResponseBase CreateBilling(BillingRequest client);

        ResponseBase UpdateStateBilling(int id, BillingRequest billing);

        ResponseBase GetBilling(int id);

        ResponseBase GetBillingAll();

    }
}
