using CommandLine;

namespace OptiScaffold.Options;

[Verb("block", HelpText = "Generates Block Scaffolding")]
internal class AddBlockOptions
{
    [Option('n', "class", Required = true, HelpText = "Block Class Name")]
    public string ClassName { get; set; }

    [Option('c', "cmsname", Required = true, HelpText = "Pretty name that appears in CMS")]
    public string CmsName { get; set; }
}