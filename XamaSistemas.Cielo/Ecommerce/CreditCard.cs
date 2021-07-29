namespace XamaSistemas.Cielo.Ecommerce
{
    public class CreditCard : CardBase
    {
        public bool SaveCard { get; set; }
        public string CardToken { get; set; }

        public CreditCard(string securityCode, string brand): base(securityCode, brand) { }
    }
}