using System.Net.Http;
using System.Threading.Tasks;

namespace XamaSistemas.Cielo.Ecommerce.request
{
    public class QuerySaleRequest : AbstractSaleRequest<SaleResponse, string>
    {
        private readonly IEnvironment _environment;
        public QuerySaleRequest(IEnvironment environment,HttpClient httpClient) : base(httpClient)
        {
            _environment = environment;
        }

        public override async Task<SaleResponse> ExecuteAsync(string paymentId)
        {
            var url = $"{_environment.GetApiQueryURL()}1/sales/{paymentId}";
            var request = await SendRequestAsync(RequestTypeEnum.GET, url, null);
            var response = await ReadResponseAsync(request);

            return response;
        }
    }
}
