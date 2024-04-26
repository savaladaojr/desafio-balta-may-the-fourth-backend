using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Application.Common.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errors)
            : base("Validation Failure :: One or more validation errors occurred.")
        {
            Errors = errors;
        }
        public IReadOnlyDictionary<string, string[]> Errors { get; }

    }
}
