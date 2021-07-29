using System.Net.Http;
using System.Threading.Tasks;

namespace XamaSistemas.Cielo.Ecommerce.request
{
    public class QueryRecurrentPaymentRequest : AbstractSaleRequest<RecurrentPayment, string>
    {
        private readonly IEnvironment _environment;
        public QueryRecurrentPaymentRequest(IEnvironment environment, HttpClient httpClient) : base(httpClient)
        {
            _environment = environment;
        }
        public override async Task<RecurrentPayment> ExecuteAsync(string recurrentPaymentId)
        {
            var url = $"{_environment.GetApiQueryURL()}1/RecurrentPayment/{recurrentPaymentId}";

            var request = await SendRequestAsync(RequestTypeEnum.GET, url, null);
            var response = await ReadResponseAsync(request);

            return response;
        }
    }
}
