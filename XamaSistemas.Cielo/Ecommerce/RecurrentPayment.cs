using System.Collections.Generic;

namespace XamaSistemas.Cielo.Ecommerce
{
    public class RecurrentPayment
    {
        public string RecurrentPaymentId { get; set; }
        public string NextRecurrency { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Interval { get; set; }
        public int Amount { get; set; }
        public string Country { get; set; }
        public string CreateDate { get; set; }
        public CurrencyEnum Currency { get; set; }
        public int CurrentRecurrencyTry { get; set; }
        public ProviderEnum Provider { get; set; }
        public int RecurrencyDay { get; set; }
        public int SuccessfulRecurrences { get; set; }
        public bool AuthorizeNow { get; set; }
        public int ReasonCode { get; set; }
        public string ReasonMessage { get; set; }
        public int Status { get; set; }
        public IList<Link> Links { get; set; }
        public IList<RecurrentTransaction> RecurrentTransactions { get; set; }

        public RecurrentPayment(bool authorizeNow)
        {
            AuthorizeNow = authorizeNow;
        }

    }
}