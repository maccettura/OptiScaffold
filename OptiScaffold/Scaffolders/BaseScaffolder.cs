using OptiScaffold.Models;
using OptiScaffold.Utility;

namespace OptiScaffold.Scaffolders;

internal abstract class BaseScaffolder
{
    protected IEnumerable<Task> WriteFiles(Dictionary<string, string> filesToWrite, string path)
    {
        return filesToWrite.Select(x => File.WriteAllTextAsync(Path.Combine(path, x.Key), x.Value));
    }

    protected string CreateNewDirectory(string featureName)
    {
        string currentPath = Environment.CurrentDirectory;

        if (!Directory.Exists(currentPath))
        {
            throw new DirectoryNotFoundException($"Cannot find directory at: {currentPath}");
        }

        string newBlockPath = Path.Combine(currentPath, featureName);

        Directory.CreateDirectory(newBlockPath);

        return newBlockPath;
    }

    protected ScaffConfigurationModel GetConfig()
    {
        var config = ConfigurationUtility.ReadScafFile();

        if (config == null)
        {
            throw new FileNotFoundException($"Scaffold config ({Constants.ConfigFileName}) file not located at project root!");
        }

        return config;
    }
}