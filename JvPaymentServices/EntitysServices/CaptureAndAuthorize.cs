using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


    public class TXVALUE
    {
        public int value { get; set; }
        public string currency { get; set; }
    }

    public class AdditionalValues
    {
        public TXVALUE TX_VALUE { get; set; }
        public TXVALUE TX_TAX { get; set; }
        public TXVALUE TX_TAX_RETURN_BASE { get; set; }
    }
    public class ShippingAddress
    {
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
    }

    public class Buyer
    {
        public string merchantBuyerId { get; set; }
        public string fullName { get; set; }
        public string emailAddress { get; set; }
        public string contactPhone { get; set; }
        public string dniNumber { get; set; }
        public ShippingAddress shippingAddress { get; set; }
    }

    public class Order
    {
        //public string accountId { get; set; }
        public string referenceCode { get; set; }
        public string description { get; set; }
        
        //public string language { get; set; }
        //public string signature { get; set; }
        //public string notifyUrl { get; set; }
        public AdditionalValues additionalValues { get; set; }
        public Buyer buyer { get; set; }
        public ShippingAddress shippingAddress { get; set; }
    }

    public class Payer
    {
        public string merchantPayerId { get; set; }
        public string fullName { get; set; }
        public string emailAddress { get; set; }
        public string contactPhone { get; set; }
        public string dniNumber { get; set; }
        public ShippingAddress shippingAddress { get; set; }
    }

    public class CreditCard
    {
        //public bool processWithoutCvv2 { get; set; }
        public string number { get; set; }
        public string securityCode { get; set; }
        public string expirationDate { get; set; }
        public string name { get; set; }
    }

    public class ExtraParameters
    {
        public int INSTALLMENTS_NUMBER { get; set; }
    }

    public class MonthsWithoutInterest
    {
        public string months { get; set; }
        public string bank { get; set; }
    }

    public class Transaction
    {
        public Order order { get; set; }
        public Payer payer { get; set; }
        public CreditCard creditCard { get; set; }
        //public ExtraParameters extraParameters { get; set; }
        public string type { get; set; }
        public string paymentMethod { get; set; }
        public string paymentCountry { get; set; }
        public string deviceSessionId { get; set; }
        public string ipAddress { get; set; }
        //public string cookie { get; set; }
        public string userAgent { get; set; }
        //public MonthsWithoutInterest monthsWithoutInterest { get; set; }
    }

    public class CaptureAndAuthorize
    {
        //public bool test { get; set; }
        //public string language { get; set; }
       // public string command { get; set; }
        //public Merchant merchant { get; set; }
        public Transaction transaction { get; set; }

        public BillingRequest billing { get; set; }
    }


}
