namespace XamaSistemas.Cielo.Ecommerce
{
    public class Customer
    {
        public string Name { get; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public Address Address { get; set; }
        public Address DeliveryAddress { get; set; }

        public Customer(string name)
        {
            Name = name;
        }
    }
}
