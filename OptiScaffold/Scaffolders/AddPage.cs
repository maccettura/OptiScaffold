using OptiScaffold.Exceptions;
using OptiScaffold.Options;
using OptiScaffold.Templates;

namespace OptiScaffold.Scaffolders;

internal class AddPage : BaseScaffolder
{
    public async Task ScaffoldPage(AddPageOptions options)
    {
        Console.WriteLine($"Starting {options.CmsName} page scaffolding...");

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

            string newPagePath = CreateNewDirectory(options.ClassName);

            var config = GetConfig();

            var replacements = new Dictionary<string, string>
            {
                ["className"] = options.ClassName,
                ["cmsname"] = options.CmsName,
                ["guid"] = Guid.NewGuid().ToString(),
                ["type"] = Constants.Page.TypeConstant,
                ["featureNamespace"] = config.Namespace,
                ["abstractNamespace"] = config.AbstractPageNamespace,
                ["abstractClassName"] = config.AbstractPageClass,
                ["pageVmClass"] = config.PageViewModelClass,
                ["pageVmNamespace"] = config.PageViewModelNamespace
            };

            Dictionary<string, string> filesToWrite = new()
            {
                { $"{options.ClassName}.cs", PageTemplates.GeneratePageTemplate(replacements) },
                { $"{options.ClassName}ViewModel.cs", PageTemplates.GeneratePageViewModel(replacements) },
                { $"{options.ClassName}Controller.cs", PageTemplates.GeneratePageController(replacements) },
                { $"{options.ClassName}.cshtml", PageTemplates.GeneratePageView(replacements) }
            };

            await Task.WhenAll(WriteFiles(filesToWrite, newPagePath));

            Console.WriteLine($"{options.CmsName} page scaffolded!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: Could not create {options.CmsName} | {ex.Message}");
        }
    }
}