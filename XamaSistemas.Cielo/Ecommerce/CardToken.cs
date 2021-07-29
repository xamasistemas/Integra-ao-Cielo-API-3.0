using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamaSistemas.Cielo.Ecommerce
{
    public class CardToken : CardBase
    {
        [JsonProperty("CardToken")]
        public string Token { get; set; }
        public string CustomerName { get; set; }
        public IList<Link> Links{ get; set; }
    }
}
