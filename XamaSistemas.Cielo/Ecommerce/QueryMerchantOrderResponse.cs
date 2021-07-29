using System.Collections.Generic;

namespace XamaSistemas.Cielo.Ecommerce
{
    public class QueryMerchantOrderResponse
    {
        public IList<Payment> Payments { get; set; }
    }
}