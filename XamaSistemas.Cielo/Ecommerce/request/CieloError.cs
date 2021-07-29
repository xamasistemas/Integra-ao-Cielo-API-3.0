namespace XamaSistemas.Cielo.Ecommerce.request
{
    public class CieloError
    {
        public int Code { get;}
        public string Message { get; }

        public CieloError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
