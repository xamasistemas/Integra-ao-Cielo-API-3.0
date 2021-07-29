using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace XamaSistemas.Cielo.Ecommerce.request
{
    public class UpdateSaleRequest : AbstractSaleRequest<SaleResponse, string>
    {
        private readonly IEnvironment _environment;
        private readonly string _type;
        private int? amount;
        private int? serviceTaxAmount;

        public UpdateSaleRequest(string type, IEnvironment environment, HttpClient httpClient) : base(httpClient)
        {
            _environment = environment;
            _type = type;
        }

        public override async Task<SaleResponse> ExecuteAsync(string paymentId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (amount != null)
                parameters.Add("amount", amount.ToString());

            if (serviceTaxAmount != null)
                parameters.Add("serviceTaxAmount", serviceTaxAmount.ToString());

            var urlParams = HttpUtility.UrlEncode(string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}")));
            var url = $"{_environment.GetApiURL()}1/sales/{paymentId}/{_type}?{urlParams}";

            var request = await SendRequestAsync(RequestTypeEnum.PUT, url, null);
            var response = await ReadResponseAsync(request);

            return response;
        }

        public void SetAmount(int? amount)
        {
            this.amount = amount;
        }

        public void SetServiceTaxAmount(int? serviceTaxAmount)
        {
            this.serviceTaxAmount = serviceTaxAmount;
        }
    }
}
