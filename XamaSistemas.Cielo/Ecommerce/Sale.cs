namespace XamaSistemas.Cielo.Ecommerce
{
    public class Sale
    {
        public string MerchantOrderId { get; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }

        public Sale(string merchantOrderId)
        {
            MerchantOrderId = merchantOrderId;
        }
    }
}
