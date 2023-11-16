using OptiScaffold.Models;
using OptiScaffold.Options;
using System.Text.Json;

namespace OptiScaffold.Utility;

internal class ConfigurationUtility
{
    public async static Task CreateScafFile(InitOptions options)
    {
        var config = new ScaffConfigurationModel()
        {
            Namespace = options.Namespace,
        };

        var block = SplitQualifiedNamespace(options.BlockBase);
        config.AbstractBlockNamespace = block.ns;
        config.AbstractBlockClass = block.className;

        var page = SplitQualifiedNamespace(options.PageBase);
        config.AbstractPageNamespace = page.ns;
        config.AbstractPageClass = page.className;

        var pageVm = SplitQualifiedNamespace(options.PageVm);
        config.PageViewModelNamespace = pageVm.ns;
        config.PageViewModelClass = pageVm.className;

        var blockVm = SplitQualifiedNamespace(options.BlockVm);
        config.BlockViewModelNamespace = blockVm.ns;
        config.BlockViewModelClass = blockVm.className;

        await File.WriteAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), Constants.ConfigFileName), JsonSerializer.Serialize(config));
    }

    public static ScaffConfigurationModel? ReadScafFile()
    {
        var (found, path) = FindScafFile();

        if (found)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<ScaffConfigurationModel>(json);
        }
        else
        {
            return null;
        }
    }

    private static (string ns, string className) SplitQualifiedNamespace(string input)
    {
        if (!input.Contains('.'))
        {
            return (ns: string.Empty, className: string.Empty);
        }

        int index = input.LastIndexOf('.');

        if (index < input.Length)
        {
            var st1 = new string(input.AsSpan()[..index]);
            index++;
            var st2 = new string(input.AsSpan()[index..]);
            return (ns: st1, className: st2);
        }

        return (ns: string.Empty, className: string.Empty);
    }

    private static (bool found, string path) FindScafFile()
    {
        var currentDir = Directory.GetCurrentDirectory();

        bool scafFileFound = false;
        while (!scafFileFound)
        {
            string newPath = Path.GetFullPath(Path.Combine(currentDir, ".."));
            if (string.IsNullOrWhiteSpace(newPath))
            {
                return (found: false, path: string.Empty); // Something is wrong, bail
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(newPath);
            if (directoryInfo.Parent == null)
            {
                return (found: false, path: string.Empty); // Reached C:/, obviously not found
            }

            string scafFile = Path.Combine(newPath, Constants.ConfigFileName);
            if (File.Exists(scafFile))
            {
                return (found: true, path: scafFile);
            }

            currentDir = newPath;
        }

        return (found: false, path: string.Empty); // no idea how this would ever get hit
    }
}