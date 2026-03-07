namespace Application.Common.Results;

public sealed record Error(string Code, string Message, int HttpStatus)
{
    public static readonly Error None = new("None", string.Empty, 200);
    public static readonly Error Unknown = new("Unknown", "An unknown error occurred.", 500);
}
