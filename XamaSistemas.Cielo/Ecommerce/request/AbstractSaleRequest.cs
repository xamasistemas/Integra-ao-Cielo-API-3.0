using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamaSistemas.Cielo.Ecommerce.request
{
    public abstract class AbstractSaleRequest<T, P>
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// AbstractSaleRequest constructor.
        /// </summary>
        /// <param name="httpClient"></param>
        public AbstractSaleRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public abstract Task<T> ExecuteAsync(P param);

        /// <summary>
        /// Send the HTTP request to Cielo with the mandatory HTTP Headers set
        /// </summary>
        /// <param name="requestType">GET, POST OR PUT</param>
        /// <param name="url">Url to request</param>
        /// <param name="content">Serializable object</param>
        /// <param name="parameters">Additional parameters</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> SendRequestAsync(RequestTypeEnum requestType, string url, object content)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(content, settings);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = requestType switch
            {
                RequestTypeEnum.GET     => await _httpClient.GetAsync(url),
                RequestTypeEnum.POST    => await _httpClient.PostAsync(url, data),
                RequestTypeEnum.PUT     => content == null ? await _httpClient.PutAsync(url, null) : await _httpClient.PutAsync(url, data),
                _ => throw new CieloRequestException("Request type not implemented"),
            };

            return response;
        }

        /// <summary>
        /// Just decode the JSON into a T or create the exception chain to be
        /// </summary>
        /// <param name="responseMessage">The response sent by Cielo</param>
        /// <returns>An instance of T or null</returns>
        protected async Task<T> ReadResponseAsync(HttpResponseMessage responseMessage)
        {
            T response = default;
            string content;

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    content = await responseMessage.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<T>(content);
                    break;
                case HttpStatusCode.BadRequest:
                    content = await responseMessage.Content.ReadAsStringAsync();
                    var errors = JsonConvert.DeserializeObject<IEnumerable<CieloError>>(content);

                    foreach (var error in errors)
                    {
                        throw new CieloRequestException(error.Message, error.Code);
                    }

                    break;
                case HttpStatusCode.NotFound:
                    throw new CieloRequestException("Resource not found", 404);

                default:
                    throw new CieloRequestException("Unknown status", (int)responseMessage.StatusCode);
            }

            return response;
        }
    }
}
