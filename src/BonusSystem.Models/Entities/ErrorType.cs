namespace BonusSystem.Models.Entities
{
    public enum ErrorType
    {
        NotFound = 0,
        Conflict = 1,
        BadRequest = 2,
        Validation = 3,
        Unexpected = 4,
        Unauthorized = 5,
        Forbidden = 6,
        Timeout = 7,
        InternalError = 8
    }
}
