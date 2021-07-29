namespace XamaSistemas.Cielo.Ecommerce
{
    public class Environment : IEnvironment
    {
        private readonly string _api;
        private readonly string _apiQuery;

        public static Environment Sandbox()
        {
            var api = "https://apisandbox.cieloecommerce.cielo.com.br/";
            var apiQuery = "https://apiquerysandbox.cieloecommerce.cielo.com.br/";

            return new Environment(api, apiQuery);
        }

        public static Environment Production()
        {
            var api = "https://api.cieloecommerce.cielo.com.br/";
            var apiQuery = "https://apiquery.cieloecommerce.cielo.com.br/";

            return new Environment(api, apiQuery);
        }

        public Environment(string api, string apiQuery)
        {
            _api = api;
            _apiQuery = apiQuery;
        }

        public string GetApiQueryURL()
        {
            return _apiQuery;
        }

        public string GetApiURL()
        {
            return _api;
        }
    }
}
