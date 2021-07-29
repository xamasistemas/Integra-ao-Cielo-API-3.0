namespace XamaSistemas.Cielo.Ecommerce
{
    public abstract class CardBase
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; }
        public string Brand { get; }

        public CardBase() { }

        public CardBase(string securityCode, string brand)
        {
            SecurityCode = securityCode;
            Brand = brand;
        }
    }
}
