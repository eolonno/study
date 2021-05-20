using System;
using System.Collections.Generic;
using System.Text;

namespace Dormitory.Data
{

    [Serializable]
    public class ValidatingException : Exception
    {
        public ValidatingException() { }
        public ValidatingErrorTypes ValidatingErrorType { get; set; }
        public ValidatingException(string message) : base(message) { }
        public ValidatingException(string message, Exception inner) : base(message, inner) { }
        public ValidatingException(string message, ValidatingErrorTypes type) : base(message)
        {
            ValidatingErrorType = type;
        }
        protected ValidatingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public enum ValidatingErrorTypes
    {
        StrError,
        PassError
    }
}
