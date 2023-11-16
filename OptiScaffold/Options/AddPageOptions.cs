using CommandLine;

namespace OptiScaffold.Options;

[Verb("page", HelpText = "Generates Page Scaffolding")]
internal class AddPageOptions
{
    [Option('n', "classname", Required = true, HelpText = "Block Class Name")]
    public string ClassName { get; set; }

    [Option('c', "cmsname", Required = true, HelpText = "Pretty name that appears in CMS")]
    public string CmsName { get; set; }
}