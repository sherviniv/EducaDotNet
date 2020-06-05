using System;

namespace Educa.Application.Common.Exceptions
{
    public class EducaException : Exception
    {
        public string Code { get; }

        public EducaException()
        {
        }

        public EducaException(string code)
        {
            Code = code;
        }

        public EducaException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public EducaException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public EducaException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public EducaException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}