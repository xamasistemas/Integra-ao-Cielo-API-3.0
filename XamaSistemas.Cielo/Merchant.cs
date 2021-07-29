namespace XamaSistemas.Cielo
{
    public sealed class Merchant
    {
        public string ID { get; }
        public string Key { get; }

        public Merchant(string id, string key)
        {
            ID = id;
            Key = key;
        }
    }
}
