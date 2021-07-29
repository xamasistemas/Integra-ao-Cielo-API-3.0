using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using XamaSistemas.Cielo.Ecommerce.request;

namespace XamaSistemas.Cielo.Ecommerce
{
    public class CieloEcommerce
    {
        private readonly Merchant _merchant;
        private readonly IEnvironment _environment;
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Create an instance of CieloEcommerce choosing the environment where the
        /// requests will be send
        /// </summary>
        /// <param name="merchant">The merchant credentials</param>
        /// <param name="environment">The environment: PRODUCTION or SANDBOX</param>
        public CieloEcommerce(Merchant merchant, IEnvironment environment, HttpClient httpClient)
        {
            if (environment == null)
                environment = Environment.Production();

            _merchant = merchant;
            _environment = environment;
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", HttpUtility.HtmlEncode("application/json"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", HttpUtility.HtmlEncode("gzip"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", HttpUtility.HtmlEncode("CieloEcommerce/3.0 .NET SDK (by Xamã Sistemas)"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", HttpUtility.HtmlEncode(_merchant.ID));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", HttpUtility.HtmlEncode(_merchant.Key));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", HttpUtility.HtmlEncode(Guid.NewGuid().ToString()));
        }

        /// <summary>
        /// Send the Sale to be created and return the Sale with tid and the status
        /// returned by Cielo.
        /// </summary>
        /// <param name="sale">The preconfigured Sale</param>
        /// <returns>The Sale with authorization, tid, etc. returned by Cielo.</returns>
        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            var saleRequest = new CreateSaleRequest(_environment, _httpClient);
            var returnData = await saleRequest.ExecuteAsync(sale);

            return returnData;
        }


        /// <summary>
        /// Query a Sale on Cielo by paymentId
        /// </summary>
        /// <param name="paymentId">The paymentId to be queried</param>
        /// <returns>The Sale with authorization, tid, etc. returned by Cielo.</returns>
        public async Task<SaleResponse> QuerySaleAsync(string paymentId)
        {
            var queryRequest = new QuerySaleRequest(_environment, _httpClient);
            var returnData = await queryRequest.ExecuteAsync(paymentId);

            return returnData;
        }

        /// <summary>
        /// Query a RecurrentPayment on Cielo by RecurrentPaymentId
        /// </summary>
        /// <param name="recurrentPaymentId"> The RecurrentPaymentId to be queried</param>
        /// <returns>The RecurrentPayment with authorization, tid, etc. returned by Cielo.</returns>
        public async Task<RecurrentPayment> GetRecurrentPaymentAsync(string recurrentPaymentId)
        {
            var queryRequest = new QueryRecurrentPaymentRequest(_environment, _httpClient);
            var returnData = await queryRequest.ExecuteAsync(recurrentPaymentId);

            return returnData;
        }

        /// <summary>
        /// Cancel a Sale on Cielo by paymentId and speficying the amount
        /// </summary>
        /// <param name="paymentId">The paymentId to be queried</param>
        /// <param name="amount">Order value in cents</param>
        /// <returns>Sale The Sale with authorization, tid, etc. returned by Cielo.</returns>
        public async Task<SaleResponse> CancelSaleAsync(string paymentId, int? amount = null)
        {
            var queryRequest = new UpdateSaleRequest("void", _environment, _httpClient);

            queryRequest.SetAmount(amount);

            var returnData = await queryRequest.ExecuteAsync(paymentId);

            return returnData;
        }

        public async Task<SaleResponse> CaptureSaleAsync(string paymentId, int? amount = null, int? serviceTaxAmount = null)
        {
            var queryRequest = new UpdateSaleRequest("capture", _environment, _httpClient);

            queryRequest.SetAmount(amount);
            queryRequest.SetServiceTaxAmount(serviceTaxAmount);

            var returnData = await queryRequest.ExecuteAsync(paymentId);

            return returnData;
        }


        /// <summary>
        /// Query a Sale on Cielo by merchantOrderId
        /// </summary>
        /// <param name="merchantOrderId">The merchantOrderId to be queried</param>
        /// <returns>The Sale with authorization, tid, etc. returned by Cielo.</returns>
        public QueryMerchantOrderResponse QueryMerchantOrder(string merchantOrderId)
        {
            throw new NotImplementedException();
        }
    }
}
