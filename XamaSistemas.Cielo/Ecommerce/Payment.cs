using System.Collections.Generic;

namespace XamaSistemas.Cielo.Ecommerce
{
    public class Payment
    {
        public int ServiceTaxAmount { get; set; }
        public int Installments { get; }
        public string Interest { get; set; }
        public bool Capture { get; set; }
        public bool Authenticate { get; set; }
        public bool Recurrent { get; set; }
        public RecurrentPayment RecurrentPayment { get; set; }
        public CreditCard CreditCard { get; set; }
        public DebitCard DebitCard { get; set; }
        public string Tid { get; set; }
        public string ProofOfSale { get; set; }
        public string AuthorizationCode { get; set; }
        public string SoftDescriptor { get; set; }
        public string ReturnUrl { get; set; }
        public ProviderEnum Provider { get; set; }
        public string PaymentId { get; set; }
        public string Type { get; set; }
        public int Amount { get; }
        public string ReceivedDate { get; set; }
        public int CapturedAmount { get; set; }
        public string CapturedDate { get; set; }
        public CurrencyEnum Currency { get; set; }
        public string Country { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public int Status { get; set; }
        public IList<Link> Links { get; set; }
        public IList<string> ExtraDataCollection { get; set; }
        public string ExpirationDate { get; set; }
        public string Url { get; set; }
        public string Number { get; set; }
        public string BarCodeNumber { get; set; }
        public string DigitableLine { get; set; }
        public string Address { get; set; }
        public string BoletoNumber { get; set; }
        public string Assignor { get; set; }
        public string Demonstrative { get; set; }
        public string Identification { get; set; }
        public string Instructions { get; set; }
        public string AuthenticationUrl { get; set; }

        public Payment() { }

        public Payment(int amount)
        {
            Amount = amount;
            Installments = 1;
        }
        public Payment(int amount, int installments)
        {
            Amount = amount;
            Installments = installments;
        }
    }
}
