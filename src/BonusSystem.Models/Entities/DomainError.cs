namespace BonusSystem.Models.Entities
{
    public class DomainError(string? message, ErrorType errorType, List<string>? errors = null) : IDomainError
    {
        public string? ErrorMessage { get; init; } = message;
        public ErrorType ErrorType { get; init; } = errorType;
        public List<string>? Errors { get; init; } = errors ?? [];

        public static DomainError Conflict(string? message = "A conflict occurred.")
            => new(message ?? "A conflict occurred.", ErrorType.Conflict);
        public static DomainError NotFound(string? message = "Resource not found.")
            => new(message ?? "Resource not found.", ErrorType.NotFound);
        public static DomainError BadRequest(string? message = "The request is invalid.")
            => new(message ?? "The request is invalid.", ErrorType.BadRequest);

        public static DomainError Validation(string? message = "Validation error occurred.")
            => new(message ?? "Validation error occurred.", ErrorType.Validation);

        public static DomainError Unexpected(string? message = "An unexpected error occurred.")
            => new(message ?? "An unexpected error occurred.", ErrorType.Unexpected);

        public static DomainError Unauthorized(string? message = "Authentication required or failed.")
            => new(message ?? "Authentication required or failed.", ErrorType.Unauthorized);

        public static DomainError Forbidden(string? message = "Access denied.")
            => new(message ?? "Access denied.", ErrorType.Forbidden);

        public static DomainError Timeout(string? message = "Request timed out.")
            => new(message ?? "Request timed out.", ErrorType.Timeout);

        public static DomainError InternalError(string? message = "An internal server error occurred.")
            => new(message ?? "An internal server error occurred.", ErrorType.InternalError);
    }
}
