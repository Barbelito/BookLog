namespace Application.Common.Results;

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new("None", string.Empty);
    public static readonly Error Unknown = new("Unknown", "An unknown error occurred.");
};
