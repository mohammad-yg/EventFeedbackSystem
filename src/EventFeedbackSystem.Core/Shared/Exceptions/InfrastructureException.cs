namespace EventFeedbackSystem.Core.Shared.Exceptions;

public class InfrastructureException : Exception
{
    public InfrastructureException(string message, Exception? ex = default) : base(message, ex) { }

    public static class Messages
    {
        public const string DuplicateRow = "DuplicateRow";
        public const string InvalidForeignKey = "InvalidForeignKey";
    }
}