using System;
using System.Runtime.Serialization;

namespace SomeTestingInAutomation
{
    [Serializable]
    internal class DataDrivenReadException : Exception
    {
        public DataDrivenReadException()
        {
        }

        public DataDrivenReadException(string message) : base(message)
        {
        }

        public DataDrivenReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataDrivenReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}