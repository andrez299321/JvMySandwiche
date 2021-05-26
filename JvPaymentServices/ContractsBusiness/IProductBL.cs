using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices;
using EntitysServices.ExternalServices;

namespace ContractsBusiness
{
    public interface IPaymentBL
    {
        ResponseBase CreatePayment(CaptureAndAuthorize payment);

        ResponseBase DeletePayment(int id);

        ResponseBase UpdatePayment(int id, PaymentRequest payment);

        ResponseBase GetPayment(int id);
        
    }
}
