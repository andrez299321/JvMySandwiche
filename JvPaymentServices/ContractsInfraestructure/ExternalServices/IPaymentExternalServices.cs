using EntitysServices.ExternalServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraestructureContracts.ExternalServices
{
    public interface IPaymentExternalServices
    {
        string AuthorizationAndCapture(CaptureAndAuthorizeExternalServices capture);


    }
}
