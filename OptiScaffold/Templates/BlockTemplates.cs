using OptiScaffold.Utility;

namespace OptiScaffold.Templates;

internal static class BlockTemplates
{
    private static string BlockTemplate { get { return blockTemplateLazy.Value; } }

    private static string BlockComponent { get { return blockComponentLazy.Value; } }

    private static string BlockViewModel { get { return blockViewModelLazy.Value; } }

    private static string BlockView { get { return blockViewLazy.Value; } }

    private static readonly Lazy<string> blockTemplateLazy = new(() => ReadEmbeddedResource.Read(Constants.Block.OptiTemplate));
    private static readonly Lazy<string> blockComponentLazy = new(() => ReadEmbeddedResource.Read(Constants.Block.ComponentTemplate));
    private static readonly Lazy<string> blockViewModelLazy = new(() => ReadEmbeddedResource.Read(Constants.Block.ViewModelTemplate));
    private static readonly Lazy<string> blockViewLazy = new(() => ReadEmbeddedResource.Read(Constants.Block.ViewTemplate));

    public static string GenerateBlockTemplate(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(BlockTemplate, replacements);
    }

    public static string GenerateBlockComponent(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(BlockComponent, replacements);
    }

    public static string GenerateBlockViewModel(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(BlockViewModel, replacements);
    }

    public static string GenerateBlockView(Dictionary<string, string> replacements)
    {
        return TemplateEngine.ApplyParameters(BlockView, replacements);
    }
}