using System.Net.Http;
using System.Threading.Tasks;

namespace XamaSistemas.Cielo.Ecommerce.request
{
    public class CreateCartTokenRequest : AbstractSaleRequest<CardToken, CardToken>
    {
        private readonly IEnvironment _environment;
        public CreateCartTokenRequest(IEnvironment environment, HttpClient httpClient) : base(httpClient)
        {
            _environment = environment;
        }
        public override async Task<CardToken> ExecuteAsync(CardToken param)
        {
            var url = $"{_environment.GetApiURL()}1/card/";
            var request = await SendRequestAsync(RequestTypeEnum.POST, url, param);
            var response = await ReadResponseAsync(request);

            return response;
        }
    }
}
