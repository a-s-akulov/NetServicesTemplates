using System.Diagnostics.CodeAnalysis;


namespace $safeprojectname$.Extensions;


public static class StringExtensions
{
    [return: NotNullIfNotNull(nameof(input))]
    public static string? FirstCharToUpper(this string? input) =>
        input switch
        {
            null => null,
            "" => string.Empty,
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };


    [return: NotNullIfNotNull(nameof(input))]
    public static string? FirstCharToLower(this string? input) =>
        input switch
        {
            null => null,
            "" => string.Empty,
            _ => string.Concat(input[0].ToString().ToLower(), input.AsSpan(1))
        };
}