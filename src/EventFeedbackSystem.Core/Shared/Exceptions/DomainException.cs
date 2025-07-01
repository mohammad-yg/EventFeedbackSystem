namespace EventFeedbackSystem.Core.Shared.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message, Exception? ex = default) : base(message, ex) { }
}
