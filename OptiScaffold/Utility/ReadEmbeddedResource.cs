using System.Reflection;

namespace OptiScaffold.Utility;

internal static class ReadEmbeddedResource
{
    public static string Read(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();

        if (assembly == null)
        {
            return string.Empty;
        }

        var assemblyNames = assembly.GetManifestResourceNames();

        if (assemblyNames == null)
        {
            return string.Empty;
        }

        string resourceName = assemblyNames.FirstOrDefault(str => str.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

        if (string.IsNullOrWhiteSpace(resourceName))
        {
            return string.Empty;
        }

        using Stream stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            return string.Empty;
        }

        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }
}
