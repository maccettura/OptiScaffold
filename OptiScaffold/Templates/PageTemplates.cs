using OptiScaffold.Utility;

namespace OptiScaffold.Templates;

internal static class PageTemplates
{
    private static string PageTemplate { get { return pageTemplateLazy.Value; } }

    private static string PageController { get { return pageControllerLazy.Value; } }

    private static string PageViewModel { get { return pageViewModelLazy.Value; } }

    private static string PageView { get { return pageViewLazy.Value; } }

    private static readonly Lazy<string> pageTemplateLazy = new(() => ReadEmbeddedResource.Read(Constants.Page.OptiTemplate));
    private static readonly Lazy<string> pageControllerLazy = new(() => ReadEmbeddedResource.Read(Constants.Page.ControllerTemplate));
    private static readonly Lazy<string> pageViewModelLazy = new(() => ReadEmbeddedResource.Read(Constants.Page.ViewModelTemplate));
    private static readonly Lazy<string> pageViewLazy = new(() => ReadEmbeddedResource.Read(Constants.Page.ViewTemplate));

    public static string GeneratePageTemplate(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(PageTemplate, replacements);
    }

    public static string GeneratePageController(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(PageController, replacements);
    }

    public static string GeneratePageViewModel(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(PageViewModel, replacements);
    }

    public static string GeneratePageView(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(PageView, replacements);
    }
}