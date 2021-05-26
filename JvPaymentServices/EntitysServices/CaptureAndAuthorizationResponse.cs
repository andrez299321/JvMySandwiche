using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices
{
    public class additionalInfo
    {
        public string paymentNetwork { get; set; }
        public string rejectionType { get; set; }
        public string responseNetworkMessage { get; set; }
        public string travelAgencyAuthorizationCode { get; set; }
        public string cardType { get; set; }
        public string transactionType { get; set; }

    }
    public class extraParameters
    {
        public string BANK_REFERENCED_CODE { get; set; }
     
    }

    public class TransactionResponse
    {
        public string orderId { get; set; }
        public string transactionId { get; set; }
        public string state { get; set; }
        public string paymentNetworkResponseCode { get; set; }
        public string paymentNetworkResponseErrorMessage { get; set; }//
        public string trazabilityCode { get; set; }
        public string authorizationCode { get; set; }
        public string pendingReason { get; set; }//
        public string responseCode { get; set; }
        public string errorCode { get; set; }//
        public string responseMessage { get; set; }
        public string transactionDate { get; set; }//
        public string transactionTime { get; set; }//
        public long operationDate { get; set; }
        public string referenceQuestionnaire { get; set; }//
        public extraParameters extraParameters { get; set; }
        public additionalInfo additionalInfo { get; set; }
    }

    public class CaptureAndAuthorizationResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public TransactionResponse transactionResponse { get; set; }
    }
}
