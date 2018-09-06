using System;
using System.Runtime.Serialization;

namespace Otc.Proxying.Tests
{
    [Serializable]
    internal class AnException : Exception
    {
        public AnException()
        {
        }

        public AnException(string message) : base(message)
        {
        }

        public AnException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AnException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}