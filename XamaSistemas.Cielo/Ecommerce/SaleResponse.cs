using System.Collections.Generic;

namespace XamaSistemas.Cielo.Ecommerce
{
    public class SaleResponse
    {
        public string MerchantOrderId { get; set; }
        public string Status { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonMessage { get; set; }
        public string ProviderReturnCode { get; set; }
        public string ProviderReturnMessage { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public string AuthenticationUrl { get; set; }
        public IList<Link> Links { get; set; }

        public SaleResponse() {}

        public SaleResponse(string status, string reasonCode, string reasonMessage, string providerReturnCode, string providerReturnMessage, string returnCode, string returnMessage, IList<Link> links)
        {
            Status = status;
            ReasonCode = reasonCode;
            ReasonMessage = reasonMessage;
            ProviderReturnCode = providerReturnCode;
            ProviderReturnMessage = providerReturnMessage;
            ReturnCode = returnCode;
            ReturnMessage = returnMessage;
            Links = links;
        }
    }
}
