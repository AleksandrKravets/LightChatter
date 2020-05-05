using System;

namespace Quantum.DAL.Infrastructure.Exceptions
{
    internal class MoreThanOneReturnParameterException : Exception
    {
        public MoreThanOneReturnParameterException(string message) : base(message)
        {
        }

        public MoreThanOneReturnParameterException()
        {
        }
    }
}
