using System.Runtime.Serialization;

namespace BonusSystem.Core.Exceptions
{
    public class UnhandledException : Exception
    {
        public UnhandledException() : base() { }
        public UnhandledException(string message) : base(message) { }
        public UnhandledException(string message, Exception innerException) : base(message, innerException) { }
        public UnhandledException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
