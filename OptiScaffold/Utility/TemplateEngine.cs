using System.Text.RegularExpressions;

namespace OptiScaffold.Utility;

internal static class TemplateEngine
{
    public static string ApplyParameters(string template, Dictionary<string, string> replacements)
    {
        return Regex.Replace(template, @"{(\w+)}", match => replacements.TryGetValue(match.Groups[1].Value, out var replacement) ? replacement : match.Value);
    }
}
