using System;
using System.Runtime.Serialization;

namespace XamaSistemas.Cielo.Ecommerce.request
{

    [Serializable]
    public class CieloRequestException : Exception
    {
        private readonly CieloError _cieloError;
        public CieloRequestException() { }

        public CieloRequestException(string message, int error) : base(message)
        {
            _cieloError = new CieloError(error, message);
        }
        public CieloRequestException(string message) : base(message) { }
        public CieloRequestException(string message, Exception inner) : base(message, inner) { }
        protected CieloRequestException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }

        public CieloError GetCieloError()
        {
            return _cieloError;
        }
    }
}
