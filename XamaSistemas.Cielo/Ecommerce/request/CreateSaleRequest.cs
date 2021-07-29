using System.Net.Http;
using System.Threading.Tasks;

namespace XamaSistemas.Cielo.Ecommerce.request
{
    public class CreateSaleRequest : AbstractSaleRequest<Sale, Sale>
    {
        private readonly IEnvironment _environment;
        public CreateSaleRequest(IEnvironment environment, HttpClient httpClient) : base(httpClient)
        {
            _environment = environment;
        }
        public override async Task<Sale> ExecuteAsync(Sale sale)
        {
            var url = $"{_environment.GetApiURL()}1/sales/";
            var request = await SendRequestAsync(RequestTypeEnum.POST, url, sale);
            var response = await ReadResponseAsync(request);

            return response;
        }
    }
}
