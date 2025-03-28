namespace BonusSystem.Core.Exceptions
{
    public class InvalidCodeException: Exception
    {
        public InvalidCodeException() { }
        public InvalidCodeException(string message) : base(message) { }
        public InvalidCodeException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCodeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
