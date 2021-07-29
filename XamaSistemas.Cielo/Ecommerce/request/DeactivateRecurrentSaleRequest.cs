using System.Net.Http;
using System.Threading.Tasks;

namespace XamaSistemas.Cielo.Ecommerce.request
{
    public class DeactivateRecurrentSaleRequest : AbstractSaleRequest<RecurrentSale, string>
    {
        private readonly IEnvironment _environment;
        public DeactivateRecurrentSaleRequest(IEnvironment environment, HttpClient httpClient) : base(httpClient)
        {
            _environment = environment;
        }

        public override async Task<RecurrentSale> ExecuteAsync(string recurrentPaymentId)
        {
            var url = $"{_environment.GetApiURL()}1/RecurrentPayment/{recurrentPaymentId}/Deactivate";

            var request = await SendRequestAsync(RequestTypeEnum.PUT, url, null);
            var response = await ReadResponseAsync(request);

            return response;
        }
    }
}
