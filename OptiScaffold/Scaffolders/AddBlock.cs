using OptiScaffold.Exceptions;
using OptiScaffold.Options;
using OptiScaffold.Templates;

namespace OptiScaffold.Scaffolders;

internal class AddBlock : BaseScaffolder
{
    public async Task ScaffoldBlock(AddBlockOptions options)
    {
        Console.WriteLine($"Starting {options.CmsName} block scaffolding...");

        try
        {
            if (options.ClassName.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException("Class Name cannot contain whitespace");
            }

            if (Directory.Exists(options.ClassName))
            {
                throw new AlreadyExistsException(options.ClassName);
            }

            string newBlockPath = CreateNewDirectory(options.ClassName);

            var config = GetConfig();

            var replacements = new Dictionary<string, string>
            {
                ["className"] = options.ClassName,
                ["cmsname"] = options.CmsName,
                ["guid"] = Guid.NewGuid().ToString(),
                ["type"] = Constants.Block.TypeConstant,
                ["featureNamespace"] = config.Namespace,
                ["abstractNamespace"] = config.AbstractBlockNamespace,
                ["abstractClassName"] = config.AbstractBlockClass,
                ["blockVmClass"] = config.BlockViewModelClass,
                ["blockVmNamespace"] = config.BlockViewModelNamespace,
            };

            Dictionary<string, string> filesToWrite = new()
            {
                { $"{options.ClassName}.cs", BlockTemplates.GenerateBlockTemplate(replacements) },
                { $"{options.ClassName}ViewModel.cs", BlockTemplates.GenerateBlockViewModel(replacements) },
                { $"{options.ClassName}Component.cs", BlockTemplates.GenerateBlockComponent(replacements) },
                { $"{options.ClassName}.cshtml", BlockTemplates.GenerateBlockView(replacements) }
            };

            await Task.WhenAll(WriteFiles(filesToWrite, newBlockPath));

            Console.WriteLine($"{options.CmsName} block scaffolded!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: Could not create {options.CmsName} | {ex.Message}");
        }
    }
}