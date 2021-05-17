using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices;
namespace ContractsBusiness
{
    public interface IPaymentBL
    {
        ResponseBase CreatePayment(PaymentRequest payment);

        ResponseBase DeletePayment(int id);

        ResponseBase UpdatePayment(int id, PaymentRequest payment);

        ResponseBase GetPayment(int id);
        
    }
}
