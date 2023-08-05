using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;

namespace Bazar.Core.Exceptions;

public class ValidationAppException : ValidationException
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public ValidationAppException(IReadOnlyDictionary<string, string[]> errors) : base(
        "One or more Validation errors occurred")
    {
        Errors = errors;
    }
}