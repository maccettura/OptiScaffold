using CommandLine;

namespace OptiScaffold.Options;

[Verb("init", HelpText = "Init Options")]
internal class InitOptions
{
    [Option('n', "namespace", Required = true, HelpText = "Namespace base for created files (e.g Something.Foo.Features), 'Blocks' and 'Pages' are added dynamically.")]
    public string Namespace { get; set; }

    [Option('b', "blockbase", Required = true, HelpText = "Fully qualified namespace of Block abstract class")]
    public string BlockBase { get; set; }

    [Option('p', "pagebase", Required = true, HelpText = "Fully qualified namespace of Page abstract class")]
    public string PageBase { get; set; }

    [Option("blockvm", Required = true, HelpText = "Fully qualified namespace of Block viewmodel base class")]
    public string BlockVm { get; set; }

    [Option("pagevm", Required = true, HelpText = "Fully qualified namespace of Page viewmodel base class")]
    public string PageVm { get; set; }
}